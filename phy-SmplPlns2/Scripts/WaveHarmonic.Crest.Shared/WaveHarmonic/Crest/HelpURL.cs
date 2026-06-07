using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class HelpURL : Decorator
	{
		public HelpURL(string path = "")
		{
		}
	}
}
