using System.Collections.Generic;
using System.Runtime.InteropServices;
using Pathfinding.Graphs.Navmesh;
using Pathfinding.Graphs.Navmesh.Jobs;
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
	public class NavMeshGraph : NavmeshBase, IUpdatableGraph
	{
		private class NavMeshGraphUpdatePromise : IGraphUpdatePromise
		{
			public NavMeshGraph graph;

			public List<GraphUpdateObject> graphUpdates;

			public void Apply(IGraphUpdateContext ctx)
			{
				for (int i = 0; i < graphUpdates.Count; i++)
				{
					GraphUpdateObject graphUpdateObject = graphUpdates[i];
					UpdateArea(graphUpdateObject, graph);
					ctx.DirtyBounds(graphUpdateObject.bounds);
				}
			}
		}

		private class NavMeshGraphScanPromise : IGraphUpdatePromise
		{
			public NavMeshGraph graph;

			private bool emptyGraph;

			private GraphTransform transform;

			private NavmeshTile[] tiles;

			private Vector3 forcedBoundsSize;

			private IntRect tileRect;

			public IEnumerator<JobHandle> Prepare()
			{
				Mesh sourceMesh = graph.sourceMesh;
				graph.cachedSourceMeshBoundsMin = ((sourceMesh != null) ? sourceMesh.bounds.min : Vector3.zero);
				transform = graph.CalculateTransform();
				if (sourceMesh == null)
				{
					emptyGraph = true;
					yield break;
				}
				if (!sourceMesh.isReadable)
				{
					Debug.LogError("The source mesh " + sourceMesh.name + " is not readable. Enable Read/Write in the mesh's import settings.", sourceMesh);
					emptyGraph = true;
					yield break;
				}
				Mesh.MeshDataArray meshData = Mesh.AcquireReadOnlyMeshData(sourceMesh);
				MeshUtility.GetMeshData(meshData, 0, out var vertices, out var indices);
				meshData.Dispose();
				Matrix4x4 meshToGraph = Matrix4x4.TRS(-sourceMesh.bounds.min * graph.scale, Quaternion.identity, Vector3.one * graph.scale);
				Promise<JobBuildTileMeshFromVertices.BuildNavmeshOutput> promise = JobBuildTileMeshFromVertices.Schedule(vertices, indices, meshToGraph, graph.RecalculateNormals);
				forcedBoundsSize = sourceMesh.bounds.size * graph.scale;
				tileRect = new IntRect(0, 0, 0, 0);
				tiles = new NavmeshTile[tileRect.Area];
				GCHandle tilesGCHandle = GCHandle.Alloc(tiles);
				Vector2 tileWorldSize = new Vector2(forcedBoundsSize.x, forcedBoundsSize.z);
				NativeArray<JobCalculateTriangleConnections.TileNodeConnectionsUnsafe> tileNodeConnections = new NativeArray<JobCalculateTriangleConnections.TileNodeConnectionsUnsafe>(tiles.Length, Allocator.Persistent);
				JobHandle job = IJobExtensions.Schedule(new JobCalculateTriangleConnections
				{
					tileMeshes = promise.GetValue().tiles,
					nodeConnections = tileNodeConnections
				}, promise.handle);
				JobHandle job2 = IJobExtensions.Schedule(new JobCreateTiles
				{
					tileMeshes = promise.GetValue().tiles,
					tiles = tilesGCHandle,
					tileRect = tileRect,
					graphTileCount = new Int2(tileRect.Width, tileRect.Height),
					graphIndex = graph.graphIndex,
					initialPenalty = graph.initialPenalty,
					recalculateNormals = graph.recalculateNormals,
					graphToWorldSpace = transform.matrix,
					tileWorldSize = tileWorldSize
				}, promise.handle);
				yield return IJobExtensions.Schedule(new JobWriteNodeConnections
				{
					tiles = tilesGCHandle,
					nodeConnections = tileNodeConnections
				}, JobHandle.CombineDependencies(job2, job));
				promise.Complete().Dispose();
				tileNodeConnections.Dispose();
				vertices.Dispose();
				indices.Dispose();
				tilesGCHandle.Free();
			}

			public void Apply(IGraphUpdateContext ctx)
			{
				if (emptyGraph)
				{
					graph.forcedBoundsSize = Vector3.zero;
					graph.transform = transform;
					graph.tileZCount = (graph.tileXCount = 1);
					TriangleMeshNode.SetNavmeshHolder(AstarPath.active.data.GetGraphIndex(graph), graph);
					graph.FillWithEmptyTiles();
					return;
				}
				graph.DestroyAllNodes();
				for (int i = 0; i < tiles.Length; i++)
				{
					AstarPath active = AstarPath.active;
					GraphNode[] nodes = tiles[i].nodes;
					active.InitializeNodes(nodes);
				}
				graph.forcedBoundsSize = forcedBoundsSize;
				graph.transform = transform;
				graph.tileXCount = tileRect.Width;
				graph.tileZCount = tileRect.Height;
				graph.tiles = tiles;
				TriangleMeshNode.SetNavmeshHolder(graph.active.data.GetGraphIndex(graph), graph);
				graph.navmeshUpdateData.OnRecalculatedTiles(tiles);
				if (graph.OnRecalculatedTiles != null)
				{
					graph.OnRecalculatedTiles(tiles.Clone() as NavmeshTile[]);
				}
			}
		}

		[JsonMember]
		public Mesh sourceMesh;

		[JsonMember]
		public Vector3 offset;

		[JsonMember]
		public Vector3 rotation;

		[JsonMember]
		public float scale = 1f;

		[JsonMember]
		public bool recalculateNormals = true;

		[JsonMember]
		private Vector3 cachedSourceMeshBoundsMin;

		[JsonMember]
		public float navmeshCuttingCharacterRadius = 0.5f;

		public override float NavmeshCuttingCharacterRadius => navmeshCuttingCharacterRadius;

		public override bool RecalculateNormals => recalculateNormals;

		public override float TileWorldSizeX => forcedBoundsSize.x;

		public override float TileWorldSizeZ => forcedBoundsSize.z;

		public override float MaxTileConnectionEdgeDistance => 0f;

		public override Bounds bounds
		{
			get
			{
				if (sourceMesh == null)
				{
					return default(Bounds);
				}
				float4x4 float4x5 = CalculateTransform().matrix;
				return new ToWorldMatrix(new float3x3(float4x5.c0.xyz, float4x5.c1.xyz, float4x5.c2.xyz)).ToWorld(new Bounds(Vector3.zero, sourceMesh.bounds.size * scale));
			}
		}

		public override bool IsInsideBounds(Vector3 point)
		{
			if (tiles == null || tiles.Length == 0 || sourceMesh == null)
			{
				return false;
			}
			Vector3 vector = transform.InverseTransform(point);
			Vector3 vector2 = sourceMesh.bounds.size * scale;
			if (vector.x >= -0.0001f && vector.y >= -0.0001f && vector.z >= -0.0001f && vector.x <= vector2.x + 0.0001f && vector.y <= vector2.y + 0.0001f)
			{
				return vector.z <= vector2.z + 0.0001f;
			}
			return false;
		}

		public override GraphTransform CalculateTransform()
		{
			return new GraphTransform(Matrix4x4.TRS(offset, Quaternion.Euler(rotation), Vector3.one) * Matrix4x4.TRS((sourceMesh != null) ? (sourceMesh.bounds.min * scale) : (cachedSourceMeshBoundsMin * scale), Quaternion.identity, Vector3.one));
		}

		IGraphUpdatePromise IUpdatableGraph.ScheduleGraphUpdates(List<GraphUpdateObject> graphUpdates)
		{
			return new NavMeshGraphUpdatePromise
			{
				graph = this,
				graphUpdates = graphUpdates
			};
		}

		public static void UpdateArea(GraphUpdateObject o, INavmeshHolder graph)
		{
			Bounds bounds = graph.transform.InverseTransform(o.bounds);
			IntRect irect = new IntRect(Mathf.FloorToInt(bounds.min.x * 1000f), Mathf.FloorToInt(bounds.min.z * 1000f), Mathf.CeilToInt(bounds.max.x * 1000f), Mathf.CeilToInt(bounds.max.z * 1000f));
			Int3 a = new Int3(irect.xmin, 0, irect.ymin);
			Int3 b = new Int3(irect.xmin, 0, irect.ymax);
			Int3 c = new Int3(irect.xmax, 0, irect.ymin);
			Int3 d = new Int3(irect.xmax, 0, irect.ymax);
			int ymin = ((Int3)bounds.min).y;
			int ymax = ((Int3)bounds.max).y;
			graph.GetNodes(delegate(GraphNode _node)
			{
				TriangleMeshNode triangleMeshNode = _node as TriangleMeshNode;
				bool flag = false;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				for (int i = 0; i < 3; i++)
				{
					Int3 vertexInGraphSpace = triangleMeshNode.GetVertexInGraphSpace(i);
					if (irect.Contains(vertexInGraphSpace.x, vertexInGraphSpace.z))
					{
						flag = true;
						break;
					}
					if (vertexInGraphSpace.x < irect.xmin)
					{
						num++;
					}
					if (vertexInGraphSpace.x > irect.xmax)
					{
						num2++;
					}
					if (vertexInGraphSpace.z < irect.ymin)
					{
						num3++;
					}
					if (vertexInGraphSpace.z > irect.ymax)
					{
						num4++;
					}
				}
				if (flag || (num != 3 && num2 != 3 && num3 != 3 && num4 != 3))
				{
					for (int j = 0; j < 3; j++)
					{
						int i2 = ((j <= 1) ? (j + 1) : 0);
						Int3 vertexInGraphSpace2 = triangleMeshNode.GetVertexInGraphSpace(j);
						Int3 vertexInGraphSpace3 = triangleMeshNode.GetVertexInGraphSpace(i2);
						if (VectorMath.SegmentsIntersectXZ(a, b, vertexInGraphSpace2, vertexInGraphSpace3))
						{
							flag = true;
							break;
						}
						if (VectorMath.SegmentsIntersectXZ(a, c, vertexInGraphSpace2, vertexInGraphSpace3))
						{
							flag = true;
							break;
						}
						if (VectorMath.SegmentsIntersectXZ(c, d, vertexInGraphSpace2, vertexInGraphSpace3))
						{
							flag = true;
							break;
						}
						if (VectorMath.SegmentsIntersectXZ(d, b, vertexInGraphSpace2, vertexInGraphSpace3))
						{
							flag = true;
							break;
						}
					}
					if (flag || triangleMeshNode.ContainsPointInGraphSpace(a) || triangleMeshNode.ContainsPointInGraphSpace(b) || triangleMeshNode.ContainsPointInGraphSpace(c) || triangleMeshNode.ContainsPointInGraphSpace(d))
					{
						flag = true;
					}
					if (flag)
					{
						int num5 = 0;
						int num6 = 0;
						for (int k = 0; k < 3; k++)
						{
							Int3 vertexInGraphSpace4 = triangleMeshNode.GetVertexInGraphSpace(k);
							if (vertexInGraphSpace4.y < ymin)
							{
								num6++;
							}
							if (vertexInGraphSpace4.y > ymax)
							{
								num5++;
							}
						}
						if (num6 != 3 && num5 != 3)
						{
							o.WillUpdateNode(triangleMeshNode);
							o.Apply(triangleMeshNode);
						}
					}
				}
			});
		}

		protected override IGraphUpdatePromise ScanInternal(bool async)
		{
			return new NavMeshGraphScanPromise
			{
				graph = this
			};
		}

		protected override void PostDeserialization(GraphSerializationContext ctx)
		{
			if (ctx.meta.version < AstarSerializer.V4_3_74)
			{
				navmeshCuttingCharacterRadius = 0f;
			}
			base.PostDeserialization(ctx);
		}
	}
}
