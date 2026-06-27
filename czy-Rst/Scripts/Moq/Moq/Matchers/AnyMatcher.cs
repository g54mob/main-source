using System;

namespace Moq.Matchers
{
	internal sealed class AnyMatcher : IMatcher
	{
		public static AnyMatcher Instance { get; } = new AnyMatcher();

		private AnyMatcher()
		{
		}

		public bool Matches(object argument, Type parameterType)
		{
			return true;
		}

		public void SetupEvaluatedSuccessfully(object argument, Type parameterType)
		{
		}
	}
}
