using System.Collections.Generic;
using Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings;
using Assets.Nimbatus.Scripts.Missions;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Sectors
{
	[ExecuteInEditMode]
	public class SolarSystemLocationSetting
	{
		public List<LocationSetting> Location = new List<LocationSetting>();

		public EMissionDifficulty Difficulty;

		public IndividualLocationSetting IndividualSetting = new IndividualLocationSetting();
	}
}
