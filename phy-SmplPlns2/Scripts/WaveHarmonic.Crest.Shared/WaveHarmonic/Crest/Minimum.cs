using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class Minimum : Decorator
	{
		public Minimum(float minimum)
		{
		}
	}
}
