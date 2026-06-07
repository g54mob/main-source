using System;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Missions;

namespace Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings
{
	public class SpaceLocationSetting : LocationSetting
	{
		public ESpaceLocation SpaceLocation;

		public override LocationData CreateLocation(Random randomGenerator, GalaxyMapSector sector, EMissionDifficulty difficulty, EMissionComplexity complexity)
		{
			SpaceLocationData spaceLocationData = new SpaceLocationData();
			spaceLocationData.Init(this, randomGenerator, sector, difficulty, complexity);
			return spaceLocationData;
		}
	}
}
