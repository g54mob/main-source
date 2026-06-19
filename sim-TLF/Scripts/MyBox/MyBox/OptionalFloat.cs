using System;
using MyBox.Internal;

namespace MyBox
{
	[Serializable]
	public class OptionalFloat : Optional<float>
	{
		public OptionalFloat(float value, bool enabledByDefault = false)
		{
			IsSet = enabledByDefault;
			Value = value;
		}

		public static OptionalFloat WithValue(float value)
		{
			return new OptionalFloat(value, enabledByDefault: true);
		}
	}
}
