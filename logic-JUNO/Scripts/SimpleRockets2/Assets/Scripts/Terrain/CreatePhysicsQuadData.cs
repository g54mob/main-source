using UnityEngine;

namespace Assets.Scripts.Terrain
{
	public class CreatePhysicsQuadData
	{
		public Vector3d Center;

		public Matrix4x4d Matrix;

		public MeshDataPhysics MeshData;

		public Vector3d[] TerrainPoints;

		public CreatePhysicsQuadData(int vertexCount)
		{
			Matrix = new Matrix4x4d();
			MeshData = new MeshDataPhysics(vertexCount);
			TerrainPoints = new Vector3d[vertexCount];
		}
	}
}
