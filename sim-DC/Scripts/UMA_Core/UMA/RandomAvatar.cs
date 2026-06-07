using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class RandomAvatar
	{
		public string RaceName;

		[Range(1f, 100f)]
		public int Chance;

		public List<RandomColors> SharedColors;

		public List<RandomWardrobeSlot> RandomWardrobeSlots;

		public List<RandomDNA> RandomDna;

		public RaceData raceData;

		public UMAPredefinedDNA GetRandomDNA()
		{
			return null;
		}

		public Dictionary<string, List<RandomWardrobeSlot>> GetRandomSlots()
		{
			return null;
		}

		private List<RandomColors> GetColorListForRace(RaceData rc)
		{
			return null;
		}

		public RandomAvatar(RaceData race)
		{
		}
	}
}
