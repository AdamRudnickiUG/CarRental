using System.Data.SqlTypes;
using System.Diagnostics;
using CarRental.Pages.CarClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Pages
{
    public class DeletionModel : PageModel
    {
        [BindProperty]
        public string SelectedCarModel { get; set; }
        public List<Car> Cars { get; set; }
        
        private readonly AppDbContext _context;

        public DeletionModel(AppDbContext context)
        {
            try
            {
                _context = context;
            }
            catch (Exception e)
            {
                Console.WriteLine("Add proper DBContext. This is null\n" + e);
                throw;
            }
        }
        
        
        public string ResultMessage { get; set; }
        

        public void OnGet()
        {
            Cars =  _context.Cars.ToList();
        }
        
        
        public IActionResult OnPost()
        {
            Console.WriteLine("OnPost start");

            var fullForm = Request.Form;
            
            var action = Request.Form["action"].ToString();
            int idForUpdate = int.Parse(Request.Form["selectedItem"]);

            if (action == "delete")
            {
                var carForDeletion = _context.Cars.Find(idForUpdate);
            
                _context.Cars.Remove(carForDeletion);
                ResultMessage = $"Car with make '{idForUpdate}' deleted successfully!";
            }

            else
            {
                string holderForChange = Request.Form["holderInput"];
                
                if (String.IsNullOrEmpty(idForUpdate.ToString()))
                {
                    ResultMessage = "Please select a car.";
                    return Page(); 
                }
                
                var carForUpdate = _context.Cars.Find(idForUpdate);
                
                if (String.IsNullOrEmpty(holderForChange))
                {
                    Console.WriteLine("Setting new holder to DEALERSHIP");
                    holderForChange = "DEALERSHIP";
                }

                carForUpdate.CurrentHolder = holderForChange;
                _context.Cars.Update(carForUpdate);
                ResultMessage = $"Car with make '{idForUpdate}' successfully set to current holder " + holderForChange;
            }

            
            _context.SaveChanges();
            Cars =  _context.Cars.ToList();
            return Page();
        }
    }
}
