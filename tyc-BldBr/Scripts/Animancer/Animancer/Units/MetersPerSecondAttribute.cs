using System.Diagnostics;

namespace Animancer.Units
{
	[Conditional("UNITY_EDITOR")]
	public sealed class MetersPerSecondAttribute : UnitsAttribute
	{
		public MetersPerSecondAttribute()
			: base(" m/s")
		{
		}
	}
}
