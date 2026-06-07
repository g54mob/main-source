using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class Stepped : Decorator
	{
		public Stepped(int minimum, int maximum, int step = 1, bool power = false)
		{
		}
	}
}
