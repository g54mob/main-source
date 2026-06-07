using System;
using UnityEngine;

namespace UMA.CharacterSystem
{
	[Serializable]
	public class WardrobeRecipeThumb
	{
		public string race;

		public string filename;

		public Sprite thumb;

		public WardrobeRecipeThumb()
		{
		}

		public WardrobeRecipeThumb(string n_race)
		{
		}

		public WardrobeRecipeThumb(string n_race, Sprite n_thumb)
		{
		}
	}
}
