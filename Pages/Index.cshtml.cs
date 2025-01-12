using System.Data.SqlTypes;
using System.Diagnostics;
using CarRental.Pages.CarClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRental.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string SelectedCarModel { get; set; }
        public List<Car> Cars { get; set; }
        
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
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
            string selectedType = Request.Form["typeDropdown"];
            string selectedModel = Request.Form["modelInput"];
            
            if (string.IsNullOrEmpty(selectedType) || string.IsNullOrEmpty(selectedModel))
            {
                ResultMessage = "Please select a car make and model.";
                return Page(); 
            }

            var newCar = new Car();
            var newID = 1;

            if (_context.Cars.Any())
            {
                newID = _context.Cars.OrderByDescending(u => u.CarID).FirstOrDefault().CarID + 1;
            }
            
            
            switch (selectedType)
            {
                case "1":
                    newCar = new FamilyCar()
                    {
                        CarID = newID,
                        Model = selectedModel
                
                    };
                    break;
                case "2":
                    newCar = new Motorbike()
                    {
                        CarID = newID,
                        Model = selectedModel
                
                    };
                    break;
                case "3":
                    newCar = new Lorry()
                    {
                        CarID = newID,
                        Model = selectedModel
                
                    };
                    break;
                case "4":
                    newCar = new Van()
                    {
                        CarID = newID,
                        Model = selectedModel
                
                    };
                    break;
                default:
                    throw new SqlNullValueException("Error in Type selection - check Type value: " + selectedType);
            }

            newCar.CarType = newCar.CarType;
            _context.Cars.Add(newCar);
            _context.SaveChanges();


            // Return the page with new message
            ResultMessage = $"Car with make '{selectedType}' added successfully!";
            Cars =  _context.Cars.ToList();

            
            return Page();
        }
    }
}
