using System;

namespace Assets.Scripts.Flight.StartLocations.Exceptions
{
	public class StartLocationNotFoundException : Exception
	{
		public StartLocationNotFoundException()
		{
		}

		public StartLocationNotFoundException(string message)
			: base(message)
		{
		}

		public StartLocationNotFoundException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public static StartLocationNotFoundException FromId(string startLocationId)
		{
			return new StartLocationNotFoundException("Start location with ID '" + startLocationId + "' could not be found.");
		}
	}
}
