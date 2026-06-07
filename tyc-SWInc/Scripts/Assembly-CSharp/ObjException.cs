using System;

public class ObjException : ApplicationException
{
	public ObjException(string Message, Exception innerException)
		: base(Message, innerException)
	{
	}

	public ObjException(string Message)
		: base(Message)
	{
	}

	public ObjException()
	{
	}
}
