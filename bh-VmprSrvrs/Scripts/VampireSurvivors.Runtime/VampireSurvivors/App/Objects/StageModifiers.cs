using System;
using Poncle.Schema.Attributes.Attributes;

namespace VampireSurvivors.App.Objects
{
	[Serializable]
	[Title("Stage Modifiers")]
	public class StageModifiers
	{
		[Title("Time Limit")]
		public float? TimeLimit { get; set; }

		[Title("Clock Speed")]
		public float? ClockSpeed { get; set; }

		[Title("Player Px Speed")]
		public float? PlayerPxSpeed { get; set; }

		[Title("Enemy Speed")]
		public float? EnemySpeed { get; set; }

		[Title("Projectile Speed")]
		public float? ProjectileSpeed { get; set; }

		[Title("Gold Multiplier")]
		public float? GoldMultiplier { get; set; }

		[Title("Enemy Health Multiplier")]
		public float? EnemyHealthMultiplier { get; set; }

		[Title("Luck Bonus")]
		public float? LuckBonus { get; set; }

		[Title("XP Bonus")]
		public float? XpBonus { get; set; }

		[Title("Starting Spawns")]
		public float? StartingSpawns { get; set; }

		[Title("End Cycles")]
		public float? EndCycles { get; set; }

		public TimeMods TimeMods { get; set; }

		[Title("Unlocked")]
		public bool unlocked { get; set; }

		[Title("Enemy Minimum Mul")]
		public float EnemyMinimumMul { get; set; }

		[Title("BGM Rate")]
		public float BGM_rate { get; set; }

		[Title("BGM Detune")]
		public int BGM_detune { get; set; }

		[Title("BGM - Ignore Mods for New Soundtrack")]
		public bool BGM_ignoreModsForNewSoundtrack { get; set; }

		[Title("BGM New Rate")]
		public float BGM_new_rate { get; set; }

		[Title("BGM New Detune")]
		public int BGM_new_detune { get; set; }

		[Title("Tint")]
		public uint? tint { get; set; }

		public void SetStageDefaults()
		{
		}

		public void Add(StageModifiers data)
		{
		}

		public void Set(StageModifiers data)
		{
		}
	}
}
