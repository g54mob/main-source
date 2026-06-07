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
				this.vertices = default(NativeArray<Vector3>);
				this.normals = default(NativeArray<Vector3>);
				this.tangents = default(NativeArray<Vector4>);
				this.smoothedNormals = default(UnsafeParallelHashMap<Vector3, Vector3>);
				this.bakedNormals = default(NativeArray<Vector2>);
			}

			void IJobParallelFor.Execute(int index)
			{
			}

			private static Vector2 OctahedronNormal(Vector3 resultNormal)
			{
				return default(Vector2);
			}
		}

		public static Vector2[] ComputeSmoothedNormals(Mesh mesh)
		{
			return null;
		}
	}
}
