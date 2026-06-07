using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Achievements;

namespace VampireSurvivors.Data
{
	public class SecretData
	{
		private const string _prefix = "secretLang/";

		public string description { get; set; }

		public CharacterType? characterToUnlock { get; set; }

		public WeaponType? weaponToUnlock { get; set; }

		public StageType? stageToUnlock { get; set; }

		public StageType? hyperToUnlock { get; set; }

		public ItemType? relicToUnlock { get; set; }

		public ArcanaType? arcanaToUnlock { get; set; }

		public PowerUpType? powerUpToUnlock { get; set; }

		public bool mistery { get; set; }

		public bool achieved { get; set; }

		public bool isSpell { get; set; }

		public string spell { get; set; }

		public string special { get; set; }

		public bool hidden { get; set; }

		public int? goldPrize { get; set; }

		public bool isModifier { get; set; }

		public List<SkinToUnlock> skinsToUnlock { get; set; }

		public List<WeaponType> weaponListToUnlock { get; set; }

		public ItemType? requiresRelic { get; set; }

		public string customTexture { get; set; }

		public string customFrame { get; set; }

		public string customSmallTexture { get; set; }

		public string customSmallFrame { get; set; }

		public Sprite GetSecondReward(DataManager dataManager)
		{
			return null;
		}

		public string GetLocalizedDescriptionTerm(SecretType t)
		{
			return null;
		}
	}
}
