using Unity.Entities;

namespace PugWorldGen
{
	public struct DungeonFillCD : IComponentData, IQueryTypeParameter
	{
		public bool defineShapeByRooms;

		public float roomSize;

		public float pathSize;
	}
}
