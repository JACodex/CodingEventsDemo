using System.ComponentModel.DataAnnotations;

namespace CodingEventsDemo.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Title is Required")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Title Length must be between 2 and 40 characters long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "Description must be between 6 and 200 Characters long")]
        public string Description { get; set; }
    }
}
