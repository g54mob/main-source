using Unity.Burst;
using Unity.Jobs;

namespace DV.PointSet.MeshUtils
{
	[BurstCompile]
	public struct CopyMeshIntoAnotherJob : IJob
	{
		public NativeMeshContainer source;

		public NativeMeshContainer destination;

		public void Execute()
		{
			int length = destination.vertices.Length;
			for (int i = 0; i < source.vertices.Length; i++)
			{
				destination.vertices.Add(source.vertices[i]);
			}
			for (int j = 0; j < source.indices.Length; j++)
			{
				destination.indices.Add(source.indices[j] + length);
			}
		}
	}
}
