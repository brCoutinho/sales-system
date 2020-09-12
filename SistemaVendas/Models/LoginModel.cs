using SistemaVendas.Uteis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Informe o e-mail do usuário!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="E-mail inválido!")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string senha { get; set; }


        public bool ValidarLogin()
        {
            string sql = $"SELECT ID FROM VENDEDOR WHERE EMAIL = '{email}' AND SENHA = '{senha}'";

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);
            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
