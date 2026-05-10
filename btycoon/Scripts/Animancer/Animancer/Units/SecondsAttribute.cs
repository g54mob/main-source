using System.Diagnostics;

namespace Animancer.Units
{
	[Conditional("UNITY_EDITOR")]
	public sealed class SecondsAttribute : UnitsAttribute
	{
		public SecondsAttribute()
			: base(" s")
		{
		}
	}
}
