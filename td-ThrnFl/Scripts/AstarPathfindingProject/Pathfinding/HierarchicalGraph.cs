using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Pathfinding.Drawing;
using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding
{
	public class HierarchicalGraph
	{
		public struct HierarhicalNodeData
		{
			[ReadOnly]
			public SlabAllocator<int> connectionAllocator;

			[ReadOnly]
			public NativeList<int> connectionAllocations;

			[ReadOnly]
			public NativeList<Bounds> bounds;
		}

		private struct JobRecalculateComponents : IJob
		{
			private struct Context
			{
				public List<GraphNode> children;

				public int hierarchicalNodeIndex;

				public List<int> connections;

				public uint graphindex;

				public Queue<GraphNode> queue;
			}

			public GCHandle hGraphGC;

			public NativeList<int> connectionAllocations;

			public NativeList<Bounds> bounds;

			public NativeList<int> dirtiedHierarchicalNodes;

			public NativeReference<int> numHierarchicalNodes;

			private void Grow(HierarchicalGraph graph)
			{
				List<GraphNode>[] array = new List<GraphNode>[Math.Max(64, graph.children.Length * 2)];
				int[] array2 = new int[array.Length];
				byte[] array3 = new byte[array.Length];
				int[] array4 = new int[array.Length];
				numHierarchicalNodes.Value = array.Length;
				graph.children.CopyTo(array, 0);
				graph.areas.CopyTo(array2, 0);
				graph.dirty.CopyTo(array3, 0);
				graph.versions.CopyTo(array4, 0);
				bounds.Resize(array.Length, NativeArrayOptions.UninitializedMemory);
				connectionAllocations.Resize(array.Length, NativeArrayOptions.ClearMemory);
				for (int num = array.Length - 1; num >= graph.children.Length; num--)
				{
					array[num] = ListPool<GraphNode>.Claim(256);
					connectionAllocations[num] = -2;
					if (num > 0)
					{
						graph.freeNodeIndices.PushEnd(num);
					}
				}
				connectionAllocations[0] = -2;
				graph.children = array;
				graph.areas = array2;
				graph.dirty = array3;
				graph.versions = array4;
			}

			private int GetHierarchicalNodeIndex(HierarchicalGraph graph)
			{
				if (graph.freeNodeIndices.Length == 0)
				{
					Grow(graph);
				}
				return graph.freeNodeIndices.PopEnd();
			}

			private void RemoveHierarchicalNode(HierarchicalGraph hGraph, int hierarchicalNode, bool removeAdjacentSmallNodes)
			{
				hGraph.freeNodeIndices.PushEnd(hierarchicalNode);
				hGraph.versions[hierarchicalNode]++;
				int allocatedIndex = connectionAllocations[hierarchicalNode];
				UnsafeSpan<int> span = hGraph.connectionAllocator.GetSpan(allocatedIndex);
				for (int i = 0; i < span.Length; i++)
				{
					int num = span[i];
					if (hGraph.dirty[num] == 0)
					{
						if (removeAdjacentSmallNodes && hGraph.children[num].Count < 128)
						{
							hGraph.dirty[num] = 2;
							RemoveHierarchicalNode(hGraph, num, removeAdjacentSmallNodes: false);
							span = hGraph.connectionAllocator.GetSpan(allocatedIndex);
						}
						else
						{
							SlabAllocator<int>.List list = hGraph.connectionAllocator.GetList(connectionAllocations[num]);
							list.Remove(hierarchicalNode);
							connectionAllocations[num] = list.allocationIndex;
						}
					}
				}
				hGraph.connectionAllocator.Free(allocatedIndex);
				connectionAllocations[hierarchicalNode] = -2;
				List<GraphNode> list2 = hGraph.children[hierarchicalNode];
				byte b = hGraph.dirty[hierarchicalNode];
				for (int j = 0; j < list2.Count; j++)
				{
					if (!list2[j].Destroyed)
					{
						hGraph.AddDirtyNode(list2[j]);
					}
				}
				hGraph.dirty[hierarchicalNode] = b;
				list2.ClearFast();
			}

			[Conditional("CHECK_INVARIANTS")]
			private void CheckConnectionInvariants()
			{
				HierarchicalGraph hierarchicalGraph = (HierarchicalGraph)hGraphGC.Target;
				_ = connectionAllocations.Length;
				_ = 0;
				for (int i = 0; i < connectionAllocations.Length; i++)
				{
					if (connectionAllocations[i] == -2)
					{
						continue;
					}
					UnsafeSpan<int> span = hierarchicalGraph.connectionAllocator.GetSpan(connectionAllocations[i]);
					for (int j = 0; j < span.Length; j++)
					{
						if (!hierarchicalGraph.connectionAllocator.GetSpan(connectionAllocations[span[j]]).Contains(i))
						{
							throw new Exception("Connections are not bidirectional");
						}
					}
				}
			}

			[Conditional("CHECK_INVARIANTS")]
			private void CheckPreUpdateInvariants()
			{
				HierarchicalGraph hierarchicalGraph = (HierarchicalGraph)hGraphGC.Target;
				_ = connectionAllocations.Length;
				_ = 0;
				for (int i = 0; i < connectionAllocations.Length; i++)
				{
					if (connectionAllocations[i] != -2)
					{
						List<GraphNode> list = hierarchicalGraph.children[i];
						for (int j = 0; j < list.Count; j++)
						{
							_ = list[j].Destroyed;
						}
					}
				}
			}

			[Conditional("CHECK_INVARIANTS")]
			private void CheckChildInvariants()
			{
				HierarchicalGraph hierarchicalGraph = (HierarchicalGraph)hGraphGC.Target;
				_ = connectionAllocations.Length;
				_ = 0;
				for (int i = 0; i < connectionAllocations.Length; i++)
				{
					if (connectionAllocations[i] != -2)
					{
						List<GraphNode> list = hierarchicalGraph.children[i];
						for (int j = 0; j < list.Count; j++)
						{
						}
					}
				}
			}

			private void FindHierarchicalNodeChildren(HierarchicalGraph hGraph, int hierarchicalNode, GraphNode startNode)
			{
				hGraph.versions[hierarchicalNode]++;
				Queue<GraphNode> temporaryQueue = hGraph.temporaryQueue;
				Context data = new Context
				{
					children = hGraph.children[hierarchicalNode],
					hierarchicalNodeIndex = hierarchicalNode,
					connections = hGraph.currentConnections,
					graphindex = startNode.GraphIndex,
					queue = temporaryQueue
				};
				data.connections.Clear();
				data.children.Add(startNode);
				data.queue.Enqueue(startNode);
				startNode.HierarchicalNodeIndex = hierarchicalNode;
				GraphNode.GetConnectionsWithData<Context> action = delegate(GraphNode neighbour, ref Context context)
				{
					if (neighbour.Destroyed)
					{
						throw new InvalidOperationException("A node in a " + AstarPath.active.graphs[context.graphindex].GetType().Name + " contained a connection to a destroyed " + neighbour.GetType().Name + ".");
					}
					int hierarchicalNodeIndex = neighbour.HierarchicalNodeIndex;
					if (hierarchicalNodeIndex == 0)
					{
						if (context.children.Count < 256 && neighbour.Walkable && neighbour.GraphIndex == context.graphindex)
						{
							neighbour.HierarchicalNodeIndex = context.hierarchicalNodeIndex;
							context.queue.Enqueue(neighbour);
							context.children.Add(neighbour);
						}
					}
					else if (hierarchicalNodeIndex != context.hierarchicalNodeIndex && !context.connections.Contains(hierarchicalNodeIndex))
					{
						context.connections.Add(hierarchicalNodeIndex);
					}
				};
				while (temporaryQueue.Count > 0)
				{
					temporaryQueue.Dequeue().GetConnections(action, ref data, 48);
				}
				if (hGraph.currentConnections.Count > 4096)
				{
					throw new Exception("Too many connections for a single hierarchical node. Do you have thousands of off-mesh links in a single location?");
				}
				for (int num = 0; num < hGraph.currentConnections.Count; num++)
				{
					int index = hGraph.currentConnections[num];
					int allocatedIndex = connectionAllocations[index];
					SlabAllocator<int>.List list = hGraph.connectionAllocator.GetList(allocatedIndex);
					list.Add(hierarchicalNode);
					connectionAllocations[index] = list.allocationIndex;
				}
				connectionAllocations[hierarchicalNode] = hGraph.connectionAllocator.Allocate(hGraph.currentConnections);
				temporaryQueue.Clear();
			}

			private void FloodFill(HierarchicalGraph hGraph)
			{
				int[] areas = hGraph.areas;
				for (int i = 0; i < areas.Length; i++)
				{
					areas[i] = 0;
				}
				Stack<int> temporaryStack = hGraph.temporaryStack;
				int num = 0;
				for (int j = 1; j < areas.Length; j++)
				{
					if (areas[j] != 0 || connectionAllocations[j] == -2)
					{
						continue;
					}
					num = (areas[j] = num + 1);
					temporaryStack.Push(j);
					while (temporaryStack.Count > 0)
					{
						int index = temporaryStack.Pop();
						UnsafeSpan<int> span = hGraph.connectionAllocator.GetSpan(connectionAllocations[index]);
						for (int num2 = span.Length - 1; num2 >= 0; num2--)
						{
							int num3 = span[num2];
							if (areas[num3] != num)
							{
								areas[num3] = num;
								temporaryStack.Push(num3);
							}
						}
					}
				}
				hGraph.NumConnectedComponents = Math.Max(1, num + 1);
				hGraph.version++;
			}

			public void Execute()
			{
				HierarchicalGraph hierarchicalGraph = hGraphGC.Target as HierarchicalGraph;
				byte[] dirty = hierarchicalGraph.dirty;
				int length = hierarchicalGraph.freeNodeIndices.Length;
				for (int i = 1; i < dirty.Length; i++)
				{
					if (dirty[i] == 1)
					{
						RemoveHierarchicalNode(hierarchicalGraph, i, removeAdjacentSmallNodes: true);
					}
				}
				for (int j = 1; j < dirty.Length; j++)
				{
					dirty[j] = 0;
				}
				NativeArray<int> arr = new NativeArray<int>(512, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
				GlobalNodeStorage nodeStorage = hierarchicalGraph.nodeStorage;
				foreach (UnsafeSpan<int> item in hierarchicalGraph.dirtyNodes.GetIterator(arr.AsUnsafeSpan()))
				{
					for (int k = 0; k < item.Length; k++)
					{
						GraphNode node = nodeStorage.GetNode((uint)item[k]);
						node.IsHierarchicalNodeDirty = false;
						node.HierarchicalNodeIndex = 0;
					}
				}
				dirtiedHierarchicalNodes.Clear();
				foreach (UnsafeSpan<int> item2 in hierarchicalGraph.dirtyNodes.GetIterator(arr.AsUnsafeSpan()))
				{
					for (int l = 0; l < item2.Length; l++)
					{
						GraphNode node2 = nodeStorage.GetNode((uint)item2[l]);
						if (!node2.Destroyed && node2.HierarchicalNodeIndex == 0 && node2.Walkable)
						{
							int value = GetHierarchicalNodeIndex(hierarchicalGraph);
							FindHierarchicalNodeChildren(hierarchicalGraph, value, node2);
							dirtiedHierarchicalNodes.Add(in value);
						}
					}
				}
				for (int m = length; m < hierarchicalGraph.freeNodeIndices.Length; m++)
				{
					dirtiedHierarchicalNodes.Add(hierarchicalGraph.freeNodeIndices[m]);
				}
				hierarchicalGraph.dirtyNodes.Clear();
				FloodFill(hierarchicalGraph);
				hierarchicalGraph.gizmoVersion++;
			}
		}

		private const int Tiling = 16;

		private const int MaxChildrenPerNode = 256;

		private const int MinChildrenPerNode = 128;

		private GlobalNodeStorage nodeStorage;

		internal List<GraphNode>[] children;

		internal NativeList<int> connectionAllocations;

		internal SlabAllocator<int> connectionAllocator;

		private NativeList<int> dirtiedHierarchicalNodes;

		private int[] areas;

		private byte[] dirty;

		private int[] versions;

		internal NativeList<Bounds> bounds;

		private NativeReference<int> numHierarchicalNodes;

		internal GCHandle gcHandle;

		public NavmeshEdges navmeshEdges;

		private Queue<GraphNode> temporaryQueue = new Queue<GraphNode>();

		private List<int> currentConnections = new List<int>();

		private Stack<int> temporaryStack = new Stack<int>();

		private HierarchicalBitset dirtyNodes;

		private CircularBuffer<int> freeNodeIndices;

		private int gizmoVersion;

		private RWLock rwLock = new RWLock();

		public int version { get; private set; }

		public int NumConnectedComponents { get; private set; }

		internal void OnDisable()
		{
			rwLock.WriteSync().Unlock();
			navmeshEdges.Dispose();
			if (gcHandle.IsAllocated)
			{
				gcHandle.Free();
			}
			if (connectionAllocator.IsCreated)
			{
				numHierarchicalNodes.Dispose();
				connectionAllocator.Dispose();
				connectionAllocations.Dispose();
				bounds.Dispose();
				dirtiedHierarchicalNodes.Dispose();
				dirtyNodes.Dispose();
				children = null;
				areas = null;
				dirty = null;
				versions = null;
				freeNodeIndices.Clear();
			}
		}

		public int GetHierarchicalNodeVersion(int index)
		{
			return (index * 71237) ^ versions[index];
		}

		public HierarhicalNodeData GetHierarhicalNodeData(out RWLock.ReadLockAsync readLock)
		{
			readLock = rwLock.Read();
			return new HierarhicalNodeData
			{
				connectionAllocator = connectionAllocator,
				connectionAllocations = connectionAllocations,
				bounds = bounds
			};
		}

		internal HierarchicalGraph(GlobalNodeStorage nodeStorage)
		{
			this.nodeStorage = nodeStorage;
			navmeshEdges = new NavmeshEdges();
			navmeshEdges.hierarchicalGraph = this;
		}

		public void OnEnable()
		{
			if (!connectionAllocator.IsCreated)
			{
				gcHandle = GCHandle.Alloc(this);
				connectionAllocator = new SlabAllocator<int>(1024, Allocator.Persistent);
				connectionAllocations = new NativeList<int>(0, Allocator.Persistent);
				bounds = new NativeList<Bounds>(0, Allocator.Persistent);
				numHierarchicalNodes = new NativeReference<int>(0, Allocator.Persistent);
				dirtiedHierarchicalNodes = new NativeList<int>(0, Allocator.Persistent);
				dirtyNodes = new HierarchicalBitset(1024, Allocator.Persistent);
				children = new List<GraphNode>[1]
				{
					new List<GraphNode>()
				};
				areas = new int[1];
				dirty = new byte[1];
				versions = new int[1];
				freeNodeIndices.Clear();
			}
		}

		internal void OnCreatedNode(GraphNode node)
		{
			AddDirtyNode(node);
		}

		internal void OnDestroyedNode(GraphNode node)
		{
			dirty[node.HierarchicalNodeIndex] = 1;
			dirtyNodes.Reset((int)node.NodeIndex);
			node.IsHierarchicalNodeDirty = false;
		}

		public void AddDirtyNode(GraphNode node)
		{
			if (!node.IsHierarchicalNodeDirty && dirtyNodes.IsCreated && !node.Destroyed)
			{
				dirtyNodes.Set((int)node.NodeIndex);
				dirty[node.HierarchicalNodeIndex] = 1;
				node.IsHierarchicalNodeDirty = true;
			}
		}

		public void ReserveNodeIndices(uint nodeIndexCount)
		{
			dirtyNodes.Capacity = Mathf.Max(dirtyNodes.Capacity, (int)nodeIndexCount);
		}

		public uint GetConnectedComponent(int hierarchicalNodeIndex)
		{
			return (uint)areas[hierarchicalNodeIndex];
		}

		public void RecalculateIfNecessary()
		{
			JobRecalculateIfNecessary().Complete();
		}

		public JobHandle JobRecalculateIfNecessary(JobHandle dependsOn = default(JobHandle))
		{
			OnEnable();
			if (!dirtyNodes.IsEmpty)
			{
				RWLock.WriteLockAsync writeLockAsync = rwLock.Write();
				JobHandle dependency = new JobRecalculateComponents
				{
					hGraphGC = gcHandle,
					connectionAllocations = connectionAllocations,
					bounds = bounds,
					dirtiedHierarchicalNodes = dirtiedHierarchicalNodes,
					numHierarchicalNodes = numHierarchicalNodes
				}.Schedule(JobHandle.CombineDependencies(writeLockAsync.dependency, dependsOn));
				dependency = navmeshEdges.RecalculateObstacles(dirtiedHierarchicalNodes, numHierarchicalNodes, dependency);
				writeLockAsync.UnlockAfter(dependency);
				return dependency;
			}
			return dependsOn;
		}

		public void RecalculateAll()
		{
			RWLock.LockSync lockSync = rwLock.WriteSync();
			AstarPath.active.data.GetNodes(AddDirtyNode);
			lockSync.Unlock();
			RecalculateIfNecessary();
		}

		public void OnDrawGizmos(DrawingData gizmos, RedrawScope redrawScope)
		{
			NodeHasher nodeHasher = new NodeHasher(AstarPath.active);
			nodeHasher.Add(gizmoVersion);
			if (gizmos.Draw(nodeHasher, redrawScope))
			{
				return;
			}
			RWLock.LockSync lockSync = rwLock.ReadSync();
			try
			{
				using CommandBuilder commandBuilder = gizmos.GetBuilder(nodeHasher, redrawScope);
				for (int i = 0; i < areas.Length; i++)
				{
					if (children[i].Count <= 0)
					{
						continue;
					}
					commandBuilder.WireBox(bounds[i].center, bounds[i].size);
					UnsafeSpan<int> span = connectionAllocator.GetSpan(connectionAllocations[i]);
					for (int j = 0; j < span.Length; j++)
					{
						if (span[j] > i)
						{
							commandBuilder.Line(bounds[i].center, bounds[span[j]].center, Color.black);
						}
					}
				}
			}
			finally
			{
				lockSync.Unlock();
			}
		}
	}
}
