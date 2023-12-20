using NodaTime;
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
        [Required(ErrorMessage = "Plese select a status")]
        public Status? Status { get; set; }

        [MinLength(3, ErrorMessage = "Description must be at least 3 characters")]
        public string? Description { get; set; }

        public LocalDateTime CreatedAt { get; set; }
        public LocalDateTime? UpdatedAt { get; set; }

        public Issue()
        {
            // Initialize CreatedTime with the current time in Dhaka time zone
            var tzdb = DateTimeZoneProviders.Tzdb;
            var dhakaTimeZone = tzdb["Asia/Dhaka"];
            var now = SystemClock.Instance.GetCurrentInstant();
            CreatedAt = now.InZone(dhakaTimeZone).LocalDateTime;
        }

    }
}
