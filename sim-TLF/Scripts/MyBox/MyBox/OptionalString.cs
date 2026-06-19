using System;
using MyBox.Internal;

namespace MyBox
{
	[Serializable]
	public class OptionalString : Optional<string>
	{
		public OptionalString(string value, bool enabledByDefault = false)
		{
			IsSet = enabledByDefault;
			Value = value;
		}

		public static OptionalString WithValue(string value)
		{
			return new OptionalString(value, enabledByDefault: true);
		}
	}
}
