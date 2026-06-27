namespace NSubstitute.Exceptions
{
	public class CouldNotConfigureCallBaseException : SubstituteException
	{
		private const string CannotConfigureSingleCallMessage = "Cannot configure the base method call as base method implementation is missing. You can call base method only if you create a class substitute and the method is not abstract.";

		private const string CannotConfigureAllCallsMessage = "Base method calls can be configured for a class substitute only, as otherwise base implementation does not exist.";

		public CouldNotConfigureCallBaseException(string message)
			: base(message)
		{
		}

		internal static CouldNotConfigureCallBaseException ForSingleCall()
		{
			return new CouldNotConfigureCallBaseException("Cannot configure the base method call as base method implementation is missing. You can call base method only if you create a class substitute and the method is not abstract.");
		}

		internal static CouldNotConfigureCallBaseException ForAllCalls()
		{
			return new CouldNotConfigureCallBaseException("Base method calls can be configured for a class substitute only, as otherwise base implementation does not exist.");
		}
	}
}
