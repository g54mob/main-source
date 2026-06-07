using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Poncle.Schema.Attributes.Attributes;
using VampireSurvivors.Objects.Algorithm;

namespace VampireSurvivors.Data.Weapons
{
	[Serializable]
	public class WeaponData
	{
		[Title("Custom Desc Value")]
		[CanBeNull]
		public string customDescValue;

		[Title("Hidden")]
		public bool hidden { get; set; }

		[Title("Always Hidden")]
		public bool alwaysHidden { get; set; }

		[Title("Level")]
		public int level { get; set; }

		[Title("Bullet Type")]
		public WeaponType bulletType { get; set; }

		[Title("Name")]
		public string name { get; set; }

		[Title("Description")]
		public string description { get; set; }

		[Title("Tips")]
		public string tips { get; set; }

		[Title("Texture")]
		public string texture { get; set; }

		[Title("Frame Name")]
		public string frameName { get; set; }

		[Title("Collection Frame")]
		public string collectionFrame { get; set; }

		[Title("Evo Into")]
		public string evoInto { get; set; }

		[Title("Evo Synergy")]
		public WeaponType[] evoSynergy { get; set; }

		[Title("Is Evolution")]
		public bool isEvolution { get; set; }

		[Title("Is Special Only")]
		public bool isSpecialOnly { get; set; }

		[Title("Evolves From")]
		public List<WeaponType> evolvesFrom { get; set; }

		[Title("Requires")]
		public List<WeaponType> requires { get; set; }

		[Title("Requires Max")]
		public List<WeaponType> requiresMax { get; set; }

		[Title("Evolution Line")]
		public List<WeaponType> evolutionLine { get; set; }

		[Title("Is Unlocked")]
		public bool isUnlocked { get; set; }

		[Title("Volume")]
		public float? volume { get; set; }

		[Title("Pool Limit")]
		public int? poolLimit { get; set; }

		[Title("Rarity")]
		public int rarity { get; set; }

		[Title("Interval")]
		public float interval { get; set; }

		[Title("Duration")]
		public float? duration { get; set; }

		[Title("Repeat Interval")]
		public float repeatInterval { get; set; }

		[Title("Power")]
		public float power { get; set; }

		[Title("Secondary Power")]
		public float secondaryPower { get; set; }

		[Title("Knockback")]
		public float? knockback { get; set; }

		[Title("Hit Box Delay")]
		public float? hitBoxDelay { get; set; }

		[Title("Area")]
		public float area { get; set; }

		[Title("Speed")]
		public float speed { get; set; }

		[Title("Amount")]
		public int amount { get; set; }

		[Title("Crit Chance")]
		public float critChance { get; set; }

		[Title("Hits Walls")]
		public bool hitsWalls { get; set; }

		[Title("Crit Mul")]
		public float critMul { get; set; }

		[Title("Seen")]
		public bool seen { get; set; }

		[Title("Add Evolved Weapon")]
		public WeaponType? addEvolvedWeapon { get; set; }

		[Title("Add Normal Weapon")]
		public WeaponType? addNormalWeapon { get; set; }

		[Title("Exclude Weapon")]
		public WeaponType? excludeWeapon { get; set; }

		[Title("Charges")]
		public int charges { get; set; }

		[Title("Interval Depends On Duration")]
		public bool intervalDependsOnDuration { get; set; }

		[Title("Is Power Up")]
		public bool isPowerUp { get; set; }

		[Title("Penetrating")]
		public int penetrating { get; set; }

		[Title("Hit VFX")]
		public HitVfxType hitVFX { get; set; }

		[Title("Forced Synergy Weapons")]
		public List<WeaponType> forcedSynergyWeapons { get; set; }

		[Title("Skip Removing Base Weapon")]
		public bool skipRemovingBaseWeapon { get; set; }

		[Title("Has Unique Requirements")]
		public bool hasUniqueRequirements { get; set; }

		[Title("Cooldown")]
		public float cooldown { get; set; }

		[Title("Max HP")]
		public float maxHp { get; set; }

		[Title("Move Speed")]
		public float moveSpeed { get; set; }

		[Title("Growth")]
		public float growth { get; set; }

		[Title("Magnet")]
		public float magnet { get; set; }

		[Title("Luck")]
		public float luck { get; set; }

		[Title("Armor")]
		public float armor { get; set; }

		[Title("Greed")]
		public float greed { get; set; }

		[Title("Regen")]
		public float regen { get; set; }

		[Title("Revivals")]
		public float revivals { get; set; }

		[Title("Rerolls")]
		public float rerolls { get; set; }

		[Title("Skips")]
		public float skips { get; set; }

		[Title("Chance")]
		public float chance { get; set; }

		[Title("BGM")]
		public string bgm { get; set; }

		[Title("Shield Invul Time")]
		public float? shieldInvulTime { get; set; }

		[Title("Curse")]
		public float curse { get; set; }

		[Title("Desc")]
		public string desc { get; set; }

		[Title("Charm")]
		public float charm { get; set; }

		[Title("Fever")]
		public float fever { get; set; }

		[Title("Invul Time Bonus")]
		public float invulTimeBonus { get; set; }

		[Title("Custom Desc")]
		public float? customDesc { get; set; }

		[Title("Unexclude Self")]
		public bool unexcludeSelf { get; set; }

		[Title("Drop Rate Affected By Luck")]
		public bool dropRateAffectedByLuck { get; set; }

		[Title("Sealable")]
		public bool sealable { get; set; }

		[Title("Price")]
		public float? price { get; set; }

		[Title("Applies Only To Owner")]
		public bool appliesOnlyToOwner { get; set; }

		[Title("Allow Duplicates")]
		public bool allowDuplicates { get; set; }

		[Title("Despawn On Unavailable")]
		public bool despawnOnUnavailable { get; set; }

		[Title("Content Group")]
		public ContentGroupType contentGroup { get; set; }

		[Title("Follower Type")]
		public CharacterType followerType { get; set; }

		[Title("Follower AI")]
		public AIType followerAI { get; set; }

		public string GetLocalizedNameTerm(WeaponType wType)
		{
			return null;
		}

		public string GetLocalizedDescriptionTerm(WeaponType wType)
		{
			return null;
		}

		public string GetLocalizedTipsTerm(WeaponType wType)
		{
			return null;
		}

		public string GetLocalizedDescriptionForLevel(WeaponData levelData, WeaponType weaponType)
		{
			return null;
		}

		private string GetLevelUpAllPrefixTranslation()
		{
			return null;
		}

		private string GetTranslation(string term)
		{
			return null;
		}

		public string GetCustomDescription(WeaponType t, float value)
		{
			return null;
		}

		public string GetDescription(string term, float value)
		{
			return null;
		}

		public string GetDescriptionPercent(string term, float value)
		{
			return null;
		}

		private string GetDescriptionWithDecimalFormatting(string term, float value, int decimalPlaces)
		{
			return null;
		}

		private string GetPrefix(WeaponType wType)
		{
			return null;
		}
	}
}
