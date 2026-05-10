using System.Diagnostics;

namespace Animancer.Units
{
	[Conditional("UNITY_EDITOR")]
	public sealed class DegreesAttribute : UnitsAttribute
	{
		public DegreesAttribute()
			: base(" º")
		{
		}
	}
}
