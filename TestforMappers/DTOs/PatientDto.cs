namespace TestforMappers.DTOs
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }  // FirstName + LastName
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
