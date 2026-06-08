using System;

namespace Moq.Matchers
{
	internal class ParamArrayMatcher : IMatcher
	{
		private IMatcher[] matchers;

		public ParamArrayMatcher(IMatcher[] matchers)
		{
			this.matchers = matchers;
		}

		public bool Matches(object argument, Type parameterType)
		{
			if (!(argument is Array array) || matchers.Length != array.Length)
			{
				return false;
			}
			Type elementType = parameterType.GetElementType();
			for (int i = 0; i < array.Length; i++)
			{
				if (!matchers[i].Matches(array.GetValue(i), elementType))
				{
					return false;
				}
			}
			return true;
		}

		public void SetupEvaluatedSuccessfully(object argument, Type parameterType)
		{
			Array array = (Array)argument;
			Type elementType = parameterType.GetElementType();
			int i = 0;
			for (int num = matchers.Length; i < num; i++)
			{
				matchers[i].SetupEvaluatedSuccessfully(array.GetValue(i), elementType);
			}
		}
	}
}
