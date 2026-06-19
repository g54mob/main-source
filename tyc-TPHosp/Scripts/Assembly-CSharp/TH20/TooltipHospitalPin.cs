using System.Collections.Generic;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class TooltipHospitalPin : Tooltip
	{
		[SerializeField]
		private TMP_Text _hospitalNameLabel;

		[SerializeField]
		private GameObject _lockIcon;

		[SerializeField]
		private GameObject _starPanel;

		[SerializeField]
		private Image[] _starIconList;

		[SerializeField]
		private Sprite _emptyStarSprite;

		[SerializeField]
		private Sprite _fullStarSprite;

		[SerializeField]
		private TMP_Text _hospitalDescriptionLabel;

		[SerializeField]
		private LayoutElement _hospitalDescriptionLayoutElement;

		[SerializeField]
		private GameObject _statsPanel;

		[SerializeField]
		private TMP_Text _balanceLabel;

		[SerializeField]
		private TMP_Text _prestigeLevelLabel;

		[SerializeField]
		private ProgressBarMaskable _reputationProgressBar;

		[SerializeField]
		private ProgressBarMaskable _prestigeProgressBar;

		[SerializeField]
		private TMP_Text _hospitalValueLabel;

		[SerializeField]
		private GameObject _hospitalDatePanel;

		[SerializeField]
		private TMP_Text _hospitalDateText;

		[SerializeField]
		private GameObject _friendsPanel;

		[SerializeField]
		private List<PlayerAvatar> _friendsPlayedAvatarList;

		[SerializeField]
		private GameObject _lockedRequirementsPanel;

		[SerializeField]
		private Image[] _prerequisiteStarIcons;

		[SerializeField]
		private TMP_Text[] _prerequisiteText;

		[SerializeField]
		private GameObject[] _prerequisiteContainers;

		public void Setup(LevelConfig levelConfig, MetagameHospitalRecord hospitalRecord, Metagame metagame, SaveSystem saveSystem)
		{
			_hospitalNameLabel.text = levelConfig.GetLocalisedDisplayName();
			if (_hospitalDatePanel != null)
			{
				GameObjectUtils.SetActive(_hospitalDatePanel, isActive: false);
			}
			SetHospitalDateText(hospitalRecord.GetHospitalDateMonth(), hospitalRecord.GetHospitalDateYear());
			if (!levelConfig.IsPlayable(metagame))
			{
				GameObjectUtils.SetActive(_lockIcon, isActive: true);
				GameObjectUtils.SetActive(_statsPanel, isActive: false);
				GameObjectUtils.SetActive(_starPanel, isActive: false);
				int num = 0;
				if (levelConfig.LevelPlayablePrerequisites != null)
				{
					LevelProgressPrerequisite[] levelPlayablePrerequisites = levelConfig.LevelPlayablePrerequisites;
					for (int i = 0; i < levelPlayablePrerequisites.Length; i++)
					{
						if (!(levelPlayablePrerequisites[i] is LevelProgressLevelHasStars { Levels: var levels } levelProgressLevelHasStars))
						{
							continue;
						}
						foreach (SharedInstance<LevelConfig> sharedInstance in levels)
						{
							if (num < _prerequisiteContainers.Length)
							{
								GameObjectUtils.SetActive(_prerequisiteContainers[num], isActive: true);
								_prerequisiteText[num].text = sharedInstance.Instance.GetLocalisedDisplayName();
								if (levelProgressLevelHasStars.IsLevelComplete(metagame, sharedInstance))
								{
									_prerequisiteStarIcons[num].sprite = _fullStarSprite;
								}
								else
								{
									_prerequisiteStarIcons[num].sprite = _emptyStarSprite;
								}
							}
							num++;
						}
					}
					if (num < _prerequisiteContainers.Length)
					{
						for (int k = num; k < _prerequisiteContainers.Length; k++)
						{
							GameObjectUtils.SetActive(_prerequisiteContainers[k], isActive: false);
						}
					}
				}
				if (num == 0)
				{
					_hospitalDescriptionLabel.text = levelConfig.GetPlayableRequiredDescription();
					GameObjectUtils.SetActive(_lockedRequirementsPanel, isActive: false);
				}
				else
				{
					GameObjectUtils.SetActive(_lockedRequirementsPanel, isActive: true);
					_hospitalDescriptionLabel.text = string.Empty;
				}
				GameObjectUtils.SetActive(_hospitalDescriptionLabel.gameObject, _hospitalDescriptionLabel.text != string.Empty);
			}
			else
			{
				GameObjectUtils.SetActive(_lockedRequirementsPanel, isActive: false);
				GameObjectUtils.SetActive(_lockIcon, isActive: false);
				GameObjectUtils.SetActive(_starPanel, isActive: true);
				int num2 = hospitalRecord.TotalStars();
				for (int l = 0; l < 3; l++)
				{
					_starIconList[l].overrideSprite = ((l < num2) ? _fullStarSprite : _emptyStarSprite);
				}
				_hospitalDescriptionLabel.text = levelConfig.GetDescriptionForNumStars(num2);
				if (metagame.CurrentLevel != null && levelConfig == metagame.CurrentLevel.Config)
				{
					Level currentLevel = metagame.CurrentLevel;
					GameObjectUtils.SetActive(_statsPanel, isActive: true);
					_balanceLabel.text = StringUtils.FormatCurrencyWithoutSymbol(currentLevel.FinanceManager.Balance);
					_reputationProgressBar.SetProgressSmooth(currentLevel.ReputationTracker.OverallReputation);
					_prestigeProgressBar.SetProgressSmooth(currentLevel.PrestigeTracker.Progress);
					_prestigeLevelLabel.text = string.Format(ScriptLocalization.Misc.PrestigeLevel_CS, currentLevel.PrestigeTracker.Level);
					_hospitalValueLabel.text = StringUtils.FormatCurrencyWithoutSymbol(currentLevel.LevelStatsDatabase.HospitalValue);
				}
				else
				{
					SaveFileHeader saveForLevel = saveSystem.GetSaveForLevel(levelConfig.UniqueId);
					if (saveForLevel != null)
					{
						GameObjectUtils.SetActive(_statsPanel, isActive: true);
						_balanceLabel.text = StringUtils.FormatCurrencyWithoutSymbol(saveForLevel.Balance);
						_reputationProgressBar.SetProgressSmooth(saveForLevel.Reputation);
						_prestigeProgressBar.SetProgressSmooth(saveForLevel.HospitalLevelProgress);
						_prestigeLevelLabel.text = string.Format(ScriptLocalization.Misc.PrestigeLevel_CS, saveForLevel.HospitalLevel);
						_hospitalValueLabel.text = StringUtils.FormatCurrencyWithoutSymbol(saveForLevel.HospitalValue);
					}
					else
					{
						GameObjectUtils.SetActive(_statsPanel, isActive: false);
					}
				}
				if (_hospitalDescriptionLabel.preferredHeight < 800f)
				{
					_hospitalDescriptionLayoutElement.preferredHeight = _hospitalDescriptionLabel.preferredHeight;
				}
				GameObjectUtils.SetActive(_hospitalDescriptionLabel.gameObject, _hospitalDescriptionLabel.text != string.Empty);
			}
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				GameObjectUtils.SetActive(_friendsPanel, isActive: false);
				return;
			}
			List<OnlinePlayerID> list = new List<OnlinePlayerID>();
			foreach (KeyValuePair<OnlinePlayerID, OnlineMetadata> item in metagame.OnlineMetadataManager.GetMetadataCache())
			{
				if (item.Value.IsVisible() && item.Value.HasPlayedLevel(levelConfig))
				{
					list.Add(item.Key);
				}
			}
			GameObjectUtils.SetActive(_friendsPanel, list.Count > 0);
			for (int m = 0; m < list.Count && m < _friendsPlayedAvatarList.Count; m++)
			{
				_friendsPlayedAvatarList[m].PlayerID = list[m];
				_friendsPlayedAvatarList[m].NumUnseenNotifications = metagame.OnlineChallengeViewRecord.GetNumUnseenEventsForOnlineChallengeInLevelForOnlinePlayerId(levelConfig, list[m]);
				GameObjectUtils.SetActive(_friendsPlayedAvatarList[m].gameObject, isActive: true);
			}
			for (int n = list.Count; n < _friendsPlayedAvatarList.Count; n++)
			{
				GameObjectUtils.SetActive(_friendsPlayedAvatarList[n].gameObject, isActive: false);
				_friendsPlayedAvatarList[n].PlayerID = OnlinePlayerID.Nil;
			}
		}

		private void SetHospitalDateText(int dateMonth, int dateYear)
		{
			if ((dateMonth != 0 || dateYear != 0) && !(_hospitalDatePanel == null) && !(_hospitalDateText == null))
			{
				GameObjectUtils.SetActive(_hospitalDatePanel, isActive: true);
				_hospitalDateText.text = GameStringUtils.GetHospitalAgeString(dateMonth, dateYear);
			}
		}
	}
}
