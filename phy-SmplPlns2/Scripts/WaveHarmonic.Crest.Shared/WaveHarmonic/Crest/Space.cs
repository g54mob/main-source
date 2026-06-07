using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class Space : Decorator
	{
		public Space(float height, bool isAlwaysVisible = false)
		{
		}
	}
}
