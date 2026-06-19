using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace PugFlora
{
	internal struct WateredGroundUserAddedPositionsRegistry : IComponentData, IQueryTypeParameter
	{
		public NativeParallelHashSet<int2> Positions;
	}
}
