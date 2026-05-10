using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	[Serializable]
	public class WaypointBase
	{
		public List<int> neighbors;

		public List<int> prev;

		public List<int> otherLanes;

		public Vector3 position;

		public string name;

		public int listIndex;

		public bool temporaryDisabled;

		public List<int> allowedAgents;

		public WaypointBase()
		{
		}

		public WaypointBase(string name, int listIndex, Vector3 position, List<int> neighbors, List<int> prev, List<int> otherLanes, List<int> allowedAgents)
		{
		}

		internal virtual void Passed(int agentIndex)
		{
		}
	}
}
