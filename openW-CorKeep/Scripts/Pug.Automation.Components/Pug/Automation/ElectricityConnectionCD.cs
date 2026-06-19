using Unity.Entities;
using Unity.Mathematics;

namespace Pug.Automation
{
	public struct ElectricityConnectionCD : IComponentData, IQueryTypeParameter
	{
		public Entity connectedEntity;

		public int2 position;

		public ElectricityDirectionMask direction;

		public CircuitConnectionMode mode;

		public int connectionModeVariation;

		public unsafe fixed int electricityAmount[4];

		private unsafe fixed int sourceEntityIndex[4];

		private unsafe fixed int sourceEntityVersion[4];

		public unsafe fixed int sourceUpdate[4];

		public bool prioritize;

		public unsafe void SetSourceEntity(int index, Entity entity)
		{
			sourceEntityIndex[index] = entity.Index;
			sourceEntityVersion[index] = entity.Version;
		}

		public unsafe readonly Entity GetSourceEntity(ElectricityDirection index)
		{
			return new Entity
			{
				Index = sourceEntityIndex[(int)index],
				Version = sourceEntityVersion[(int)index]
			};
		}
	}
}
