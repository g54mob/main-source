using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class InlineToggle : Decorator
	{
		public InlineToggle(bool fix = false)
		{
		}
	}
}
