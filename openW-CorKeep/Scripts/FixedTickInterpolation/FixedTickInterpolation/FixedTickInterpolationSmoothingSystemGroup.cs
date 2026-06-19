using Unity.Entities;
using UnityEngine.Scripting;

namespace FixedTickInterpolation
{
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	public class FixedTickInterpolationSmoothingSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		[Preserve]
		public FixedTickInterpolationSmoothingSystemGroup()
		{
		}
	}
}
