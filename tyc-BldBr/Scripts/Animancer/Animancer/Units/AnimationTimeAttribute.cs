using System.Diagnostics;

namespace Animancer.Units
{
	[Conditional("UNITY_EDITOR")]
	public sealed class AnimationTimeAttribute : UnitsAttribute
	{
		public enum Units
		{
			Normalized = 0,
			Seconds = 1,
			Frames = 2
		}

		public const string Tooltip = "x = Normalized, s = Seconds, f = Frame";

		public AnimationTimeAttribute(Units units)
		{
		}
	}
}
