using System;
using System.Collections.Generic;
using System.Linq;
using Pathfinding.Drawing;
using Pathfinding.Graphs.Grid;
using Pathfinding.Graphs.Grid.Jobs;
using Pathfinding.Graphs.Grid.Rules;
using Pathfinding.Jobs;
using Pathfinding.Serialization;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	[JsonOptIn]
	[Preserve]
	public class GridGraph : NavGraph, IUpdatableGraph, ITransformedGraph, IRaycastableGraph
	{
		public class TextureData
		{
			public enum ChannelUse
			{
				None = 0,
				Penalty = 1,
				Position = 2,
				WalkablePenalty = 3
			}

			public bool enabled;

			public Texture2D source;

			public float[] factors = new float[3];

			public ChannelUse[] channels = new ChannelUse[3];

			private Color32[] data;

			public void Initialize()
			{
				if (!enabled || !(source != null))
				{
					return;
				}
				for (int i = 0; i < channels.Length; i++)
				{
					if (channels[i] != ChannelUse.None)
					{
						try
						{
							data = source.GetPixels32();
							break;
						}
						catch (UnityException ex)
						{
							Debug.LogWarning(ex.ToString());
							data = null;
							break;
						}
					}
				}
			}

			public void Apply(GridNode node, int x, int z)
			{
				if (enabled && data != null && x < source.width && z < source.height)
				{
					Color32 color = data[z * source.width + x];
					if (channels[0] != ChannelUse.None)
					{
						ApplyChannel(node, x, z, color.r, channels[0], factors[0]);
					}
					if (channels[1] != ChannelUse.None)
					{
						ApplyChannel(node, x, z, color.g, channels[1], factors[1]);
					}
					if (channels[2] != ChannelUse.None)
					{
						ApplyChannel(node, x, z, color.b, channels[2], factors[2]);
					}
					node.WalkableErosion = node.Walkable;
				}
			}

			private void ApplyChannel(GridNode node, int x, int z, int value, ChannelUse channelUse, float factor)
			{
				switch (channelUse)
				{
				case ChannelUse.Penalty:
					node.Penalty += (uint)Mathf.RoundToInt((float)value * factor);
					break;
				case ChannelUse.Position:
					node.position = GridNode.GetGridGraph(node.GraphIndex).GraphPointToWorld(x, z, value);
					break;
				case ChannelUse.WalkablePenalty:
					if (value == 0)
					{
						node.Walkable = false;
					}
					else
					{
						node.Penalty += (uint)Mathf.RoundToInt((float)(value - 1) * factor);
					}
					break;
				}
			}
		}

		public enum RecalculationMode
		{
			RecalculateFromScratch = 0,
			RecalculateMinimal = 1,
			NoRecalculation = 2
		}

		private class GridGraphMovePromise : IGraphUpdatePromise
		{
			public GridGraph graph;

			public int dx;

			public int dz;

			private IGraphUpdatePromise[] promises;

			private IntRect[] rects;

			private int3 startingSize;

			private static void DecomposeInsetsToRectangles(int width, int height, int insetLeft, int insetRight, int insetBottom, int insetTop, IntRect[] output)
			{
				output[0] = new IntRect(0, 0, insetLeft - 1, height - 1);
				output[1] = new IntRect(width - insetRight, 0, width - 1, height - 1);
				output[2] = new IntRect(insetLeft, 0, width - insetRight - 1, insetBottom - 1);
				output[3] = new IntRect(insetLeft, height - insetTop - 1, width - insetRight - 1, height - 1);
			}

			public GridGraphMovePromise(GridGraph graph, int dx, int dz)
			{
				this.graph = graph;
				this.dx = dx;
				this.dz = dz;
				GraphTransform transform = graph.transform * Matrix4x4.Translate(new Vector3(dx, 0f, dz));
				startingSize = new int3(graph.width, graph.LayerCount, graph.depth);
				if (math.abs(dx) > graph.width / 2 || math.abs(dz) > graph.depth / 2)
				{
					rects = new IntRect[1]
					{
						new IntRect(0, 0, graph.width - 1, graph.depth - 1)
					};
				}
				else
				{
					int insetLeft = math.max(1, -dx);
					int insetRight = math.max(1, dx);
					int insetBottom = math.max(1, -dz);
					int insetTop = math.max(1, dz);
					rects = new IntRect[4];
					DecomposeInsetsToRectangles(graph.width, graph.depth, insetLeft, insetRight, insetBottom, insetTop, rects);
				}
				IGraphUpdatePromise[] array = new GridGraphUpdatePromise[rects.Length];
				promises = array;
				GridGraphUpdatePromise.NodesHolder nodes = new GridGraphUpdatePromise.NodesHolder
				{
					nodes = graph.nodes
				};
				for (int i = 0; i < rects.Length; i++)
				{
					JobDependencyTracker dependencyTracker = ObjectPool<JobDependencyTracker>.Claim();
					promises[i] = new GridGraphUpdatePromise(graph, transform, nodes, startingSize, rects[i], dependencyTracker, default(JobHandle), Allocator.Persistent, RecalculationMode.RecalculateMinimal, null, ownsJobDependencyTracker: true, isFinalUpdate: false);
				}
			}

			public IEnumerator<JobHandle> Prepare()
			{
				yield return graph.nodeData.Rotate2D(-dx, -dz, default(JobHandle));
				for (int i = 0; i < promises.Length; i++)
				{
					IEnumerator<JobHandle> it = promises[i].Prepare();
					while (it.MoveNext())
					{
						yield return it.Current;
					}
				}
			}

			public void Apply(IGraphUpdateContext ctx)
			{
				graph.AssertSafeToUpdateGraph();
				GridNodeBase[] nodes = graph.nodes;
				if (!math.all(new int3(graph.width, graph.LayerCount, graph.depth) == startingSize))
				{
					throw new InvalidOperationException("The graph has been resized since the update was created. This is not allowed.");
				}
				if (nodes == null || nodes.Length != graph.width * graph.depth * graph.LayerCount)
				{
					throw new InvalidOperationException("The Grid Graph is not scanned, cannot recalculate connections.");
				}
				Memory.Rotate3DArray(nodes, startingSize, -dx, -dz);
				for (int i = 0; i < startingSize.y; i++)
				{
					int num = i * startingSize.x * startingSize.z;
					for (int j = 0; j < startingSize.z; j++)
					{
						int num2 = j * startingSize.x;
						for (int k = 0; k < startingSize.x; k++)
						{
							int num3 = num2 + k;
							GridNodeBase gridNodeBase = nodes[num + num3];
							if (gridNodeBase != null)
							{
								gridNodeBase.NodeInGridIndex = num3;
							}
						}
					}
				}
				int layerCount = graph.LayerCount;
				for (int l = 0; l < rects.Length; l++)
				{
					IntRect intRect = rects[l];
					for (int m = 0; m < layerCount; m++)
					{
						int num4 = m * graph.width * graph.depth;
						for (int n = intRect.ymin; n <= intRect.ymax; n++)
						{
							int num5 = n * graph.width + num4;
							for (int num6 = intRect.xmin; num6 <= intRect.xmax; num6++)
							{
								nodes[num5 + num6]?.ClearCustomConnections(alsoReverse: true);
							}
						}
					}
				}
				for (int num7 = 0; num7 < promises.Length; num7++)
				{
					promises[num7].Apply(ctx);
				}
				graph.center += graph.transform.TransformVector(new Vector3(dx, 0f, dz));
				graph.UpdateTransform();
				if (promises.Length != 0)
				{
					graph.rules.ExecuteRuleMainThread(GridGraphRule.Pass.AfterApplied, (promises[0] as GridGraphUpdatePromise).context);
				}
			}
		}

		private class GridGraphUpdatePromise : IGraphUpdatePromise
		{
			public class NodesHolder
			{
				public GridNodeBase[] nodes;
			}

			public GridGraph graph;

			public NodesHolder nodes;

			public JobDependencyTracker dependencyTracker;

			public int3 nodeArrayBounds;

			public IntRect rect;

			public JobHandle nodesDependsOn;

			public Allocator allocationMethod;

			public RecalculationMode recalculationMode;

			public GraphUpdateObject graphUpdateObject;

			private IntBounds writeMaskBounds;

			internal GridGraphRules.Context context;

			private bool emptyUpdate;

			private IntBounds readBounds;

			private IntBounds fullRecalculationBounds;

			public bool ownsJobDependencyTracker;

			private bool isFinalUpdate;

			private GraphTransform transform;

			public int CostEstimate => fullRecalculationBounds.volume;

			public GridGraphUpdatePromise(GridGraph graph, GraphTransform transform, NodesHolder nodes, int3 nodeArrayBounds, IntRect rect, JobDependencyTracker dependencyTracker, JobHandle nodesDependsOn, Allocator allocationMethod, RecalculationMode recalculationMode, GraphUpdateObject graphUpdateObject, bool ownsJobDependencyTracker, bool isFinalUpdate)
			{
				this.graph = graph;
				this.transform = transform;
				this.nodes = nodes;
				this.nodeArrayBounds = nodeArrayBounds;
				this.dependencyTracker = dependencyTracker;
				this.nodesDependsOn = nodesDependsOn;
				this.allocationMethod = allocationMethod;
				this.recalculationMode = recalculationMode;
				this.graphUpdateObject = graphUpdateObject;
				this.ownsJobDependencyTracker = ownsJobDependencyTracker;
				this.isFinalUpdate = isFinalUpdate;
				CalculateRectangles(graph, rect, out this.rect, out var fullRecalculationRect, out var writeMaskRect, out var readRect);
				if (recalculationMode == RecalculationMode.RecalculateFromScratch)
				{
					fullRecalculationRect = readRect;
				}
				if (!fullRecalculationRect.IsValid())
				{
					emptyUpdate = true;
				}
				readBounds = new IntBounds(readRect.xmin, 0, readRect.ymin, readRect.xmax + 1, nodeArrayBounds.y, readRect.ymax + 1);
				fullRecalculationBounds = new IntBounds(fullRecalculationRect.xmin, 0, fullRecalculationRect.ymin, fullRecalculationRect.xmax + 1, nodeArrayBounds.y, fullRecalculationRect.ymax + 1);
				writeMaskBounds = new IntBounds(writeMaskRect.xmin, 0, writeMaskRect.ymin, writeMaskRect.xmax + 1, nodeArrayBounds.y, writeMaskRect.ymax + 1);
				if (ownsJobDependencyTracker)
				{
					dependencyTracker.SetLinearDependencies(CostEstimate < 500);
				}
			}

			public static void CalculateRectangles(GridGraph graph, IntRect rect, out IntRect originalRect, out IntRect fullRecalculationRect, out IntRect writeMaskRect, out IntRect readRect)
			{
				fullRecalculationRect = rect;
				GraphCollision collision = graph.collision;
				if (collision.collisionCheck && collision.type != ColliderType.Ray)
				{
					fullRecalculationRect = fullRecalculationRect.Expand(Mathf.FloorToInt(collision.diameter * 0.5f + 0.5f));
				}
				writeMaskRect = fullRecalculationRect.Expand(graph.erodeIterations + 1);
				readRect = writeMaskRect.Expand(graph.erodeIterations + 1);
				IntRect b = new IntRect(0, 0, graph.width - 1, graph.depth - 1);
				readRect = IntRect.Intersection(readRect, b);
				fullRecalculationRect = IntRect.Intersection(fullRecalculationRect, b);
				writeMaskRect = IntRect.Intersection(writeMaskRect, b);
				originalRect = IntRect.Intersection(rect, b);
			}

			public IEnumerator<JobHandle> Prepare()
			{
				if (emptyUpdate)
				{
					yield break;
				}
				GraphCollision collision = graph.collision;
				GridGraphRules rules = graph.rules;
				if (recalculationMode != RecalculationMode.RecalculateFromScratch)
				{
					writeMaskBounds.max.y = (fullRecalculationBounds.max.y = (readBounds.max.y = graph.nodeData.bounds.max.y));
				}
				int minLayers = ((recalculationMode == RecalculationMode.RecalculateFromScratch) ? 1 : fullRecalculationBounds.max.y);
				if (recalculationMode == RecalculationMode.RecalculateMinimal && readBounds == fullRecalculationBounds)
				{
					recalculationMode = RecalculationMode.RecalculateFromScratch;
				}
				bool layeredDataLayout = graph is LayerGridGraph;
				float characterHeight = ((graph is LayerGridGraph layerGridGraph) ? layerGridGraph.characterHeight : float.PositiveInfinity);
				context = new GridGraphRules.Context
				{
					graph = graph,
					data = new GridGraphScanData
					{
						dependencyTracker = dependencyTracker,
						transform = transform,
						up = transform.TransformVector(Vector3.up).normalized
					}
				};
				IEnumerator<JobHandle> wait;
				if (recalculationMode == RecalculationMode.RecalculateFromScratch || recalculationMode == RecalculationMode.RecalculateMinimal)
				{
					if (collision.heightCheck && !collision.use2D)
					{
						NativeArray<int> layerCount = dependencyTracker.NewNativeArray<int>(1, allocationMethod, NativeArrayOptions.UninitializedMemory);
						yield return context.data.HeightCheck(collision, graph.MaxLayers, fullRecalculationBounds, layerCount, characterHeight, allocationMethod);
						int y = Mathf.Max(minLayers, layerCount[0]);
						readBounds.max.y = (fullRecalculationBounds.max.y = (writeMaskBounds.max.y = y));
						context.data.heightHitsBounds.max.y = layerCount[0];
						context.data.nodes = new GridGraphNodeData
						{
							bounds = fullRecalculationBounds,
							numNodes = fullRecalculationBounds.volume,
							layeredDataLayout = layeredDataLayout,
							allocationMethod = allocationMethod
						};
						context.data.nodes.AllocateBuffers(dependencyTracker);
						context.data.SetDefaultNodePositions(transform);
						context.data.CopyHits(context.data.heightHitsBounds);
						context.data.CalculateWalkabilityFromHeightData(graph.useRaycastNormal, collision.unwalkableWhenNoGround, graph.maxSlope, characterHeight);
					}
					else
					{
						context.data.nodes = new GridGraphNodeData
						{
							bounds = fullRecalculationBounds,
							numNodes = fullRecalculationBounds.volume,
							layeredDataLayout = layeredDataLayout,
							allocationMethod = allocationMethod
						};
						context.data.nodes.AllocateBuffers(dependencyTracker);
						context.data.SetDefaultNodePositions(transform);
						context.data.nodes.walkable.MemSet(value: true).Schedule(dependencyTracker);
						context.data.nodes.normals.MemSet(new float4(context.data.up.x, context.data.up.y, context.data.up.z, 0f)).Schedule(dependencyTracker);
					}
					context.data.SetDefaultPenalties(graph.initialPenalty);
					JobHandle.ScheduleBatchedJobs();
					rules.RebuildIfNecessary();
					wait = rules.ExecuteRule(GridGraphRule.Pass.BeforeCollision, context);
					while (wait.MoveNext())
					{
						yield return wait.Current;
					}
					if (collision.collisionCheck)
					{
						context.tracker.timeSlice = TimeSlice.MillisFromNow(1f);
						wait = context.data.CollisionCheck(collision, fullRecalculationBounds);
						while (wait != null && wait.MoveNext())
						{
							yield return wait.Current;
							context.tracker.timeSlice = TimeSlice.MillisFromNow(2f);
						}
					}
					wait = rules.ExecuteRule(GridGraphRule.Pass.BeforeConnections, context);
					while (wait.MoveNext())
					{
						yield return wait.Current;
					}
					if (recalculationMode == RecalculationMode.RecalculateMinimal)
					{
						GridGraphNodeData gridGraphNodeData = new GridGraphNodeData
						{
							bounds = readBounds,
							numNodes = readBounds.volume,
							layeredDataLayout = layeredDataLayout,
							allocationMethod = allocationMethod
						};
						gridGraphNodeData.AllocateBuffers(dependencyTracker);
						gridGraphNodeData.normals.MemSet(float4.zero).Schedule(dependencyTracker);
						gridGraphNodeData.walkable.MemSet(value: false).Schedule(dependencyTracker);
						gridGraphNodeData.walkableWithErosion.MemSet(value: false).Schedule(dependencyTracker);
						gridGraphNodeData.CopyFrom(graph.nodeData, copyPenaltyAndTags: true, dependencyTracker);
						gridGraphNodeData.CopyFrom(context.data.nodes, graphUpdateObject == null || graphUpdateObject.resetPenaltyOnPhysics, dependencyTracker);
						context.data.nodes = gridGraphNodeData;
					}
				}
				else
				{
					context.data.nodes = new GridGraphNodeData
					{
						bounds = readBounds,
						numNodes = readBounds.volume,
						layeredDataLayout = layeredDataLayout,
						allocationMethod = allocationMethod
					};
					context.data.nodes.AllocateBuffers(dependencyTracker);
					context.data.nodes.CopyFrom(graph.nodeData, copyPenaltyAndTags: true, dependencyTracker);
				}
				if (graphUpdateObject != null)
				{
					if (graphUpdateObject.GetType() != typeof(GraphUpdateObject))
					{
						GridNodeBase[] array = nodes.nodes;
						for (int i = writeMaskBounds.min.y; i < writeMaskBounds.max.y; i++)
						{
							for (int j = writeMaskBounds.min.z; j < writeMaskBounds.max.z; j++)
							{
								int num = i * nodeArrayBounds.x * nodeArrayBounds.z + j * nodeArrayBounds.x;
								for (int k = writeMaskBounds.min.x; k < writeMaskBounds.max.x; k++)
								{
									graphUpdateObject.WillUpdateNode(array[num + k]);
								}
							}
						}
					}
					IntRect intRect = rect;
					if (intRect.IsValid())
					{
						IntBounds intBounds = new IntBounds(intRect.xmin, 0, intRect.ymin, intRect.xmax + 1, context.data.nodes.layers, intRect.ymax + 1).Offset(-context.data.nodes.bounds.min);
						NativeArray<int> nodeIndices = dependencyTracker.NewNativeArray<int>(intBounds.volume, context.data.nodes.allocationMethod);
						int num2 = 0;
						int3 size = context.data.nodes.bounds.size;
						for (int l = intBounds.min.y; l < intBounds.max.y; l++)
						{
							for (int m = intBounds.min.z; m < intBounds.max.z; m++)
							{
								int num3 = l * size.x * size.z + m * size.x;
								for (int n = intBounds.min.x; n < intBounds.max.x; n++)
								{
									nodeIndices[num2++] = num3 + n;
								}
							}
						}
						graphUpdateObject.ApplyJob(new GraphUpdateObject.GraphUpdateData
						{
							nodePositions = context.data.nodes.positions,
							nodePenalties = context.data.nodes.penalties,
							nodeWalkable = context.data.nodes.walkable,
							nodeTags = context.data.nodes.tags,
							nodeIndices = nodeIndices
						}, dependencyTracker);
					}
				}
				context.data.Connections(graph.maxStepHeight, graph.maxStepUsesSlope, context.data.nodes.bounds, graph.neighbours, graph.cutCorners, collision.use2D, useErodedWalkability: false, characterHeight);
				wait = rules.ExecuteRule(GridGraphRule.Pass.AfterConnections, context);
				while (wait.MoveNext())
				{
					yield return wait.Current;
				}
				if (graph.erodeIterations > 0)
				{
					context.data.Erosion(graph.neighbours, graph.erodeIterations, writeMaskBounds, graph.erosionUseTags, graph.erosionFirstTag, graph.erosionTagsPrecedenceMask);
					wait = rules.ExecuteRule(GridGraphRule.Pass.AfterErosion, context);
					while (wait.MoveNext())
					{
						yield return wait.Current;
					}
					context.data.Connections(graph.maxStepHeight, graph.maxStepUsesSlope, context.data.nodes.bounds, graph.neighbours, graph.cutCorners, collision.use2D, useErodedWalkability: true, characterHeight);
					wait = rules.ExecuteRule(GridGraphRule.Pass.AfterConnections, context);
					while (wait.MoveNext())
					{
						yield return wait.Current;
					}
				}
				else
				{
					context.data.nodes.walkable.CopyToJob(context.data.nodes.walkableWithErosion).Schedule(dependencyTracker);
				}
				wait = rules.ExecuteRule(GridGraphRule.Pass.PostProcess, context);
				while (wait.MoveNext())
				{
					yield return wait.Current;
				}
				graph.nodeData.TrackBuffers(dependencyTracker);
				if (recalculationMode == RecalculationMode.RecalculateFromScratch)
				{
					graph.nodeData = context.data.nodes;
				}
				else
				{
					graph.nodeData.ResizeLayerCount(context.data.nodes.layers, dependencyTracker);
					graph.nodeData.CopyFrom(context.data.nodes, writeMaskBounds, copyPenaltyAndTags: true, dependencyTracker);
				}
				graph.nodeData.PersistBuffers(dependencyTracker);
				yield return nodesDependsOn;
				yield return dependencyTracker.AllWritesDependency;
				dependencyTracker.ClearMemory();
			}

			public void Apply(IGraphUpdateContext ctx)
			{
				graph.AssertSafeToUpdateGraph();
				if (emptyUpdate)
				{
					Dispose();
					if (isFinalUpdate)
					{
						graph.rules.ExecuteRuleMainThread(GridGraphRule.Pass.AfterApplied, context ?? new GridGraphRules.Context
						{
							graph = graph
						});
					}
					return;
				}
				bool flag = nodes.nodes != graph.nodes;
				if (context.data.nodes.layers > 1)
				{
					nodeArrayBounds.y = context.data.nodes.layers;
					int newSize = nodeArrayBounds.x * nodeArrayBounds.y * nodeArrayBounds.z;
					Memory.Realloc(ref nodes.nodes, newSize);
					JobAllocateNodes jobAllocateNodes = default(JobAllocateNodes);
					jobAllocateNodes.active = graph.active;
					jobAllocateNodes.nodeNormals = graph.nodeData.normals;
					jobAllocateNodes.dataBounds = context.data.nodes.bounds;
					jobAllocateNodes.nodeArrayBounds = nodeArrayBounds;
					jobAllocateNodes.nodes = nodes.nodes;
					jobAllocateNodes.newGridNodeDelegate = graph.newGridNodeDelegate;
					jobAllocateNodes.Execute();
				}
				graph.nodeData.AssignToNodes(nodes.nodes, nodeArrayBounds, writeMaskBounds, graph.graphIndex, default(JobHandle), dependencyTracker).Complete();
				if (nodes.nodes != graph.nodes)
				{
					if (flag)
					{
						graph.DestroyAllNodes();
					}
					graph.nodes = nodes.nodes;
					graph.LayerCount = context.data.nodes.layers;
				}
				ctx.DirtyBounds(graph.GetBoundsFromRect(new IntRect(writeMaskBounds.min.x, writeMaskBounds.min.z, writeMaskBounds.max.x - 1, writeMaskBounds.max.z - 1)));
				Dispose();
				if (isFinalUpdate)
				{
					graph.rules.ExecuteRuleMainThread(GridGraphRule.Pass.AfterApplied, context);
				}
			}

			public void Dispose()
			{
				if (ownsJobDependencyTracker)
				{
					ObjectPool<JobDependencyTracker>.Release(ref dependencyTracker);
					if (context != null)
					{
						context.data.dependencyTracker = null;
					}
				}
			}
		}

		private class CombinedGridGraphUpdatePromise : IGraphUpdatePromise
		{
			private List<IGraphUpdatePromise> promises;

			public CombinedGridGraphUpdatePromise(GridGraph graph, List<GraphUpdateObject> graphUpdates)
			{
				promises = ListPool<IGraphUpdatePromise>.Claim();
				GridGraphUpdatePromise.NodesHolder nodes = new GridGraphUpdatePromise.NodesHolder
				{
					nodes = graph.nodes
				};
				for (int i = 0; i < graphUpdates.Count; i++)
				{
					GraphUpdateObject graphUpdateObject = graphUpdates[i];
					GridGraphUpdatePromise item = new GridGraphUpdatePromise(graph, graph.transform, nodes, new int3(graph.width, graph.LayerCount, graph.depth), graph.GetRectFromBounds(graphUpdateObject.bounds), ObjectPool<JobDependencyTracker>.Claim(), default(JobHandle), Allocator.Persistent, graphUpdateObject.updatePhysics ? RecalculationMode.RecalculateMinimal : RecalculationMode.NoRecalculation, graphUpdateObject, ownsJobDependencyTracker: true, i == graphUpdates.Count - 1);
					promises.Add(item);
				}
			}

			public IEnumerator<JobHandle> Prepare()
			{
				for (int i = 0; i < promises.Count; i++)
				{
					IEnumerator<JobHandle> it = promises[i].Prepare();
					while (it.MoveNext())
					{
						yield return it.Current;
					}
				}
			}

			public void Apply(IGraphUpdateContext ctx)
			{
				for (int i = 0; i < promises.Count; i++)
				{
					promises[i].Apply(ctx);
				}
				ListPool<IGraphUpdatePromise>.Release(ref promises);
			}
		}

		private class GridGraphSnapshot : IGraphSnapshot, IDisposable
		{
			internal GridGraphNodeData nodes;

			internal GridGraph graph;

			public void Dispose()
			{
				nodes.Dispose();
			}

			public void Restore(IGraphUpdateContext ctx)
			{
				graph.AssertSafeToUpdateGraph();
				if (graph.isScanned)
				{
					if (!graph.nodeData.bounds.Contains(nodes.bounds))
					{
						Debug.LogError("Cannot restore snapshot because the graph dimensions have changed since the snapshot was taken");
						return;
					}
					JobDependencyTracker obj = ObjectPool<JobDependencyTracker>.Claim();
					graph.nodeData.CopyFrom(nodes, copyPenaltyAndTags: true, obj);
					nodes.AssignToNodes(graph.nodes, graph.nodeData.bounds.size, nodes.bounds, graph.graphIndex, default(JobHandle), obj).Complete();
					obj.AllWritesDependency.Complete();
					ObjectPool<JobDependencyTracker>.Release(ref obj);
					ctx.DirtyBounds(graph.GetBoundsFromRect(new IntRect(nodes.bounds.min.x, nodes.bounds.min.z, nodes.bounds.max.x - 1, nodes.bounds.max.z - 1)));
				}
			}
		}

		[JsonMember]
		public InspectorGridMode inspectorGridMode;

		[JsonMember]
		public InspectorGridHexagonNodeSize inspectorHexagonSizeMode;

		public int width;

		public int depth;

		[JsonMember]
		public float aspectRatio = 1f;

		[JsonMember]
		public float isometricAngle;

		public static readonly float StandardIsometricAngle = 90f - Mathf.Atan(1f / Mathf.Sqrt(2f)) * 57.29578f;

		public static readonly float StandardDimetricAngle = Mathf.Acos(0.5f) * 57.29578f;

		[JsonMember]
		public bool uniformEdgeCosts;

		[JsonMember]
		public Vector3 rotation;

		[JsonMember]
		public Vector3 center;

		[JsonMember]
		public Vector2 unclampedSize = new Vector2(10f, 10f);

		[JsonMember]
		public float nodeSize = 1f;

		[JsonMember]
		public GraphCollision collision = new GraphCollision();

		[JsonMember]
		public float maxStepHeight = 0.4f;

		[JsonMember]
		public bool maxStepUsesSlope = true;

		[JsonMember]
		public float maxSlope = 90f;

		[JsonMember]
		public int erodeIterations;

		[JsonMember]
		public bool erosionUseTags;

		[JsonMember]
		public int erosionFirstTag = 1;

		[JsonMember]
		public int erosionTagsPrecedenceMask = -1;

		[JsonMember]
		public NumNeighbours neighbours = NumNeighbours.Eight;

		[JsonMember]
		public bool cutCorners = true;

		[JsonMember]
		[Obsolete("Use the RuleElevationPenalty class instead")]
		public float penaltyPositionOffset;

		[JsonMember]
		[Obsolete("Use the RuleElevationPenalty class instead")]
		public bool penaltyPosition;

		[JsonMember]
		[Obsolete("Use the RuleElevationPenalty class instead")]
		public float penaltyPositionFactor = 1f;

		[JsonMember]
		[Obsolete("Use the RuleAnglePenalty class instead")]
		public bool penaltyAngle;

		[JsonMember]
		[Obsolete("Use the RuleAnglePenalty class instead")]
		public float penaltyAngleFactor = 100f;

		[JsonMember]
		[Obsolete("Use the RuleAnglePenalty class instead")]
		public float penaltyAnglePower = 1f;

		[JsonMember]
		public GridGraphRules rules = new GridGraphRules();

		[JsonMember]
		public bool showMeshOutline = true;

		[JsonMember]
		public bool showNodeConnections;

		[JsonMember]
		public bool showMeshSurface = true;

		[JsonMember]
		[Obsolete("Use the RuleTexture class instead")]
		public TextureData textureData = new TextureData();

		[NonSerialized]
		public readonly int[] neighbourOffsets = new int[8];

		[NonSerialized]
		public readonly uint[] neighbourCosts = new uint[8];

		public static readonly int[] neighbourXOffsets = new int[8] { 0, 1, 0, -1, 1, 1, -1, -1 };

		public static readonly int[] neighbourZOffsets = new int[8] { -1, 0, 1, 0, -1, 1, 1, -1 };

		internal static readonly int[] hexagonNeighbourIndices = new int[6] { 0, 1, 5, 2, 3, 7 };

		internal static readonly int[] axisAlignedNeighbourIndices = new int[4] { 0, 1, 2, 3 };

		internal static readonly int[] allNeighbourIndices = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };

		internal const int HexagonConnectionMask = 175;

		public GridNodeBase[] nodes;

		protected GridGraphNodeData nodeData;

		protected Func<GridNodeBase> newGridNodeDelegate = () => new GridNode();

		public const int FixedPrecisionScale = 1024;

		public virtual int LayerCount
		{
			get
			{
				return 1;
			}
			protected set
			{
				if (value != 1)
				{
					throw new NotSupportedException("Grid graphs cannot have multiple layers");
				}
			}
		}

		public virtual int MaxLayers => 1;

		[Obsolete("This field has been renamed to maxStepHeight")]
		public float maxClimb
		{
			get
			{
				return maxStepHeight;
			}
			set
			{
				maxStepHeight = value;
			}
		}

		protected bool useRaycastNormal => Math.Abs(90f - maxSlope) > float.Epsilon;

		public Vector2 size { get; protected set; }

		internal ref GridGraphNodeData nodeDataRef => ref nodeData;

		public GraphTransform transform { get; private set; } = new GraphTransform(Matrix4x4.identity);

		public bool is2D
		{
			get
			{
				return Quaternion.Euler(rotation) * Vector3.up == -Vector3.forward;
			}
			set
			{
				if (value != is2D)
				{
					rotation = (value ? new Vector3(rotation.y - 90f, 270f, 90f) : new Vector3(0f, rotation.x + 90f, 0f));
				}
			}
		}

		public override bool isScanned => nodes != null;

		public override Bounds bounds => transform.Transform(new Bounds(new Vector3((float)width * 0.5f, collision.fromHeight * 0.5f, (float)depth * 0.5f), new Vector3(width, collision.fromHeight, depth)));

		public int Width
		{
			get
			{
				return width;
			}
			set
			{
				width = value;
			}
		}

		public int Depth
		{
			get
			{
				return depth;
			}
			set
			{
				depth = value;
			}
		}

		protected override void DisposeUnmanagedData()
		{
			DestroyAllNodes();
			GridNode.ClearGridGraph((int)graphIndex, this);
			rules.DisposeUnmanagedData();
			nodeData.Dispose();
		}

		protected override void DestroyAllNodes()
		{
			GetNodes(delegate(GraphNode node)
			{
				(node as GridNodeBase).ClearCustomConnections(alsoReverse: true);
				node.ClearConnections(alsoReverse: false);
				node.Destroy();
			});
			nodes = null;
		}

		public override int CountNodes()
		{
			if (nodes == null)
			{
				return 0;
			}
			return nodes.Length;
		}

		public override void GetNodes(Action<GraphNode> action)
		{
			if (nodes != null)
			{
				for (int i = 0; i < nodes.Length; i++)
				{
					action(nodes[i]);
				}
			}
		}

		public static int[] GetNeighbourDirections(NumNeighbours neighbours)
		{
			return neighbours switch
			{
				NumNeighbours.Four => axisAlignedNeighbourIndices, 
				NumNeighbours.Six => hexagonNeighbourIndices, 
				_ => allNeighbourIndices, 
			};
		}

		protected virtual GridNodeBase[] AllocateNodesJob(int size, out JobHandle dependency)
		{
			GridNodeBase[] result = new GridNodeBase[size];
			dependency = active.AllocateNodes(result, size, newGridNodeDelegate, 1u);
			return result;
		}

		public override void RelocateNodes(Matrix4x4 deltaMatrix)
		{
			throw new Exception("This method cannot be used for Grid Graphs. Please use the other overload of RelocateNodes instead");
		}

		public void RelocateNodes(Vector3 center, Quaternion rotation, float nodeSize, float aspectRatio = 1f, float isometricAngle = 0f)
		{
			GraphTransform graphTransform = transform;
			this.center = center;
			this.rotation = rotation.eulerAngles;
			this.aspectRatio = aspectRatio;
			this.isometricAngle = isometricAngle;
			DirtyBounds(bounds);
			SetDimensions(width, depth, nodeSize);
			new JobRelocateNodes
			{
				previousWorldToGraph = graphTransform.inverseMatrix,
				graphToWorld = transform.matrix,
				positions = nodeData.positions,
				bounds = nodeData.bounds
			}.Run();
			UnsafeSpan<Vector3> unsafeSpan = nodeData.positions.AsUnsafeSpan();
			for (int i = 0; i < nodes.Length; i++)
			{
				GridNodeBase gridNodeBase = nodes[i];
				if (gridNodeBase != null)
				{
					gridNodeBase.position = (Int3)unsafeSpan[i];
				}
			}
			DirtyBounds(bounds);
		}

		public override bool IsInsideBounds(Vector3 point)
		{
			if (nodes == null)
			{
				return false;
			}
			Vector3 vector = transform.InverseTransform(point);
			if (!(vector.x >= 0f) || !(vector.z >= 0f) || !(vector.x <= (float)width) || !(vector.z <= (float)depth))
			{
				return false;
			}
			if (collision.use2D || !collision.heightCheck)
			{
				return true;
			}
			if (vector.y >= 0f)
			{
				return vector.y <= collision.fromHeight;
			}
			return false;
		}

		public Int3 GraphPointToWorld(int x, int z, float height)
		{
			return (Int3)transform.Transform(new Vector3((float)x + 0.5f, height, (float)z + 0.5f));
		}

		public static float ConvertHexagonSizeToNodeSize(InspectorGridHexagonNodeSize mode, float value)
		{
			switch (mode)
			{
			case InspectorGridHexagonNodeSize.Diameter:
				value *= 1.5f / (float)Math.Sqrt(2.0);
				break;
			case InspectorGridHexagonNodeSize.Width:
				value *= (float)Math.Sqrt(1.5);
				break;
			}
			return value;
		}

		public static float ConvertNodeSizeToHexagonSize(InspectorGridHexagonNodeSize mode, float value)
		{
			switch (mode)
			{
			case InspectorGridHexagonNodeSize.Diameter:
				value *= (float)Math.Sqrt(2.0) / 1.5f;
				break;
			case InspectorGridHexagonNodeSize.Width:
				value *= (float)Math.Sqrt(0.6666666865348816);
				break;
			}
			return value;
		}

		public uint GetConnectionCost(int dir)
		{
			return neighbourCosts[dir];
		}

		public void SetGridShape(InspectorGridMode shape)
		{
			switch (shape)
			{
			case InspectorGridMode.Grid:
				isometricAngle = 0f;
				aspectRatio = 1f;
				uniformEdgeCosts = false;
				if (neighbours == NumNeighbours.Six)
				{
					neighbours = NumNeighbours.Eight;
				}
				break;
			case InspectorGridMode.Hexagonal:
				isometricAngle = StandardIsometricAngle;
				aspectRatio = 1f;
				uniformEdgeCosts = true;
				neighbours = NumNeighbours.Six;
				break;
			case InspectorGridMode.IsometricGrid:
				uniformEdgeCosts = false;
				if (neighbours == NumNeighbours.Six)
				{
					neighbours = NumNeighbours.Eight;
				}
				isometricAngle = StandardIsometricAngle;
				break;
			}
			inspectorGridMode = shape;
		}

		public void AlignToTilemap(GridLayout grid)
		{
			Vector3 vector = grid.CellToWorld(new Vector3Int(0, 0, 0));
			Vector3 lhs = grid.CellToWorld(new Vector3Int(1, 0, 0)) - vector;
			Vector3 rhs = grid.CellToWorld(new Vector3Int(0, 1, 0)) - vector;
			switch (grid.cellLayout)
			{
			case GridLayout.CellLayout.Rectangle:
			{
				quaternion quaternion4 = new quaternion(new float3x3(lhs.normalized, -Vector3.Cross(lhs, rhs).normalized, rhs.normalized));
				nodeSize = rhs.magnitude;
				isometricAngle = 0f;
				aspectRatio = lhs.magnitude / nodeSize;
				if (!float.IsFinite(aspectRatio))
				{
					aspectRatio = 1f;
				}
				rotation = ((Quaternion)quaternion4).eulerAngles;
				uniformEdgeCosts = false;
				if (neighbours == NumNeighbours.Six)
				{
					neighbours = NumNeighbours.Eight;
				}
				inspectorGridMode = InspectorGridMode.Grid;
				break;
			}
			case GridLayout.CellLayout.Isometric:
			{
				Vector3 a = grid.CellToWorld(new Vector3Int(1, 1, 0)) - vector;
				Vector3 b = grid.CellToWorld(new Vector3Int(1, -1, 0)) - vector;
				if (a.magnitude > b.magnitude)
				{
					Memory.Swap(ref a, ref b);
				}
				quaternion quaternion3 = math.mul(new quaternion(new float3x3(b.normalized, -Vector3.Cross(b, a).normalized, a.normalized)), quaternion.RotateY(-MathF.PI / 4f));
				isometricAngle = Mathf.Acos(a.magnitude / b.magnitude) * 57.29578f;
				nodeSize = b.magnitude / Mathf.Sqrt(2f);
				rotation = ((Quaternion)quaternion3).eulerAngles;
				uniformEdgeCosts = false;
				aspectRatio = 1f;
				if (neighbours == NumNeighbours.Six)
				{
					neighbours = NumNeighbours.Eight;
				}
				inspectorGridMode = InspectorGridMode.IsometricGrid;
				break;
			}
			case GridLayout.CellLayout.Hexagon:
			{
				Vector3 lhs2 = grid.CellToWorld(new Vector3Int(1, 0, 0)) - vector;
				Vector3 rhs2 = grid.CellToWorld(new Vector3Int(-1, 1, 0)) - vector;
				aspectRatio = lhs2.magnitude / Mathf.Sqrt(2f / 3f) / (Vector3.Cross(lhs2.normalized, rhs2).magnitude / (1.5f * Mathf.Sqrt(2f) / 3f));
				nodeSize = ConvertHexagonSizeToNodeSize(InspectorGridHexagonNodeSize.Width, lhs2.magnitude / aspectRatio);
				Vector3 rhs3 = -Vector3.Cross(lhs2, Vector3.Cross(lhs2, rhs2));
				quaternion quaternion2 = new quaternion(new float3x3(lhs2.normalized, -Vector3.Cross(lhs2, rhs3).normalized, rhs3.normalized));
				rotation = ((Quaternion)quaternion2).eulerAngles;
				uniformEdgeCosts = true;
				neighbours = NumNeighbours.Six;
				inspectorGridMode = InspectorGridMode.Hexagonal;
				break;
			}
			}
			UpdateTransform();
			bool flag = grid.cellLayout == GridLayout.CellLayout.Hexagon;
			Vector3 dir = new Vector3((width % 2 == 0 != flag) ? 0f : 0.5f, 0f, (depth % 2 == 0 != flag) ? 0f : 0.5f);
			Vector3 vector2 = transform.TransformVector(dir);
			Vector3Int cellPosition = grid.WorldToCell(center + vector2);
			cellPosition.z = 0;
			center = grid.CellToWorld(cellPosition) - vector2;
			if (float.IsNaN(center.x))
			{
				center = Vector3.zero;
			}
			UpdateTransform();
		}

		public void SetDimensions(int width, int depth, float nodeSize)
		{
			unclampedSize = new Vector2(width, depth) * nodeSize;
			this.nodeSize = nodeSize;
			UpdateTransform();
		}

		public void UpdateTransform()
		{
			CalculateDimensions(out width, out depth, out nodeSize);
			transform = CalculateTransform();
		}

		public GraphTransform CalculateTransform()
		{
			CalculateDimensions(out var num, out var num2, out var num3);
			if (neighbours == NumNeighbours.Six)
			{
				Vector3 vector = new Vector3(num3 * aspectRatio * Mathf.Sqrt(2f / 3f), 0f, 0f);
				Vector3 vector2 = new Vector3(0f, 1f, 0f);
				Matrix4x4 matrix4x = new Matrix4x4(column2: new Vector3((0f - aspectRatio) * num3 * 0.5f * Mathf.Sqrt(2f / 3f), 0f, num3 * (1.5f * Mathf.Sqrt(2f) / 3f)), column0: vector, column1: vector2, column3: new Vector4(0f, 0f, 0f, 1f));
				matrix4x = Matrix4x4.TRS((Matrix4x4.TRS(center, Quaternion.Euler(rotation), Vector3.one) * matrix4x).MultiplyPoint3x4(-new Vector3(num, 0f, num2) * 0.5f), Quaternion.Euler(rotation), Vector3.one) * matrix4x;
				return new GraphTransform(matrix4x);
			}
			Vector3 vector3 = new Vector3(Mathf.Cos(MathF.PI / 180f * isometricAngle), 1f, 1f);
			Matrix4x4 matrix4x2 = Matrix4x4.Scale(new Vector3(num3 * aspectRatio, 1f, num3));
			float num4 = Mathf.Atan2(num3, num3 * aspectRatio) * 57.29578f;
			matrix4x2 = Matrix4x4.Rotate(Quaternion.Euler(0f, 0f - num4, 0f)) * Matrix4x4.Scale(vector3) * Matrix4x4.Rotate(Quaternion.Euler(0f, num4, 0f)) * matrix4x2;
			return new GraphTransform(Matrix4x4.TRS((Matrix4x4.TRS(center, Quaternion.Euler(rotation), Vector3.one) * matrix4x2).MultiplyPoint3x4(-new Vector3(num, 0f, num2) * 0.5f), Quaternion.Euler(rotation), Vector3.one) * matrix4x2);
		}

		private void CalculateDimensions(out int width, out int depth, out float nodeSize)
		{
			Vector2 vector = unclampedSize;
			vector.x *= Mathf.Sign(vector.x);
			vector.y *= Mathf.Sign(vector.y);
			nodeSize = Mathf.Max(this.nodeSize, vector.x / 1024f);
			nodeSize = Mathf.Max(this.nodeSize, vector.y / 1024f);
			vector.x = ((vector.x < nodeSize) ? nodeSize : vector.x);
			vector.y = ((vector.y < nodeSize) ? nodeSize : vector.y);
			size = vector;
			width = Mathf.FloorToInt(size.x / nodeSize);
			depth = Mathf.FloorToInt(size.y / nodeSize);
			if (Mathf.Approximately(size.x / nodeSize, Mathf.CeilToInt(size.x / nodeSize)))
			{
				width = Mathf.CeilToInt(size.x / nodeSize);
			}
			if (Mathf.Approximately(size.y / nodeSize, Mathf.CeilToInt(size.y / nodeSize)))
			{
				depth = Mathf.CeilToInt(size.y / nodeSize);
			}
		}

		public override float NearestNodeDistanceSqrLowerBound(Vector3 position, NNConstraint constraint)
		{
			if (nodes == null || depth * width * LayerCount != nodes.Length)
			{
				return float.PositiveInfinity;
			}
			position = transform.InverseTransform(position);
			float x = position.x;
			float z = position.z;
			float num = Mathf.Clamp(x, 0f, width);
			float num2 = Mathf.Clamp(z, 0f, depth);
			return (x - num) * (x - num) + (z - num2) * (z - num2);
		}

		protected virtual GridNodeBase GetNearestFromGraphSpace(Vector3 positionGraphSpace)
		{
			if (nodes == null || depth * width != nodes.Length)
			{
				return null;
			}
			float x = positionGraphSpace.x;
			float z = positionGraphSpace.z;
			int num = Mathf.Clamp((int)x, 0, width - 1);
			int num2 = Mathf.Clamp((int)z, 0, depth - 1);
			return nodes[num2 * width + num];
		}

		public override NNInfo GetNearest(Vector3 position, NNConstraint constraint, float maxDistanceSqr)
		{
			if (nodes == null || depth * width * LayerCount != nodes.Length)
			{
				return NNInfo.Empty;
			}
			Vector3 vector = position;
			position = transform.InverseTransform(position);
			float x = position.x;
			float z = position.z;
			int num = Mathf.Clamp((int)x, 0, width - 1);
			int num2 = Mathf.Clamp((int)z, 0, depth - 1);
			GridNodeBase gridNodeBase = null;
			bool flag = constraint?.distanceMetric.isProjectedDistance ?? false;
			float num3 = maxDistanceSqr;
			int layerCount = LayerCount;
			int num4 = width * depth;
			long num5 = 0L;
			float num6 = 0f;
			Int3 rhs = default(Int3);
			if (flag)
			{
				rhs = (Int3)transform.WorldUpAtGraphPosition(vector);
				num5 = Int3.DotLong((Int3)vector, rhs);
				num6 = constraint.distanceMetric.distanceScaleAlongProjectionDirection * 0.001f * 0.001f;
			}
			for (int i = 0; i < layerCount; i++)
			{
				GridNodeBase gridNodeBase2 = nodes[num2 * width + num + num4 * i];
				if (gridNodeBase2 != null && (constraint == null || constraint.Suitable(gridNodeBase2)))
				{
					float num9;
					if (flag)
					{
						float num7 = math.clamp(x, num, (float)num + 1f) - x;
						float num8 = math.clamp(z, num2, (float)num2 + 1f) - z;
						float f = nodeSize * nodeSize * (num7 * num7 + num8 * num8);
						float f2 = (float)(Int3.DotLong(gridNodeBase2.position, rhs) - num5) * num6;
						num9 = Mathf.Sqrt(f) + Mathf.Abs(f2);
						num9 *= num9;
					}
					else
					{
						num9 = ((Vector3)gridNodeBase2.position - vector).sqrMagnitude;
					}
					if (num9 <= num3)
					{
						num3 = num9;
						gridNodeBase = gridNodeBase2;
					}
				}
			}
			float num10 = Mathf.Min(Mathf.Min(x - (float)num, 1f - (x - (float)num)), Mathf.Min(z - (float)num2, 1f - (z - (float)num2))) * nodeSize;
			int num11 = 1;
			while (true)
			{
				float num12 = (float)math.max(0, num11 - 2) * nodeSize + num10;
				if (num3 - 1E-05f <= num12 * num12)
				{
					break;
				}
				bool flag2 = false;
				int num13 = num + num11;
				int num14 = num2;
				int num15 = -1;
				int num16 = 1;
				for (int j = 0; j < 4; j++)
				{
					for (int k = 0; k < num11; k++)
					{
						if (num13 >= 0 && num14 >= 0 && num13 < width && num14 < depth)
						{
							flag2 = true;
							int num17 = num13 + num14 * width;
							for (int l = 0; l < layerCount; l++)
							{
								GridNodeBase gridNodeBase3 = nodes[num17 + num4 * l];
								if (gridNodeBase3 != null && (constraint == null || constraint.Suitable(gridNodeBase3)))
								{
									float num20;
									if (flag)
									{
										float num18 = math.clamp(x, num13, (float)num13 + 1f) - x;
										float num19 = math.clamp(z, num14, (float)num14 + 1f) - z;
										float f3 = nodeSize * nodeSize * (num18 * num18 + num19 * num19);
										float f4 = (float)(Int3.DotLong(gridNodeBase3.position, rhs) - num5) * num6;
										num20 = Mathf.Sqrt(f3) + Mathf.Abs(f4);
										num20 *= num20;
									}
									else
									{
										num20 = ((Vector3)gridNodeBase3.position - vector).sqrMagnitude;
									}
									if (num20 <= num3)
									{
										num3 = num20;
										gridNodeBase = gridNodeBase3;
									}
								}
							}
						}
						num13 += num15;
						num14 += num16;
					}
					int num21 = -num16;
					int num22 = num15;
					num15 = num21;
					num16 = num22;
				}
				if (!flag2)
				{
					break;
				}
				num11++;
			}
			if (gridNodeBase != null)
			{
				if (flag)
				{
					while (true)
					{
						int num23 = num - gridNodeBase.XCoordinateInGrid;
						int num24 = num2 - gridNodeBase.ZCoordinateInGrid;
						if (num23 == 0 && num24 == 0)
						{
							break;
						}
						int a = ((num23 > 0) ? 1 : ((num23 < 0) ? 3 : (-1)));
						int b = ((num24 > 0) ? 2 : ((num24 >= 0) ? (-1) : 0));
						if (Mathf.Abs(num23) < Mathf.Abs(num24))
						{
							Memory.Swap(ref a, ref b);
						}
						GridNodeBase neighbourAlongDirection = gridNodeBase.GetNeighbourAlongDirection(a);
						if (neighbourAlongDirection != null && (constraint == null || constraint.Suitable(neighbourAlongDirection)))
						{
							gridNodeBase = neighbourAlongDirection;
							continue;
						}
						if (b == -1 || (neighbourAlongDirection = gridNodeBase.GetNeighbourAlongDirection(b)) == null || (constraint != null && !constraint.Suitable(neighbourAlongDirection)))
						{
							break;
						}
						gridNodeBase = neighbourAlongDirection;
					}
				}
				int xCoordinateInGrid = gridNodeBase.XCoordinateInGrid;
				int zCoordinateInGrid = gridNodeBase.ZCoordinateInGrid;
				Vector3 vector2 = transform.Transform(new Vector3(Mathf.Clamp(x, xCoordinateInGrid, (float)xCoordinateInGrid + 1f), transform.InverseTransform((Vector3)gridNodeBase.position).y, Mathf.Clamp(z, zCoordinateInGrid, (float)zCoordinateInGrid + 1f)));
				float num25 = (flag ? num3 : (vector2 - vector).sqrMagnitude);
				if (!(num25 <= maxDistanceSqr))
				{
					return NNInfo.Empty;
				}
				return new NNInfo(gridNodeBase, vector2, num25);
			}
			return NNInfo.Empty;
		}

		public virtual void SetUpOffsetsAndCosts()
		{
			neighbourOffsets[0] = -width;
			neighbourOffsets[1] = 1;
			neighbourOffsets[2] = width;
			neighbourOffsets[3] = -1;
			neighbourOffsets[4] = -width + 1;
			neighbourOffsets[5] = width + 1;
			neighbourOffsets[6] = width - 1;
			neighbourOffsets[7] = -width - 1;
			float num = ((neighbours == NumNeighbours.Six) ? ConvertNodeSizeToHexagonSize(InspectorGridHexagonNodeSize.Width, nodeSize) : nodeSize);
			uint num2 = (uint)Mathf.RoundToInt(num * 1000f);
			uint num3 = (uniformEdgeCosts ? num2 : ((uint)Mathf.RoundToInt(num * Mathf.Sqrt(2f) * 1000f)));
			neighbourCosts[0] = num2;
			neighbourCosts[1] = num2;
			neighbourCosts[2] = num2;
			neighbourCosts[3] = num2;
			neighbourCosts[4] = num3;
			neighbourCosts[5] = num3;
			neighbourCosts[6] = num3;
			neighbourCosts[7] = num3;
		}

		public IGraphUpdatePromise TranslateInDirection(int dx, int dz)
		{
			return new GridGraphMovePromise(this, dx, dz);
		}

		protected override IGraphUpdatePromise ScanInternal(bool async)
		{
			if (nodeSize <= 0f)
			{
				return null;
			}
			UpdateTransform();
			if (width > 1024 || depth > 1024)
			{
				Debug.LogError("One of the grid's sides is longer than 1024 nodes");
				return null;
			}
			SetUpOffsetsAndCosts();
			GridNode.SetGridGraph((int)graphIndex, this);
			if (collision == null)
			{
				collision = new GraphCollision();
			}
			collision.Initialize(transform, nodeSize);
			JobDependencyTracker dependencyTracker = ObjectPool<JobDependencyTracker>.Claim();
			JobHandle dependency;
			GridNodeBase[] array = AllocateNodesJob(width * depth, out dependency);
			return new GridGraphUpdatePromise(this, transform, new GridGraphUpdatePromise.NodesHolder
			{
				nodes = array
			}, new int3(width, 1, depth), new IntRect(0, 0, width - 1, depth - 1), dependencyTracker, dependency, Allocator.Persistent, RecalculationMode.RecalculateFromScratch, null, ownsJobDependencyTracker: true, isFinalUpdate: true);
		}

		public void SetWalkability(bool[] walkability, IntRect rect)
		{
			AssertSafeToUpdateGraph();
			IntRect intRect = new IntRect(0, 0, width - 1, depth - 1);
			if (!intRect.Contains(rect))
			{
				string[] obj = new string[5] { "Rect (", null, null, null, null };
				IntRect intRect2 = rect;
				obj[1] = intRect2.ToString();
				obj[2] = ") must be within the graph bounds (";
				intRect2 = intRect;
				obj[3] = intRect2.ToString();
				obj[4] = ")";
				throw new ArgumentException(string.Concat(obj));
			}
			if (walkability.Length != rect.Width * rect.Height)
			{
				throw new ArgumentException("Array must have the same length as rect.Width*rect.Height");
			}
			if (LayerCount != 1)
			{
				throw new InvalidOperationException("This method only works in single-layered grid graphs.");
			}
			for (int i = 0; i < rect.Height; i++)
			{
				int num = (i + rect.ymin) * width + rect.xmin;
				for (int j = 0; j < rect.Width; j++)
				{
					bool flag = walkability[i * rect.Width + j];
					nodes[num + j].WalkableErosion = flag;
					nodes[num + j].Walkable = flag;
				}
			}
			RecalculateConnectionsInRegion(rect.Expand(1));
		}

		public void RecalculateAllConnections()
		{
			RecalculateConnectionsInRegion(new IntRect(0, 0, width - 1, depth - 1));
		}

		public void RecalculateConnectionsInRegion(IntRect recalculateRect)
		{
			AssertSafeToUpdateGraph();
			if (nodes == null || nodes.Length != width * depth * LayerCount)
			{
				throw new InvalidOperationException("The Grid Graph is not scanned, cannot recalculate connections.");
			}
			IntRect b = new IntRect(0, 0, width - 1, depth - 1);
			IntRect rect = IntRect.Intersection(recalculateRect, b);
			if (rect.IsValid())
			{
				JobDependencyTracker obj = ObjectPool<JobDependencyTracker>.Claim();
				IntRect intRect = IntRect.Intersection(rect.Expand(1), b);
				IntBounds slice = new IntBounds(intRect.xmin, 0, intRect.ymin, intRect.xmax + 1, LayerCount, intRect.ymax + 1);
				if (slice.volume < 200)
				{
					obj.SetLinearDependencies(linearDependencies: true);
				}
				bool layeredDataLayout = this is LayerGridGraph;
				GridGraphScanData gridGraphScanData = new GridGraphScanData
				{
					dependencyTracker = obj,
					nodes = GridGraphNodeData.ReadFromNodes(nodes, new Slice3D(nodeData.bounds, slice), default(JobHandle), nodeData.normals, Allocator.TempJob, layeredDataLayout, obj),
					transform = transform,
					up = transform.WorldUpAtGraphPosition(Vector3.zero)
				};
				float characterHeight = ((this is LayerGridGraph layerGridGraph) ? layerGridGraph.characterHeight : float.PositiveInfinity);
				IntBounds intBounds = new IntBounds(rect.xmin, 0, rect.ymin, rect.xmax + 1, LayerCount, rect.ymax + 1);
				gridGraphScanData.Connections(maxStepHeight, maxStepUsesSlope, intBounds, neighbours, cutCorners, collision.use2D, useErodedWalkability: true, characterHeight);
				nodeData.CopyFrom(gridGraphScanData.nodes, intBounds, copyPenaltyAndTags: true, obj);
				obj.AllWritesDependency.Complete();
				gridGraphScanData.AssignNodeConnections(nodes, new int3(width, LayerCount, depth), intBounds);
				ObjectPool<JobDependencyTracker>.Release(ref obj);
				active.DirtyBounds(GetBoundsFromRect(rect));
			}
		}

		public void CalculateConnectionsForCellAndNeighbours(int x, int z)
		{
			RecalculateConnectionsInRegion(new IntRect(x - 1, z - 1, x + 1, z + 1));
		}

		[Obsolete("This method is very slow since 4.3.80. Use RecalculateConnectionsInRegion or RecalculateAllConnections instead to batch connection recalculations.")]
		public virtual void CalculateConnections(GridNodeBase node)
		{
			int nodeInGridIndex = node.NodeInGridIndex;
			int x = nodeInGridIndex % width;
			int z = nodeInGridIndex / width;
			CalculateConnections(x, z);
		}

		[Obsolete("This method is very slow since 4.3.80. Use RecalculateConnectionsInRegion instead to batch connection recalculations.")]
		public virtual void CalculateConnections(int x, int z)
		{
			RecalculateConnectionsInRegion(new IntRect(x, z, x, z));
		}

		public override void OnDrawGizmos(DrawingData gizmos, bool drawNodes, RedrawScope redrawScope)
		{
			using (GraphGizmoHelper graphGizmoHelper = GraphGizmoHelper.GetSingleFrameGizmoHelper(gizmos, active, redrawScope))
			{
				CalculateDimensions(out var num, out var num2, out var _);
				Bounds bounds = default(Bounds);
				bounds.SetMinMax(Vector3.zero, new Vector3(num, 0f, num2));
				using (graphGizmoHelper.builder.WithMatrix(CalculateTransform().matrix))
				{
					graphGizmoHelper.builder.WireBox(bounds, Color.white);
					int num4 = ((nodes != null) ? nodes.Length : (-1));
					if (drawNodes && width * depth * LayerCount != num4)
					{
						Color color = new Color(1f, 1f, 1f, 0.2f);
						graphGizmoHelper.builder.WireGrid(new float3((float)num * 0.5f, 0f, (float)num2 * 0.5f), Quaternion.identity, new int2(num, num2), new float2(num, num2), color);
					}
				}
			}
			if (!drawNodes)
			{
				return;
			}
			GridNodeBase[] array = ArrayPool<GridNodeBase>.Claim(1024 * LayerCount);
			for (int num5 = width / 32; num5 >= 0; num5--)
			{
				for (int num6 = depth / 32; num6 >= 0; num6--)
				{
					int nodesInRegion = GetNodesInRegion(new IntRect(num5 * 32, num6 * 32, (num5 + 1) * 32 - 1, (num6 + 1) * 32 - 1), array);
					NodeHasher nodeHasher = new NodeHasher(active);
					nodeHasher.Add(showMeshOutline);
					nodeHasher.Add(showMeshSurface);
					nodeHasher.Add(showNodeConnections);
					for (int i = 0; i < nodesInRegion; i++)
					{
						nodeHasher.HashNode(array[i]);
					}
					if (!gizmos.Draw(nodeHasher, redrawScope))
					{
						using GraphGizmoHelper graphGizmoHelper2 = GraphGizmoHelper.GetGizmoHelper(gizmos, active, nodeHasher, redrawScope);
						if (showNodeConnections)
						{
							if (graphGizmoHelper2.showSearchTree)
							{
								graphGizmoHelper2.builder.PushLineWidth(2f);
							}
							for (int j = 0; j < nodesInRegion; j++)
							{
								if (array[j].Walkable)
								{
									graphGizmoHelper2.DrawConnections(array[j]);
								}
							}
							if (graphGizmoHelper2.showSearchTree)
							{
								graphGizmoHelper2.builder.PopLineWidth();
							}
						}
						if (showMeshSurface || showMeshOutline)
						{
							CreateNavmeshSurfaceVisualization(array, nodesInRegion, graphGizmoHelper2);
						}
					}
				}
			}
			ArrayPool<GridNodeBase>.Release(ref array);
			if (active.showUnwalkableNodes)
			{
				DrawUnwalkableNodes(gizmos, nodeSize * 0.3f, redrawScope);
			}
		}

		private void CreateNavmeshSurfaceVisualization(GridNodeBase[] nodes, int nodeCount, GraphGizmoHelper helper)
		{
			int num = 0;
			for (int i = 0; i < nodeCount; i++)
			{
				if (nodes[i].Walkable)
				{
					num++;
				}
			}
			int[] array = ((neighbours == NumNeighbours.Six) ? hexagonNeighbourIndices : new int[4] { 0, 1, 2, 3 });
			float num2 = ((neighbours == NumNeighbours.Six) ? 0.333333f : 0.5f);
			int num3 = array.Length - 2;
			int num4 = 3 * num3;
			Vector3[] array2 = ArrayPool<Vector3>.Claim(num * num4);
			Color[] array3 = ArrayPool<Color>.Claim(num * num4);
			int num5 = 0;
			for (int j = 0; j < nodeCount; j++)
			{
				GridNodeBase gridNodeBase = nodes[j];
				if (!gridNodeBase.Walkable)
				{
					continue;
				}
				Color color = helper.NodeColor(gridNodeBase);
				if (color.a <= 0.001f)
				{
					continue;
				}
				for (int k = 0; k < array.Length; k++)
				{
					int num6 = array[k];
					int num7 = array[(k + 1) % array.Length];
					GridNodeBase gridNodeBase2 = null;
					GridNodeBase neighbourAlongDirection = gridNodeBase.GetNeighbourAlongDirection(num6);
					if (neighbourAlongDirection != null && neighbours != NumNeighbours.Six)
					{
						gridNodeBase2 = neighbourAlongDirection.GetNeighbourAlongDirection(num7);
					}
					GridNodeBase neighbourAlongDirection2 = gridNodeBase.GetNeighbourAlongDirection(num7);
					if (neighbourAlongDirection2 != null && gridNodeBase2 == null && neighbours != NumNeighbours.Six)
					{
						gridNodeBase2 = neighbourAlongDirection2.GetNeighbourAlongDirection(num6);
					}
					Vector3 point = new Vector3((float)gridNodeBase.XCoordinateInGrid + 0.5f, 0f, (float)gridNodeBase.ZCoordinateInGrid + 0.5f);
					point.x += (float)(neighbourXOffsets[num6] + neighbourXOffsets[num7]) * num2;
					point.z += (float)(neighbourZOffsets[num6] + neighbourZOffsets[num7]) * num2;
					point.y += transform.InverseTransform((Vector3)gridNodeBase.position).y;
					if (neighbourAlongDirection != null)
					{
						point.y += transform.InverseTransform((Vector3)neighbourAlongDirection.position).y;
					}
					if (neighbourAlongDirection2 != null)
					{
						point.y += transform.InverseTransform((Vector3)neighbourAlongDirection2.position).y;
					}
					if (gridNodeBase2 != null)
					{
						point.y += transform.InverseTransform((Vector3)gridNodeBase2.position).y;
					}
					point.y /= 1f + ((neighbourAlongDirection != null) ? 1f : 0f) + ((neighbourAlongDirection2 != null) ? 1f : 0f) + ((gridNodeBase2 != null) ? 1f : 0f);
					point = transform.Transform(point);
					array2[num5 + k] = point;
				}
				if (neighbours == NumNeighbours.Six)
				{
					array2[num5 + 6] = array2[num5];
					array2[num5 + 7] = array2[num5 + 2];
					array2[num5 + 8] = array2[num5 + 3];
					array2[num5 + 9] = array2[num5];
					array2[num5 + 10] = array2[num5 + 3];
					array2[num5 + 11] = array2[num5 + 5];
				}
				else
				{
					array2[num5 + 4] = array2[num5];
					array2[num5 + 5] = array2[num5 + 2];
				}
				for (int l = 0; l < num4; l++)
				{
					array3[num5 + l] = color;
				}
				for (int m = 0; m < array.Length; m++)
				{
					GridNodeBase neighbourAlongDirection3 = gridNodeBase.GetNeighbourAlongDirection(array[(m + 1) % array.Length]);
					if (neighbourAlongDirection3 == null || (showMeshOutline && gridNodeBase.NodeInGridIndex < neighbourAlongDirection3.NodeInGridIndex))
					{
						helper.builder.Line(array2[num5 + m], array2[num5 + (m + 1) % array.Length], (neighbourAlongDirection3 == null) ? Color.black : color);
					}
				}
				num5 += num4;
			}
			if (showMeshSurface)
			{
				helper.DrawTriangles(array2, array3, num5 * num3 / num4);
			}
			ArrayPool<Vector3>.Release(ref array2);
			ArrayPool<Color>.Release(ref array3);
		}

		public Bounds GetBoundsFromRect(IntRect rect)
		{
			rect = IntRect.Intersection(rect, new IntRect(0, 0, width - 1, depth - 1));
			if (!rect.IsValid())
			{
				return default(Bounds);
			}
			return transform.Transform(new Bounds(new Vector3(rect.xmin + rect.xmax, collision.fromHeight, rect.ymin + rect.ymax) * 0.5f, new Vector3(rect.Width + 1, collision.fromHeight, rect.Height + 1)));
		}

		public IntRect GetRectFromBounds(Bounds bounds)
		{
			bounds = transform.InverseTransform(bounds);
			Vector3 min = bounds.min;
			Vector3 max = bounds.max;
			int xmin = Mathf.FloorToInt(min.x + 0.01f);
			int xmax = Mathf.FloorToInt(max.x - 0.01f);
			int ymin = Mathf.FloorToInt(min.z + 0.01f);
			int ymax = Mathf.FloorToInt(max.z - 0.01f);
			IntRect a = new IntRect(xmin, ymin, xmax, ymax);
			IntRect b = new IntRect(0, 0, width - 1, depth - 1);
			return IntRect.Intersection(a, b);
		}

		public List<GraphNode> GetNodesInRegion(Bounds bounds)
		{
			return GetNodesInRegion(bounds, null);
		}

		public List<GraphNode> GetNodesInRegion(GraphUpdateShape shape)
		{
			return GetNodesInRegion(shape.GetBounds(), shape);
		}

		protected virtual List<GraphNode> GetNodesInRegion(Bounds bounds, GraphUpdateShape shape)
		{
			IntRect rectFromBounds = GetRectFromBounds(bounds);
			if (nodes == null || !rectFromBounds.IsValid() || nodes.Length != width * depth * LayerCount)
			{
				return ListPool<GraphNode>.Claim();
			}
			List<GraphNode> list = ListPool<GraphNode>.Claim(rectFromBounds.Width * rectFromBounds.Height);
			int num = rectFromBounds.Width;
			for (int i = 0; i < LayerCount; i++)
			{
				for (int j = rectFromBounds.ymin; j <= rectFromBounds.ymax; j++)
				{
					int num2 = i * width * depth + j * width + rectFromBounds.xmin;
					for (int k = 0; k < num; k++)
					{
						GridNodeBase gridNodeBase = nodes[num2 + k];
						if (gridNodeBase != null)
						{
							Vector3 point = (Vector3)gridNodeBase.position;
							if (bounds.Contains(point) && (shape == null || shape.Contains(point)))
							{
								list.Add(gridNodeBase);
							}
						}
					}
				}
			}
			return list;
		}

		public List<GraphNode> GetNodesInRegion(IntRect rect)
		{
			rect = IntRect.Intersection(b: new IntRect(0, 0, width - 1, depth - 1), a: rect);
			if (nodes == null || !rect.IsValid() || nodes.Length != width * depth * LayerCount)
			{
				return ListPool<GraphNode>.Claim(0);
			}
			List<GraphNode> list = ListPool<GraphNode>.Claim(rect.Width * rect.Height);
			int num = rect.Width;
			for (int i = 0; i < LayerCount; i++)
			{
				for (int j = rect.ymin; j <= rect.ymax; j++)
				{
					int num2 = i * width * depth + j * width + rect.xmin;
					for (int k = 0; k < num; k++)
					{
						GridNodeBase gridNodeBase = nodes[num2 + k];
						if (gridNodeBase != null)
						{
							list.Add(gridNodeBase);
						}
					}
				}
			}
			return list;
		}

		public virtual int GetNodesInRegion(IntRect rect, GridNodeBase[] buffer)
		{
			rect = IntRect.Intersection(b: new IntRect(0, 0, width - 1, depth - 1), a: rect);
			if (nodes == null || !rect.IsValid() || nodes.Length != width * depth)
			{
				return 0;
			}
			if (buffer.Length < rect.Width * rect.Height)
			{
				throw new ArgumentException("Buffer is too small");
			}
			int num = 0;
			int num2 = rect.ymin;
			while (num2 <= rect.ymax)
			{
				Array.Copy(nodes, num2 * Width + rect.xmin, buffer, num, rect.Width);
				num2++;
				num += rect.Width;
			}
			return num;
		}

		public virtual GridNodeBase GetNode(int x, int z)
		{
			if (x < 0 || z < 0 || x >= width || z >= depth)
			{
				return null;
			}
			return nodes[x + z * width];
		}

		IGraphUpdatePromise IUpdatableGraph.ScheduleGraphUpdates(List<GraphUpdateObject> graphUpdates)
		{
			if (!isScanned || nodes.Length != width * depth * LayerCount)
			{
				Debug.LogWarning("The Grid Graph is not scanned, cannot update graph");
				return null;
			}
			collision.Initialize(transform, nodeSize);
			return new CombinedGridGraphUpdatePromise(this, graphUpdates);
		}

		public override IGraphSnapshot Snapshot(Bounds bounds)
		{
			if (active.isScanning || active.IsAnyWorkItemInProgress)
			{
				throw new InvalidOperationException("Trying to capture a grid graph snapshot while inside a work item. This is not supported, as the graphs may be in an inconsistent state.");
			}
			if (!isScanned || nodes.Length != width * depth * LayerCount)
			{
				return null;
			}
			GridGraphUpdatePromise.CalculateRectangles(this, GetRectFromBounds(bounds), out var _, out var _, out var writeMaskRect, out var _);
			if (!writeMaskRect.IsValid())
			{
				return null;
			}
			IntBounds intBounds = new IntBounds(writeMaskRect.xmin, 0, writeMaskRect.ymin, writeMaskRect.xmax + 1, LayerCount, writeMaskRect.ymax + 1);
			GridGraphNodeData gridGraphNodeData = new GridGraphNodeData
			{
				allocationMethod = Allocator.Persistent,
				bounds = intBounds,
				numNodes = intBounds.volume
			};
			gridGraphNodeData.AllocateBuffers(null);
			gridGraphNodeData.CopyFrom(nodeData, copyPenaltyAndTags: true, null);
			return new GridGraphSnapshot
			{
				nodes = gridGraphNodeData,
				graph = this
			};
		}

		public bool Linecast(Vector3 from, Vector3 to)
		{
			GraphHitInfo hit;
			return Linecast(from, to, out hit, (List<GraphNode>)null, (Func<GraphNode, bool>)null);
		}

		[Obsolete("The hint parameter is deprecated")]
		public bool Linecast(Vector3 from, Vector3 to, GraphNode hint)
		{
			GraphHitInfo hit;
			return Linecast(from, to, hint, out hit);
		}

		[Obsolete("The hint parameter is deprecated")]
		public bool Linecast(Vector3 from, Vector3 to, GraphNode hint, out GraphHitInfo hit)
		{
			return Linecast(from, to, hint, out hit, null);
		}

		protected static long CrossMagnitude(int2 a, int2 b)
		{
			return (long)a.x * (long)b.y - (long)b.x * (long)a.y;
		}

		protected bool ClipLineSegmentToBounds(Vector3 a, Vector3 b, out Vector3 outA, out Vector3 outB)
		{
			if (a.x < 0f || a.z < 0f || a.x > (float)width || a.z > (float)depth || b.x < 0f || b.z < 0f || b.x > (float)width || b.z > (float)depth)
			{
				Vector3 vector = new Vector3(0f, 0f, 0f);
				Vector3 vector2 = new Vector3(0f, 0f, depth);
				Vector3 vector3 = new Vector3(width, 0f, depth);
				Vector3 vector4 = new Vector3(width, 0f, 0f);
				int num = 0;
				Vector3 vector5 = VectorMath.SegmentIntersectionPointXZ(a, b, vector, vector2, out var intersects);
				if (intersects)
				{
					num++;
					if (!VectorMath.RightOrColinearXZ(vector, vector2, a))
					{
						a = vector5;
					}
					else
					{
						b = vector5;
					}
				}
				vector5 = VectorMath.SegmentIntersectionPointXZ(a, b, vector2, vector3, out intersects);
				if (intersects)
				{
					num++;
					if (!VectorMath.RightOrColinearXZ(vector2, vector3, a))
					{
						a = vector5;
					}
					else
					{
						b = vector5;
					}
				}
				vector5 = VectorMath.SegmentIntersectionPointXZ(a, b, vector3, vector4, out intersects);
				if (intersects)
				{
					num++;
					if (!VectorMath.RightOrColinearXZ(vector3, vector4, a))
					{
						a = vector5;
					}
					else
					{
						b = vector5;
					}
				}
				vector5 = VectorMath.SegmentIntersectionPointXZ(a, b, vector4, vector, out intersects);
				if (intersects)
				{
					num++;
					if (!VectorMath.RightOrColinearXZ(vector4, vector, a))
					{
						a = vector5;
					}
					else
					{
						b = vector5;
					}
				}
				if (num == 0)
				{
					outA = Vector3.zero;
					outB = Vector3.zero;
					return false;
				}
			}
			outA = a;
			outB = b;
			return true;
		}

		[Obsolete("The hint parameter is deprecated")]
		public bool Linecast(Vector3 from, Vector3 to, GraphNode hint, out GraphHitInfo hit, List<GraphNode> trace, Func<GraphNode, bool> filter = null)
		{
			return Linecast(from, to, out hit, trace, filter);
		}

		public bool Linecast(Vector3 from, Vector3 to, out GraphHitInfo hit, List<GraphNode> trace = null, Func<GraphNode, bool> filter = null)
		{
			GridHitInfo hit2;
			bool num = Linecast(from, to, out hit2, trace, filter);
			hit = new GraphHitInfo
			{
				origin = from,
				node = hit2.node
			};
			if (num)
			{
				int direction = hit2.direction;
				if (direction == -1 || hit2.node == null)
				{
					hit.point = ((hit2.node == null || !hit2.node.Walkable || (filter != null && !filter(hit2.node))) ? from : to);
					if (hit2.node != null)
					{
						hit.point = hit2.node.ProjectOnSurface(hit.point);
					}
					hit.tangentOrigin = Vector3.zero;
					hit.tangent = Vector3.zero;
					return num;
				}
				Vector3 vector = transform.InverseTransform(from);
				Vector3 vector2 = transform.InverseTransform(to);
				Vector2 start = new Vector2(vector.x - 0.5f, vector.z - 0.5f);
				Vector2 end = new Vector2(vector2.x - 0.5f, vector2.z - 0.5f);
				Vector2 vector3 = new Vector2(neighbourXOffsets[direction], neighbourZOffsets[direction]);
				Vector2 vector4 = new Vector2(neighbourXOffsets[(direction - 1 + 4) & 3], neighbourZOffsets[(direction - 1 + 4) & 3]);
				Vector2 vector5 = new Vector2(neighbourXOffsets[(direction + 1) & 3], neighbourZOffsets[(direction + 1) & 3]);
				Vector2 vector6 = new Vector2(hit2.node.XCoordinateInGrid, hit2.node.ZCoordinateInGrid) + (vector3 + vector4) * 0.5f;
				Vector2 vector7 = VectorMath.LineIntersectionPoint(vector6, vector6 + vector5, start, end);
				Vector3 vector8 = transform.InverseTransform((Vector3)hit2.node.position);
				Vector3 point = new Vector3(vector7.x + 0.5f, vector8.y, vector7.y + 0.5f);
				Vector3 point2 = new Vector3(vector6.x + 0.5f, vector8.y, vector6.y + 0.5f);
				hit.point = transform.Transform(point);
				hit.tangentOrigin = transform.Transform(point2);
				hit.tangent = transform.TransformVector(new Vector3(vector5.x, 0f, vector5.y));
				return num;
			}
			hit.point = to;
			return num;
		}

		[Obsolete("Use Linecast instead")]
		public bool SnappedLinecast(Vector3 from, Vector3 to, GraphNode hint, out GraphHitInfo hit)
		{
			return Linecast((Vector3)GetNearest(from).node.position, (Vector3)GetNearest(to).node.position, hint, out hit);
		}

		public bool Linecast(GridNodeBase fromNode, GridNodeBase toNode, Func<GraphNode, bool> filter = null)
		{
			int2 int5 = new int2(512, 512);
			GridHitInfo hit;
			return Linecast(fromNode, int5, toNode, int5, out hit, null, filter);
		}

		public bool Linecast(Vector3 from, Vector3 to, out GridHitInfo hit, List<GraphNode> trace = null, Func<GraphNode, bool> filter = null)
		{
			Vector3 vector = transform.InverseTransform(from);
			Vector3 vector2 = transform.InverseTransform(to);
			if (!ClipLineSegmentToBounds(vector, vector2, out var outA, out var outB))
			{
				hit = new GridHitInfo
				{
					node = null,
					direction = -1
				};
				return false;
			}
			if ((vector - outA).sqrMagnitude > 1.0000001E-06f)
			{
				hit = new GridHitInfo
				{
					node = null,
					direction = -1
				};
				return true;
			}
			bool continuePastEnd = (vector2 - outB).sqrMagnitude > 1.0000001E-06f;
			GridNodeBase nearestFromGraphSpace = GetNearestFromGraphSpace(outA);
			GridNodeBase nearestFromGraphSpace2 = GetNearestFromGraphSpace(outB);
			if (nearestFromGraphSpace == null || nearestFromGraphSpace2 == null)
			{
				hit = new GridHitInfo
				{
					node = null,
					direction = -1
				};
				return false;
			}
			return Linecast(nearestFromGraphSpace, new Vector2(outA.x - (float)nearestFromGraphSpace.XCoordinateInGrid, outA.z - (float)nearestFromGraphSpace.ZCoordinateInGrid), nearestFromGraphSpace2, new Vector2(outB.x - (float)nearestFromGraphSpace2.XCoordinateInGrid, outB.z - (float)nearestFromGraphSpace2.ZCoordinateInGrid), out hit, trace, filter, continuePastEnd);
		}

		public bool Linecast(GridNodeBase fromNode, Vector2 normalizedFromPoint, GridNodeBase toNode, Vector2 normalizedToPoint, out GridHitInfo hit, List<GraphNode> trace = null, Func<GraphNode, bool> filter = null, bool continuePastEnd = false)
		{
			int2 fixedNormalizedFromPoint = new int2((int)Mathf.Round(normalizedFromPoint.x * 1024f), (int)Mathf.Round(normalizedFromPoint.y * 1024f));
			int2 fixedNormalizedToPoint = new int2((int)Mathf.Round(normalizedToPoint.x * 1024f), (int)Mathf.Round(normalizedToPoint.y * 1024f));
			return Linecast(fromNode, fixedNormalizedFromPoint, toNode, fixedNormalizedToPoint, out hit, trace, filter, continuePastEnd);
		}

		public bool Linecast(GridNodeBase fromNode, int2 fixedNormalizedFromPoint, GridNodeBase toNode, int2 fixedNormalizedToPoint, out GridHitInfo hit, List<GraphNode> trace = null, Func<GraphNode, bool> filter = null, bool continuePastEnd = false)
		{
			if (fixedNormalizedFromPoint.x < 0 || fixedNormalizedFromPoint.x > 1024)
			{
				throw new ArgumentOutOfRangeException("fixedNormalizedFromPoint", "must be between 0 and 1024");
			}
			if (fixedNormalizedToPoint.x < 0 || fixedNormalizedToPoint.x > 1024)
			{
				throw new ArgumentOutOfRangeException("fixedNormalizedToPoint", "must be between 0 and 1024");
			}
			if (fromNode == null)
			{
				throw new ArgumentNullException("fromNode");
			}
			if (toNode == null)
			{
				throw new ArgumentNullException("toNode");
			}
			if ((filter != null && !filter(fromNode)) || !fromNode.Walkable)
			{
				hit = new GridHitInfo
				{
					node = fromNode,
					direction = -1
				};
				return true;
			}
			if (fromNode == toNode)
			{
				hit = new GridHitInfo
				{
					node = fromNode,
					direction = -1
				};
				trace?.Add(fromNode);
				return false;
			}
			int2 int5 = new int2(fromNode.XCoordinateInGrid, fromNode.ZCoordinateInGrid);
			int2 int6 = new int2(toNode.XCoordinateInGrid, toNode.ZCoordinateInGrid);
			int2 int7 = new int2(int5.x * 1024, int5.y * 1024) + fixedNormalizedFromPoint;
			int2 int8 = new int2(int6.x * 1024, int6.y * 1024) + fixedNormalizedToPoint;
			int2 obj = int8 - int7;
			int num = Math.Abs(int5.x - int6.x) + Math.Abs(int5.y - int6.y);
			if (continuePastEnd)
			{
				num = int.MaxValue;
			}
			if (math.all(int7 == int8))
			{
				num = 0;
			}
			int num2 = 0;
			int2 int9 = obj;
			if (int9.x == 0)
			{
				int9.x = Math.Sign(512 - fixedNormalizedToPoint.x);
			}
			if (int9.y == 0)
			{
				int9.y = Math.Sign(512 - fixedNormalizedToPoint.y);
			}
			if (int9.x <= 0 && int9.y > 0)
			{
				num2 = 1;
			}
			else if (int9.x < 0 && int9.y <= 0)
			{
				num2 = 2;
			}
			else if (int9.x >= 0 && int9.y < 0)
			{
				num2 = 3;
			}
			int num3 = (num2 + 1) & 3;
			int num4 = (num2 + 2) & 3;
			long num5 = CrossMagnitude(obj, new int2(neighbourXOffsets[num4] + neighbourXOffsets[num3], neighbourZOffsets[num4] + neighbourZOffsets[num3]));
			long num6 = CrossMagnitude(b: new int2(512, 512) - fixedNormalizedFromPoint, a: obj) * 2 / 1024;
			long num7 = -obj.y * 2;
			long num8 = obj.x * 2;
			int num9 = num4;
			int num10 = num3;
			if (CrossMagnitude(b: new int2(int6.x * 1024, int6.y * 1024) + new int2(512, 512) - int7, a: obj) < 0)
			{
				num9 = num3;
				num10 = num4;
			}
			GridNodeBase gridNodeBase = null;
			GridNodeBase gridNodeBase2 = null;
			while (num > 0)
			{
				trace?.Add(fromNode);
				long num11 = num6 + num5;
				int num12;
				GridNodeBase gridNodeBase3;
				if (num11 == 0L)
				{
					num12 = num9;
					gridNodeBase3 = fromNode.GetNeighbourAlongDirection(num12);
					if ((filter != null && gridNodeBase3 != null && !filter(gridNodeBase3)) || gridNodeBase3 == gridNodeBase)
					{
						gridNodeBase3 = null;
					}
					if (gridNodeBase3 == null)
					{
						num12 = num10;
						gridNodeBase3 = fromNode.GetNeighbourAlongDirection(num12);
						if ((filter != null && gridNodeBase3 != null && !filter(gridNodeBase3)) || gridNodeBase3 == gridNodeBase)
						{
							gridNodeBase3 = null;
						}
					}
				}
				else
				{
					num12 = ((num11 < 0) ? num4 : num3);
					gridNodeBase3 = fromNode.GetNeighbourAlongDirection(num12);
					if ((filter != null && gridNodeBase3 != null && !filter(gridNodeBase3)) || gridNodeBase3 == gridNodeBase)
					{
						gridNodeBase3 = null;
					}
				}
				if (gridNodeBase3 == null)
				{
					for (int i = -1; i <= 1; i += 2)
					{
						int num13 = (num12 + i + 4) & 3;
						if (num6 + num7 / 2 * (neighbourXOffsets[num12] + neighbourXOffsets[num13]) + num8 / 2 * (neighbourZOffsets[num12] + neighbourZOffsets[num13]) == 0L)
						{
							gridNodeBase3 = fromNode.GetNeighbourAlongDirection(num13);
							if ((filter != null && gridNodeBase3 != null && !filter(gridNodeBase3)) || gridNodeBase3 == gridNodeBase || gridNodeBase3 == gridNodeBase2)
							{
								gridNodeBase3 = null;
							}
							if (gridNodeBase3 != null)
							{
								num = 1 + Math.Abs(gridNodeBase3.XCoordinateInGrid - int6.x) + Math.Abs(gridNodeBase3.ZCoordinateInGrid - int6.y);
								num12 = num13;
								gridNodeBase = fromNode;
								gridNodeBase2 = gridNodeBase3;
							}
							break;
						}
					}
					if (gridNodeBase3 == null)
					{
						hit = new GridHitInfo
						{
							node = fromNode,
							direction = num12
						};
						return true;
					}
				}
				num6 += num7 * neighbourXOffsets[num12] + num8 * neighbourZOffsets[num12];
				fromNode = gridNodeBase3;
				num--;
			}
			hit = new GridHitInfo
			{
				node = fromNode,
				direction = -1
			};
			if (fromNode != toNode)
			{
				int2 int10 = int8 - (new int2(fromNode.XCoordinateInGrid, fromNode.ZCoordinateInGrid) * 1024 + new int2(512, 512));
				if (math.all(math.abs(int10) == new int2(512, 512)))
				{
					int2 int11 = int10 * 2 / 1024;
					int num14 = -1;
					for (int j = 0; j < 4; j++)
					{
						if (neighbourXOffsets[j] + neighbourXOffsets[(j + 1) & 3] == int11.x && neighbourZOffsets[j] + neighbourZOffsets[(j + 1) & 3] == int11.y)
						{
							num14 = j;
							break;
						}
					}
					int num15 = trace?.Count ?? 0;
					int num16 = num14;
					GridNodeBase gridNodeBase4 = fromNode;
					for (int k = 0; k < 3; k++)
					{
						if (gridNodeBase4 == toNode)
						{
							break;
						}
						trace?.Add(gridNodeBase4);
						gridNodeBase4 = gridNodeBase4.GetNeighbourAlongDirection(num16);
						if (gridNodeBase4 == null || (filter != null && !filter(gridNodeBase4)))
						{
							gridNodeBase4 = null;
							break;
						}
						num16 = (num16 + 1) & 3;
					}
					if (gridNodeBase4 != toNode)
					{
						trace?.RemoveRange(num15, trace.Count - num15);
						gridNodeBase4 = fromNode;
						num16 = (num14 + 1) & 3;
						for (int l = 0; l < 3; l++)
						{
							if (gridNodeBase4 == toNode)
							{
								break;
							}
							trace?.Add(gridNodeBase4);
							gridNodeBase4 = gridNodeBase4.GetNeighbourAlongDirection(num16);
							if (gridNodeBase4 == null || (filter != null && !filter(gridNodeBase4)))
							{
								gridNodeBase4 = null;
								break;
							}
							num16 = (num16 - 1 + 4) & 3;
						}
						if (gridNodeBase4 != toNode)
						{
							trace?.RemoveRange(num15, trace.Count - num15);
						}
					}
					fromNode = gridNodeBase4;
				}
			}
			trace?.Add(fromNode);
			return fromNode != toNode;
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
			GridNodeBase[] array = new GridNode[num];
			nodes = array;
			for (int i = 0; i < nodes.Length; i++)
			{
				nodes[i] = newGridNodeDelegate();
				active.InitializeNode(nodes[i]);
				nodes[i].DeserializeNode(ctx);
			}
			DeserializeNativeData(ctx, ctx.meta.version >= AstarSerializer.V4_3_6);
		}

		protected void DeserializeNativeData(GraphSerializationContext ctx, bool normalsSerialized)
		{
			UpdateTransform();
			JobDependencyTracker obj = ObjectPool<JobDependencyTracker>.Claim();
			bool layeredDataLayout = this is LayerGridGraph;
			int3 int5 = new int3(width, LayerCount, depth);
			nodeData = GridGraphNodeData.ReadFromNodes(nodes, new Slice3D(int5, new IntBounds(0, int5)), default(JobHandle), default(NativeArray<float4>), Allocator.Persistent, layeredDataLayout, obj);
			nodeData.PersistBuffers(obj);
			DeserializeNodeSurfaceNormals(ctx, nodes, !normalsSerialized);
			obj.AllWritesDependency.Complete();
			ObjectPool<JobDependencyTracker>.Release(ref obj);
		}

		protected void SerializeNodeSurfaceNormals(GraphSerializationContext ctx)
		{
			UnsafeSpan<float4> unsafeSpan = nodeData.normals.AsUnsafeReadOnlySpan();
			for (int i = 0; i < nodes.Length; i++)
			{
				ctx.SerializeVector3(new Vector3(unsafeSpan[i].x, unsafeSpan[i].y, unsafeSpan[i].z));
			}
		}

		protected void DeserializeNodeSurfaceNormals(GraphSerializationContext ctx, GridNodeBase[] nodes, bool ignoreForCompatibility)
		{
			if (nodeData.normals.IsCreated)
			{
				nodeData.normals.Dispose();
			}
			nodeData.normals = new NativeArray<float4>(nodes.Length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			if (ignoreForCompatibility)
			{
				for (int i = 0; i < nodes.Length; i++)
				{
					nodeData.normals[i] = ((nodes[i] != null) ? new float4(0f, 1f, 0f, 0f) : float4.zero);
				}
				return;
			}
			for (int j = 0; j < nodes.Length; j++)
			{
				Vector3 vector = ctx.DeserializeVector3();
				nodeData.normals[j] = new float4(vector.x, vector.y, vector.z, 0f);
			}
		}

		private void HandleBackwardsCompatibility(GraphSerializationContext ctx)
		{
			if (ctx.meta.version <= AstarSerializer.V4_3_2)
			{
				maxStepUsesSlope = false;
			}
			if (penaltyPosition)
			{
				penaltyPosition = false;
				rules.AddRule(new RuleElevationPenalty
				{
					penaltyScale = 1000f * penaltyPositionFactor * 1000f,
					elevationRange = new Vector2((0f - penaltyPositionOffset) / 1000f, (0f - penaltyPositionOffset) / 1000f + 1000f),
					curve = AnimationCurve.Linear(0f, 0f, 1f, 1f)
				});
			}
			if (penaltyAngle)
			{
				penaltyAngle = false;
				AnimationCurve animationCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
				Keyframe[] array = new Keyframe[7];
				for (int i = 0; i < array.Length; i++)
				{
					float num = MathF.PI / 2f * (float)i / (float)(array.Length - 1);
					float value = (1f - Mathf.Pow(Mathf.Cos(num), penaltyAnglePower)) * penaltyAngleFactor;
					Keyframe keyframe = new Keyframe(57.29578f * num, value);
					array[i] = keyframe;
				}
				float num2 = array.Max((Keyframe k) => k.value);
				if (num2 > 0f)
				{
					for (int num3 = 0; num3 < array.Length; num3++)
					{
						array[num3].value /= num2;
					}
				}
				animationCurve.keys = array;
				for (int num4 = 0; num4 < array.Length; num4++)
				{
					animationCurve.SmoothTangents(num4, 0.5f);
				}
				rules.AddRule(new RuleAnglePenalty
				{
					penaltyScale = num2,
					curve = animationCurve
				});
			}
			if (textureData.enabled)
			{
				textureData.enabled = false;
				List<float> list = textureData.factors.Select((float x) => x / 255f).ToList();
				while (list.Count < 4)
				{
					list.Add(1000f);
				}
				List<RuleTexture.ChannelUse> list2 = textureData.channels.Cast<RuleTexture.ChannelUse>().ToList();
				while (list2.Count < 4)
				{
					list2.Add(RuleTexture.ChannelUse.None);
				}
				rules.AddRule(new RuleTexture
				{
					texture = textureData.source,
					channels = list2.ToArray(),
					channelScales = list.ToArray(),
					scalingMode = RuleTexture.ScalingMode.FixedScale,
					nodesPerPixel = 1f
				});
			}
		}

		protected override void PostDeserialization(GraphSerializationContext ctx)
		{
			HandleBackwardsCompatibility(ctx);
			UpdateTransform();
			SetUpOffsetsAndCosts();
			GridNode.SetGridGraph((int)graphIndex, this);
			if (nodes == null || nodes.Length == 0)
			{
				return;
			}
			if (width * depth != nodes.Length)
			{
				Debug.LogError("Node data did not match with bounds data. Probably a change to the bounds/width/depth data was made after scanning the graph just prior to saving it. Nodes will be discarded");
				nodes = new GridNodeBase[0];
				return;
			}
			for (int i = 0; i < depth; i++)
			{
				for (int j = 0; j < width; j++)
				{
					GridNodeBase gridNodeBase = nodes[i * width + j];
					if (gridNodeBase == null)
					{
						Debug.LogError("Deserialization Error : Couldn't cast the node to the appropriate type - GridGenerator");
						return;
					}
					gridNodeBase.NodeInGridIndex = i * width + j;
				}
			}
		}
	}
}
