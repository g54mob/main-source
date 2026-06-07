using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class ShowComputedProperty : Decorator
	{
		public ShowComputedProperty(string name)
		{
		}
	}
}
