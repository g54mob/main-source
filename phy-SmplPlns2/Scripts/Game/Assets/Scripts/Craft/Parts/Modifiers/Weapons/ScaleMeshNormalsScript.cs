using Assets.Scripts.Craft.MeshGen;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	[BurstCompile]
	public class ScaleMeshNormalsScript : MonoBehaviour
	{
		[BurstCompile]
		private struct ScaleNormalsJob : IJob
		{
			public float4x4 Matrix;

			public Mesh.MeshDataArray MeshDataArray;

			public NativeList<float3> MeshNormals;

			public bool FirstRun;

			unsafe void IJob.Execute()
			{
				Mesh.MeshData meshData = MeshDataArray[0];
				if (meshData.HasVertexAttribute(VertexAttribute.Normal) && meshData.GetVertexAttributeFormat(VertexAttribute.Normal) == VertexAttributeFormat.Float32 && meshData.GetVertexAttributeDimension(VertexAttribute.Normal) == 3)
				{
					NativeList<float3> meshNormals = MeshNormals;
					int vertexCount = meshData.vertexCount;
					if (meshNormals.Length != vertexCount)
					{
						meshNormals.Length = vertexCount;
						meshData.CopyAttributeToSlice(VertexAttribute.Normal, meshNormals.AsArray().Slice());
					}
					int vertexAttributeStream = meshData.GetVertexAttributeStream(VertexAttribute.Normal);
					int vertexBufferStride = meshData.GetVertexBufferStride(vertexAttributeStream);
					byte* unsafePtr = (byte*)meshData.GetVertexData<byte>(vertexAttributeStream).GetUnsafePtr();
					unsafePtr += meshData.GetVertexAttributeOffset(VertexAttribute.Normal);
					float3x3 a = (float3x3)Matrix;
					Hint.Assume(vertexBufferStride >= sizeof(float3));
					for (int i = 0; i < vertexCount; i++)
					{
						float3* ptr = (float3*)(unsafePtr + i * vertexBufferStride);
						*ptr = math.mul(a, meshNormals[i]);
					}
				}
			}
		}

		private static class Profile
		{
			public static readonly ProfilerMarker ScaleNormals = new ProfilerMarker("ScaleMeshNormalsScript.ScaleNormals");
		}

		private bool _initialized;

		private MeshFilter _meshFilter;

		private NativeList<float3> _meshNormals;

		public void ScaleNormals()
		{
			bool flag = !_initialized;
			if (flag)
			{
				_initialized = true;
				_meshFilter = GetComponent<MeshFilter>();
				_meshNormals = new NativeList<float3>(256, Allocator.Persistent);
			}
			using (Profile.ScaleNormals.Auto())
			{
				Mesh mesh = _meshFilter.mesh;
				Mesh.MeshDataArray meshDataArray = Mesh.AllocateWritableMeshData(mesh);
				new ScaleNormalsJob
				{
					MeshDataArray = meshDataArray,
					Matrix = base.transform.worldToLocalMatrix.transpose,
					MeshNormals = _meshNormals,
					FirstRun = flag
				}.Run();
				Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, mesh);
			}
		}

		protected void OnDestroy()
		{
			Extensions.DisposeIfCreated(ref _meshNormals);
		}
	}
}
