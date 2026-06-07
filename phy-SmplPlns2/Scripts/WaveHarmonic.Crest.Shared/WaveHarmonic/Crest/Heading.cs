using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class Heading : Decorator
	{
		public enum Style
		{
			Normal = 0,
			Settings = 1
		}

		public Heading(string heading, Style style = Style.Normal, bool alwaysVisible = false, bool alwaysEnabled = false, string helpLink = null)
		{
		}
	}
}
