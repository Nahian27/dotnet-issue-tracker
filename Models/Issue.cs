using System.ComponentModel.DataAnnotations;

namespace dotnet_issue_tracker.Models
{

    public enum Status
    {
        OPEN, IN_PROGESS, CLOSED
    }
    public class Issue
    {
        public Guid Id { get; set; }

        [MinLength(3, ErrorMessage = "Title must be at least 3 characters")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Please select a status")]
        public Status? Status { get; set; }

        [MinLength(3, ErrorMessage = "Description must be at least 3 characters")]
        public string? Description { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdatedAt { get; set; }

    }
}
