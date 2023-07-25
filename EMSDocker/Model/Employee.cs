namespace EMSDocker.Model
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Employee()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            JobDescription = string.Empty;
            Department = string.Empty;
            Salary = 0;
            Address = string.Empty;
            Email = string.Empty;
        }
        public Employee(NewEmployeeRecord newRecord)
        {
            this.Id = Guid.NewGuid();
            this.Name = newRecord.Name;
            this.JobDescription = newRecord.JobDescription;
            this.Department = newRecord.Department;
            this.Salary = newRecord.Salary;
            this.Address = newRecord.Address;
            this.Email = newRecord.Email;
        }
        public void UpdateEmployee(NewEmployeeRecord updatedRecord)
        {
            this.Name = updatedRecord.Name;
            this.JobDescription = updatedRecord.JobDescription;
            this.Department = updatedRecord.Department;
            this.Salary = updatedRecord.Salary;
            this.Address = updatedRecord.Address;
            this.Email = updatedRecord.Email;
        }
    }
}
