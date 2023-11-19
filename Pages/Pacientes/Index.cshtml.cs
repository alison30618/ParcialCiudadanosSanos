using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParcialCiudadanosSanos.Data;
using ParcialCiudadanosSanos.Models;

namespace ParcialCiudadanosSanos.Pages.Pacientes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ParcialCiudadanosSanosContext _context;
        public IndexModel(ParcialCiudadanosSanosContext context)
        {
            _context = context;
        }
        public IList<Paciente> Pacientes { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Paciente != null)
            {
                Pacientes = await _context.Paciente.ToListAsync();
            }
        }
    }
}
