using System;

public class SimulationException : Exception
{
	public SimulationException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
