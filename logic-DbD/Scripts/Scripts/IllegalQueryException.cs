public class IllegalQueryException : SearchException
{
	public IllegalQueryException()
	{
	}

	public IllegalQueryException(string message)
		: base(message)
	{
	}
}
