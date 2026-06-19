using Unity.Entities;

namespace ContainedMiniSim.Components
{
	public struct ContainedMiniSimContainerCD : IComponentData, IQueryTypeParameter
	{
		public int maxNumberOfSimulatedElements;

		public Entity simulatedEntity;
	}
}
