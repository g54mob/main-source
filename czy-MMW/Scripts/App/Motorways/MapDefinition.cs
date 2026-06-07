using System;
using System.Collections.Generic;
using Factory;
using JetBrains.Annotations;
using Motorways.Themes;
using NaughtyAttributes;
using UnityEngine;

namespace Motorways
{
	[CreateAssetMenu(fileName = "New Map", menuName = "Motorways/Map Definition", order = 1)]
	public class MapDefinition : ScriptableObject
	{
		public enum CityNames
		{
			None = 0,
			LosAngeles = 1,
			Beijing = 2,
			MexicoCity = 3,
			DarEsSalaam = 4,
			Moscow = 5,
			Tokyo = 6,
			Munich = 7,
			Manila = 8,
			Zurich = 9,
			RioDeJaneiro = 10,
			Dubai = 11,
			Wellington = 12,
			Warsaw = 13,
			ChiangMai = 14,
			Lisbon = 15,
			Busan = 16,
			London = 17,
			Mumbai = 18,
			NewYorkCity = 19,
			Reykjavik = 20,
			Vancouver = 21,
			Cairns = 22,
			Copenhagen = 23,
			HongKong = 24,
			CapeTown = 25
		}

		[EnumSearch(typeof(CityNames), false, isString = true)]
		public string cityName;

		[EnumSearch(typeof(StringId), false, isString = true)]
		public string mapName;

		[EnumSearch(typeof(StringId), false, isString = true)]
		public string mapDescription;

		public string mapAssetBundle;

		public string mapPrefabName;

		[NonReorderable]
		[EnumTypedArray(typeof(MotorwaysThemePreference))]
		[Space(20f)]
		public Theme[] themes = new Theme[5];

		[NonReorderable]
		[EnumTypedArray(typeof(MotorwaysThemePreference))]
		public Sprite[] themePreviewSprites = new Sprite[5];

		[Tooltip("What upgrades does this map provide?")]
		public UpgradeType[] availableUpgrades;

		[Tooltip("What score does the player need to unlock challenge mode?")]
		public int challengeModeTargetScore;

		public CityChallengeData[] cityChallenges;

		[SerializeField]
		[CanBeNull]
		private AchievementData _expertRequiredAchievement;

		[InfoBox("Completing any of the achievements in this list will unlock this map.", InfoBoxType.Normal, null)]
		[CanBeNull]
		[SerializeField]
		public List<AchievementData> _achievementsThatUnlockMap;

		[EnumSearch(typeof(StringId), false, isString = true)]
		public string howToUnlockDescription;

		public bool isTrainMap;

		public bool isBoatMap;

		public CityNames CityNameEnum => (CityNames)Enum.Parse(typeof(CityNames), cityName, ignoreCase: true);

		public StringId HowToUnlockDescription
		{
			get
			{
				if (Enum.TryParse<StringId>(howToUnlockDescription, out var result))
				{
					return result;
				}
				return StringId.None;
			}
		}

		public bool IsLocked(IScope scope)
		{
			if (FeatureToggle.IsFeatureDisabled(Feature.MapUnlocks))
			{
				return false;
			}
			if (FeatureToggle.IsFeatureEnabled(Feature.AppleStoreDemo) && _achievementsThatUnlockMap != null)
			{
				return true;
			}
			ActivePlayer activePlayer = scope.Get<ActivePlayer>();
			AchievementDatabase achievementDatabase = scope.Get<AchievementDatabase>();
			MotorwaysCityStatistics cityStatisticsForCity = activePlayer.GetCityStatisticsForCity(cityName, GameMode.Normal);
			if (cityStatisticsForCity != null && cityStatisticsForCity.MaxTrips > 0)
			{
				return false;
			}
			if (_achievementsThatUnlockMap == null || _achievementsThatUnlockMap.Count == 0)
			{
				return false;
			}
			if (_achievementsThatUnlockMap.Count == 1 && _achievementsThatUnlockMap[0] == null)
			{
				return false;
			}
			foreach (AchievementData item in _achievementsThatUnlockMap)
			{
				if (!(item == null) && activePlayer.IsAchievementCompleted(achievementDatabase[item.GetId()]))
				{
					return false;
				}
			}
			return true;
		}

		public bool IsExpertModeUnlocked(IScope scope)
		{
			if (FeatureToggle.IsFeatureDisabled(Feature.MapUnlocks))
			{
				return true;
			}
			if (FeatureToggle.IsFeatureEnabled(Feature.ExpertLock))
			{
				return false;
			}
			ActivePlayer activePlayer = scope.Get<ActivePlayer>();
			AchievementDatabase achievementDatabase = scope.Get<AchievementDatabase>();
			if (_expertRequiredAchievement == null)
			{
				return true;
			}
			return activePlayer.IsAchievementCompleted(achievementDatabase[_expertRequiredAchievement.GetId()]);
		}

		public bool IsCityChallengeLocked(IScope scope)
		{
			if (FeatureToggle.IsFeatureDisabled(Feature.MapUnlocks))
			{
				return false;
			}
			if (FeatureToggle.IsFeatureDisabled(Feature.CityChallenges))
			{
				return false;
			}
			if (FeatureToggle.IsFeatureEnabled(Feature.AppleStoreDemo))
			{
				return true;
			}
			return scope.Get<ActivePlayer>().GetCityStatisticsForCity(cityName, GameMode.Normal, createIfNecessary: true).MaxTrips < challengeModeTargetScore;
		}

		public bool HasUpgradeType(UpgradeType upgradeType)
		{
			UpgradeType[] array = availableUpgrades;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == upgradeType)
				{
					return true;
				}
			}
			return false;
		}
	}
}
