using System;
using System.Collections.Generic;
using Poncle.Schema.Attributes.Attributes;

namespace VampireSurvivors.Data.Characters
{
	[Serializable]
	[Title("Loadout")]
	public class Loadout
	{
		[Title("Starting Loadout")]
		public List<WeaponType> startingLoadout { get; set; }

		[Title("Loadout")]
		public List<WeaponType> loadout { get; set; }

		[Title("Auto Shuffle")]
		public bool autoShuffle { get; set; }
	}
}
