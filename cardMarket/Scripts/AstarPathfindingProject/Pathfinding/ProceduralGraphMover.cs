using System;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Procedural Graph Mover")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/proceduralgraphmover.html")]
	public class ProceduralGraphMover : VersionedMonoBehaviour
	{
		public float updateDistance = 10f;

		public Transform target;

		public NavGraph graph;

		[HideInInspector]
		public int graphIndex;

		public bool updatingGraph { get; private set; }

		private void Start()
		{
			if (AstarPath.active == null)
			{
				throw new Exception("There is no AstarPath object in the scene");
			}
			if (graph == null)
			{
				if (graphIndex < 0)
				{
					throw new Exception("Graph index should not be negative");
				}
				if (graphIndex >= AstarPath.active.data.graphs.Length)
				{
					throw new Exception("The ProceduralGraphMover was configured to use graph index " + graphIndex + ", but only " + AstarPath.active.data.graphs.Length + " graphs exist");
				}
				graph = AstarPath.active.data.graphs[graphIndex];
				if (!(graph is GridGraph) && !(graph is RecastGraph))
				{
					throw new Exception("The ProceduralGraphMover was configured to use graph index " + graphIndex + " but that graph either does not exist or is not a GridGraph, LayerGridGraph or RecastGraph");
				}
				if (graph is RecastGraph { useTiles: false })
				{
					Debug.LogWarning("The ProceduralGraphMover component only works with tiled recast graphs. Enable tiling in the recast graph inspector.", this);
				}
			}
			UpdateGraph();
		}

		private void OnDisable()
		{
			if (AstarPath.active != null)
			{
				AstarPath.active.FlushWorkItems();
			}
			updatingGraph = false;
		}

		private void Update()
		{
			if (AstarPath.active == null || graph == null || !graph.isScanned)
			{
				return;
			}
			if (graph is GridGraph gridGraph)
			{
				Vector3 a = gridGraph.transform.InverseTransform(gridGraph.center);
				Vector3 b = gridGraph.transform.InverseTransform(target.position);
				if (VectorMath.SqrDistanceXZ(a, b) > updateDistance * updateDistance)
				{
					UpdateGraph();
				}
			}
			else
			{
				if (!(graph is RecastGraph))
				{
					throw new Exception("ProceduralGraphMover cannot be used with graphs of type " + graph.GetType().Name);
				}
				UpdateGraph();
			}
		}

		public void UpdateGraph(bool async = true)
		{
			if (!base.enabled)
			{
				throw new InvalidOperationException("This component has been disabled");
			}
			if (updatingGraph)
			{
				return;
			}
			if (graph is GridGraph gridGraph)
			{
				UpdateGridGraph(gridGraph, async);
			}
			else if (graph is RecastGraph recastGraph)
			{
				Int2 delta = RecastGraphTileShift(recastGraph, target.position);
				if (delta.x != 0 || delta.y != 0)
				{
					updatingGraph = true;
					UpdateRecastGraph(recastGraph, delta, async);
				}
			}
		}

		private void UpdateGridGraph(GridGraph graph, bool async)
		{
			updatingGraph = true;
			List<(IGraphUpdatePromise, IEnumerator<JobHandle>)> promises = new List<(IGraphUpdatePromise, IEnumerator<JobHandle>)>();
			AstarPath.active.AddWorkItem(new AstarWorkItem(delegate
			{
				Vector3 vector = graph.transform.InverseTransformVector(target.position - graph.center);
				int num = Mathf.RoundToInt(vector.x);
				int num2 = Mathf.RoundToInt(vector.z);
				if (num != 0 || num2 != 0)
				{
					IGraphUpdatePromise graphUpdatePromise = graph.TranslateInDirection(num, num2);
					promises.Add((graphUpdatePromise, graphUpdatePromise.Prepare()));
				}
			}, delegate(IWorkItemContext ctx, bool force)
			{
				if (GraphUpdateProcessor.ProcessGraphUpdatePromises(promises, ctx, force))
				{
					updatingGraph = false;
					return true;
				}
				return false;
			}));
			if (!async)
			{
				AstarPath.active.FlushWorkItems();
			}
		}

		private static Int2 RecastGraphTileShift(RecastGraph graph, Vector3 targetCenter)
		{
			Vector3 vector = graph.transform.InverseTransform(targetCenter) - graph.transform.InverseTransform(graph.forcedBoundsCenter);
			if (Mathf.Abs(vector.x) > Mathf.Abs(vector.z))
			{
				vector.z = 0f;
			}
			else
			{
				vector.x = 0f;
			}
			return new Int2((int)(Mathf.Max(0f, Mathf.Abs(vector.x) / graph.TileWorldSizeX + 0.5f - 0.2f) * Mathf.Sign(vector.x)), (int)(Mathf.Max(0f, Mathf.Abs(vector.z) / graph.TileWorldSizeZ + 0.5f - 0.2f) * Mathf.Sign(vector.z)));
		}

		private void UpdateRecastGraph(RecastGraph graph, Int2 delta, bool async)
		{
			updatingGraph = true;
			List<(IGraphUpdatePromise, IEnumerator<JobHandle>)> promises = new List<(IGraphUpdatePromise, IEnumerator<JobHandle>)>();
			AstarPath.active.AddWorkItem(new AstarWorkItem(delegate
			{
				IGraphUpdatePromise graphUpdatePromise = graph.TranslateInDirection(delta.x, delta.y);
				promises.Add((graphUpdatePromise, graphUpdatePromise.Prepare()));
			}, delegate(IWorkItemContext ctx, bool force)
			{
				if (GraphUpdateProcessor.ProcessGraphUpdatePromises(promises, ctx, force))
				{
					updatingGraph = false;
					return true;
				}
				return false;
			}));
			if (!async)
			{
				AstarPath.active.FlushWorkItems();
			}
		}
	}
}
