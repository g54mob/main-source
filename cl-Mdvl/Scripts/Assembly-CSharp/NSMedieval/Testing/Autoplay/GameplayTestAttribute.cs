using System;

namespace NSMedieval.Testing.Autoplay
{
	public class GameplayTestAttribute : Attribute
	{
		public string Id { get; set; }

		public GameplayTestAttribute(string id)
		{
			Id = id;
		}
	}
}
