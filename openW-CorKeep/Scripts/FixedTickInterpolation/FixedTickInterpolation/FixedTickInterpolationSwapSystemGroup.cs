using Unity.Entities;
using UnityEngine.Scripting;

namespace FixedTickInterpolation
{
	[UpdateBefore(typeof(FixedTickInterpolationSmoothingSystemGroup))]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	public class FixedTickInterpolationSwapSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		[Preserve]
		public FixedTickInterpolationSwapSystemGroup()
		{
		}
	}
}
