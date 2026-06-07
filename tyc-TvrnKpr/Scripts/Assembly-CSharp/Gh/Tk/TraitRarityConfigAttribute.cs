using System;

namespace Gh.Tk
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
	internal sealed class TraitRarityConfigAttribute : Attribute
	{
		public float Rarity { get; private set; }

		public string Race { get; private set; }

		public TraitRarityConfigAttribute(float rarity, string race = null)
		{
		}

		public static float GetTraitRarity(Type traitType, string race)
		{
			return 0f;
		}
	}
}
