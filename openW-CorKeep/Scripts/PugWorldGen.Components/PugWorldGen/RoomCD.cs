using Unity.Entities;
using Unity.Mathematics;

namespace PugWorldGen
{
	public struct RoomCD : IComponentData, IQueryTypeParameter
	{
		public int2 position;

		public int size;

		public RoomFlags flags;
	}
}
