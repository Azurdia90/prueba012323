using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Usuario
{
	public string id { get; set; }

	public string usuario { get; set; }

	public string password { get; set; }

	public string rol { get; set; }

	public static List<Usuario> TMP()
	{
		var list = new List<Usuario>()
		{
			new Usuario
			{
				id = "1",
				usuario = "yo",
				password = "admin",
				rol = "admin"
			},
			new Usuario
			{
				id = "1",
				usuario = "usuario1",
				password = "usuario1",
				rol = "usuario1"
			},
			new Usuario
			{
				id = "1",
				usuario = "usuario2",
				password = "usuario2",
				rol = "usuario2"
			},
		};

		return list;
	}

	public Usuario()
	{
		//
		// TODO: Add constructor logic here
		//
	}


}
