using System;
using Pathfinding.Graphs.Navmesh;
using Pathfinding.Jobs;
using Pathfinding.Serialization;
using Pathfinding.Sync;
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

			public float Progress => 0f;

			public void Dispose()
			{
			}
		}

		private struct SerializeJob : IJob
		{
			public Promise<TileBuilder.TileBuilderOutput> tileMeshesPromise;

			public SerializedOutput output;

			public void Execute()
			{
			}
		}

		public TextAsset serializedNavmesh;

		public bool applyOnStart;

		public bool removeTilesWhenDisabled;

		public Bounds bounds;

		private bool startHasRun;

		protected override void Reset()
		{
		}

		[ContextMenu("Snap to closest tile alignment")]
		public void SnapToClosestTileAlignment()
		{
		}

		[ContextMenu("Apply here")]
		public void Apply()
		{
		}

		public void SnapToClosestTileAlignment(RecastGraph graph)
		{
		}

		public void SnapSizeToClosestTileMultiple(RecastGraph graph)
		{
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public static Bounds SnapSizeToClosestTileMultiple(RecastGraph graph, Bounds bounds)
		{
			return default(Bounds);
		}

		public static void SnapToGraph(TileLayout tileLayout, Vector3 position, Quaternion rotation, Bounds bounds, out IntRect tileRect, out int snappedRotation, out float yOffset)
		{
			tileRect = default(IntRect);
			snappedRotation = default(int);
			yOffset = default(float);
		}

		public void Apply(RecastGraph graph)
		{
		}

		public byte[] Scan()
		{
			return null;
		}

		public byte[] Scan(RecastGraph graph)
		{
			return null;
		}

		public Promise<SerializedOutput> ScanAsync(RecastGraph graph)
		{
			return default(Promise<SerializedOutput>);
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
		}
	}
}
