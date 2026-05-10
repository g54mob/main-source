using System.Diagnostics;

namespace Animancer.Units
{
	[Conditional("UNITY_EDITOR")]
	public sealed class DegreesPerSecondAttribute : UnitsAttribute
	{
		public DegreesPerSecondAttribute()
			: base(" º/s")
		{
		}
	}
}
