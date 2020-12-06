using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PDVApi.Models
{
    //Coneção SqlServer para o Dapper
    public class PdvRepository
    {
        private string ConnectionString;

        public PdvRepository() 
        {
            ConnectionString = @"Data Source=SRV2012R2-01;User ID=sa;Password=Eruinem8ii; Initial Catalog=DbPDV; Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public IDbConnection Connection 
        {
            get 
            {
                return new SqlConnection(ConnectionString);
            }
        }
        //Metodos Dapper
        public void Add(PDV pdv) 
        {
            using (IDbConnection dbConnection = Connection) 
            {
            string  sQuery = @"INSERT INTO PDVS (Pagamento,Preco,Troco,NotasMoedas) VALUES(@Pagamento,@Preco,@Troco,@NotasMoedas)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, pdv);
            }
        }
        public IEnumerable<PDV> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM PDVS";
                dbConnection.Open();
                return dbConnection.Query<PDV>(sQuery);
            }
        }

        public PDV GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM PDVS Where PDVId = @id";
                dbConnection.Open();
                return dbConnection.Query<PDV>(sQuery, new { id=id }).FirstOrDefault();
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM PDVS Where PDVId = @id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { id = id });
            }
        }
        public void Update(PDV pdv)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE PDVS SET  Pagamento=@Pagamento,Preco=@Preco,Troco=@Troco,NotasMoedasWhere=@NotasMoedas Where PDVId = @PDVId";
                dbConnection.Open();
                dbConnection.Query(sQuery, pdv);
            }
        }
    }
}
