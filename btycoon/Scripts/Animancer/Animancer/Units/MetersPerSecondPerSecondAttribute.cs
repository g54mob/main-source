using System.Diagnostics;

namespace Animancer.Units
{
	[Conditional("UNITY_EDITOR")]
	public sealed class MetersPerSecondPerSecondAttribute : UnitsAttribute
	{
		public MetersPerSecondPerSecondAttribute()
			: base(" m/s²")
		{
		}
	}
}
