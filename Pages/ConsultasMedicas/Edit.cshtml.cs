using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParcialCiudadanosSanos.Data;
using ParcialCiudadanosSanos.Models;

namespace ParcialCiudadanosSanos.Pages.ConsultasMedicas
{
    public class EditModel : PageModel
    {
        private readonly ParcialCiudadanosSanosContext _context;
        public EditModel(ParcialCiudadanosSanosContext context)
        {
            _context = context;
        }
        [BindProperty]
        public ConsultaMedica Consultamedica { get; set; } = default!;
        public SelectList Pacientes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ConsultaMedica == null)
            {
                return NotFound();
            }
            var consulta = await _context.ConsultaMedica.FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }
            Consultamedica = consulta;
            ListarPacientes();
            return Page();
        }
        private void ListarPacientes()
        {
            var pacientes = _context.Paciente.ToList();
            Pacientes = new SelectList(pacientes, "Id", "Name");
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ListarPacientes();
                return NotFound();
            }
            _context.Attach(Consultamedica).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Consultamedica.Id))
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
        private bool ProductExists(int id)
        {
            return (_context.ConsultaMedica?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}