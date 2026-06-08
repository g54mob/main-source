namespace Moq
{
	internal static class FailForStrictMock
	{
		public static void Handle(Invocation invocation, Mock mock)
		{
			if (mock.Behavior == MockBehavior.Strict)
			{
				throw MockException.NoSetup(invocation);
			}
		}
	}
}
