using System;
using MyBox.Internal;

namespace MyBox
{
	[Serializable]
	public class OptionalInt : Optional<int>
	{
		public OptionalInt(int value, bool enabledByDefault = false)
		{
			IsSet = enabledByDefault;
			Value = value;
		}

		public static OptionalInt WithValue(int value)
		{
			return new OptionalInt(value, enabledByDefault: true);
		}
	}
}
