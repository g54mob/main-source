using System;
using MyBox.Internal;

namespace MyBox
{
	[Serializable]
	public class OptionalInt : Optional<int>
	{
		public static OptionalInt WithValue(int value)
		{
			return null;
		}
	}
}
