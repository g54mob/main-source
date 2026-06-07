using ModApi.Planet;

namespace Assets.Scripts.Terrain.Pooling
{
	public class MeshDataTerrainPool : QuadMeshDataPool<MeshDataTerrain>
	{
		public MeshDataTerrainPool(int vertexCount, QuadMeshDataFlags requiredData, int initialSize)
			: base(QuadMeshPoolType.Terrain, vertexCount, requiredData, initialSize)
		{
		}

		protected override MeshDataTerrain CreateItem(int id)
		{
			return new MeshDataTerrain(base.VertexCount, base.RequiredData);
		}
	}
}
