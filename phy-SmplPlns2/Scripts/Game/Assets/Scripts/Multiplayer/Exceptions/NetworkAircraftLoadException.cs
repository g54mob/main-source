using System;

namespace Assets.Scripts.Multiplayer.Exceptions
{
	public class NetworkAircraftLoadException : Exception
	{
		public NetworkAircraftLoadException(string message)
			: base(message)
		{
		}

		public NetworkAircraftLoadException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
