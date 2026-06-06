using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	public struct JobCreateTiles : IJob
	{
		[ReadOnly]
		[NativeDisableContainerSafetyRestriction]
		public NativeArray<TileMesh.TileMeshUnsafe> preCutTileMeshes;

		[ReadOnly]
		public NativeArray<TileMesh.TileMeshUnsafe> tileMeshes;

		public GCHandle tiles;

		public uint graphIndex;

		public Vector2Int graphTileCount;

		public IntRect tileRect;

		public uint initialPenalty;

		public bool recalculateNormals;

		public Vector2 tileWorldSize;

		public Matrix4x4 graphToWorldSpace;

		public void Execute()
		{
		}
	}
}
