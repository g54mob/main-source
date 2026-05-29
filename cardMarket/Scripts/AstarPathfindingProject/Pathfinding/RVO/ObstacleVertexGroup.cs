using Unity.Mathematics;

namespace Pathfinding.RVO
{
	public struct ObstacleVertexGroup
	{
		public ObstacleType type;

		public int vertexCount;

		public float3 boundsMn;

		public float3 boundsMx;
	}
}
