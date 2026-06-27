namespace NSubstitute.Exceptions
{
	public class CouldNotSetReturnDueToNoLastCallException : CouldNotSetReturnException
	{
		public CouldNotSetReturnDueToNoLastCallException()
			: base("Could not find a call to return from.")
		{
		}
	}
}
