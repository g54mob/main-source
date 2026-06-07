using System;

public class SaveFileException : Exception
{
	public SaveFileException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
