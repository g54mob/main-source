using System;
using System.Collections.Generic;
using Pathfinding.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	[Serializable]
	public class NavmeshUpdates
	{
		public class NavmeshUpdateSettings : IDisposable
		{
			internal readonly NavmeshBase graph;

			public GridLookup<NavmeshClipper> clipperLookup;

			public TileLayout tileLayout;

			private UnsafeBitArray dirtyTiles;

			private List<Vector2Int> dirtyTileCoordinates;

			public bool attachedToGraph { get; private set; }

			public bool enabled => false;

			public bool anyTilesDirty => false;

			private void AssertEnabled()
			{
			}

			public NavmeshUpdateSettings(NavmeshBase graph)
			{
			}

			public NavmeshUpdateSettings(NavmeshBase graph, TileLayout tileLayout)
			{
			}

			public void UpdateLayoutFromGraph()
			{
			}

			private void ForceUpdateLayoutFromGraph()
			{
			}

			private void SetLayout(TileLayout tileLayout)
			{
			}

			internal void MarkTilesDirty(IntRect rect)
			{
			}

			public void ReloadAllTiles()
			{
			}

			public void AttachToGraph()
			{
			}

			public void Enable()
			{
			}

			public void Disable()
			{
			}

			public void Dispose()
			{
			}

			public void DiscardPending()
			{
			}

			public void OnResized(IntRect newTileBounds, TileLayout tileLayout)
			{
			}

			public void Dirty(NavmeshClipper obj)
			{
			}

			public void AddClipper(NavmeshClipper obj)
			{
			}

			public void RemoveClipper(NavmeshClipper obj)
			{
			}

			public void ScheduleDirtyTilesReload()
			{
			}

			public void ReloadDirtyTilesImmediately()
			{
			}
		}

		public float updateInterval;

		internal AstarPath astar;

		private List<NavmeshUpdateSettings> listeners;

		private float lastUpdateTime;

		private static Rect ExpandedXZBounds(Bounds bounds)
		{
			return default(Rect);
		}

		internal void OnEnable()
		{
		}

		internal void OnDisable()
		{
		}

		public void ForceUpdateAround(NavmeshClipper clipper)
		{
		}

		public void DiscardPending()
		{
		}

		private void HandleOnEnableCallback(NavmeshClipper obj)
		{
		}

		private void HandleOnDisableCallback(NavmeshClipper obj)
		{
		}

		private void AddListener(NavmeshUpdateSettings listener)
		{
		}

		private void RemoveListener(NavmeshUpdateSettings listener)
		{
		}

		internal void Update()
		{
		}

		public void ForceUpdate()
		{
		}

		private void RefreshEnabledState()
		{
		}

		private void ScheduleTileUpdates()
		{
		}
	}
}
