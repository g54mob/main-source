using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class PrefabField : Decorator
	{
		public PrefabField(string title = "", string name = "")
		{
		}
	}
}
