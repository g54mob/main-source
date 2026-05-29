using System.Diagnostics;

namespace Animancer.Units
{
	[Conditional("UNITY_EDITOR")]
	public sealed class MultiplierAttribute : UnitsAttribute
	{
		public MultiplierAttribute()
			: base(" x")
		{
		}
	}
}
