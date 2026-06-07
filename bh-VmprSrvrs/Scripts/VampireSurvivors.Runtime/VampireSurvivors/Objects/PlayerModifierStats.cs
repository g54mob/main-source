using System;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects
{
	[Serializable]
	public class PlayerModifierStats
	{
		public EggFloat Power { get; set; }

		public EggFloat Area { get; set; }

		public EggFloat Speed { get; set; }

		public EggFloat MoveSpeed { get; set; }

		public EggFloat Growth { get; set; }

		public EggFloat Luck { get; set; }

		public EggFloat Duration { get; set; }

		public EggFloat Cooldown { get; set; }

		public EggFloat Amount { get; set; }

		public EggFloat Armor { get; set; }

		public EggFloat Greed { get; set; }

		public EggFloat Regen { get; set; }

		public EggFloat ReRolls { get; set; }

		public EggFloat Skips { get; set; }

		public EggFloat MaxHp { get; set; }

		public EggFloat Magnet { get; set; }

		public EggFloat Curse { get; set; }

		public EggFloat Banish { get; set; }

		public EggDouble Revivals { get; set; }

		public int UsedRevivals { get; set; }

		public float Shroud { get; set; }

		public float Shields { get; set; }

		public int Charm { get; set; }

		public float Defang { get; set; }

		public float Thorns { get; set; }

		public float InvulTimeBonus { get; set; }

		public float Fever { get; set; }

		public float Recycle { get; set; }

		public void ResetStats()
		{
		}

		public void Set(ModifierStats modifierStats)
		{
		}

		public void Upgrade(ModifierStats other, bool multiplicativeMaxHp = false)
		{
		}
	}
}
