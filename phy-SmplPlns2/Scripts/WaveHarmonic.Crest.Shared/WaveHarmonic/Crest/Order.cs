using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class Order : Decorator
	{
		public enum Placement
		{
			Heading = 0,
			Below = 1,
			Above = 2
		}

		public Order(string target, Placement placement = Placement.Heading)
		{
		}
	}
}
