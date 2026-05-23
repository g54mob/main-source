using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Deform
{
	[BurstCompile(CompileSynchronously = true)]
	public struct AddTriangleNormalToNormalsJob : IJob
	{
		public NativeArray<int> triangles;

		public NativeArray<float3> vertices;

		public NativeArray<float3> normals;

		public void Execute()
		{
			for (int i = 0; i < triangles.Length; i += 3)
			{
				int index = triangles[i];
				int index2 = triangles[i + 1];
				int index3 = triangles[i + 2];
				float3 float5 = vertices[index];
				float3 float6 = vertices[index2];
				float3 float7 = vertices[index3];
				float3 float8 = math.float3(float5.y * float6.z - float5.y * float7.z - float6.y * float5.z + float6.y * float7.z + float7.y * float5.z - float7.y * float6.z, (0f - float5.x) * float6.z + float5.x * float7.z + float6.x * float5.z - float6.x * float7.z - float7.x * float5.z + float7.x * float6.z, float5.x * float6.y - float5.x * float7.y - float6.x * float5.y + float6.x * float7.y + float7.x * float5.y - float7.x * float6.y);
				normals[index] += float8;
				normals[index2] += float8;
				normals[index3] += float8;
			}
		}
	}
}
