using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ParcialCiudadanosSanos.Data;
using ParcialCiudadanosSanos.Models;

namespace ParcialCiudadanosSanos.Pages.Pacientes
{
    public class CreateModel : PageModel
    {
        private readonly ParcialCiudadanosSanosContext _context;

        public CreateModel(ParcialCiudadanosSanosContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Paciente Paciente { get; set; } = default!;

        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Paciente == null || Paciente == null)
            {
                return Page();
            }
            _context.Paciente.Add(Paciente);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

    }
}
