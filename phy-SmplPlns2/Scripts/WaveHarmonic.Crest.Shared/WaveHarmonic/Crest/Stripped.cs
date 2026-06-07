using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class Stripped : Decorator
	{
		public enum Style
		{
			None = 0,
			PlatformTab = 1
		}

		public Stripped(Style style = Style.None, bool indent = false)
		{
		}
	}
}
