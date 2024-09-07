public class Detail
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Remarks { get; set; }

    public DateTime RequestTime { get; set; }

    // Constructor with parameters for required properties
    public Detail(string name, string email, string phoneNumber, string remarks)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Remarks = remarks;
        RequestTime = DateTime.UtcNow; // Or set as needed
    }
}
