using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class Group : Decorator
	{
		public enum Style
		{
			None = 0,
			Foldout = 1,
			Accordian = 2
		}

		public Group(string title = null, Style style = Style.Foldout, bool isCustomFoldout = false)
		{
		}
	}
}
