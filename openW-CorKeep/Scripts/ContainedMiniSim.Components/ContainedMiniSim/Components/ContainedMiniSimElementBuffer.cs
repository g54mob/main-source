using Unity.Entities;

namespace ContainedMiniSim.Components
{
	public struct ContainedMiniSimElementBuffer : IBufferElementData
	{
		public Entity entity;
	}
}
