using Unity.Entities;
using Unity.Mathematics;

namespace PugWorldGen
{
	public struct PathCD : IComponentData, IQueryTypeParameter
	{
		public int2 from;

		public int2 to;

		public float width;

		public RoomFlags flags;
	}
}
