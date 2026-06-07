using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Poncle.Schema.Attributes.Attributes;

namespace VampireSurvivors.Data.Enemies
{
	[Serializable]
	public class EnemyData
	{
		[JsonIgnore]
		public List<string> Internal_FrameNamesAnim;

		[JsonIgnore]
		public List<List<string>> Internal_IdleAnimFrameNames;

		[JsonIgnore]
		public List<List<string>> Internal_DeathAnimFrameNames;

		[Title("Level")]
		public int level { get; set; }

		[Title("Max HP")]
		public float maxHp { get; set; }

		[Title("Speed")]
		public float speed { get; set; }

		[Title("Max Speed")]
		public float maxSpeed { get; set; }

		[Title("Power")]
		public float power { get; set; }

		[Title("Skills")]
		public List<EnemySkillType> skills { get; set; }

		[Title("Minimum HP Scale Level")]
		public int? minimumHpScalingLevel { get; set; }

		[Title("Maximum HP Scale Level")]
		public int? maximumHpScalingLevel { get; set; }

		[Title("Shield Duration")]
		public float shieldDuration { get; set; }

		[Title("Knockback")]
		public float knockback { get; set; }

		[Title("Max Knockback")]
		public float maxKnockback { get; set; }

		[Title("Death KB")]
		public float deathKB { get; set; }

		[Title("Tint")]
		public uint? tint { get; set; }

		[Title("XP")]
		public float xp { get; set; }

		[Title("More X")]
		public int moreX { get; set; }

		[Title("More Y")]
		public int moreY { get; set; }

		[Title("Alpha")]
		public float alpha { get; set; }

		[Title("Scale")]
		public float? scale { get; set; }

		[Title("Res Freeze")]
		public float? res_Freeze { get; set; }

		[Title("Res Rosary")]
		public float? res_Rosary { get; set; }

		[Title("Res Debuffs")]
		public float? res_Debuffs { get; set; }

		[Title("Res Knockback")]
		public float? res_Knockback { get; set; }

		[Title("Res Corridor")]
		public float? res_Corridor { get; set; }

		[Title("Res Defang")]
		public float? res_Defang { get; set; }

		[Title("Pass Through Walls")]
		public bool passThroughWalls { get; set; }

		[Title("Cannot Be Follower")]
		public bool CannotBeFollower { get; set; }

		public ColliderOverride colliderOverride { get; set; }

		[Title("Weak Fire")]
		public float? weak_Fire { get; set; }

		[Title("Skip Credits")]
		public bool skipCredits { get; set; }

		[Title("Idle Frame Count")]
		public int idleFrameCount { get; set; }

		[Title("Killed Amount")]
		public float killedAmount { get; set; }

		[Title("Texture Name")]
		[Required]
		public string textureName { get; set; }

		[Title("End")]
		public int end { get; set; }

		[Title("Frame Names")]
		[Required]
		public List<string> frameNames { get; set; }

		[Title("Patrol Duration")]
		public float patrolDuration { get; set; }

		[Title("Fire Delay")]
		public float? fireDelay { get; set; }

		[Title("Fire Delay Randomness")]
		public float? fireDelayRandomness { get; set; }

		[Title("Firing Range Min")]
		public float? firingRangeMin { get; set; }

		[Title("Firing Range Max")]
		public float? firingRangeMax { get; set; }

		[Title("Bullet Type")]
		public EnemyType? bulletType { get; set; }

		[Title("Lives")]
		public int? lives { get; set; }

		[Title("Flag Name")]
		public string flagName { get; set; }

		[Title("Alias")]
		public EnemyData alias { get; set; }

		[Title("Fever Value")]
		public float feverValue { get; set; }

		[Title("Name")]
		public string bName { get; set; }

		[Title("Description")]
		public string bDesc { get; set; }

		[Title("Places")]
		public List<StageType> bPlaces { get; set; }

		[Title("Include")]
		public bool bInclude { get; set; }

		[Title("Ignore")]
		public bool bIgnore { get; set; }

		[Title("Highlight")]
		public bool bHighlight { get; set; }

		[Title("Variants")]
		public List<EnemyType> bVariants { get; set; }

		[Title("Include Color Variants")]
		public bool bIncludeColorVariants { get; set; }

		[Title("Material Type")]
		public MaterialType materialType { get; set; }

		public string GetLocalizedDescription(EnemyType type)
		{
			return null;
		}

		public string GetLocalizedTips(EnemyType type)
		{
			return null;
		}

		public string GetLocalizedDescriptionTerm(EnemyType type)
		{
			return null;
		}

		public string GetLocalizedNameTerm(EnemyType type)
		{
			return null;
		}

		public string GetLocalizedBestiaryNameTerm(EnemyType type)
		{
			return null;
		}

		public string GetLocalizedBestiaryDescription(EnemyType type)
		{
			return null;
		}

		public string GetLocalizedTipsTerm(EnemyType type)
		{
			return null;
		}

		public string GetLocalPrefix(EnemyType t)
		{
			return null;
		}
	}
}
