using System;

namespace Jundroo.Common.Expressions
{
	public static class Converters
	{
		public static Func<float> BoolToNumber(Func<bool> func)
		{
			return () => (!func()) ? (-1f) : 1f;
		}

		public static Func<bool> NumberToBool(Func<float> func)
		{
			return () => func() > 0f;
		}
	}
}
