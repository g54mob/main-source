using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class Filtered : Decorator
	{
		public enum Mode
		{
			Include = 0,
			Exclude = 1
		}

		public Filtered(int unset = 0)
		{
		}
	}
}
