using Unity.Entities;

namespace ContainedMiniSim.Components
{
	public struct ContainedMiniSimElementLastVisualBuffer : IBufferElementData
	{
		public int lastAnimationCounter;
	}
}
