using Unity.Collections;

namespace VoxelMeshGeneration.DataBuilding
{
	public struct VoxelMeshData
	{
		public struct Counter
		{
			public ushort vertexesCount;

			public ushort indexesCount;
		}

		public NativeArray<VoxelMeshVertex> vertexes;

		public NativeArray<ushort> indexes;

		public Counter counter;

		public VoxelMeshData(NativeArray<VoxelMeshVertex> vertexes, NativeArray<ushort> indexes, Counter counter)
		{
			this.vertexes = default(NativeArray<VoxelMeshVertex>);
			this.indexes = default(NativeArray<ushort>);
			this.counter = default(Counter);
		}

		public void dpn()
		{
		}
	}
}
