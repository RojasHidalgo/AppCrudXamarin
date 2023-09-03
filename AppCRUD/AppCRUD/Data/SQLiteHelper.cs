using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using AppCRUD.Modelos;
using System.Threading.Tasks;

namespace AppCRUD.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Pacientes>().Wait();
        }

        public Task<int> SavePacientesAsync(Pacientes pacient)
        {
            if (pacient.IdPaciente != 0)
            {
                return db.UpdateAsync(pacient);
            }
            else
            {
                return db.InsertAsync(pacient);
            }
        }
        public Task<int> DeletePacienteAsync(Pacientes paciente)
        {
            return db.DeleteAsync(paciente);
        }

        /// <summary>
        /// Recuperar a todos los pacientes
        /// </summary>
        /// <returns></returns>
        public Task<List<Pacientes>> GetPacientesAsync()
        {
            return db.Table<Pacientes>().ToListAsync();
        }
        /// <summary>
        /// Recupera los pacientes por id
        /// </summary>
        /// <param name="idPaciente">Id del paciente que se elija</param>
        /// <returns></returns>
        public Task<Pacientes> GetPacientesByIdAsync(int idPaciente)
        {
            return db.Table<Pacientes>().Where(a =>a.IdPaciente==idPaciente).FirstOrDefaultAsync();
        }
    }
}
