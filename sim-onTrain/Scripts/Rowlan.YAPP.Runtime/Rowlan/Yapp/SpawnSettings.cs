using System;
using UnityEngine;

namespace Rowlan.Yapp
{
	[Serializable]
	public class SpawnSettings
	{
		public enum AutoSimulationType
		{
			None = 0,
			Continuous = 1
		}

		public enum AutoCollider
		{
			[Tooltip("Add collider only to objects which are spawned during the current physics simulation")]
			SpawnedOnly = 0,
			[Tooltip("Add a collider to all container children during the current physics simulation")]
			Container = 1
		}

		public AutoSimulationType autoSimulationType;

		public float autoSimulationHeightOffset = 1f;

		public AutoCollider autoSimulationCollider;
	}
}
