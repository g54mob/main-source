using System.Runtime.CompilerServices;

namespace HandlebarsDotNet.Runtime
{
	public static class BoxedValues
	{
		private const int BoxedIntegersCount = 20;

		private static readonly object[] BoxedIntegers;

		public static readonly object True;

		public static readonly object False;

		public static readonly object Zero;

		static BoxedValues()
		{
			BoxedIntegers = new object[20];
			True = true;
			False = false;
			Zero = 0;
			for (int i = 0; i < BoxedIntegers.Length; i++)
			{
				BoxedIntegers[i] = i;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static object Int(int value)
		{
			if (value >= 0 && value < 20)
			{
				return BoxedIntegers[value];
			}
			return value;
		}
	}
}
