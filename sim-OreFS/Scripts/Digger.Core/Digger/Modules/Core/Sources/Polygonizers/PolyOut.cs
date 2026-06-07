using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Digger.Modules.Core.Sources.Polygonizers
{
	public struct PolyOut
	{
		public const int MaxVertexCount = 65536;

		public const int MaxTriangleCount = 65536;

		private const MeshUpdateFlags MeshUpdateFlags = MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds;

		public NativeArray<VertexData> outVertexData;

		public NativeArray<ushort> outTriangles;

		public int vertexCount;

		public int triangleCount;

		public void Dispose()
		{
			outVertexData.Dispose();
			outTriangles.Dispose();
		}

		public static PolyOut New()
		{
			return new PolyOut
			{
				outVertexData = new NativeArray<VertexData>(65536, Allocator.Persistent, NativeArrayOptions.UninitializedMemory),
				outTriangles = new NativeArray<ushort>(65536, Allocator.Persistent, NativeArrayOptions.UninitializedMemory),
				vertexCount = 0,
				triangleCount = 0
			};
		}

		public bool TransferVertexData(Mesh mesh, Bounds bounds)
		{
			if (vertexCount < 3 || triangleCount < 1 || vertexCount >= 65536 || triangleCount >= 65536)
			{
				return false;
			}
			mesh.SetVertexBufferParams(vertexCount, VertexData.Layout);
			mesh.SetVertexBufferData(outVertexData, 0, 0, vertexCount, 0, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
			mesh.SetIndexBufferParams(triangleCount, IndexFormat.UInt16);
			mesh.SetIndexBufferData(outTriangles, 0, 0, triangleCount, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
			mesh.SetSubMesh(0, new SubMeshDescriptor(0, triangleCount), MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
			mesh.bounds = bounds;
			return true;
		}
	}
}
