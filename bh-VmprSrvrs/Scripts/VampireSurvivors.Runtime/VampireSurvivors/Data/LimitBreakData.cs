using System;
using VampireSurvivors.Data.Weapons;

namespace VampireSurvivors.Data
{
	[Serializable]
	public class LimitBreakData
	{
		public int rarity { get; set; }

		public float? power { get; set; }

		public float? area { get; set; }

		public float? speed { get; set; }

		public int? max { get; set; }

		public int? penetrating { get; set; }

		public int? amount { get; set; }

		public float? chance { get; set; }

		public int? duration { get; set; }

		public float? critChance { get; set; }

		public float? cooldown { get; set; }

		public WeaponType? addEvolvedWeapon { get; set; }

		public void AccumulateData(LimitBreakData limitBreakData)
		{
		}

		public void ApplyDataToWeapon(WeaponData weaponData)
		{
		}

		public string GetLocalizedDescription()
		{
			return null;
		}

		private string GetDescription(string term, decimal value, int decimalPlaces = 0)
		{
			return null;
		}
	}
}
