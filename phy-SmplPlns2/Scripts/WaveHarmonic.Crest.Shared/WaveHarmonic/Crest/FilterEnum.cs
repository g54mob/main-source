using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class FilterEnum : Decorator
	{
		public FilterEnum(string property, Filtered.Mode mode, params int[] values)
		{
		}
	}
}
