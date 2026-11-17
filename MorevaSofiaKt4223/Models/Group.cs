namespace MorevaSofiaKt4223.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public int Course { get; set; }
        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}