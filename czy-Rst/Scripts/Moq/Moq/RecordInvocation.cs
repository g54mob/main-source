namespace Moq
{
	internal static class RecordInvocation
	{
		public static void Handle(Invocation invocation, Mock mock)
		{
			mock.MutableInvocations.Add(invocation);
		}
	}
}
