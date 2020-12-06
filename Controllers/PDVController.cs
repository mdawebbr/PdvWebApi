using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDVApi.Context;
using PDVApi.Models;

namespace PDVApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDVController : ControllerBase
    {

        #region
        /*
        //Persistencia EntityFrameWorks

        private readonly PDVContext _PDVContext;

        public PDVController(PDVContext PDVContext)
        {
            _PDVContext = PDVContext;
        }

        // GET: api/PDV
        [HttpGet]
        public IEnumerable<PDV> Get()
        {
            return _PDVContext.PDVS;
        }

        // GET: api/PDV/5
        [HttpGet("{id}", Name = "Get")]
        public PDV Get(int id)
        {
            return _PDVContext.PDVS.SingleOrDefault(x => x.PDVId == id);
        }

        // POST: api/PDV
        [HttpPost]
        public void Post([FromBody] PDV pdv)
        {
            pdv.NotasMoedas = calculaTroco(pdv.Preco, pdv.Pagamento);

            pdv.Troco = pdv.Pagamento - pdv.Preco;

            _PDVContext.PDVS.Add(pdv);
            _PDVContext.SaveChanges();
        }

        // PUT: api/PDV/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PDV pdv)
        {
            pdv.NotasMoedas = calculaTroco(pdv.Pagamento, pdv.Preco);

            pdv.Troco = pdv.Pagamento - pdv.Preco;

            _PDVContext.PDVS.Update(pdv);
            _PDVContext.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _PDVContext.PDVS.FirstOrDefault(x => x.PDVId == id);
            if (item != null)
            {
                _PDVContext.PDVS.Remove(item);
            }
        }
        private String calculaTroco(double valorDevido, double valorDado)
        {
            int[] cedulas = { 100, 50, 20, 10, 5, 2 };
            int[] moedas = { 50, 25, 10, 5, 1 };
            String resultado;
            double troco;
            int i, valor, contador;

            troco = valorDado - valorDevido;

            //resultado = "\nTroco = R$   " + troco + "\n\n";
            resultado = "\n";

            // parte inteira do troco 
            valor = (int)troco;
            i = 0; while (valor != 0)
            {
                contador = valor / cedulas[i];
                // quantidade de notas
                if (contador != 0)
                {
                    resultado = resultado + (contador + " nota(s) de R$ " + cedulas[i] + " \n ");
                    valor = valor % cedulas[i];
                    // resto
                }
                i = i + 1;
                // próxima nota
            }
            resultado = resultado + "\n";
            // parte fracionária do troco

            valor = (int)Math.Round((troco - (int)troco) * 100);
            i = 0;
            while (valor != 0)
            {
                contador = valor / moedas[i];
                // quantidade de moedas
                if (contador != 0)
                {
                    resultado = resultado + (contador + " moeda(s) de " + moedas[i] + " centavo(s) \n ");
                    valor = valor % moedas[i];
                    // resto
                }
                i = i + 1;
                // próximo 
            }

            return (resultado);

        }//private String calculaTroco(double valorDevido, double valorDado)
        */
        #endregion


        #region
        //Persistencia Dapper
        private readonly PdvRepository pdvRepository;

        public PDVController()
        {
            pdvRepository = new PdvRepository();
        }

        [HttpGet]
        public IEnumerable<PDV> Get()
        {
            return pdvRepository.GetAll();
        }

        [HttpGet("{id}")]
        public PDV Get(int id)
        {
            return pdvRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] PDV pdv) 
        {
            if (ModelState.IsValid)
                pdvRepository.Add(pdv);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PDV pdv)
        {
            pdv.PDVId = id;
            if (ModelState.IsValid)
                pdvRepository.Update(pdv);
        }
        [HttpDelete]

        public void Delete(int id) 
        {
            pdvRepository.Delete(id);
        }



        #endregion

    }//public class PDVController : ControllerBase

}//namespace PDVApi.Controllers
