using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace prueba012323.Controllers
{
    [Route("Pruebas")]
    public class Pruebas : Controller
    {
        public IConfiguration configuration_value;

        public Pruebas(IConfiguration configuration_request)
        {
            configuration_value = configuration_request;
        }

        [HttpGet]
        [Route("autorizado")]
        [Authorize]
        public dynamic prueba_autorizacion()
        {
            return new 
            {
                success = true,
			    message = "usuario valido",
			    result = "autorizado"
            };
        }
    }
}
