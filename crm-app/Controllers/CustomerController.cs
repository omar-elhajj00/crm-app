using crm_app.Models;
using Microsoft.AspNetCore.Mvc; // Import the necessary namespace for MVC controllers.
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace crm_app.Controllers
{
    public class CustomerController : Controller // Define the CustomerController class and inherit from the base Controller class.
    {
        private readonly IConfiguration _configuration; // Declare a private field to hold the application's configuration.

        public CustomerController(IConfiguration configuration) // Create a constructor that accepts an IConfiguration instance.
        {
            _configuration = configuration; // Assign the provided configuration to the private field.
        }

        // This is the Create action method
        public IActionResult Create(CustomerModel model) // Define the Create action method that takes a CustomerModel parameter.
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            // Retrieve Dynamics 365 connection string from app settings
            var connectionString = _configuration.GetConnectionString("Dynamics365"); // Retrieve the connection string named "Dynamics365" from the configuration.


            // Create a connection to Dynamics 365
            using var service = new CrmServiceClient(connectionString); // Create a connection to Dynamics 365 using the retrieved connection string.
            if (service.IsReady)
            {
                // Create a new CRM entity (e.g., contact)
                var contact = new Entity("contact");
                contact["Id"] = model.Id;
                contact["firstname"] = model.Name;
                contact["emailaddress1"] = model.Email;
                contact["telephone1"] = model.Phone;

                // Create the record
                service.Create(contact);

                // Handle success or redirect to an appropriate page
                return RedirectToAction("Index");
            }
            else
            {
                // Handle connection error
                return RedirectToAction("Error");
            }


            // Other action methods for your CustomerController go here
        }
    }
}
