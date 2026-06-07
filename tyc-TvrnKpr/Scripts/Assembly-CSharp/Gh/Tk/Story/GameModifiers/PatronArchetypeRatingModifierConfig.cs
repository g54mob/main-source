using System;
using UnityEngine;

namespace Gh.Tk.Story.GameModifiers
{
	[Serializable]
	public class PatronArchetypeRatingModifierConfig
	{
		[DropDownChoice(typeof(StoryHelper), "GetRaces")]
		public string race;

		[Range(0f, 5f)]
		[Tooltip("0 means all tiers")]
		public int tier;

		[Range(0f, 100f)]
		public int modifierPercentage;
	}
}
