namespace NSubstitute.Exceptions
{
	public abstract class TypeForwardingException : SubstituteException
	{
		protected TypeForwardingException(string message)
			: base(message)
		{
		}
	}
}
