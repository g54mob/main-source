using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class Embedded : Decorator
	{
		public Embedded(int margin = 0, string defaultPropertyName = null)
		{
		}
	}
}
