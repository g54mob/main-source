using System.Diagnostics;

namespace Animancer.Units
{
	[Conditional("UNITY_EDITOR")]
	public sealed class MetersAttribute : UnitsAttribute
	{
		public MetersAttribute()
			: base(" m")
		{
		}
	}
}
