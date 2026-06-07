using Digger.Modules.Core.Sources.Jobs;
using Digger.Modules.Core.Sources.NativeCollections;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Digger.Modules.Core.Sources.Polygonizers
{
	public class MarchingCubesPolygonizer : IPolygonizer
	{
		private readonly byte isLowPolyStyle;

		private PolyOut mcOut;

		private NativeArray<Voxel> voxels;

		private NativeArray<float3> normals;

		private NativeArray<float> alphamaps;

		private NativeCounter vertexCounter;

		public MarchingCubesPolygonizer(bool lowPolyStyle = false)
		{
			isLowPolyStyle = (byte)(lowPolyStyle ? 1u : 0u);
		}

		public JobHandle BuildMesh(VoxelChunk chunk, int lod)
		{
			mcOut = PolyOut.New();
			NativeArray<int> mCEdgeTable = NativeCollectionsPool.Instance.GetMCEdgeTable();
			NativeArray<int> mCTriTable = NativeCollectionsPool.Instance.GetMCTriTable();
			NativeArray<float3> mCCorners = NativeCollectionsPool.Instance.GetMCCorners();
			voxels = new NativeArray<Voxel>(chunk.VoxelArray, Allocator.Persistent);
			normals = new NativeArray<float3>(chunk.NormalArray, Allocator.Persistent);
			alphamaps = new NativeArray<float>(chunk.AlphamapArray, Allocator.Persistent);
			vertexCounter = new NativeCounter(Allocator.Persistent, 3);
			int2 alphamapsSize = chunk.Digger.AlphamapsSize;
			Vector2 uVScale = chunk.Digger.UVScale;
			float3 float5 = new float3(chunk.Digger.HeightmapScale);
			if (lod <= 0)
			{
				lod = 1;
			}
			MarchingCubesJob jobData = new MarchingCubesJob(mCEdgeTable, mCTriTable, mCCorners, vertexCounter.ToConcurrent(), voxels, normals, alphamaps, mcOut, float5, uVScale, chunk.WorldPosition, lod, chunk.AlphamapArrayOrigin, alphamapsSize, chunk.AlphamapArraySize, chunk.Digger.MaterialType);
			jobData.SizeVox = chunk.SizeVox;
			jobData.SizeVox2 = chunk.SizeVox * chunk.SizeVox;
			jobData.Isovalue = 0f;
			jobData.AlteredOnly = 1;
			jobData.FullOutput = 1;
			jobData.IsBuiltInHDRP = ((chunk.Digger.MaterialType == TerrainMaterialType.HDRP) ? ((byte)1) : ((byte)0));
			jobData.IsLowPolyStyle = isLowPolyStyle;
			return IJobParallelForExtensions.Schedule(jobData, voxels.Length, 4);
		}

		public bool CompleteBuildMesh(Mesh mesh, Bounds bounds)
		{
			int count = vertexCounter.Count;
			mcOut.vertexCount = count;
			mcOut.triangleCount = count;
			bool result = mcOut.TransferVertexData(mesh, bounds);
			voxels.Dispose();
			normals.Dispose();
			alphamaps.Dispose();
			vertexCounter.Dispose();
			mcOut.Dispose();
			return result;
		}
	}
}
