using System;
using Pathfinding.Graphs.Navmesh;
using Pathfinding.Jobs;
using Pathfinding.Serialization;
using Pathfinding.Util;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Navmesh Prefab")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/navmeshprefab.html")]
	public class NavmeshPrefab : VersionedMonoBehaviour
	{
		public class SerializedOutput : IProgress, IDisposable
		{
			public Promise<TileBuilder.TileBuilderOutput> promise;

			public byte[] data;

			public DisposeArena arena;

			public float Progress => promise.Progress;

			public void Dispose()
			{
				promise.Dispose();
				arena.DisposeAll();
			}
		}

		private struct SerializeJob : IJob
		{
			public Promise<TileBuilder.TileBuilderOutput> tileMeshesPromise;

			public SerializedOutput output;

			public void Execute()
			{
				TileBuilder.TileBuilderOutput value = tileMeshesPromise.GetValue();
				output.data = value.tileMeshes.ToManaged().Serialize();
			}
		}

		public TextAsset serializedNavmesh;

		public bool applyOnStart = true;

		public bool removeTilesWhenDisabled = true;

		public Bounds bounds = new Bounds(Vector3.zero, new Vector3(10f, 10f, 10f));

		private bool startHasRun;

		protected override void Reset()
		{
			base.Reset();
			AstarPath.FindAstarPath();
			if (AstarPath.active != null && AstarPath.active.data.recastGraph != null)
			{
				RecastGraph recastGraph = AstarPath.active.data.recastGraph;
				bounds = new Bounds(Vector3.zero, new Vector3(recastGraph.TileWorldSizeX, recastGraph.forcedBoundsSize.y, recastGraph.TileWorldSizeZ));
			}
		}

		[ContextMenu("Snap to closest tile alignment")]
		public void SnapToClosestTileAlignment()
		{
			AstarPath.FindAstarPath();
			if (AstarPath.active != null && AstarPath.active.data.recastGraph != null)
			{
				SnapToClosestTileAlignment(AstarPath.active.data.recastGraph);
			}
		}

		[ContextMenu("Apply here")]
		public void Apply()
		{
			AstarPath.FindAstarPath();
			if (AstarPath.active != null && AstarPath.active.data.recastGraph != null)
			{
				RecastGraph recastGraph = AstarPath.active.data.recastGraph;
				Apply(recastGraph);
			}
		}

		public void SnapToClosestTileAlignment(RecastGraph graph)
		{
			TileLayout tileLayout = new TileLayout(graph);
			SnapToGraph(tileLayout, base.transform.position, base.transform.rotation, bounds, out var tileRect, out var snappedRotation, out var yOffset);
			Bounds tileBoundsInGraphSpace = tileLayout.GetTileBoundsInGraphSpace(tileRect.xmin, tileRect.ymin, tileRect.Width, tileRect.Height);
			Vector3 point = new Vector3(tileBoundsInGraphSpace.center.x, yOffset, tileBoundsInGraphSpace.center.z);
			base.transform.rotation = Quaternion.Euler(graph.rotation) * Quaternion.Euler(0f, snappedRotation * 90, 0f);
			base.transform.position = tileLayout.transform.Transform(point) + base.transform.rotation * (-bounds.center + new Vector3(0f, bounds.extents.y, 0f));
		}

		public void SnapSizeToClosestTileMultiple(RecastGraph graph)
		{
			bounds = SnapSizeToClosestTileMultiple(graph, bounds);
		}

		private void Start()
		{
			startHasRun = true;
			if (applyOnStart && serializedNavmesh != null && AstarPath.active != null && AstarPath.active.data.recastGraph != null)
			{
				Apply(AstarPath.active.data.recastGraph);
			}
		}

		private void OnEnable()
		{
			if (startHasRun && applyOnStart && serializedNavmesh != null && AstarPath.active != null && AstarPath.active.data.recastGraph != null)
			{
				Apply(AstarPath.active.data.recastGraph);
			}
		}

		private void OnDisable()
		{
			if (!removeTilesWhenDisabled || !(serializedNavmesh != null) || !(AstarPath.active != null))
			{
				return;
			}
			Vector3 pos = base.transform.position;
			Quaternion rot = base.transform.rotation;
			AstarPath.active.AddWorkItem((Action<IWorkItemContext>)delegate
			{
				RecastGraph recastGraph = AstarPath.active.data.recastGraph;
				if (recastGraph != null)
				{
					SnapToGraph(new TileLayout(recastGraph), pos, rot, bounds, out var tileRect, out var _, out var _);
					recastGraph.ClearTiles(tileRect);
				}
			});
		}

		public static Bounds SnapSizeToClosestTileMultiple(RecastGraph graph, Bounds bounds)
		{
			float num = Mathf.Max((float)graph.editorTileSize * graph.cellSize, 0.001f);
			Vector2 vector = new Vector2(bounds.size.x / num, bounds.size.z / num);
			Int2 @int = new Int2(Mathf.Max(1, Mathf.RoundToInt(vector.x)), Mathf.Max(1, Mathf.RoundToInt(vector.y)));
			return new Bounds(bounds.center, new Vector3((float)@int.x * num, bounds.size.y, (float)@int.y * num));
		}

		public static void SnapToGraph(TileLayout tileLayout, Vector3 position, Quaternion rotation, Bounds bounds, out IntRect tileRect, out int snappedRotation, out float yOffset)
		{
			Vector3 vector = tileLayout.transform.InverseTransformVector(rotation * Vector3.right);
			snappedRotation = -Mathf.RoundToInt(Mathf.Atan2(vector.z, vector.x) / (MathF.PI / 2f));
			Quaternion quaternion = Quaternion.Euler(0f, snappedRotation * 90, 0f);
			Matrix4x4 matrix4x = tileLayout.transform.inverseMatrix * Matrix4x4.TRS(position + quaternion * bounds.center, quaternion, Vector3.one);
			Vector3 lhs = matrix4x.MultiplyPoint3x4(-bounds.extents);
			Vector3 rhs = matrix4x.MultiplyPoint3x4(bounds.extents);
			Vector3 a = Vector3.Min(lhs, rhs);
			Vector3 vector2 = Vector3.Scale(a, new Vector3(1f / tileLayout.TileWorldSizeX, 1f, 1f / tileLayout.TileWorldSizeZ));
			Int2 @int = new Int2(Mathf.RoundToInt(vector2.x), Mathf.RoundToInt(vector2.z));
			Vector2 vector3 = new Vector2(bounds.size.x, bounds.size.z);
			if ((snappedRotation % 2 + 2) % 2 == 1)
			{
				Memory.Swap(ref vector3.x, ref vector3.y);
			}
			int num = Mathf.Max(1, Mathf.RoundToInt(vector3.x / tileLayout.TileWorldSizeX));
			int num2 = Mathf.Max(1, Mathf.RoundToInt(vector3.y / tileLayout.TileWorldSizeZ));
			tileRect = new IntRect(@int.x, @int.y, @int.x + num - 1, @int.y + num2 - 1);
			yOffset = a.y;
		}

		public void Apply(RecastGraph graph)
		{
			if (serializedNavmesh == null)
			{
				throw new InvalidOperationException("Cannot Apply NavmeshPrefab because no serialized data has been set");
			}
			AstarPath.active.AddWorkItem((Action)delegate
			{
				SnapToGraph(new TileLayout(graph), base.transform.position, base.transform.rotation, bounds, out var tileRect, out var snappedRotation, out var yOffset);
				TileMeshes tileMeshes = TileMeshes.Deserialize(serializedNavmesh.bytes);
				tileMeshes.Rotate(snappedRotation);
				if (tileMeshes.tileRect.Width != tileRect.Width || tileMeshes.tileRect.Height != tileRect.Height)
				{
					throw new Exception("NavmeshPrefab has been scanned with a different size than it is right now (or with a different graph). Expected to find " + tileRect.Width + "x" + tileRect.Height + " tiles, but found " + tileMeshes.tileRect.Width + "x" + tileMeshes.tileRect.Height);
				}
				tileMeshes.tileRect = tileRect;
				graph.ReplaceTiles(tileMeshes, yOffset);
			});
		}

		public byte[] Scan()
		{
			AstarPath.FindAstarPath();
			if (AstarPath.active == null || AstarPath.active.data.recastGraph == null)
			{
				throw new InvalidOperationException("There's no recast graph in the scene. Add one if you want to scan this navmesh prefab.");
			}
			return Scan(AstarPath.active.data.recastGraph);
		}

		public byte[] Scan(RecastGraph graph)
		{
			SerializedOutput serializedOutput = ScanAsync(graph).Complete();
			byte[] data = serializedOutput.data;
			serializedOutput.Dispose();
			return data;
		}

		public Promise<SerializedOutput> ScanAsync(RecastGraph graph)
		{
			DisposeArena arena = new DisposeArena();
			TileLayout tileLayout = new TileLayout(new Bounds(base.transform.position + base.transform.rotation * bounds.center, bounds.size), base.transform.rotation, graph.cellSize, graph.editorTileSize, graph.useTiles);
			tileLayout.graphSpaceSize.x = float.PositiveInfinity;
			tileLayout.graphSpaceSize.z = float.PositiveInfinity;
			TileBuilder tileBuilder = RecastBuilder.BuildTileMeshes(graph, tileLayout, new IntRect(0, 0, tileLayout.tileCount.x - 1, tileLayout.tileCount.y - 1));
			tileBuilder.scene = base.gameObject.scene;
			Promise<TileBuilder.TileBuilderOutput> promise = tileBuilder.Schedule(arena);
			SerializedOutput serializedOutput = new SerializedOutput
			{
				promise = promise,
				arena = arena
			};
			return new Promise<SerializedOutput>(new SerializeJob
			{
				tileMeshesPromise = promise,
				output = serializedOutput
			}.ScheduleManaged(promise.handle), serializedOutput);
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
			migrations.TryMigrateFromLegacyFormat(out var _);
			if (migrations.AddAndMaybeRunMigration(1))
			{
				removeTilesWhenDisabled = false;
			}
			base.OnUpgradeSerializedData(ref migrations, unityThread);
		}
	}
}
