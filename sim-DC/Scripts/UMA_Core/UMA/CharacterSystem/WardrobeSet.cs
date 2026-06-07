using System;
using System.Collections.Generic;

namespace UMA.CharacterSystem
{
	[Serializable]
	public class WardrobeSet
	{
		public string targetRace;

		public List<WardrobeSettings> wardrobeSet;

		public WardrobeSet()
		{
		}

		public WardrobeSet(string race)
		{
		}

		public WardrobeSet(string race, List<WardrobeSettings> settings)
		{
		}
	}
}
