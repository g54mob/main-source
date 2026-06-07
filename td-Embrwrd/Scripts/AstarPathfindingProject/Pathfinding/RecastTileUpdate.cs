using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Pathfinding
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_recast_tile_update.php")]
	[AddComponentMenu("Pathfinding/Navmesh/RecastTileUpdate")]
	public class RecastTileUpdate : MonoBehaviour
	{
		public static event Action<Bounds> OnNeedUpdates
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public void ScheduleUpdate()
		{
		}
	}
}
