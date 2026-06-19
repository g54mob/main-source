using Unity.Entities;
using Unity.Mathematics;

namespace Pug.Automation
{
	public struct StorageCD : IComponentData, IQueryTypeParameter
	{
		public int2 position;

		public Entity inventoryEntity;

		public uint wasEmptyAtVersion;
	}
}
