using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Persistence.Achievements
{
	[Serializable]
	public class AchievementSetting
	{
		public EAchievement AchievementType;

		public Texture2D UnlockedIcon;

		public Texture2D LockedIcon;

		public TranslationTerm Name;

		public TranslationTerm Description;

		public TranslationTerm RewardText;
	}
}
