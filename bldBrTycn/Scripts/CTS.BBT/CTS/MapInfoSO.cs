using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.ScriptableSettings;
using Eflatun.SceneReference;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(fileName = "MapInfoSO", menuName = "BBT/MapSelection")]
	public class MapInfoSO : ScriptableObject
	{
		[SerializeField]
		private List<string> _starsSuccesOrder = new List<string>();

		[field: SerializeField]
		public bool AvailableInDemo { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Base Settings")]
		public SceneReference SceneToLoad { get; private set; }

		[field: SerializeField]
		public Sprite MapIcon { get; private set; }

		[field: SerializeField]
		public Sprite MapIconBig { get; private set; }

		[field: SerializeField]
		public EActors MainCharacter { get; private set; }

		[field: SerializeField]
		public MapInfoSO MapToUnlock { get; private set; }

		[field: SerializeField]
		public SettingObject<bool> FreeModeUnlock { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Localization Information")]
		[field: Space(10f)]
		public LocalizedString LevelNameLocalizationString { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Localization Information")]
		public LocalizedString LevelDescriptionLocalizationString { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Localization Information")]
		public LocalizedString StoryModeTitle { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Localization Information")]
		public LocalizedString StoryModeSubtitle { get; private set; }

		public static event Action<MapInfoSO> MapWinScore;

		public static event Action<MapInfoSO, int> CheckSuccesToiletAndLoan;

		public static event Action MapWinThreeStars;

		public void SetScoreInProfile(int score)
		{
			MapInfoSO.CheckSuccesToiletAndLoan?.Invoke(this, score);
			Debug.Log(GetScoreInProfile() + " " + score);
			if (GetScoreInProfile() < score && CTSSingleton<ProfileManager>.TryGetInstance(out var outInstance) && outInstance.CurrentProfile is CareerProfile careerProfile)
			{
				if (score > 0)
				{
					FreeModeUnlock?.SetValue(value: true);
				}
				careerProfile.SetScore(this, score);
				MapInfoSO.MapWinScore?.Invoke(this);
				CheckIfWeNeedSucces();
			}
		}

		private void CheckIfWeNeedSucces()
		{
			int num = -1;
			switch (GetScoreInProfile())
			{
			case 2:
				num = 0;
				break;
			case 4:
				num = 1;
				break;
			case 6:
				num = 2;
				MapInfoSO.MapWinThreeStars?.Invoke();
				break;
			}
			if (num >= 0 && _starsSuccesOrder[num] != null)
			{
				AchievementManager.UnlockAchievement(_starsSuccesOrder[num]);
			}
		}

		public int GetScoreInProfile()
		{
			if (CTSSingleton<ProfileManager>.TryGetInstance(out var outInstance) && outInstance.CurrentProfile is CareerProfile { LevelProgress: var levelProgress })
			{
				return levelProgress[this].Score;
			}
			return 0;
		}
	}
}
