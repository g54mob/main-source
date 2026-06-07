using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Rules
{
	[Preserve]
	public class RuleTexture : GridGraphRule
	{
		public enum ScalingMode
		{
			FixedScale = 0,
			StretchToFitGraph = 1
		}

		public enum ChannelUse
		{
			None = 0,
			Penalty = 1,
			Position = 2,
			WalkablePenalty = 3,
			Walkable = 4
		}

		[BurstCompile]
		public struct JobTexturePosition : IJob, GridIterationUtilities.INodeModifier
		{
			[ReadOnly]
			public NativeArray<int> colorData;

			[WriteOnly]
			public NativeArray<Vector3> nodePositions;

			[ReadOnly]
			public NativeArray<float4> nodeNormals;

			public Matrix4x4 graphToWorld;

			public IntBounds bounds;

			public int2 colorDataSize;

			public float2 scale;

			public float4 channelPositionScale;

			public void ModifyNode(int dataIndex, int dataX, int dataLayer, int dataZ)
			{
			}

			public void Execute()
			{
			}
		}

		[BurstCompile]
		public struct JobTexturePenalty : IJob, GridIterationUtilities.INodeModifier
		{
			[ReadOnly]
			public NativeArray<int> colorData;

			public NativeArray<uint> penalty;

			public NativeArray<bool> walkable;

			[ReadOnly]
			public NativeArray<float4> nodeNormals;

			public IntBounds bounds;

			public int2 colorDataSize;

			public float2 scale;

			public float4 channelPenalties;

			public bool4 channelDeterminesWalkability;

			public void ModifyNode(int dataIndex, int dataX, int dataLayer, int dataZ)
			{
			}

			public void Execute()
			{
			}
		}

		public Texture2D texture;

		public ChannelUse[] channels;

		public float[] channelScales;

		public ScalingMode scalingMode;

		public float nodesPerPixel;

		private NativeArray<int> colors;

		public override int Hash => 0;

		public override void Register(GridGraphRules rules)
		{
		}

		public override void DisposeUnmanagedData()
		{
		}
	}
}
