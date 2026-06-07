using System;
using System.Collections.Generic;
using Pathfinding.Util;

namespace Pathfinding
{
	[Serializable]
	public class NavmeshUpdates
	{
		internal class NavmeshUpdateSettings
		{
			public TileHandler handler;

			public readonly List<IntRect> forcedReloadRects;

			private readonly NavmeshBase graph;

			public NavmeshUpdateSettings(NavmeshBase graph)
			{
			}

			public void Refresh(bool forceCreate = false)
			{
			}

			public void OnRecalculatedTiles(NavmeshTile[] tiles)
			{
			}

			public void AddClipper(NavmeshClipper obj)
			{
			}

			public void RemoveClipper(NavmeshClipper obj)
			{
			}
		}

		public float updateInterval;

		private float lastUpdateTime;

		internal void OnEnable()
		{
		}

		internal void OnDisable()
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

		internal void Update()
		{
		}

		public void ForceUpdate()
		{
		}
	}
}
