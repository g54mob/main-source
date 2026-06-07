using System;
using Newtonsoft.Json;

namespace VampireSurvivors.Objects
{
	[Serializable]
	public class ModifierStats
	{
		[JsonProperty("power")]
		public float Power { get; set; }

		[JsonProperty("area")]
		public float Area { get; set; }

		[JsonProperty("speed")]
		public float Speed { get; set; }

		[JsonProperty("moveSpeed")]
		public float MoveSpeed { get; set; }

		[JsonProperty("growth")]
		public float Growth { get; set; }

		[JsonProperty("luck")]
		public float Luck { get; set; }

		[JsonProperty("duration")]
		public float Duration { get; set; }

		[JsonProperty("cooldown")]
		public float Cooldown { get; set; }

		[JsonProperty("amount")]
		public float Amount { get; set; }

		[JsonProperty("shields")]
		public float Shields { get; set; }

		[JsonProperty("armor")]
		public float Armor { get; set; }

		[JsonProperty("greed")]
		public float Greed { get; set; }

		[JsonProperty("regen")]
		public float Regen { get; set; }

		[JsonProperty("revivals")]
		public double Revivals { get; set; }

		[JsonProperty("rerolls")]
		public float ReRolls { get; set; }

		[JsonProperty("skips")]
		public float Skips { get; set; }

		[JsonProperty("maxHp")]
		public float MaxHp { get; set; }

		[JsonProperty("magnet")]
		public float Magnet { get; set; }

		[JsonProperty("curse")]
		public float Curse { get; set; }

		[JsonProperty("banish")]
		public float Banish { get; set; }

		[JsonProperty("shroud")]
		public float Shroud { get; set; }

		[JsonProperty("charm")]
		public int Charm { get; set; }

		[JsonProperty("defang")]
		public float Defang { get; set; }

		[JsonProperty("thorns")]
		public float Thorns { get; set; }

		[JsonProperty("invulTimeBonus")]
		public float InvulTimeBonus { get; set; }

		[JsonProperty("fever")]
		public float Fever { get; set; }

		[JsonProperty("recycle")]
		public float Recycle { get; set; }

		public void ResetStats()
		{
		}

		public void Upgrade(ModifierStats other, bool multiplicativeMaxHp = false)
		{
		}

		public void LogClass()
		{
		}

		public static ModifierStats operator *(ModifierStats stats, float f)
		{
			return null;
		}
	}
}
