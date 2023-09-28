using crm_app.Models;
using Microsoft.AspNetCore.Mvc; // Import the necessary namespace for MVC controllers.
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
            // Retrieve Dynamics 365 connection string from app settings
            var connectionString = _configuration.GetConnectionString("Dynamics365"); // Retrieve the connection string named "Dynamics365" from the configuration.

            // Create a connection to Dynamics 365
            using (var service = new CrmServiceClient(connectionString)) // Create a connection to Dynamics 365 using the retrieved connection string.
            {
                // Use the CRM SDK to interact with Dynamics 365 here
                // e.g., create a new record in Dynamics 365 based on the user input

                // The code inside this block is where you would perform operations on Dynamics 365, such as creating records.
            }

            // Redirect to a success page or handle errors
            return RedirectToAction("Success"); // Redirect to the "Success" action or another action after completing the operation.
        }

        // Other action methods for your CustomerController go here
    }
}
