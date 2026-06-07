using Pathfinding.Drawing;
using Pathfinding.ECS.RVO;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.RVO
{
	public struct RVOQuadtreeBurst
	{
		[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Fast)]
		public struct JobBuild : IJob
		{
			public NativeArray<int> agents;

			[ReadOnly]
			public NativeArray<float3> agentPositions;

			[ReadOnly]
			public NativeArray<AgentIndex> agentVersions;

			[ReadOnly]
			public NativeArray<float> agentSpeeds;

			[ReadOnly]
			public NativeArray<float> agentRadii;

			[WriteOnly]
			public NativeArray<float3> outBoundingBox;

			[WriteOnly]
			public NativeArray<int> outAgentCount;

			public NativeArray<int> outChildPointers;

			public NativeArray<float> outMaxSpeeds;

			public NativeArray<float> outMaxRadius;

			public NativeArray<float> outArea;

			[WriteOnly]
			public NativeArray<float3> outAgentPositions;

			[WriteOnly]
			public NativeArray<float> outAgentRadii;

			public int numAgents;

			public MovementPlane movementPlane;

			private static int Partition(NativeSlice<int> indices, int startIndex, int endIndex, NativeSlice<float> coordinates, float splitPoint)
			{
				return 0;
			}

			private void BuildNode(float3 boundsMin, float3 boundsMax, int depth, int agentsStart, int agentsEnd, int nodeOffset, ref int firstFreeChild)
			{
			}

			private void CalculateSpeeds(int nodeCount)
			{
			}

			public void Execute()
			{
			}
		}

		public struct QuadtreeQuery
		{
			public float3 position;

			public float speed;

			public float timeHorizon;

			public float agentRadius;

			public int outputStartIndex;

			public int maxCount;

			public RVOLayer layerMask;

			public NativeArray<RVOLayer> layers;

			public NativeArray<int> result;

			public NativeArray<float> resultDistances;
		}

		[BurstCompile]
		public struct DebugDrawJob : IJob
		{
			public CommandBuilder draw;

			[ReadOnly]
			public RVOQuadtreeBurst quadtree;

			public void Execute()
			{
			}
		}

		private const int LeafSize = 16;

		private const int MaxDepth = 10;

		private NativeArray<int> agents;

		private NativeArray<int> childPointers;

		private NativeArray<float3> boundingBoxBuffer;

		private NativeArray<int> agentCountBuffer;

		private NativeArray<float3> agentPositions;

		private NativeArray<float> agentRadii;

		private NativeArray<float> maxSpeeds;

		private NativeArray<float> maxRadius;

		private NativeArray<float> nodeAreas;

		private MovementPlane movementPlane;

		private const int LeafNodeBit = 1073741824;

		private const int BitPackingShift = 15;

		private const int BitPackingMask = 32767;

		private const int MaxAgents = 32767;

		private static readonly byte[] ChildLookup;

		private const float DistanceInfinity = 1E+30f;

		public Rect bounds => default(Rect);

		static RVOQuadtreeBurst()
		{
		}

		private static int InnerNodeCountUpperBound(int numAgents, MovementPlane movementPlane)
		{
			return 0;
		}

		public void Dispose()
		{
		}

		private void Reserve(int minSize)
		{
		}

		public JobBuild BuildJob(NativeArray<float3> agentPositions, NativeArray<AgentIndex> agentVersions, NativeArray<float> agentSpeeds, NativeArray<float> agentRadii, int numAgents, MovementPlane movementPlane)
		{
			return default(JobBuild);
		}

		public int QueryKNearest(QuadtreeQuery query)
		{
			return 0;
		}

		private void QueryRec(ref QuadtreeQuery query, int treeNodeIndex, float3 nodeMin, float3 nodeMax, ref float maxRadius)
		{
		}

		public float QueryArea(float3 position, float radius)
		{
			return 0f;
		}

		private float QueryAreaRec(int treeNodeIndex, float3 p, float radius, float3 nodeMin, float3 nodeMax)
		{
			return 0f;
		}

		public void DebugDraw(CommandBuilder draw)
		{
		}

		private void DebugDraw(int nodeIndex, float3 nodeMin, float3 nodeMax, CommandBuilder draw)
		{
		}
	}
}
