using System;

public class SearchException : Exception
{
	public SearchException()
	{
	}

	public SearchException(string message)
		: base(message)
	{
	}
}
