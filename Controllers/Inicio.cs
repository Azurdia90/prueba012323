using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

/// <summary>
/// Summary description for Class1
/// </summary>

[ApiController]
[Route("Usuario")]
public class Inicio : ControllerBase
{
	public IConfiguration configuration_value;
	public Inicio(IConfiguration configuration_request)
	{
		configuration_value = configuration_request;
	}

	[HttpPost]
	[Route("login")]
	public dynamic InicioSesion([FromBody] Object RequestData)
	{
		var data = JsonConvert.DeserializeObject<dynamic>(RequestData.ToString());
		var jwt = configuration_value.GetSection("JWT").Get<Jwt>();

		string user_request = data.user_request.ToString();
		string pass_request = data.pass_request.ToString();

		Usuario usuario = Usuario.TMP().Where(x => x.usuario == user_request && x.password == pass_request).FirstOrDefault();

		if(usuario == null)
		{
			return new
			{
				success = false,
				message = "Usuario no permitido",
				result = ""
			};
		}


		var claims = new[]
		{
			new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, jwt.subject),
			new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
			new Claim("usuario", usuario.usuario)
		};

		var key_jwt = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
		var string_entry = new SigningCredentials(key_jwt, SecurityAlgorithms.HmacSha256);


		var token_request = new JwtSecurityToken(
			jwt.issuer,
			jwt.audience,
			claims,
			expires: DateTime.Now.AddMinutes(15)
		);

		return new
		{
			success = true,
			message = "usuario valido",
			result  = new JwtSecurityTokenHandler().WriteToken(token_request)
		};
	}
}
