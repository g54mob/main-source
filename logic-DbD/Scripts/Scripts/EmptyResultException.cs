public class EmptyResultException : SearchException
{
	public EmptyResultException()
	{
	}

	public EmptyResultException(string message)
		: base(message)
	{
	}
}
