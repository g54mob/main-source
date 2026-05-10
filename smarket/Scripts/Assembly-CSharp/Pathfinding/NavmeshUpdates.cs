using System;

namespace Pathfinding
{
	[Serializable]
	public class NavmeshUpdates
	{
		internal class NavmeshUpdateSettings
		{
			public NavmeshUpdateSettings(NavmeshBase graph)
			{
			}

			public void OnRecalculatedTiles(NavmeshTile[] tiles)
			{
			}
		}

		public float updateInterval;

		internal void Update()
		{
		}

		internal void OnEnable()
		{
		}

		internal void OnDisable()
		{
		}
	}
}
