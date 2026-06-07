using UnityEngine;

namespace VampireSurvivors.Objects
{
	public class DebuffZonePrefab : DamagingZonePrefab
	{
		[HideInInspector]
		public DebuffZoneFlexible.DebuffType debuffType;

		[HideInInspector]
		public float debuffValue;

		protected override void SpawnPattern()
		{
		}

		protected override void SpawnCrosshatchPattern()
		{
		}
	}
}
