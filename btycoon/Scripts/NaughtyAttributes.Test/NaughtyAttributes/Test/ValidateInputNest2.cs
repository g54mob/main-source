using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class ValidateInputNest2
	{
		[ValidateInput("NotZero2", null)]
		[AllowNesting]
		public int int2;

		private bool NotZero2(int value)
		{
			return value != 0;
		}
	}
}
