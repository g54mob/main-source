using System;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Missions;

namespace Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings
{
	public class GarageLocationSetting : LocationSetting
	{
		public override LocationData CreateLocation(Random randomGenerator, GalaxyMapSector sector, EMissionDifficulty difficulty, EMissionComplexity complexity)
		{
			GarageLocationData garageLocationData = new GarageLocationData();
			garageLocationData.Init(this, randomGenerator, sector, difficulty, complexity);
			return garageLocationData;
		}
	}
}
