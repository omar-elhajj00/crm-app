namespace crm_app.Models
{
    public class CustomerModel
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
    }
}
