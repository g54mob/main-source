using System;
using UnityEngine;

namespace Gh.Tk.Story.GameModifiers
{
	[Serializable]
	public class TraitRarityRaceConfig
	{
		[DropDownChoice(typeof(StoryHelper), "GetRaces")]
		public string race;

		[Range(0f, 100f)]
		public int percentage;
	}
}
