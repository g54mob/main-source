using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class DecoratedField : Decorator
	{
		public DecoratedField(bool isCustomFoldout = false)
		{
		}
	}
}
