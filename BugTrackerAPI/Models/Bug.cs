namespace BugTrackerAPI.Models
{
    public enum Status
    {
        FIXED,
        TOFIX
    }

    public enum Priority
    {
        HIGH,
        MEDIUM,
        LOW
    }

    public class Bug
    {
        public long? Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }
        public int NbReport { get; set; }
        public Priority Priority { get; set; }
        public DateTime FixedDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
