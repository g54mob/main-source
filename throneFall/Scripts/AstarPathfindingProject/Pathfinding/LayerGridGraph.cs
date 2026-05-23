using System;
using Pathfinding.Serialization;
using Pathfinding.Util;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding
{
	[Preserve]
	public class LayerGridGraph : GridGraph, IUpdatableGraph
	{
		[JsonMember]
		internal int layerCount;

		[JsonMember]
		public float characterHeight = 0.4f;

		internal int lastScannedWidth;

		internal int lastScannedDepth;

		public override int LayerCount
		{
			get
			{
				return layerCount;
			}
			protected set
			{
				layerCount = value;
			}
		}

		public override int MaxLayers => 15;

		protected override void DisposeUnmanagedData()
		{
			base.DisposeUnmanagedData();
			LevelGridNode.ClearGridGraph((int)graphIndex, this);
		}

		public LayerGridGraph()
		{
			newGridNodeDelegate = () => new LevelGridNode();
		}

		protected override GridNodeBase[] AllocateNodesJob(int size, out JobHandle dependency)
		{
			LevelGridNode[] array = new LevelGridNode[size];
			AstarPath astarPath = active;
			GridNodeBase[] result = array;
			dependency = astarPath.AllocateNodes(result, size, newGridNodeDelegate, 1u);
			return array;
		}

		public override int CountNodes()
		{
			if (nodes == null)
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < nodes.Length; i++)
			{
				if (nodes[i] != null)
				{
					num++;
				}
			}
			return num;
		}

		public override void GetNodes(Action<GraphNode> action)
		{
			if (nodes == null)
			{
				return;
			}
			for (int i = 0; i < nodes.Length; i++)
			{
				if (nodes[i] != null)
				{
					action(nodes[i]);
				}
			}
		}

		public override int GetNodesInRegion(IntRect rect, GridNodeBase[] buffer)
		{
			rect = IntRect.Intersection(b: new IntRect(0, 0, width - 1, depth - 1), a: rect);
			if (nodes == null || !rect.IsValid() || nodes.Length != width * depth * layerCount)
			{
				return 0;
			}
			int num = 0;
			try
			{
				for (int i = 0; i < layerCount; i++)
				{
					int num2 = i * base.Width * base.Depth;
					for (int j = rect.ymin; j <= rect.ymax; j++)
					{
						int num3 = num2 + j * base.Width;
						for (int k = rect.xmin; k <= rect.xmax; k++)
						{
							GridNodeBase gridNodeBase = nodes[num3 + k];
							if (gridNodeBase != null)
							{
								buffer[num] = gridNodeBase;
								num++;
							}
						}
					}
				}
				return num;
			}
			catch (IndexOutOfRangeException)
			{
				throw new ArgumentException("Buffer is too small");
			}
		}

		public GridNodeBase GetNode(int x, int z, int layer)
		{
			if (x < 0 || z < 0 || x >= width || z >= depth || layer < 0 || layer >= layerCount)
			{
				return null;
			}
			return nodes[x + z * width + layer * width * depth];
		}

		protected override IGraphUpdatePromise ScanInternal(bool async)
		{
			LevelGridNode.SetGridGraph((int)graphIndex, this);
			layerCount = 0;
			lastScannedWidth = width;
			lastScannedDepth = depth;
			return base.ScanInternal(async);
		}

		protected override GridNodeBase GetNearestFromGraphSpace(Vector3 positionGraphSpace)
		{
			if (nodes == null || depth * width * layerCount != nodes.Length)
			{
				return null;
			}
			float x = positionGraphSpace.x;
			float z = positionGraphSpace.z;
			int x2 = Mathf.Clamp((int)x, 0, width - 1);
			int z2 = Mathf.Clamp((int)z, 0, depth - 1);
			Vector3 position = base.transform.Transform(positionGraphSpace);
			return GetNearestNode(position, x2, z2, null);
		}

		private GridNodeBase GetNearestNode(Vector3 position, int x, int z, NNConstraint constraint)
		{
			int num = width * z + x;
			float num2 = float.PositiveInfinity;
			GridNodeBase result = null;
			for (int i = 0; i < layerCount; i++)
			{
				GridNodeBase gridNodeBase = nodes[num + width * depth * i];
				if (gridNodeBase != null)
				{
					float sqrMagnitude = ((Vector3)gridNodeBase.position - position).sqrMagnitude;
					if (sqrMagnitude < num2 && (constraint == null || constraint.Suitable(gridNodeBase)))
					{
						num2 = sqrMagnitude;
						result = gridNodeBase;
					}
				}
			}
			return result;
		}

		protected override void SerializeExtraInfo(GraphSerializationContext ctx)
		{
			if (nodes == null)
			{
				ctx.writer.Write(-1);
				return;
			}
			ctx.writer.Write(nodes.Length);
			for (int i = 0; i < nodes.Length; i++)
			{
				if (nodes[i] == null)
				{
					ctx.writer.Write(-1);
					continue;
				}
				ctx.writer.Write(0);
				nodes[i].SerializeNode(ctx);
			}
			SerializeNodeSurfaceNormals(ctx);
		}

		protected override void DeserializeExtraInfo(GraphSerializationContext ctx)
		{
			int num = ctx.reader.ReadInt32();
			if (num == -1)
			{
				nodes = null;
				return;
			}
			GridNodeBase[] array = new LevelGridNode[num];
			nodes = array;
			for (int i = 0; i < nodes.Length; i++)
			{
				if (ctx.reader.ReadInt32() != -1)
				{
					nodes[i] = newGridNodeDelegate();
					active.InitializeNode(nodes[i]);
					nodes[i].DeserializeNode(ctx);
				}
				else
				{
					nodes[i] = null;
				}
			}
			DeserializeNativeData(ctx, ctx.meta.version >= AstarSerializer.V4_3_37);
		}

		protected override void PostDeserialization(GraphSerializationContext ctx)
		{
			UpdateTransform();
			lastScannedWidth = width;
			lastScannedDepth = depth;
			SetUpOffsetsAndCosts();
			LevelGridNode.SetGridGraph((int)graphIndex, this);
			if (nodes == null || nodes.Length == 0)
			{
				return;
			}
			if (width * depth * layerCount != nodes.Length)
			{
				Debug.LogError("Node data did not match with bounds data. Probably a change to the bounds/width/depth data was made after scanning the graph, just prior to saving it. Nodes will be discarded");
				nodes = new GridNodeBase[0];
				return;
			}
			for (int i = 0; i < layerCount; i++)
			{
				for (int j = 0; j < depth; j++)
				{
					for (int k = 0; k < width; k++)
					{
						if (nodes[j * width + k + width * depth * i] is LevelGridNode levelGridNode)
						{
							levelGridNode.NodeInGridIndex = j * width + k;
							levelGridNode.LayerCoordinateInGrid = i;
						}
					}
				}
			}
		}
	}
}
