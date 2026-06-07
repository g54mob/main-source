using System;
using System.Collections.Generic;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class CrimeSaveData
	{
		public float crimeRate;

		public List<CrimeOffenseEntry> offenseHistory;

		public List<PlayerWantedRecordEntry> playerWantedRecords;
	}
}
