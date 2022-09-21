using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.DataSetBibliotecaTableAdapters;
using System.Data;
namespace BLL
{
    public class ClassLogica
    {
        private EditorialTableAdapter _editorial;
        
        public ClassLogica()
        {
            _editorial = new EditorialTableAdapter();
        }//fin del constructor

        public DataTable ListarEditoriales()
        {
            return _editorial.GetDataEditoriales();
        }//fin ListarEditoriales

        /// <summary>
        /// Graba una nueva editorial y valida si ya existe.
        /// </summary>
        /// <param name="Nombre">recibe el nombre de la nueva editorial</param>
        /// <param name="Pais">recibe el nombre del pais de la nueva editorial</param>
        /// <returns>Retorna el mensaje de éxito o de error</returns>
        public string NuevaEditorial(string Nombre, string Pais)
        {
            try
            {
                DataTable tabla = _editorial.GetDataByNombreEditorial(Nombre);
                if (tabla.Rows.Count < 1)
                {
                    _editorial.InsertQueryEditorial(Nombre, Pais, true);
                    return "Se grabó la nueva Editorial";
                }
                else
                    return "Error: el nombre de la editorial " + Nombre + " ya existe";

            }
            catch (Exception error)
            {
                return "Error: " + error.Message;
            }
        }//fin NuevaEditorial

        public string ActulizaEditorial(string Nombre, string Pais, bool Estado, int Id)
        {
            string respuesta = "";
            try
            {
                _editorial.UpdateQueryEditorial(Nombre, Pais, Estado, Id);
                respuesta = "Se actualizó el registro de Editorial";
            }
            catch (Exception error)
            {
                respuesta = "Error: " + error.Message;
            }
            return respuesta;
        }//fin ActualizaEditorial

        public int TotalEditoriales()
        {
            int total = 0;
            total = (int)_editorial.ScalarQueryTotalEditoriales();
            return total;
        }//fin de TotalEditoriales

        public DataTable BuscaPorPais(string Pais)
        {
            return _editorial.GetDataByPais(Pais);
        }//fin BuscaPorPais
    }
}
