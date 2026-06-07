using System;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
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
				for (int i = 0; i < vertices.Length; i++)
				{
					outputVertices[i] = (Int3)matrix.MultiplyPoint3x4(vertices[i]);
				}
			}
		}

		public struct BuildNavmeshOutput : IProgress, IDisposable
		{
			public NativeArray<TileMesh.TileMeshUnsafe> tiles;

			public float Progress => 0f;

			public void Dispose()
			{
				for (int i = 0; i < tiles.Length; i++)
				{
					tiles[i].Dispose();
				}
				tiles.Dispose();
			}
		}

		public NativeArray<Vector3> vertices;

		public NativeArray<int> indices;

		public Matrix4x4 meshToGraph;

		public NativeArray<TileMesh.TileMeshUnsafe> outputBuffers;

		public bool recalculateNormals;

		public static Promise<BuildNavmeshOutput> Schedule(NativeArray<Vector3> vertices, NativeArray<int> indices, Matrix4x4 meshToGraph, bool recalculateNormals)
		{
			if (vertices.Length > 4095)
			{
				throw new ArgumentException("Too many vertices in the navmesh graph. Provided " + vertices.Length + ", but the maximum number of vertices per tile is " + 4095 + ". You can raise this limit by enabling ASTAR_RECAST_LARGER_TILES in the A* Inspector Optimizations tab");
			}
			NativeArray<TileMesh.TileMeshUnsafe> tiles = new NativeArray<TileMesh.TileMeshUnsafe>(1, Allocator.Persistent);
			return new Promise<BuildNavmeshOutput>(IJobExtensions.Schedule(new JobBuildTileMeshFromVertices
			{
				vertices = vertices,
				indices = indices,
				meshToGraph = meshToGraph,
				outputBuffers = tiles,
				recalculateNormals = recalculateNormals
			}), new BuildNavmeshOutput
			{
				tiles = tiles
			});
		}

		public unsafe void Execute()
		{
			NativeArray<Int3> outputVertices = new NativeArray<Int3>(vertices.Length, Allocator.Temp);
			NativeArray<int> tags = new NativeArray<int>(indices.Length / 3, Allocator.Temp);
			JobTransformTileCoordinates jobTransformTileCoordinates = default(JobTransformTileCoordinates);
			jobTransformTileCoordinates.vertices = vertices;
			jobTransformTileCoordinates.outputVertices = outputVertices;
			jobTransformTileCoordinates.matrix = meshToGraph;
			jobTransformTileCoordinates.Execute();
			TileMesh.TileMeshUnsafe* unsafePtr = (TileMesh.TileMeshUnsafe*)outputBuffers.GetUnsafePtr();
			UnsafeAppendBuffer* ptr = &unsafePtr->verticesInTileSpace;
			UnsafeAppendBuffer* ptr2 = &unsafePtr->triangles;
			UnsafeAppendBuffer* ptr3 = &unsafePtr->tags;
			*ptr = new UnsafeAppendBuffer(0, 4, Allocator.Persistent);
			*ptr2 = new UnsafeAppendBuffer(0, 4, Allocator.Persistent);
			*ptr3 = new UnsafeAppendBuffer(0, 4, Allocator.Persistent);
			MeshUtility.JobRemoveDuplicateVertices jobRemoveDuplicateVertices = default(MeshUtility.JobRemoveDuplicateVertices);
			jobRemoveDuplicateVertices.vertices = outputVertices;
			jobRemoveDuplicateVertices.triangles = indices;
			jobRemoveDuplicateVertices.tags = tags;
			jobRemoveDuplicateVertices.outputVertices = ptr;
			jobRemoveDuplicateVertices.outputTriangles = ptr2;
			jobRemoveDuplicateVertices.outputTags = ptr3;
			jobRemoveDuplicateVertices.Execute();
			if (recalculateNormals)
			{
				UnsafeSpan<Int3> unsafeSpan = (*ptr).AsUnsafeSpan<Int3>();
				UnsafeSpan<int> triangles = (*ptr2).AsUnsafeSpan<int>();
				MeshUtility.MakeTrianglesClockwise(ref unsafeSpan, ref triangles);
			}
			outputVertices.Dispose();
		}
	}
}
