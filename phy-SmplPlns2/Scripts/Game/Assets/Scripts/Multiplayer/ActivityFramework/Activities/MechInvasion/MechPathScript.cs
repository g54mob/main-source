using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Activities.MechInvasion
{
	public class MechPathScript : MonoBehaviour
	{
		[SerializeField]
		private Transform _objective;

		[SerializeField]
		private MechPathWaypointScript[] _waypoints;

		public Transform Objective => _objective;

		public IReadOnlyList<MechPathWaypointScript> Waypoints => _waypoints;

		protected virtual void Awake()
		{
			MechPathWaypointScript[] waypoints = _waypoints;
			for (int i = 0; i < waypoints.Length; i++)
			{
				waypoints[i].Initialize(this);
			}
		}
	}
}
