using System;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_tile_handler_helper.php")]
	[Obsolete("Use AstarPath.navmeshUpdates instead. You can safely remove this component.")]
	public class TileHandlerHelper : VersionedMonoBehaviour
	{
		public float updateInterval
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[Obsolete("All navmesh/recast graphs now use navmesh cutting")]
		public void UseSpecifiedHandler(TileHandler newHandler)
		{
		}

		public void DiscardPending()
		{
		}

		public void ForceUpdate()
		{
		}
	}
}
