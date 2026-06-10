using System;
using NSEipix.Base;
using UnityEngine;

namespace Raid.Config
{
	[Serializable]
	public class RaidSpawnSettings : SingletonModel<RaidSpawnSettings, RaidSpawnSettingsData>
	{
		[Serializable]
		private class SiegeRaidSettings
		{
			[SerializeField]
			private int siegeVictoriesInRowCount;

			[SerializeField]
			private float siegeMinPointsForSiegeWeapons;

			public int SiegeVictoriesInRowCount => siegeVictoriesInRowCount;

			public float SiegeMinPointsForSiegeWeapons => siegeMinPointsForSiegeWeapons;
		}

		[SerializeField]
		private SiegeRaidSettings siegeSettings;

		[SerializeField]
		private SiegePathfinderPenaltyModifiers standardSiegePathfinderSettings;

		[SerializeField]
		private SiegePathfinderPenaltyModifiers harderSiegePathfinderSettings;

		public int SiegeVictoriesInRowCount => siegeSettings.SiegeVictoriesInRowCount;

		public float SiegeMinPointsForSiegeWeapons => siegeSettings.SiegeMinPointsForSiegeWeapons;

		public SiegePathfinderPenaltyModifiers StandardSiegePathfinderSettings => standardSiegePathfinderSettings;

		public SiegePathfinderPenaltyModifiers HarderSiegePathfinderSettings => harderSiegePathfinderSettings;

		public override string GetID()
		{
			return "RaidSpawnSettings";
		}
	}
}
