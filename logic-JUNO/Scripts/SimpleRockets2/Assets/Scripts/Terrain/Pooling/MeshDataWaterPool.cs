using ModApi.Planet;

namespace Assets.Scripts.Terrain.Pooling
{
	public class MeshDataWaterPool : QuadMeshDataPool<MeshDataWater>
	{
		public MeshDataWaterPool(int vertexCount, QuadMeshDataFlags requiredData, int initialSize)
			: base(QuadMeshPoolType.Water, vertexCount, requiredData, initialSize)
		{
		}

		protected override MeshDataWater CreateItem(int id)
		{
			return new MeshDataWater(base.VertexCount, base.RequiredData);
		}
	}
}
