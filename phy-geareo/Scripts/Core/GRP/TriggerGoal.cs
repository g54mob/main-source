using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class TriggerGoal : Goal
	{
		public string key;

		public int minCount;

		public bool removeOnExit;

		private List<GoalTarget> targets;

		private void OnTriggerEnter(Collider other)
		{
		}

		private void OnTriggerExit(Collider other)
		{
		}
	}
}
