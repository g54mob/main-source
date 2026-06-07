using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public class RaceLibrary : RaceLibraryBase
	{
		[SerializeField]
		protected RaceData[] raceElementList;

		private Dictionary<string, RaceData> raceDictionary;

		private void Awake()
		{
		}

		public override void ValidateDictionary()
		{
		}

		public override void UpdateDictionary()
		{
		}

		public override void AddRace(RaceData race)
		{
		}

		public override RaceData HasRace(string raceName)
		{
			return null;
		}

		public override RaceData HasRace(int raceHash)
		{
			return null;
		}

		public override RaceData GetRace(string raceName)
		{
			return null;
		}

		public override RaceData GetRace(int raceHash)
		{
			return null;
		}

		public override RaceData[] GetAllRaces()
		{
			return null;
		}
	}
}
