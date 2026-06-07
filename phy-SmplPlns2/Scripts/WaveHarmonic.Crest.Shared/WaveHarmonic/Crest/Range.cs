using System;
using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class Range : Decorator
	{
		[Flags]
		public enum Clamp
		{
			None = 0,
			Minimum = 1,
			Maximum = 2,
			Both = 3
		}

		public Range(float minimum, float maximum, Clamp clamp = Clamp.Both, float scale = 1f, bool delayed = false, int step = 0, bool power = false)
		{
		}
	}
}
