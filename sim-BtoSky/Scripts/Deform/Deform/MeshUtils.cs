using Unity.Jobs;

namespace Deform
{
	public static class MeshUtils
	{
		public static JobHandle RecalculateNormals(NativeMeshData data, JobHandle dependency = default(JobHandle))
		{
			int length = data.NormalBuffer.Length;
			dependency = new ResetNormalsJob
			{
				normals = data.NormalBuffer
			}.Schedule(length, 256, dependency);
			dependency = new AddTriangleNormalToNormalsJob
			{
				triangles = data.IndexBuffer,
				vertices = data.VertexBuffer,
				normals = data.NormalBuffer
			}.Schedule(dependency);
			dependency = new NormalizeNormalsJob
			{
				normals = data.NormalBuffer
			}.Schedule(length, 256, dependency);
			return dependency;
		}

		public static JobHandle RecalculateBounds(NativeMeshData data, JobHandle dependency = default(JobHandle))
		{
			return new RecalculateBoundsJob
			{
				bounds = data.Bounds,
				vertices = data.VertexBuffer
			}.Schedule(dependency);
		}
	}
}
