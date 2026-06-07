using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap.Boss;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Missions;

namespace Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings
{
	public class BossfightLocationSetting : LocationSetting
	{
		public List<BossFight> Bossfights;

		public override LocationData CreateLocation(Random randomGenerator, GalaxyMapSector sector, EMissionDifficulty difficulty, EMissionComplexity complexity)
		{
			BossfightLocationData bossfightLocationData = new BossfightLocationData();
			bossfightLocationData.Init(this, randomGenerator, sector, difficulty, complexity);
			bossfightLocationData.SetBossFight(GetFight(randomGenerator));
			return bossfightLocationData;
		}

		private BossFight GetFight(Random randomGenerator)
		{
			if (Bossfights != null)
			{
				return Bossfights.RandomItem(randomGenerator);
			}
			return null;
		}
	}
}
