using System;
using System.Collections.Generic;
using Unity.Mathematics;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterSkillCard_RandomGenerator
	{
		public enum STATNAME
		{
			Amount = 0,
			Area = 1,
			Armor = 2,
			Cooldown = 3,
			Banish = 4,
			Charm = 5,
			Curse = 6,
			Defang = 7,
			Duration = 8,
			Fever = 9,
			Greed = 10,
			Growth = 11,
			InvulTimeBonus = 12,
			Luck = 13,
			Magnet = 14,
			MaxHp = 15,
			MoveSpeed = 16,
			Power = 17,
			Recycle = 18,
			Regen = 19,
			ReRolls = 20,
			Revivals = 21,
			Shroud = 22,
			Skips = 23,
			Speed = 24
		}

		public struct WeightedArcana
		{
			public ArcanaData data;

			public float weight;
		}

		public static Dictionary<STATNAME, float[]> StatBonuses;

		public static Dictionary<STATNAME, float[]> StatPerLevelGrowth;

		private static Array StatNameValues;

		private static bool IsInitialised;

		public static int TotalWeight;

		public static List<ArcanaType> SubSkills_Foil;

		public static List<ArcanaType> SubSkills_All;

		public static List<ArcanaType> SubSkills_AddWeapon;

		public static List<ArcanaType> SubSkills_XLevel;

		public static List<ArcanaType> SubSkills_OnSkip;

		public static List<ArcanaType> SubSkills_EnemiesCount;

		public static List<ArcanaType> SubSkills_OnDamaged;

		public static List<ArcanaType> SubSkills_OnRevive;

		public static List<ArcanaType> SubSkills_Passives;

		public static List<ArcanaType> SubSkills_GoldCount;

		public static List<ArcanaType> SubSkills_Overheal;

		public static List<ArcanaType> SubSkills_HPCritical;

		public static int NUM_SET_DEFAULT;

		public static int NUM_SET_EXPANSION1;

		public static List<WeightedArcana> WeightedSurvarots { get; set; }

		public static void Init()
		{
		}

		public static void GetRandomModifierStat(ModifierStats stats, bool isGrowthValue = false)
		{
		}

		public static void GetRandomModifierGrowth(ModifierStats stats)
		{
		}

		public static void ChangeStats(ModifierStats stats, STATNAME converted, float bonusAmount)
		{
		}

		public static List<int> GetRandomLevelProgression()
		{
			return null;
		}

		public static ArcanaType GetRandomSubCard()
		{
			return default(ArcanaType);
		}

		public static ArcanaType GetRandomSubCard(List<ArcanaType> list)
		{
			return default(ArcanaType);
		}

		public static ArcanaType GetOneSurvarotFromWeightedList(List<ArcanaType> exclusions, ref Unity.Mathematics.Random random)
		{
			return default(ArcanaType);
		}

		public static List<ArcanaType> GetWeightedSurvarots(int cardsNumber, ref Unity.Mathematics.Random random)
		{
			return null;
		}
	}
}
