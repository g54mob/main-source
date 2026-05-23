using UnityEngine;

namespace VoxelMeshGeneration
{
	public readonly struct VoxelFaceNormalSbyte
	{
		public readonly sbyte normalX;

		public readonly sbyte normalY;

		public readonly sbyte normalZ;

		public VoxelFaceNormalSbyte(Vector3Int normalDirection)
		{
			normalX = 0;
			normalY = 0;
			normalZ = 0;
		}
	}
}
