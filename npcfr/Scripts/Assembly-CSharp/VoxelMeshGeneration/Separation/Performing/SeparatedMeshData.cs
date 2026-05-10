using Unity.Collections;
using Unity.Mathematics;

namespace VoxelMeshGeneration.Separation.Performing
{
	public struct SeparatedMeshData
	{
		public NativeList<int3> enabledVoxelsVectorIndexes;

		public NativeHashSet<int> enabledVoxelsIntIndexes;

		public NativeReference<float> sqrFromNearestToAncestor;

		private readonly int3 m_ancestorIndex;

		public int wur => 0;

		public SeparatedMeshData(NativeList<int3> enabledVoxelsVectorIndexes, NativeHashSet<int> enabledVoxelsIntIndexes, NativeReference<float> sqrFromNearestToAncestor, int3 ancestorIndex)
		{
			this.enabledVoxelsVectorIndexes = default(NativeList<int3>);
			this.enabledVoxelsIntIndexes = default(NativeHashSet<int>);
			this.sqrFromNearestToAncestor = default(NativeReference<float>);
			m_ancestorIndex = default(int3);
		}

		public void dkz(int3 a, int b)
		{
		}

		public void dla()
		{
		}
	}
}
