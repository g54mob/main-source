using System.Collections.Generic;
using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	public class WaypointSettingsBase : MonoBehaviour
	{
		public List<WaypointSettingsBase> neighbors;

		public List<WaypointSettingsBase> prev;

		public bool draw;

		public bool inView;

		public Vector3 position;

		public bool priorityLocked;

		public int priority;

		public bool triggerEvent;

		public string eventData;

		public List<int> distance;

		public bool penaltyLocked;

		public int penalty;

		public virtual void Initialize()
		{
		}

		public virtual void VerifyAssignments(bool showPrevsWarning)
		{
		}

		public void SetPriorityForAllNeighbors(int newPriority)
		{
		}

		public void SetPenaltyForAllNeighbors(int newPenalty)
		{
		}
	}
}
