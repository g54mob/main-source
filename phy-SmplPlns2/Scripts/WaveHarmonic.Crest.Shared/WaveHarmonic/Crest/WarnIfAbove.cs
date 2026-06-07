using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class WarnIfAbove : Decorator
	{
		public WarnIfAbove(float maximum)
		{
		}
	}
}
