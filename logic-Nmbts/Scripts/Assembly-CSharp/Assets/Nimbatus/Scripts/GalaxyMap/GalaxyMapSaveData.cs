using System;
using System.Collections.Generic;

namespace Assets.Nimbatus.Scripts.GalaxyMap
{
	[Serializable]
	public class GalaxyMapSaveData
	{
		public List<Galaxy> Galaxies;

		public int CurrentLevel;

		public string CurrentLocationId;
	}
}
