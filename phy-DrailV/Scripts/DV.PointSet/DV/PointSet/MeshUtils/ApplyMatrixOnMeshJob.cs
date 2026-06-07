using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace DV.PointSet.MeshUtils
{
	[BurstCompile]
	public struct ApplyMatrixOnMeshJob : IJobParallelFor
	{
		[NativeDisableParallelForRestriction]
		public NativeMeshContainer mesh;

		public float4x4 matrix;

		public void Execute(int index)
		{
			NativeMeshContainer.Vertex value = mesh.vertices[index];
			value.pos = math.mul(matrix, new float4(value.pos, 1f)).xyz;
			value.normal = math.mul((float3x3)matrix, value.normal);
			mesh.vertices[index] = value;
		}
	}
}
