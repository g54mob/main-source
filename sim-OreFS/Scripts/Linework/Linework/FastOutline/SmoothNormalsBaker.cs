using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;

namespace Linework.FastOutline
{
	public static class SmoothNormalsBaker
	{
		private struct BakeNormalJob : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<Vector3> vertices;

			[ReadOnly]
			public NativeArray<Vector3> normals;

			[ReadOnly]
			public NativeArray<Vector4> tangents;

			[NativeDisableContainerSafetyRestriction]
			[ReadOnly]
			public UnsafeParallelHashMap<Vector3, Vector3> smoothedNormals;

			[WriteOnly]
			public NativeArray<Vector2> bakedNormals;

			public BakeNormalJob(NativeArray<Vector3> vertices, NativeArray<Vector3> normals, NativeArray<Vector4> tangents, UnsafeParallelHashMap<Vector3, Vector3> smoothedNormals, NativeArray<Vector2> bakedNormals)
			{
				this.vertices = vertices;
				this.normals = normals;
				this.tangents = tangents;
				this.smoothedNormals = smoothedNormals;
				this.bakedNormals = bakedNormals;
			}

			void IJobParallelFor.Execute(int index)
			{
				Vector3 vector = smoothedNormals[vertices[index]];
				Vector3 normalized = normals[index].normalized;
				Vector3 normalized2 = ((Vector3)tangents[index]).normalized;
				Vector3 normalized3 = (Vector3.Cross(normalized, normalized2) * tangents[index].w).normalized;
				Vector2 value = OctahedronNormal(new Matrix4x4(normalized2, normalized3, normalized, Vector3.zero).transpose.MultiplyVector(vector).normalized);
				bakedNormals[index] = value;
			}

			private static Vector2 OctahedronNormal(Vector3 resultNormal)
			{
				Vector3 rhs = new Vector3(Mathf.Abs(resultNormal.x), Mathf.Abs(resultNormal.y), Mathf.Abs(resultNormal.z));
				Vector2 result = (Vector2)resultNormal / Vector3.Dot(Vector3.one, rhs);
				if (!(resultNormal.z <= 0f))
				{
					return result;
				}
				float num = Mathf.Abs(result.y);
				float num2 = (1f - num) * (float)((result.y >= 0f) ? 1 : (-1));
				return new Vector2(num2, num2);
			}
		}

		public static Vector2[] ComputeSmoothedNormals(Mesh mesh)
		{
			Vector3[] vertices = mesh.vertices;
			Vector3[] normals = mesh.normals;
			Vector4[] tangents = mesh.tangents;
			int num = vertices.Length;
			if (tangents.Length == 0)
			{
				Debug.LogError("Mesh " + mesh.name + " did not contain any tangents.");
				return null;
			}
			UnsafeParallelHashMap<Vector3, Vector3> smoothedNormals = new UnsafeParallelHashMap<Vector3, Vector3>(num, Allocator.Persistent);
			for (int i = 0; i < num; i++)
			{
				if (smoothedNormals.ContainsKey(vertices[i]))
				{
					smoothedNormals[vertices[i]] += normals[i];
				}
				else
				{
					smoothedNormals.Add(vertices[i], normals[i]);
				}
			}
			NativeArray<Vector3> normals2 = new NativeArray<Vector3>(normals, Allocator.Persistent);
			NativeArray<Vector3> vertices2 = new NativeArray<Vector3>(vertices, Allocator.Persistent);
			NativeArray<Vector4> tangents2 = new NativeArray<Vector4>(tangents, Allocator.Persistent);
			NativeArray<Vector2> bakedNormals = new NativeArray<Vector2>(num, Allocator.Persistent);
			IJobParallelForExtensions.Schedule(new BakeNormalJob(vertices2, normals2, tangents2, smoothedNormals, bakedNormals), num, 100).Complete();
			Vector2[] array = new Vector2[num];
			bakedNormals.CopyTo(array);
			smoothedNormals.Dispose();
			normals2.Dispose();
			vertices2.Dispose();
			tangents2.Dispose();
			bakedNormals.Dispose();
			return array;
		}
	}
}
