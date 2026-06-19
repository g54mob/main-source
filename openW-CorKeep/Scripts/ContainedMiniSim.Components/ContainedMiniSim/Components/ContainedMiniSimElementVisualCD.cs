using Unity.Entities;
using Unity.Mathematics;

namespace ContainedMiniSim.Components
{
	public struct ContainedMiniSimElementVisualCD : IComponentData, IQueryTypeParameter
	{
		public float3 position;

		public int animation;

		public int animationCounter;

		public int orientationHash;

		public bool flipX;
	}
}
