using Assets.Scripts.Craft.MeshGen;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Parts.Fuselage
{
	[BurstCompile]
	public struct FuselageSmoothJob : IJob
	{
		public RigidTransform BTransform;

		public float MergeRadius;

		public NativeMesh MeshA;

		public ulong MeshASubmeshMask;

		[ReadOnly]
		public NativeMesh MeshB;

		public ulong MeshBSubmeshMask;

		public bool SetMean;

		void IJob.Execute()
		{
			NativeParallelMultiHashMap<int4, int> nativeParallelMultiHashMap = new NativeParallelMultiHashMap<int4, int>(MeshB.Vertices.Length + 32, Allocator.Temp);
			NativeHashSet<int> nativeHashSet = new NativeHashSet<int>(math.max(MeshA.Vertices.Length, MeshB.Vertices.Length), Allocator.Temp);
			NativeArray<int> nativeArray = MeshB.Triangles.AsArray().Reinterpret<int>(12);
			float num = MergeRadius * 2.1f;
			float num2 = 1f / num;
			for (int i = 0; i < MeshB.Runs.Length; i++)
			{
				NativeMesh.TriangleRun triangleRun = MeshB.Runs[i];
				if (!CheckMask(MeshBSubmeshMask, triangleRun.MaterialId))
				{
					continue;
				}
				int num3 = ((i == MeshB.Runs.Length - 1) ? nativeArray.Length : (MeshB.Runs[i + 1].StartTriangles * 3));
				for (int j = triangleRun.StartTriangles * 3; j < num3; j++)
				{
					int num4 = nativeArray[j];
					if (!nativeHashSet.Add(num4))
					{
						continue;
					}
					float3 obj = math.transform(BTransform, MeshB.Vertices[num4].position) * num2;
					int3 int5 = (int3)math.floor(obj);
					int3 int6 = (int3)math.sign(obj - int5 - 0.5f);
					int3x2 int3x5 = math.int3x2(int5, int5 + int6);
					for (int k = 0; k < 2; k++)
					{
						for (int l = 0; l < 2; l++)
						{
							for (int m = 0; m < 2; m++)
							{
								int4 key = math.int4(int3x5[k].x, int3x5[l].y, int3x5[m].z, triangleRun.MaterialId);
								nativeParallelMultiHashMap.Add(key, num4);
							}
						}
					}
				}
			}
			float num5 = MergeRadius * MergeRadius;
			nativeArray = MeshA.Triangles.AsArray().Reinterpret<int>(12);
			nativeHashSet.Clear();
			for (int n = 0; n < MeshA.Runs.Length; n++)
			{
				NativeMesh.TriangleRun triangleRun2 = MeshA.Runs[n];
				if (!CheckMask(MeshASubmeshMask, triangleRun2.MaterialId))
				{
					continue;
				}
				int num6 = ((n == MeshA.Runs.Length - 1) ? nativeArray.Length : (MeshA.Runs[n + 1].StartTriangles * 3));
				for (int num7 = triangleRun2.StartTriangles * 3; num7 < num6; num7++)
				{
					int num8 = nativeArray[num7];
					if (!nativeHashSet.Add(num8))
					{
						continue;
					}
					Vertex value = MeshA.Vertices[num8];
					int4 key2 = math.int4((int3)math.floor(value.position * num2), triangleRun2.MaterialId);
					int index = 0;
					bool flag = false;
					float num9 = 0f;
					foreach (int item in nativeParallelMultiHashMap.GetValuesForKey(key2))
					{
						Vertex vertex = MeshB.Vertices[item];
						float num10 = math.lengthsq(math.transform(BTransform, vertex.position) - value.position);
						if (!(num10 > num5))
						{
							float num11 = math.lengthsq(vertex.normal - value.normal) * 2f + num10;
							if (!flag || num11 < num9)
							{
								flag = true;
								index = item;
								num9 = num11;
							}
						}
					}
					if (flag)
					{
						float3 float5 = math.mul(BTransform.rot, MeshB.Vertices[index].normal);
						value.normal = math.normalizesafe(SetMean ? (value.normal + float5) : float5, value.normal);
						MeshA.Vertices[num8] = value;
					}
				}
			}
			static bool CheckMask(ulong mask, int num12)
			{
				return (mask & (ulong)(1L << num12)) != 0;
			}
		}
	}
}
