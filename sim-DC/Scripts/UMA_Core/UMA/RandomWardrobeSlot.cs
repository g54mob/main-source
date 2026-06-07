using System;
using System.Collections.Generic;
using UMA.CharacterSystem;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class RandomWardrobeSlot
	{
		public UMAWardrobeRecipe WardrobeSlot;

		[Range(1f, 100f)]
		public int Chance;

		public List<RandomColors> Colors;

		public string _slotName;

		public string SlotName => null;

		public RandomWardrobeSlot(UMAWardrobeRecipe slot, string slotName)
		{
		}
	}
}
