using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class Maximum : Decorator
	{
		public Maximum(float maximum)
		{
		}
	}
}
