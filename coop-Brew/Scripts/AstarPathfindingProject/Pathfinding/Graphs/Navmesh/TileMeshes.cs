using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	public struct TileMeshes
	{
		public TileMesh[] tileMeshes;

		public IntRect tileRect;

		public Vector2 tileWorldSize;

		public void Rotate(int rotation)
		{
		}

		public byte[] Serialize()
		{
			return null;
		}

		public static TileMeshes Deserialize(byte[] bytes)
		{
			return default(TileMeshes);
		}
	}
}
