using Microsoft.AspNetCore.Mvc;
using Questao2.Modells;

namespace Questao2.Controllers
{
    [ApiController]
    [Route("API/Frete")] //CONTROLLER
    public class ProdutoController : ControllerBase
    {
        [HttpPost]
        public IActionResult CalcularFreteProduto(Frete frete)
        {
            double volume = frete.Altura * frete.Largura * frete.Comprimento;
            
            
            const double taxaPorCmCubico = 0.01;

            double taxaPorEstado;
            switch (frete.UF.ToUpper())
            {
                case "SP":
                    taxaPorEstado = 50;
                    break;

                case "RJ":
                    taxaPorEstado = 60;
                    break;

                case "MG":
                    taxaPorEstado = 55;
                    break;

                default:
                    taxaPorEstado = 70;
                    break;
            }
            double Resultado = (volume * taxaPorCmCubico) + taxaPorEstado;
            string resultadoEmReais = Resultado.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));

            return Ok(resultadoEmReais);
          
        }
    }
}
