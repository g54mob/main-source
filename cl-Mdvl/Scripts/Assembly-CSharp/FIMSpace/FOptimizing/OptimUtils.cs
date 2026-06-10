using UnityEngine;

namespace FIMSpace.FOptimizing
{
	public static class OptimUtils
	{
		private static IgnoreOptimizer ign;

		public static bool ShouldBeIgnored(Component comp)
		{
			return comp.gameObject.TryGetComponent<IgnoreOptimizer>(out ign);
		}
	}
}
