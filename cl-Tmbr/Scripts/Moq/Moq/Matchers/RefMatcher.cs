using System;

namespace Moq.Matchers
{
	internal class RefMatcher : IMatcher
	{
		private readonly object reference;

		private readonly bool referenceIsValueType;

		public RefMatcher(object reference)
		{
			this.reference = reference;
			referenceIsValueType = reference?.GetType().IsValueType ?? false;
		}

		public bool Matches(object argument, Type parameterType)
		{
			if (!referenceIsValueType)
			{
				return reference == argument;
			}
			return object.Equals(reference, argument);
		}

		public void SetupEvaluatedSuccessfully(object value, Type parameterType)
		{
		}
	}
}
