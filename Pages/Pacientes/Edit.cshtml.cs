using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParcialCiudadanosSanos.Data;
using ParcialCiudadanosSanos.Models;

namespace ParcialCiudadanosSanos.Pages.Pacientes
{
    public class EditModel : PageModel
    {
        private readonly ParcialCiudadanosSanosContext _context;

        public EditModel(ParcialCiudadanosSanosContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Paciente Paciente { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Paciente == null)
            {
                return NotFound();
            }
            var paciente = await _context.Paciente.FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }
            Paciente = paciente;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            _context.Attach(Paciente).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(Paciente.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return RedirectToPage("./Index");
        }

        private bool PacienteExists(int id)
        {
            return (_context.Paciente?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}