using System;
using System.Collections.Generic;
using Pathfinding.Graphs.Util;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	[Serializable]
	public class NavmeshUpdates
	{
		public class NavmeshUpdateSettings
		{
			public TileHandler handler;

			public readonly List<IntRect> forcedReloadRects = new List<IntRect>();

			private readonly NavmeshBase graph;

			public NavmeshUpdateSettings(NavmeshBase graph)
			{
				this.graph = graph;
			}

			public void ReloadAllTiles()
			{
				if (handler != null)
				{
					handler.ReloadInBounds(new IntRect(int.MinValue, int.MinValue, int.MaxValue, int.MaxValue));
				}
			}

			public void Refresh(bool forceCreate = false)
			{
				if (!graph.enableNavmeshCutting)
				{
					if (handler != null)
					{
						handler.cuts.Clear();
						ReloadAllTiles();
						graph.active.FlushGraphUpdates();
						graph.active.FlushWorkItems();
						forcedReloadRects.ClearFast();
						handler = null;
					}
				}
				else if ((handler == null && (forceCreate || NavmeshClipper.allEnabled.Count > 0)) || (handler != null && !handler.isValid))
				{
					handler = new TileHandler(graph);
					for (int i = 0; i < NavmeshClipper.allEnabled.Count; i++)
					{
						AddClipper(NavmeshClipper.allEnabled[i]);
					}
					handler.CreateTileTypesFromGraph();
					forcedReloadRects.Add(new IntRect(int.MinValue, int.MinValue, int.MaxValue, int.MaxValue));
				}
			}

			public void DiscardPending()
			{
				if (handler != null)
				{
					for (int i = 0; i < NavmeshClipper.allEnabled.Count; i++)
					{
						NavmeshClipper navmeshClipper = NavmeshClipper.allEnabled[i];
						GridLookup<NavmeshClipper>.Root root = handler.cuts.GetRoot(navmeshClipper);
						if (root != null)
						{
							navmeshClipper.NotifyUpdated(root);
						}
					}
				}
				forcedReloadRects.Clear();
			}

			public void OnResized(IntRect newTileBounds)
			{
				if (handler == null)
				{
					return;
				}
				handler.Resize(newTileBounds);
				float navmeshCuttingCharacterRadius = graph.NavmeshCuttingCharacterRadius;
				for (GridLookup<NavmeshClipper>.Root root = handler.cuts.AllItems; root != null; root = root.next)
				{
					Rect bounds = root.obj.GetBounds(handler.graph.transform, navmeshCuttingCharacterRadius);
					IntRect touchingTilesInGraphSpace = handler.graph.GetTouchingTilesInGraphSpace(bounds);
					if (root.previousBounds != touchingTilesInGraphSpace)
					{
						handler.cuts.Dirty(root.obj);
						handler.cuts.Move(root.obj, touchingTilesInGraphSpace);
					}
				}
			}

			public void OnRecalculatedTiles(NavmeshTile[] tiles)
			{
				Refresh();
				if (handler != null)
				{
					handler.OnRecalculatedTiles(tiles);
				}
				if (graph.GetTiles().Length == tiles.Length)
				{
					DiscardPending();
				}
			}

			public void Dirty(NavmeshClipper obj)
			{
				if (handler != null)
				{
					handler.cuts.Dirty(obj);
				}
			}

			public void AddClipper(NavmeshClipper obj)
			{
				if (obj.graphMask.Contains((int)graph.graphIndex))
				{
					Refresh(forceCreate: true);
					if (handler != null)
					{
						float navmeshCuttingCharacterRadius = graph.NavmeshCuttingCharacterRadius;
						Rect bounds = obj.GetBounds(graph.transform, navmeshCuttingCharacterRadius);
						IntRect touchingTilesInGraphSpace = handler.graph.GetTouchingTilesInGraphSpace(bounds);
						handler.cuts.Add(obj, touchingTilesInGraphSpace);
					}
				}
			}

			public void RemoveClipper(NavmeshClipper obj)
			{
				Refresh();
				if (handler != null)
				{
					GridLookup<NavmeshClipper>.Root root = handler.cuts.GetRoot(obj);
					if (root != null)
					{
						forcedReloadRects.Add(root.previousBounds);
						handler.cuts.Remove(obj);
					}
				}
			}
		}

		public float updateInterval;

		internal AstarPath astar;

		private float lastUpdateTime = float.NegativeInfinity;

		internal void OnEnable()
		{
			NavmeshClipper.AddEnableCallback(HandleOnEnableCallback, HandleOnDisableCallback);
		}

		internal void OnDisable()
		{
			NavmeshClipper.RemoveEnableCallback(HandleOnEnableCallback, HandleOnDisableCallback);
		}

		public void ForceUpdateAround(NavmeshClipper clipper)
		{
			NavGraph[] graphs = astar.graphs;
			if (graphs == null)
			{
				return;
			}
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] is NavmeshBase navmeshBase)
				{
					navmeshBase.navmeshUpdateData.Dirty(clipper);
				}
			}
		}

		public void DiscardPending()
		{
			NavGraph[] graphs = astar.graphs;
			if (graphs == null)
			{
				return;
			}
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] is NavmeshBase navmeshBase)
				{
					navmeshBase.navmeshUpdateData.DiscardPending();
				}
			}
		}

		private void HandleOnEnableCallback(NavmeshClipper obj)
		{
			NavGraph[] graphs = astar.graphs;
			if (graphs == null)
			{
				return;
			}
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] is NavmeshBase navmeshBase)
				{
					navmeshBase.navmeshUpdateData.AddClipper(obj);
				}
			}
		}

		private void HandleOnDisableCallback(NavmeshClipper obj)
		{
			NavGraph[] graphs = astar.graphs;
			if (graphs == null)
			{
				return;
			}
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] is NavmeshBase navmeshBase)
				{
					navmeshBase.navmeshUpdateData.RemoveClipper(obj);
				}
			}
			lastUpdateTime = float.NegativeInfinity;
		}

		internal void Update()
		{
			if (astar.isScanning)
			{
				return;
			}
			bool flag = false;
			NavGraph[] graphs = astar.graphs;
			if (graphs == null)
			{
				return;
			}
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] is NavmeshBase navmeshBase)
				{
					navmeshBase.navmeshUpdateData.Refresh();
					flag = navmeshBase.navmeshUpdateData.forcedReloadRects.Count > 0;
				}
			}
			if ((updateInterval >= 0f && Time.realtimeSinceStartup - lastUpdateTime > updateInterval) || flag)
			{
				ForceUpdate();
			}
		}

		public void ForceUpdate()
		{
			lastUpdateTime = Time.realtimeSinceStartup;
			NavGraph[] graphs = astar.graphs;
			if (graphs == null)
			{
				return;
			}
			for (int i = 0; i < graphs.Length; i++)
			{
				if (!(graphs[i] is NavmeshBase navmeshBase))
				{
					continue;
				}
				navmeshBase.navmeshUpdateData.Refresh();
				TileHandler handler = navmeshBase.navmeshUpdateData.handler;
				if (handler == null)
				{
					continue;
				}
				List<IntRect> forcedReloadRects = navmeshBase.navmeshUpdateData.forcedReloadRects;
				GridLookup<NavmeshClipper>.Root allItems = handler.cuts.AllItems;
				if (forcedReloadRects.Count == 0)
				{
					bool flag = false;
					for (GridLookup<NavmeshClipper>.Root root = allItems; root != null; root = root.next)
					{
						if (root.obj.RequiresUpdate(root))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						continue;
					}
				}
				handler.StartBatchLoad();
				for (int j = 0; j < forcedReloadRects.Count; j++)
				{
					handler.ReloadInBounds(forcedReloadRects[j]);
				}
				forcedReloadRects.ClearFast();
				float navmeshCuttingCharacterRadius = handler.graph.NavmeshCuttingCharacterRadius;
				for (GridLookup<NavmeshClipper>.Root root2 = allItems; root2 != null; root2 = root2.next)
				{
					if (root2.obj.RequiresUpdate(root2))
					{
						handler.ReloadInBounds(root2.previousBounds);
						Rect bounds = root2.obj.GetBounds(handler.graph.transform, navmeshCuttingCharacterRadius);
						IntRect touchingTilesInGraphSpace = handler.graph.GetTouchingTilesInGraphSpace(bounds);
						handler.cuts.Move(root2.obj, touchingTilesInGraphSpace);
						handler.ReloadInBounds(touchingTilesInGraphSpace);
						root2.obj.NotifyUpdated(root2);
					}
				}
				handler.EndBatchLoad();
			}
		}
	}
}
