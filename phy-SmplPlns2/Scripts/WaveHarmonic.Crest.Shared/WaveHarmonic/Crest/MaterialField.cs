using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class MaterialField : Decorator
	{
		public MaterialField(string shader, string title = "", string name = "", string parent = null)
		{
		}
	}
}
