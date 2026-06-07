using System;

public class SteamException : SystemException
{
	public SteamException(string message)
		: base(message)
	{
	}

	public SteamException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
