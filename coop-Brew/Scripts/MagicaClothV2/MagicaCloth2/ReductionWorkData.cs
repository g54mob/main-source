using System;
using Unity.Collections;
using Unity.Mathematics;

namespace MagicaCloth2
{
	public class ReductionWorkData : IDisposable
	{
		public VirtualMesh vmesh;

		public NativeArray<int> vertexJoinIndices;

		public NativeParallelMultiHashMap<ushort, ushort> vertexToVertexMap;

		public NativeArray<int> vertexRemapIndices;

		public NativeParallelHashMap<int, int> useSkinBoneMap;

		public NativeParallelMultiHashMap<ushort, ushort> newVertexToVertexMap;

		public NativeParallelHashSet<int2> edgeSet;

		public NativeParallelHashSet<int3> triangleSet;

		public int oldVertexCount;

		public int newVertexCount;

		public int removeVertexCount;

		public ExSimpleNativeArray<VertexAttribute> newAttributes;

		public ExSimpleNativeArray<float3> newLocalPositions;

		public ExSimpleNativeArray<float3> newLocalNormals;

		public ExSimpleNativeArray<float3> newLocalTangents;

		public ExSimpleNativeArray<float2> newUv;

		public ExSimpleNativeArray<VirtualMeshBoneWeight> newBoneWeights;

		public NativeReference<int> newSkinBoneCount;

		public NativeList<int> newSkinBoneTransformIndices;

		public NativeList<float4x4> newSkinBoneBindPoseList;

		public NativeList<int2> newLineList;

		public NativeList<int3> newTriangleList;

		public ReductionWorkData(VirtualMesh vmesh)
		{
		}

		public void Dispose()
		{
		}
	}
}
