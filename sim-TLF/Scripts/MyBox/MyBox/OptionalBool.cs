using System;
using MyBox.Internal;

namespace MyBox
{
	[Serializable]
	public class OptionalBool : Optional<bool>
	{
		public OptionalBool(bool value, bool enabledByDefault = false)
		{
			IsSet = enabledByDefault;
			Value = value;
		}

		public static OptionalBool WithValue(bool value)
		{
			return new OptionalBool(value, enabledByDefault: true);
		}
	}
}
