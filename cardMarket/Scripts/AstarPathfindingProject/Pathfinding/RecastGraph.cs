using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Pathfinding.Graphs.Navmesh;
using Pathfinding.Graphs.Navmesh.Jobs;
using Pathfinding.Jobs;
using Pathfinding.Serialization;
using Pathfinding.Util;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	[JsonOptIn]
	[Preserve]
	public class RecastGraph : NavmeshBase, IUpdatableGraph
	{
		public enum RelevantGraphSurfaceMode
		{
			DoNotRequire = 0,
			OnlyForCompletelyInsideTile = 1,
			RequireForAll = 2
		}

		public enum DimensionMode
		{
			Dimension2D = 0,
			Dimension3D = 1
		}

		public enum BackgroundTraversability
		{
			Walkable = 0,
			Unwalkable = 1
		}

		[Serializable]
		public struct PerLayerModification
		{
			public int layer;

			public RecastMeshObj.Mode mode;

			public int surfaceID;

			public static PerLayerModification Default => new PerLayerModification
			{
				layer = 0,
				mode = RecastMeshObj.Mode.WalkableSurface,
				surfaceID = 1
			};

			public static PerLayerModification[] ToLayerLookup(List<PerLayerModification> perLayerModifications, PerLayerModification defaultValue)
			{
				PerLayerModification[] array = new PerLayerModification[32];
				int num = 0;
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = defaultValue;
					array[i].layer = i;
				}
				for (int j = 0; j < perLayerModifications.Count; j++)
				{
					if (perLayerModifications[j].layer < 0 || perLayerModifications[j].layer >= 32)
					{
						Debug.LogError("Layer " + perLayerModifications[j].layer + " is out of range. Layers must be in the range [0...31]");
						continue;
					}
					if ((num & (1 << perLayerModifications[j].layer)) != 0)
					{
						Debug.LogError("Several per layer modifications refer to the same layer '" + LayerMask.LayerToName(perLayerModifications[j].layer) + "'");
						continue;
					}
					num |= 1 << perLayerModifications[j].layer;
					array[perLayerModifications[j].layer] = perLayerModifications[j];
				}
				return array;
			}
		}

		[Serializable]
		public class CollectionSettings
		{
			public enum FilterMode
			{
				Layers = 0,
				Tags = 1
			}

			public FilterMode collectionMode;

			public LayerMask layerMask = -1;

			public List<string> tagMask = new List<string>();

			public bool rasterizeColliders;

			public bool rasterizeMeshes = true;

			public bool rasterizeTerrain = true;

			public bool rasterizeTrees = true;

			public int terrainHeightmapDownsamplingFactor = 3;

			public float colliderRasterizeDetail = 1f;

			public Action<RecastMeshGatherer> onCollectMeshes;
		}

		private class RecastGraphUpdatePromise : IGraphUpdatePromise
		{
			public List<(Promise<TileBuilder.TileBuilderOutput>, Promise<JobBuildNodes.BuildNodeTilesOutput>)> promises;

			public List<GraphUpdateObject> graphUpdates;

			public RecastGraph graph;

			private int graphHash;

			public RecastGraphUpdatePromise(RecastGraph graph, List<GraphUpdateObject> graphUpdates)
			{
				promises = ListPool<(Promise<TileBuilder.TileBuilderOutput>, Promise<JobBuildNodes.BuildNodeTilesOutput>)>.Claim();
				this.graph = graph;
				graphHash = HashSettings(graph);
				List<(IntRect, GraphUpdateObject)> list = ListPool<(IntRect, GraphUpdateObject)>.Claim();
				for (int num = graphUpdates.Count - 1; num >= 0; num--)
				{
					GraphUpdateObject graphUpdateObject = graphUpdates[num];
					if (graphUpdateObject.updatePhysics)
					{
						graphUpdates.RemoveAt(num);
						IntRect touchingTiles = graph.GetTouchingTiles(graphUpdateObject.bounds, graph.TileBorderSizeInWorldUnits);
						if (touchingTiles.IsValid())
						{
							list.Add((touchingTiles, graphUpdateObject));
						}
					}
				}
				this.graphUpdates = graphUpdates;
				if (list.Count > 1)
				{
					list.Sort(((IntRect, GraphUpdateObject) a, (IntRect, GraphUpdateObject) b) => b.Item1.Area.CompareTo(a.Item1.Area));
				}
				for (int num2 = 0; num2 < list.Count; num2++)
				{
					IntRect item = list[num2].Item1;
					if (list.Count > 1)
					{
						bool flag = false;
						for (int num3 = item.ymin; num3 <= item.ymax; num3++)
						{
							for (int num4 = item.xmin; num4 <= item.xmax; num4++)
							{
								NavmeshTile tile = graph.GetTile(num4, num3);
								flag |= !tile.flag;
								tile.flag = true;
							}
						}
						if (!flag)
						{
							continue;
						}
					}
					TileLayout tileLayout = new TileLayout(graph);
					Promise<TileBuilder.TileBuilderOutput> promise = RecastBuilder.BuildTileMeshes(graph, tileLayout, item).Schedule(graph.pendingGraphUpdateArena);
					Promise<JobBuildNodes.BuildNodeTilesOutput> item2 = RecastBuilder.BuildNodeTiles(graph, tileLayout).Schedule(graph.pendingGraphUpdateArena, promise);
					promises.Add((promise, item2));
				}
				if (list.Count > 1)
				{
					for (int num5 = 0; num5 < list.Count; num5++)
					{
						IntRect item3 = list[num5].Item1;
						for (int num6 = item3.ymin; num6 <= item3.ymax; num6++)
						{
							for (int num7 = item3.xmin; num7 <= item3.xmax; num7++)
							{
								graph.GetTile(num7, num6).flag = false;
							}
						}
					}
				}
				ListPool<(IntRect, GraphUpdateObject)>.Release(ref list);
			}

			public IEnumerator<JobHandle> Prepare()
			{
				for (int i = 0; i < promises.Count; i++)
				{
					yield return promises[i].Item2.handle;
					yield return promises[i].Item1.handle;
				}
			}

			private static int HashSettings(RecastGraph graph)
			{
				return (((graph.tileXCount * 31) ^ graph.tileZCount) * 31) ^ (graph.TileWorldSizeX.GetHashCode() * 31) ^ graph.TileWorldSizeZ.GetHashCode();
			}

			public void Apply(IGraphUpdateContext ctx)
			{
				if (HashSettings(graph) != graphHash)
				{
					throw new InvalidOperationException("Recast graph changed while a graph update was in progress. This is not allowed. Use AstarPath.active.AddWorkItem if you need to update graphs.");
				}
				for (int i = 0; i < promises.Count; i++)
				{
					Promise<TileBuilder.TileBuilderOutput> item = promises[i].Item1;
					Promise<JobBuildNodes.BuildNodeTilesOutput> item2 = promises[i].Item2;
					JobBuildNodes.BuildNodeTilesOutput buildNodeTilesOutput = item2.Complete();
					IntRect tileRect = buildNodeTilesOutput.dependency.tileMeshes.tileRect;
					NavmeshTile[] tiles = buildNodeTilesOutput.tiles;
					item.Dispose();
					item2.Dispose();
					for (int j = 0; j < tiles.Length; j++)
					{
						AstarPath active = AstarPath.active;
						GraphNode[] nodes = tiles[j].nodes;
						active.InitializeNodes(nodes);
					}
					graph.StartBatchTileUpdate();
					for (int k = 0; k < tileRect.Height; k++)
					{
						for (int l = 0; l < tileRect.Width; l++)
						{
							int num = (k + tileRect.ymin) * graph.tileXCount + (l + tileRect.xmin);
							graph.ClearTile(l + tileRect.xmin, k + tileRect.ymin);
							NavmeshTile navmeshTile = tiles[k * tileRect.Width + l];
							navmeshTile.graph = graph;
							graph.tiles[num] = navmeshTile;
						}
					}
					graph.EndBatchTileUpdate();
					GCHandle tilesHandle = GCHandle.Alloc(graph.tiles);
					JobConnectTiles.ScheduleRecalculateBorders(tileRect: new IntRect(0, 0, graph.tileXCount - 1, graph.tileZCount - 1), tilesHandle: tilesHandle, dependency: default(JobHandle), innerRect: tileRect, tileWorldSize: new Vector2(graph.TileWorldSizeX, graph.TileWorldSizeZ), maxTileConnectionEdgeDistance: graph.MaxTileConnectionEdgeDistance).Complete();
					tilesHandle.Free();
					graph.navmeshUpdateData.OnRecalculatedTiles(tiles);
					if (graph.OnRecalculatedTiles != null)
					{
						graph.OnRecalculatedTiles(tiles);
					}
					ctx.DirtyBounds(graph.GetTileBounds(tileRect));
				}
				graph.pendingGraphUpdateArena.DisposeAll();
				if (graphUpdates == null)
				{
					return;
				}
				for (int m = 0; m < graphUpdates.Count; m++)
				{
					GraphUpdateObject graphUpdateObject = graphUpdates[m];
					IntRect touchingTiles = graph.GetTouchingTiles(graphUpdateObject.bounds, graph.TileBorderSizeInWorldUnits);
					if (!touchingTiles.IsValid())
					{
						continue;
					}
					for (int n = touchingTiles.ymin; n <= touchingTiles.ymax; n++)
					{
						for (int num2 = touchingTiles.xmin; num2 <= touchingTiles.xmax; num2++)
						{
							NavmeshTile navmeshTile2 = graph.tiles[n * graph.tileXCount + num2];
							NavMeshGraph.UpdateArea(graphUpdateObject, navmeshTile2);
						}
					}
					ctx.DirtyBounds(graph.GetTileBounds(touchingTiles));
				}
			}
		}

		private class RecastGraphScanPromise : IGraphUpdatePromise
		{
			public RecastGraph graph;

			private TileLayout tileLayout;

			private bool emptyGraph;

			private NavmeshTile[] tiles;

			private IProgress progressSource;

			public float Progress
			{
				get
				{
					if (progressSource == null)
					{
						return 1f;
					}
					return progressSource.Progress;
				}
			}

			public IEnumerator<JobHandle> Prepare()
			{
				TriangleMeshNode.SetNavmeshHolder(AstarPath.active.data.GetGraphIndex(graph), graph);
				if (!Application.isPlaying)
				{
					RelevantGraphSurface.FindAllGraphSurfaces();
				}
				RelevantGraphSurface.UpdateAllPositions();
				tileLayout = new TileLayout(graph);
				if (graph.scanEmptyGraph || tileLayout.tileCount.x * tileLayout.tileCount.y <= 0)
				{
					emptyGraph = true;
					yield break;
				}
				DisposeArena arena = new DisposeArena();
				Promise<TileBuilder.TileBuilderOutput> tileMeshesPromise = RecastBuilder.BuildTileMeshes(graph, tileLayout, new IntRect(0, 0, tileLayout.tileCount.x - 1, tileLayout.tileCount.y - 1)).Schedule(arena);
				Promise<JobBuildNodes.BuildNodeTilesOutput> tilesPromise = RecastBuilder.BuildNodeTiles(graph, tileLayout).Schedule(arena, tileMeshesPromise);
				progressSource = tilesPromise;
				yield return tilesPromise.handle;
				progressSource = null;
				JobBuildNodes.BuildNodeTilesOutput buildNodeTilesOutput = tilesPromise.Complete();
				TileBuilder.TileBuilderOutput tileBuilderOutput = tileMeshesPromise.Complete();
				tiles = buildNodeTilesOutput.tiles;
				tileBuilderOutput.Dispose();
				buildNodeTilesOutput.Dispose();
				arena.DisposeAll();
			}

			public void Apply(IGraphUpdateContext ctx)
			{
				graph.DestroyAllNodes();
				graph.hasExtendedInZ = false;
				graph.hasExtendedInX = false;
				if (emptyGraph)
				{
					graph.SetLayout(tileLayout);
					graph.FillWithEmptyTiles();
				}
				else
				{
					for (int i = 0; i < tiles.Length; i++)
					{
						AstarPath active = AstarPath.active;
						GraphNode[] nodes = tiles[i].nodes;
						active.InitializeNodes(nodes);
					}
					graph.SetLayout(tileLayout);
					graph.tiles = tiles;
					for (int j = 0; j < tiles.Length; j++)
					{
						tiles[j].graph = graph;
					}
				}
				graph.navmeshUpdateData.OnRecalculatedTiles(graph.tiles);
				if (graph.OnRecalculatedTiles != null)
				{
					graph.OnRecalculatedTiles(graph.tiles.Clone() as NavmeshTile[]);
				}
			}
		}

		private class RecastMovePromise : IGraphUpdatePromise
		{
			private RecastGraph graph;

			private TileMeshes tileMeshes;

			private Int2 delta;

			private IntRect newTileRect;

			public RecastMovePromise(RecastGraph graph, Int2 delta)
			{
				this.graph = graph;
				this.delta = delta;
				if (delta.x != 0 && delta.y != 0)
				{
					throw new ArgumentException("Only translation in a single direction is supported. delta.x == 0 || delta.y == 0 must hold.");
				}
			}

			public IEnumerator<JobHandle> Prepare()
			{
				if (delta.x == 0 && delta.y == 0)
				{
					yield break;
				}
				IntRect b = new IntRect(0, 0, graph.tileXCount - 1, graph.tileZCount - 1);
				newTileRect = b.Offset(delta);
				IntRect createdTiles = IntRect.Exclude(newTileRect, b);
				if (!graph.hasExtendedInX && delta.x != 0)
				{
					if (delta.x > 0)
					{
						createdTiles.xmin--;
					}
					graph.hasExtendedInX = true;
				}
				if (!graph.hasExtendedInZ && delta.y != 0)
				{
					if (delta.y > 0)
					{
						createdTiles.ymin--;
					}
					graph.hasExtendedInZ = true;
				}
				DisposeArena disposeArena = new DisposeArena();
				TileLayout tileLayout = new TileLayout(graph);
				tileLayout.graphSpaceSize.x = float.PositiveInfinity;
				tileLayout.graphSpaceSize.z = float.PositiveInfinity;
				TileBuilder tileBuilder = RecastBuilder.BuildTileMeshes(graph, tileLayout, createdTiles);
				tileBuilder.scene = graph.active.gameObject.scene;
				Promise<TileBuilder.TileBuilderOutput> pendingPromise = tileBuilder.Schedule(disposeArena);
				yield return pendingPromise.handle;
				TileBuilder.TileBuilderOutput value = pendingPromise.GetValue();
				tileMeshes = value.tileMeshes.ToManaged();
				pendingPromise.Dispose();
				disposeArena.DisposeAll();
				tileMeshes.tileRect = createdTiles.Offset(-delta);
			}

			public void Apply(IGraphUpdateContext ctx)
			{
				if (delta.x != 0 || delta.y != 0)
				{
					graph.Resize(newTileRect);
					graph.ReplaceTiles(tileMeshes);
				}
			}
		}

		[JsonMember]
		public float characterRadius = 1.5f;

		[JsonMember]
		public float contourMaxError = 2f;

		[JsonMember]
		public float cellSize = 0.5f;

		[JsonMember]
		public float walkableHeight = 2f;

		[JsonMember]
		public float walkableClimb = 0.5f;

		[JsonMember]
		public float maxSlope = 30f;

		[JsonMember]
		public float maxEdgeLength = 20f;

		[JsonMember]
		public float minRegionSize = 3f;

		[JsonMember]
		public int editorTileSize = 128;

		[JsonMember]
		public int tileSizeX = 128;

		[JsonMember]
		public int tileSizeZ = 128;

		[JsonMember]
		public bool useTiles = true;

		public bool scanEmptyGraph;

		[JsonMember]
		public List<PerLayerModification> perLayerModifications = new List<PerLayerModification>();

		[JsonMember]
		public DimensionMode dimensionMode = DimensionMode.Dimension3D;

		[JsonMember]
		public BackgroundTraversability backgroundTraversability;

		[JsonMember]
		public RelevantGraphSurfaceMode relevantGraphSurfaceMode;

		[JsonMember]
		public CollectionSettings collectionSettings = new CollectionSettings();

		[JsonMember]
		public Vector3 rotation;

		[JsonMember]
		public Vector3 forcedBoundsCenter;

		private DisposeArena pendingGraphUpdateArena = new DisposeArena();

		private bool hasExtendedInX;

		private bool hasExtendedInZ;

		[Obsolete("Use collectionSettings.rasterizeColliders instead")]
		public bool rasterizeColliders
		{
			get
			{
				return collectionSettings.rasterizeColliders;
			}
			set
			{
				collectionSettings.rasterizeColliders = value;
			}
		}

		[Obsolete("Use collectionSettings.rasterizeMeshes instead")]
		public bool rasterizeMeshes
		{
			get
			{
				return collectionSettings.rasterizeMeshes;
			}
			set
			{
				collectionSettings.rasterizeMeshes = value;
			}
		}

		[Obsolete("Use collectionSettings.rasterizeTerrain instead")]
		public bool rasterizeTerrain
		{
			get
			{
				return collectionSettings.rasterizeTerrain;
			}
			set
			{
				collectionSettings.rasterizeTerrain = value;
			}
		}

		[Obsolete("Use collectionSettings.rasterizeTrees instead")]
		public bool rasterizeTrees
		{
			get
			{
				return collectionSettings.rasterizeTrees;
			}
			set
			{
				collectionSettings.rasterizeTrees = value;
			}
		}

		[Obsolete("Use collectionSettings.colliderRasterizeDetail instead")]
		public float colliderRasterizeDetail
		{
			get
			{
				return collectionSettings.colliderRasterizeDetail;
			}
			set
			{
				collectionSettings.colliderRasterizeDetail = value;
			}
		}

		[Obsolete("Use collectionSettings.layerMask instead")]
		public LayerMask mask
		{
			get
			{
				return collectionSettings.layerMask;
			}
			set
			{
				collectionSettings.layerMask = value;
			}
		}

		[Obsolete("Use collectionSettings.tagMask instead")]
		public List<string> tagMask
		{
			get
			{
				return collectionSettings.tagMask;
			}
			set
			{
				collectionSettings.tagMask = value;
			}
		}

		[Obsolete("Use collectionSettings.terrainHeightmapDownsamplingFactor instead")]
		public int terrainSampleSize
		{
			get
			{
				return collectionSettings.terrainHeightmapDownsamplingFactor;
			}
			set
			{
				collectionSettings.terrainHeightmapDownsamplingFactor = value;
			}
		}

		public override float NavmeshCuttingCharacterRadius => characterRadius;

		public override bool RecalculateNormals => true;

		public override float TileWorldSizeX => (float)tileSizeX * cellSize;

		public override float TileWorldSizeZ => (float)tileSizeZ * cellSize;

		public override float MaxTileConnectionEdgeDistance => walkableClimb;

		public override Bounds bounds
		{
			get
			{
				float4x4 float4x5 = CalculateTransform().matrix;
				Bounds result = new ToWorldMatrix(new float3x3(float4x5.c0.xyz, float4x5.c1.xyz, float4x5.c2.xyz)).ToWorld(new Bounds(Vector3.zero, forcedBoundsSize));
				result.center += forcedBoundsCenter;
				return result;
			}
		}

		internal int CharacterRadiusInVoxels => Mathf.CeilToInt(characterRadius / cellSize - 0.1f);

		internal int TileBorderSizeInVoxels => CharacterRadiusInVoxels + 3;

		internal float TileBorderSizeInWorldUnits => (float)TileBorderSizeInVoxels * cellSize;

		public override bool IsInsideBounds(Vector3 point)
		{
			if (tiles == null || tiles.Length == 0)
			{
				return false;
			}
			float3 float5 = transform.InverseTransform(point);
			if (dimensionMode == DimensionMode.Dimension2D)
			{
				if (float5.x >= 0f && float5.z >= 0f && float5.x <= forcedBoundsSize.x)
				{
					return float5.z <= forcedBoundsSize.z;
				}
				return false;
			}
			if (math.all(float5 >= 0f))
			{
				return math.all(float5 <= forcedBoundsSize);
			}
			return false;
		}

		public void SnapForceBoundsToScene()
		{
			DisposeArena disposeArena = new DisposeArena();
			RecastMeshGatherer.MeshCollection data = new TileBuilder(this, new TileLayout(this), default(IntRect)).CollectMeshes(new Bounds(Vector3.zero, new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity)));
			if (data.meshes.Length > 0)
			{
				ToWorldMatrix toWorldMatrix = new ToWorldMatrix(new float3x3(Quaternion.Inverse(Quaternion.Euler(rotation))));
				Bounds bounds = toWorldMatrix.ToWorld(data.meshes[0].bounds);
				for (int i = 1; i < data.meshes.Length; i++)
				{
					bounds.Encapsulate(toWorldMatrix.ToWorld(data.meshes[i].bounds));
				}
				forcedBoundsCenter = Quaternion.Euler(rotation) * bounds.center;
				forcedBoundsSize = bounds.size;
			}
			disposeArena.Add(data);
			disposeArena.DisposeAll();
		}

		IGraphUpdatePromise IUpdatableGraph.ScheduleGraphUpdates(List<GraphUpdateObject> graphUpdates)
		{
			return new RecastGraphUpdatePromise(this, graphUpdates);
		}

		public IGraphUpdatePromise TranslateInDirection(int dx, int dz)
		{
			return new RecastMovePromise(this, new Int2(dx, dz));
		}

		protected override IGraphUpdatePromise ScanInternal(bool async)
		{
			return new RecastGraphScanPromise
			{
				graph = this
			};
		}

		public override GraphTransform CalculateTransform()
		{
			return CalculateTransform(new Bounds(forcedBoundsCenter, forcedBoundsSize), Quaternion.Euler(rotation));
		}

		public static GraphTransform CalculateTransform(Bounds bounds, Quaternion rotation)
		{
			return new GraphTransform(Matrix4x4.TRS(bounds.center, rotation, Vector3.one) * Matrix4x4.TRS(-bounds.extents, Quaternion.identity, Vector3.one));
		}

		protected void SetLayout(TileLayout info)
		{
			tileXCount = info.tileCount.x;
			tileZCount = info.tileCount.y;
			tileSizeX = info.tileSizeInVoxels.x;
			tileSizeZ = info.tileSizeInVoxels.y;
			transform = info.transform;
		}

		public virtual void Resize(IntRect newTileBounds)
		{
			AssertSafeToUpdateGraph();
			if (!newTileBounds.IsValid())
			{
				throw new ArgumentException("Invalid tile bounds");
			}
			if (newTileBounds == new IntRect(0, 0, tileXCount - 1, tileZCount - 1))
			{
				return;
			}
			if (newTileBounds.Area == 0)
			{
				throw new ArgumentException("Tile count must at least 1x1");
			}
			StartBatchTileUpdate();
			NavmeshTile[] array = new NavmeshTile[newTileBounds.Area];
			for (int i = 0; i < tileZCount; i++)
			{
				for (int j = 0; j < tileXCount; j++)
				{
					if (newTileBounds.Contains(j, i))
					{
						NavmeshTile navmeshTile = tiles[j + i * tileXCount];
						array[j - newTileBounds.xmin + (i - newTileBounds.ymin) * newTileBounds.Width] = navmeshTile;
					}
					else
					{
						ClearTile(j, i);
						DirtyBounds(GetTileBounds(j, i));
					}
				}
			}
			forcedBoundsSize = new Vector3((float)newTileBounds.Width * TileWorldSizeX, forcedBoundsSize.y, (float)newTileBounds.Height * TileWorldSizeZ);
			forcedBoundsCenter = transform.Transform(new Vector3((float)(newTileBounds.xmin + newTileBounds.xmax + 1) * 0.5f * TileWorldSizeX, forcedBoundsSize.y * 0.5f, (float)(newTileBounds.ymin + newTileBounds.ymax + 1) * 0.5f * TileWorldSizeZ));
			transform = CalculateTransform();
			Int3 int5 = -(Int3)new Vector3(TileWorldSizeX * (float)newTileBounds.xmin, 0f, TileWorldSizeZ * (float)newTileBounds.ymin);
			for (int k = 0; k < newTileBounds.Height; k++)
			{
				for (int l = 0; l < newTileBounds.Width; l++)
				{
					int num = l + k * newTileBounds.Width;
					NavmeshTile navmeshTile2 = array[num];
					if (navmeshTile2 == null)
					{
						array[num] = NewEmptyTile(l, k);
						continue;
					}
					navmeshTile2.x = l;
					navmeshTile2.z = k;
					for (int m = 0; m < navmeshTile2.nodes.Length; m++)
					{
						TriangleMeshNode obj = navmeshTile2.nodes[m];
						obj.v0 = (obj.v0 & 0xFFF) | (num << 12);
						obj.v1 = (obj.v1 & 0xFFF) | (num << 12);
						obj.v2 = (obj.v2 & 0xFFF) | (num << 12);
					}
					for (int n = 0; n < navmeshTile2.vertsInGraphSpace.Length; n++)
					{
						navmeshTile2.vertsInGraphSpace[n] += int5;
					}
					navmeshTile2.vertsInGraphSpace.CopyTo(navmeshTile2.verts);
					transform.Transform(navmeshTile2.verts);
					navmeshTile2.bbTree.Dispose();
					navmeshTile2.bbTree = new BBTree(navmeshTile2.tris, navmeshTile2.vertsInGraphSpace);
				}
			}
			tiles = array;
			tileXCount = newTileBounds.Width;
			tileZCount = newTileBounds.Height;
			EndBatchTileUpdate();
			navmeshUpdateData.OnResized(newTileBounds);
		}

		public void EnsureInitialized()
		{
			AssertSafeToUpdateGraph();
			if (tiles == null)
			{
				TriangleMeshNode.SetNavmeshHolder(AstarPath.active.data.GetGraphIndex(this), this);
				SetLayout(new TileLayout(this));
				FillWithEmptyTiles();
			}
		}

		public void ReplaceTiles(TileMeshes tileMeshes, float yOffset = 0f)
		{
			AssertSafeToUpdateGraph();
			EnsureInitialized();
			if (tileMeshes.tileWorldSize.x != TileWorldSizeX || tileMeshes.tileWorldSize.y != TileWorldSizeZ)
			{
				string[] obj = new string[7] { "Loaded tile size does not match this graph's tile size.\nThe source tiles have a world-space tile size of ", null, null, null, null, null, null };
				Vector2 tileWorldSize = tileMeshes.tileWorldSize;
				obj[1] = tileWorldSize.ToString();
				obj[2] = " while this graph's tile size is (";
				obj[3] = TileWorldSizeX.ToString();
				obj[4] = ",";
				obj[5] = TileWorldSizeZ.ToString();
				obj[6] = ").\nFor a recast graph, the world-space tile size is defined as the cell size * the tile size in voxels";
				throw new Exception(string.Concat(obj));
			}
			int width = tileMeshes.tileRect.Width;
			int height = tileMeshes.tileRect.Height;
			IntRect newTileBounds = IntRect.Union(new IntRect(0, 0, tileXCount - 1, tileZCount - 1), tileMeshes.tileRect);
			Resize(newTileBounds);
			tileMeshes.tileRect = tileMeshes.tileRect.Offset(-newTileBounds.Min);
			StartBatchTileUpdate();
			NavmeshTile[] array = new NavmeshTile[width * height];
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					TileMesh tileMesh = tileMeshes.tileMeshes[j + i * width];
					Int3 int5 = (Int3)new Vector3(0f, yOffset, 0f);
					for (int k = 0; k < tileMesh.verticesInTileSpace.Length; k++)
					{
						tileMesh.verticesInTileSpace[k] += int5;
					}
					Int2 int6 = new Int2(j, i) + tileMeshes.tileRect.Min;
					ReplaceTile(int6.x, int6.y, tileMesh.verticesInTileSpace, tileMesh.triangles);
					array[j + i * width] = GetTile(int6.x, int6.y);
				}
			}
			EndBatchTileUpdate();
			navmeshUpdateData.OnRecalculatedTiles(array);
			if (OnRecalculatedTiles != null)
			{
				OnRecalculatedTiles(array);
			}
		}

		protected override void PostDeserialization(GraphSerializationContext ctx)
		{
			base.PostDeserialization(ctx);
			if (ctx.meta.version < AstarSerializer.V4_3_80)
			{
				collectionSettings.colliderRasterizeDetail = 2f * cellSize * collectionSettings.colliderRasterizeDetail * collectionSettings.colliderRasterizeDetail / 9.869605f;
			}
			if (ctx.meta.version < AstarSerializer.V5_1_0)
			{
				if (collectionSettings.tagMask.Count > 0 && (int)collectionSettings.layerMask != -1)
				{
					Debug.LogError("In version 5.1.0 or higher of the A* Pathfinding Project you can no longer include objects both using a tag mask and a layer mask. Please choose in the recast graph inspector which one you want to use.");
				}
				else if (collectionSettings.tagMask.Count > 0)
				{
					collectionSettings.collectionMode = CollectionSettings.FilterMode.Tags;
				}
			}
		}
	}
}
