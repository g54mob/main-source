using Pathfinding.Jobs;
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
				int2 xz = bounds.min.xz;
				int2 int5 = math.clamp((int2)math.round((new float2(dataX, dataZ) + xz) * scale), int2.zero, colorDataSize - new int2(1, 1));
				int index = int5.y * colorDataSize.x + int5.x;
				float y = math.dot(y: new int4(colorData[index] & 0xFF, (colorData[index] >> 8) & 0xFF, (colorData[index] >> 16) & 0xFF, (colorData[index] >> 24) & 0xFF), x: channelPositionScale);
				nodePositions[dataIndex] = graphToWorld.MultiplyPoint3x4(new Vector3((float)(bounds.min.x + dataX) + 0.5f, y, (float)(bounds.min.z + dataZ) + 0.5f));
			}

			public void Execute()
			{
				GridIterationUtilities.ForEachNode(bounds.size, nodeNormals, ref this);
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
				int2 xz = bounds.min.xz;
				int2 int5 = math.clamp((int2)math.round((new float2(dataX, dataZ) + xz) * scale), int2.zero, colorDataSize - new int2(1, 1));
				int index = int5.y * colorDataSize.x + int5.x;
				int4 int6 = new int4(colorData[index] & 0xFF, (colorData[index] >> 8) & 0xFF, (colorData[index] >> 16) & 0xFF, (colorData[index] >> 24) & 0xFF);
				penalty[dataIndex] += (uint)math.dot(channelPenalties, int6);
				walkable[dataIndex] &= !math.any(channelDeterminesWalkability & (int6 == 0));
			}

			public void Execute()
			{
				GridIterationUtilities.ForEachNode(bounds.size, nodeNormals, ref this);
			}
		}

		public Texture2D texture;

		public ChannelUse[] channels = new ChannelUse[4];

		public float[] channelScales = new float[4] { 1000f, 1000f, 1000f, 1000f };

		public ScalingMode scalingMode = ScalingMode.StretchToFitGraph;

		public float nodesPerPixel = 1f;

		private NativeArray<int> colors;

		public override int Hash => base.Hash ^ (int)((texture != null) ? texture.updateCount : 0);

		public override void Register(GridGraphRules rules)
		{
			if (texture == null)
			{
				return;
			}
			if (!texture.isReadable)
			{
				Debug.LogError("Texture for the texture rule on a grid graph is not marked as readable.", texture);
				return;
			}
			if (colors.IsCreated)
			{
				colors.Dispose();
			}
			colors = new NativeArray<Color32>(texture.GetPixels32(), Allocator.Persistent).Reinterpret<int>();
			int2 textureSize = new int2(texture.width, texture.height);
			float4 channelPenaltiesCombined = float4.zero;
			bool4 channelDeterminesWalkability = false;
			float4 channelPositionScalesCombined = float4.zero;
			for (int i = 0; i < 4; i++)
			{
				channelPenaltiesCombined[i] = ((channels[i] == ChannelUse.Penalty || channels[i] == ChannelUse.WalkablePenalty) ? channelScales[i] : 0f);
				channelDeterminesWalkability[i] = channels[i] == ChannelUse.Walkable || channels[i] == ChannelUse.WalkablePenalty;
				channelPositionScalesCombined[i] = ((channels[i] == ChannelUse.Position) ? channelScales[i] : 0f);
			}
			channelPositionScalesCombined /= 255f;
			channelPenaltiesCombined /= 255f;
			if (math.any(channelPositionScalesCombined))
			{
				rules.AddJobSystemPass(Pass.BeforeCollision, delegate(GridGraphRules.Context context)
				{
					new JobTexturePosition
					{
						colorData = colors,
						nodePositions = context.data.nodes.positions,
						nodeNormals = context.data.nodes.normals,
						bounds = context.data.nodes.bounds,
						colorDataSize = textureSize,
						scale = ((scalingMode == ScalingMode.FixedScale) ? ((float2)(1f / math.max(0.01f, nodesPerPixel))) : (textureSize / new float2(context.graph.width, context.graph.depth))),
						channelPositionScale = channelPositionScalesCombined,
						graphToWorld = context.data.transform.matrix
					}.Schedule(context.tracker);
				});
			}
			rules.AddJobSystemPass(Pass.BeforeConnections, delegate(GridGraphRules.Context context)
			{
				new JobTexturePenalty
				{
					colorData = colors,
					penalty = context.data.nodes.penalties,
					walkable = context.data.nodes.walkable,
					nodeNormals = context.data.nodes.normals,
					bounds = context.data.nodes.bounds,
					colorDataSize = textureSize,
					scale = ((scalingMode == ScalingMode.FixedScale) ? ((float2)(1f / math.max(0.01f, nodesPerPixel))) : (textureSize / new float2(context.graph.width, context.graph.depth))),
					channelPenalties = channelPenaltiesCombined,
					channelDeterminesWalkability = channelDeterminesWalkability
				}.Schedule(context.tracker);
			});
		}

		public override void DisposeUnmanagedData()
		{
			if (colors.IsCreated)
			{
				colors.Dispose();
			}
		}
	}
}
