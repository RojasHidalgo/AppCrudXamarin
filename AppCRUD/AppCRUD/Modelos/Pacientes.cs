using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppCRUD.Modelos
{
    public class Pacientes
    {
        [PrimaryKey,AutoIncrement]
        public int IdPaciente { get; set; }
        [MaxLength(100)]
        public string Nom_pacie { get; set; }
        [MaxLength(50)]
        public int Edad { get; set; }
        [MaxLength(50)]
        public string Nom_dueñ { get; set; }
        [MaxLength(50)]
        public string Direccion { get; set; }
    }
}
