using System;

public class StonescriptRuntimeException : Exception
{
	public StonescriptRuntimeException(string message)
		: base(message)
	{
	}
}
