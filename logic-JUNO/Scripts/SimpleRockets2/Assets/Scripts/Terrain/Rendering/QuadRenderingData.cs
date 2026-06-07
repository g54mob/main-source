using UnityEngine;

namespace Assets.Scripts.Terrain.Rendering
{
	public class QuadRenderingData
	{
		public QuadAxisAlignedBoundingBox BoundingBox;

		public Quaterniond BoundingBoxRotation;

		public int Id;

		public Vector3d LocalPosition;

		public MaterialPropertyBlock RaycastMaterialPropertyBlock;

		public Material TerrainMaterial;

		public Mesh TerrainMesh;

		public Material WaterMaterial;

		public Mesh WaterMesh;
	}
}
