using System;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Missions;

namespace Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings
{
	public class WormHoleLocationSetting : LocationSetting
	{
		public override LocationData CreateLocation(Random randomGenerator, GalaxyMapSector sector, EMissionDifficulty difficulty, EMissionComplexity complexity)
		{
			WormHoleLocationData wormHoleLocationData = new WormHoleLocationData();
			wormHoleLocationData.Init(this, randomGenerator, sector, difficulty, complexity);
			return wormHoleLocationData;
		}
	}
}
