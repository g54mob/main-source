using Unity.Entities;
using Unity.Mathematics;

namespace PugFlora
{
	public struct WateredGroundUserAddedCD : ICleanupComponentData, IComponentData, IQueryTypeParameter
	{
		public int2 position;
	}
}
