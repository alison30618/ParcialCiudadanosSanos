﻿namespace ParcialCiudadanosSanos.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string genero { get; set; }
        public int NroDocumento { get; set; }
        public long Contacto { get; set; }
        public ICollection<ConsultaMedica>? consultaMedicas { get; set; }
    }
}
