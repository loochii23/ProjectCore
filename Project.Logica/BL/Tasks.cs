using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectCore.Logica.BL
{
    public class Tasks
    {
        public List<Models.DB.Tasks> GetTasks(int? projectId,
            int? id)
        {
            DAL.Models.ProjectCoreContext _context = new DAL.Models.ProjectCoreContext();

            var listTasks = (from _tasks in _context.Tasks
                             join _states in _context.States on _tasks.StateId equals _states.Id
                             join _activities in _context.Activities on _tasks.ActivityId equals _activities.Id
                             join _priorities in _context.Priorities on _tasks.PriorityId equals _priorities.Id
                             select new Models.DB.Tasks
                             { 
                                Id = _tasks.Id,
                                Title = _tasks.Title,
                                Details = _tasks.Details,
                                ExpirationDate = _tasks.ExpirationDate,
                                IsCompleted = _tasks.IsCompleted,
                                Effort = _tasks.Effort,
                                RemainingWork = _tasks.RemainingWork,
                                StateId = _tasks.StateId,
                                States = new Models.DB.States
                                {
                                    Name = _states.Name
                                },
                                PriorityId = _tasks.PriorityId,
                                Priorities = new Models.DB.Priorities
                                {
                                    Name = _priorities.Name
                                },
                                ActivityId = _tasks.ActivityId,
                                Activities = new Models.DB.Activities
                                {
                                    Name = _activities.Name
                                },
                                ProjectId = _tasks.ProjectId
                             }).ToList();

            if (projectId != null)
                listTasks = listTasks.Where(x => x.ProjectId == projectId).ToList();
            if(id != null)
                listTasks = listTasks.Where(x => x.Id == id).ToList();

            return listTasks;

        }

        public void CreateTasks(string title,
            string details,
            DateTime? expirationDate,
            bool? isComplete,
            int? effort,
            int? remainingWork,
            int? stateId,
            int? activityId,
            int? priorityId,
            int? projectId)
        {
            DAL.Models.ProjectCoreContext _contex = new DAL.Models.ProjectCoreContext();
            _contex.Tasks.Add(new DAL.Models.Tasks
            {
                Title = title,
                Details = details,
                ExpirationDate = expirationDate,
                IsCompleted = isComplete,
                Effort = effort, 
                RemainingWork = remainingWork, 
                StateId = stateId,
                ActivityId = activityId, 
                PriorityId = priorityId,
                ProjectId = projectId
            });
            _contex.SaveChanges();
        }
    }
}
