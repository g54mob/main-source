using Unity.Collections;

namespace VoxelMeshGeneration
{
	public struct VoxelFaceVerticesIndexes
	{
		[ReadOnly]
		private unsafe fixed int m_vertices[4];

		public int this[int index] => 0;

		public VoxelFaceVerticesIndexes(int vertice0, int vertice1, int vertice2, int vertice3)
		{
		}
	}
}
