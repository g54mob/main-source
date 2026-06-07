using System;
using System.Collections.Generic;
using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Grid
{
	public struct GridGraphScanData
	{
		public JobDependencyTracker dependencyTracker;

		public Vector3 up;

		public GraphTransform transform;

		public GridGraphNodeData nodes;

		public NativeArray<RaycastHit> heightHits;

		public IntBounds heightHitsBounds;

		[Obsolete("Use nodes.bounds or heightHitsBounds depending on if you are using the heightHits array or not")]
		public IntBounds bounds => default(IntBounds);

		[Obsolete("Use nodes.layeredDataLayout instead")]
		public bool layeredDataLayout => false;

		[Obsolete("Use nodes.positions instead")]
		public NativeArray<Vector3> nodePositions => default(NativeArray<Vector3>);

		[Obsolete("Use nodes.connections instead")]
		public NativeArray<ulong> nodeConnections => default(NativeArray<ulong>);

		[Obsolete("Use nodes.penalties instead")]
		public NativeArray<uint> nodePenalties => default(NativeArray<uint>);

		[Obsolete("Use nodes.tags instead")]
		public NativeArray<int> nodeTags => default(NativeArray<int>);

		[Obsolete("Use nodes.normals instead")]
		public NativeArray<float4> nodeNormals => default(NativeArray<float4>);

		[Obsolete("Use nodes.walkable instead")]
		public NativeArray<bool> nodeWalkable => default(NativeArray<bool>);

		[Obsolete("Use nodes.walkableWithErosion instead")]
		public NativeArray<bool> nodeWalkableWithErosion => default(NativeArray<bool>);

		public void SetDefaultPenalties(uint initialPenalty)
		{
		}

		public void SetDefaultNodePositions(GraphTransform transform)
		{
		}

		public JobHandle HeightCheck(GraphCollision collision, int maxHits, IntBounds recalculationBounds, NativeArray<int> outLayerCount, float characterHeight, Allocator allocator)
		{
			return default(JobHandle);
		}

		public void CopyHits(IntBounds recalculationBounds)
		{
		}

		public void CalculateWalkabilityFromHeightData(bool useRaycastNormal, bool unwalkableWhenNoGround, float maxSlope, float characterHeight)
		{
		}

		public IEnumerator<JobHandle> CollisionCheck(GraphCollision collision, IntBounds calculationBounds)
		{
			return null;
		}

		public void Connections(float maxStepHeight, bool maxStepUsesSlope, IntBounds calculationBounds, NumNeighbours neighbours, bool cutCorners, bool use2D, bool useErodedWalkability, float characterHeight)
		{
		}

		public void Erosion(NumNeighbours neighbours, int erodeIterations, IntBounds erosionWriteMask, bool erosionUsesTags, int erosionStartTag, int erosionTagsPrecedenceMask)
		{
		}

		public void AssignNodeConnections(GridNodeBase[] nodes, int3 nodeArrayBounds, IntBounds writeBounds)
		{
		}
	}
}
