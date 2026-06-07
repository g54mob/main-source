using Pathfinding.Sync;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	[BurstCompile(FloatMode = FloatMode.Default)]
	public struct JobBuildTileMeshFromVertices : IJob
	{
		[BurstCompile(FloatMode = FloatMode.Fast)]
		public struct JobTransformTileCoordinates : IJob
		{
			public NativeArray<Vector3> vertices;

			public NativeArray<Int3> outputVertices;

			public Matrix4x4 matrix;

			public void Execute()
			{
			}
		}

		public NativeArray<Vector3> vertices;

		public NativeArray<int> indices;

		public Matrix4x4 meshToGraph;

		public NativeArray<TileMesh.TileMeshUnsafe> outputBuffers;

		public bool recalculateNormals;

		public static Promise<TileBuilder.TileBuilderOutput> Schedule(NativeArray<Vector3> vertices, NativeArray<int> indices, Matrix4x4 meshToGraph, bool recalculateNormals)
		{
			return default(Promise<TileBuilder.TileBuilderOutput>);
		}

		public void Execute()
		{
		}
	}
}
