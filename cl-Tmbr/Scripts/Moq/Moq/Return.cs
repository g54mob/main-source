using Moq.Behaviors;

namespace Moq
{
	internal static class Return
	{
		public static void Handle(Invocation invocation, Mock mock)
		{
			new ReturnBaseOrDefaultValue(mock).Execute(invocation);
		}
	}
}
