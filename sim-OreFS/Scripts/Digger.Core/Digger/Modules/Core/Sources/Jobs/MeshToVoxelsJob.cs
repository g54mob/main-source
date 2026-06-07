using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Digger.Modules.Core.Sources.Jobs
{
	[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Fast, OptimizeFor = OptimizeFor.Performance)]
	public struct MeshToVoxelsJob : IJobParallelFor
	{
		public int3 SizeVox;

		public int3 Origin;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<float3> Vertices;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<ushort> Triangles;

		[WriteOnly]
		public NativeArray<Voxel> Voxels;

		public void Execute(int index)
		{
			float3 p = IndexToXYZ(index);
			float num = float.MaxValue;
			float num2 = float.MinValue;
			for (int i = 0; i < Triangles.Length; i += 3)
			{
				float orthogonality;
				float x = SignedDistanceFromPointToTriangle(p, Vertices[Triangles[i]], Vertices[Triangles[i + 1]], Vertices[Triangles[i + 2]], out orthogonality);
				if (math.abs(x) < math.max(num - 0.001f, 0.001f) || (Utils.Approximately(math.abs(x), num, 0.001f) && math.abs(orthogonality) > math.abs(num2)))
				{
					num = math.abs(x);
					num2 = orthogonality;
				}
			}
			Voxel value = new Voxel(((num2 < 0f) ? (-1f) : 1f) * math.sqrt(num), 10f);
			Voxels[index] = value;
		}

		private float3 IndexToXYZ(int index)
		{
			int num = SizeVox.y * SizeVox.z;
			int num2 = index / num;
			int num3 = (index - num2 * num) / SizeVox.z;
			int num4 = index - num2 * num - num3 * SizeVox.z;
			return new float3(num2, num3, num4);
		}

		private float dot2(float3 v)
		{
			return math.dot(v, v);
		}

		private float SignedDistanceFromPointToTriangle(float3 p, float3 v1, float3 v2, float3 v3, out float orthogonality)
		{
			v1 += (float3)Origin;
			v2 += (float3)Origin;
			v3 += (float3)Origin;
			float3 float5 = v2 - v1;
			float3 float6 = p - v1;
			float3 float7 = v3 - v2;
			float3 float8 = p - v2;
			float3 float9 = v1 - v3;
			float3 float10 = p - v3;
			float3 float11 = math.normalize(math.cross(float5, float9));
			orthogonality = math.dot(float11, float6);
			if (!(math.sign(math.dot(math.cross(float5, float11), float6)) + math.sign(math.dot(math.cross(float7, float11), float8)) + math.sign(math.dot(math.cross(float9, float11), float10)) < 2f))
			{
				return math.dot(float11, float6) * math.dot(float11, float6) / dot2(float11);
			}
			return math.min(math.min(dot2(float5 * math.clamp(math.dot(float5, float6) / dot2(float5), 0f, 1f) - float6), dot2(float7 * math.clamp(math.dot(float7, float8) / dot2(float7), 0f, 1f) - float8)), dot2(float9 * math.clamp(math.dot(float9, float10) / dot2(float9), 0f, 1f) - float10));
		}
	}
}
