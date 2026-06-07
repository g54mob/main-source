using System;
using System.Collections.Generic;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments
{
	[Serializable]
	public class TournamentManagerSaveData
	{
		public List<Tournament> Tournaments;

		public string Version { get; set; }
	}
}
