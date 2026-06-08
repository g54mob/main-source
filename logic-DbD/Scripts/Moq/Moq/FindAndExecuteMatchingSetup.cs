namespace Moq
{
	internal static class FindAndExecuteMatchingSetup
	{
		public static bool Handle(Invocation invocation, Mock mock)
		{
			Setup setup = mock.MutableSetups.FindLast((Setup setup2) => setup2.Matches(invocation));
			if (setup != null)
			{
				setup.Execute(invocation);
				return true;
			}
			return false;
		}
	}
}
