using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParcialCiudadanosSanos.Data;
using ParcialCiudadanosSanos.Models;

namespace ParcialCiudadanosSanos.Pages.ConsultasMedicas
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
            ListarPacientes();
            return Page();
        }

        [BindProperty]
        public ConsultaMedica consultamedica { get; set; } = default!;

        public SelectList ListaPacientes { get; set; }

        private void ListarPacientes()
        {
            var pacientes = _context.Paciente.ToList();
            ListaPacientes = new SelectList(pacientes, "Id", "Name");
        }
        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.ConsultaMedica == null || consultamedica == null)
            {
                ListarPacientes();
                return Page();
            }
            _context.ConsultaMedica.Add(consultamedica);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

    }
}
