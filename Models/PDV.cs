using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDVApi.Models
{
    public class PDV
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        //Para criar o banco de dados e as tabelas no Sql Server
        //Rodar no Console PM os comandos:
        //Add-Migration FirstMigration
        //Update-Database
        //Para criar o Script de banco de dados
        //Script-Migration

        public int PDVId { get; set; }
        public double Pagamento { get; set; }
        public double Preco { get; set; }
        public double Troco { get; set; }
        public string NotasMoedas { get; set; }
    }
}
