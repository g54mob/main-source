using System.Diagnostics;

namespace Animancer.Units
{
	[Conditional("UNITY_EDITOR")]
	public class UnitsAttribute : SelfDrawerAttribute
	{
		public Validate.Value Rule { get; set; }

		protected UnitsAttribute()
		{
		}

		public UnitsAttribute(string suffix)
		{
		}

		public UnitsAttribute(float[] multipliers, string[] suffixes, int unitIndex = 0)
		{
		}
	}
}
