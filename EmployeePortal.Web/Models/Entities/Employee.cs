namespace EmployeePortal.Web.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public bool Experience  { get; set; }
    }
}
