using System;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Missions;

namespace Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings
{
	public class PlanetLocationSetting : LocationSetting
	{
		public IndividualLocationSetting PresetSetting;

		public override LocationData CreateLocation(Random randomGenerator, GalaxyMapSector sector, EMissionDifficulty difficulty, EMissionComplexity complexity)
		{
			PlanetLocationData planetLocationData = new PlanetLocationData();
			planetLocationData.Init(this, randomGenerator, sector, difficulty, complexity);
			if (PresetSetting != null)
			{
				planetLocationData.SetPreset(PresetSetting, randomGenerator);
			}
			return planetLocationData;
		}
	}
}
