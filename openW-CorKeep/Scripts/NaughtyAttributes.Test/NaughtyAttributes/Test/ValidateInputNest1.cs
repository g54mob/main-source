using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class ValidateInputNest1
	{
		[ValidateInput("NotZero1", null)]
		[AllowNesting]
		public int int1;

		public ValidateInputNest2 nest2;

		private bool NotZero1(int value)
		{
			return value != 0;
		}
	}
}
