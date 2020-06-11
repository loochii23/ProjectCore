using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectCore.Logica.Models.BindingModel
{
    public class TasksCreateBindingModel
    {
        [Required(ErrorMessage = "The field Title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The field Details is required")]
        [Display(Name = "Details")]
        public string Details { get; set; }
        [Required(ErrorMessage = "The field Expiration Date is required")]
        [Display(Name = "ExpirationDate")]
        public DateTime? ExpirationDate { get; set; }
        [Required(ErrorMessage = "The field Is Completed is required")]
        [Display(Name = "Is Completed")]
        public bool IsCompleted { get; set; }
        [Required(ErrorMessage = "The field Effort is required")]
        [Display(Name = "Effort")]
        public int? Effort { get; set; }
        [Required(ErrorMessage = "The field RemainingWork is required")]
        [Display(Name = "RemainingWork")]
        public int? RemainingWork { get; set; }

        [Required(ErrorMessage = "The field State is required")]
        [Display(Name = "State")]
        public int? StateId { get; set; }
        [Required(ErrorMessage = "The field Activity is required")]
        [Display(Name = "Activity")]
        public int? ActivityId { get; set; }
        [Required(ErrorMessage = "The field Priority is required")]
        [Display(Name = "Priority")]
        public int? PriorityId { get; set; }

        public int? ProjectId { get; set; }
    }
}
