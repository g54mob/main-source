using Unity.Entities;
using Unity.Mathematics;

namespace ContainedMiniSim.Components
{
	public struct ContainedMiniSimDimensionsCD : IComponentData, IQueryTypeParameter
	{
		public float2 simulateAreaMinMaxWidth;

		public float2 simulateAreaMinMaxHeight;

		public float2 simulateAreaMinMaxLength;
	}
}
