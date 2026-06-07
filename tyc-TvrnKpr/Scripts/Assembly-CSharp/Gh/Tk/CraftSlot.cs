using System;
using UnityEngine;

namespace Gh.Tk
{
	[Serializable]
	public class CraftSlot : IEquatable<CraftSlot>
	{
		public string DisplayName;

		public GameObject Icon;

		public string[] allowedTypes;

		public string[] disallowedTypes;

		public bool isMandatory;

		public float weighting;

		public int amount;

		public bool IsValid(IngredientTemplate ingredientTemplate)
		{
			return false;
		}

		public bool Equals(CraftSlot other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(CraftSlot left, CraftSlot right)
		{
			return false;
		}

		public static bool operator !=(CraftSlot left, CraftSlot right)
		{
			return false;
		}
	}
}
