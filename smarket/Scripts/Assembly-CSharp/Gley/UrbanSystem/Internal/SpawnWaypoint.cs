using System;
using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	[Serializable]
	public struct SpawnWaypoint
	{
		[SerializeField]
		private int[] _allowedAgents;

		[SerializeField]
		private int _waypointIndex;

		[SerializeField]
		private int _priority;

		public readonly int[] AllowedAgents => null;

		public readonly int WaypointIndex => 0;

		public readonly int Priority => 0;

		public SpawnWaypoint(int waypointIndex, int[] allowedVehicles, int priority)
		{
			_allowedAgents = null;
			_waypointIndex = 0;
			_priority = 0;
		}
	}
}
