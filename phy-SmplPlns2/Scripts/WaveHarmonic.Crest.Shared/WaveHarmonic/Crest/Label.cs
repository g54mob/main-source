using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class Label : Decorator
	{
		public Label(string label)
		{
		}
	}
}
