namespace NSubstitute.Exceptions
{
	public class CouldNotSetReturnDueToMissingInfoAboutLastCallException : CouldNotSetReturnException
	{
		public CouldNotSetReturnDueToMissingInfoAboutLastCallException()
			: base("Could not find information about the last call to return from.")
		{
		}
	}
}
