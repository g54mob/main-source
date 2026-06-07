using System;
using System.Linq;

namespace DV.Game.Tutorial
{
	public static class ControlHintUtil
	{
		private static ControlHintAttribute[] attributes;

		static ControlHintUtil()
		{
			attributes = Enum.GetValues(typeof(ControlHint)).Cast<ControlHint>().SelectMany((ControlHint value) => typeof(ControlHint).GetField(value.ToString()).GetCustomAttributes(typeof(ControlHintAttribute), inherit: false).Cast<ControlHintAttribute>())
				.ToArray();
		}

		public static ControlHintAttribute GetAttribute(this ControlHint hint)
		{
			return attributes[(int)hint];
		}
	}
}
