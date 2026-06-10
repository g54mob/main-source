using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.RoomDetection
{
	[Serializable]
	public class RoomProductionSpeedMultiplier
	{
		[SerializeField]
		private float speedMultiplier = 1f;

		[SerializeField]
		private List<string> applyTo = new List<string>();

		private HashSet<string> cache;

		private HashSet<string> ApplyTo => cache ?? (cache = new HashSet<string>(applyTo));

		public float GetSpeedMultiplier(string buildableId)
		{
			if (ApplyTo.Contains(buildableId))
			{
				return speedMultiplier;
			}
			return 1f;
		}
	}
}
