using System;
using System.Collections.Generic;
using System.Globalization;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using Steamworks;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SelectedHospitalMenu : AnimatedMenuBase
	{
		[SerializeField]
		private Localize _hospitalNameLabel;

		[SerializeField]
		private GameObject _hospitalDescriptionPanel;

		[SerializeField]
		private TMP_Text _hospitalDescriptionText;

		[SerializeField]
		private GameObject _starsPanel;

		[SerializeField]
		private Image[] _starImages;

		[SerializeField]
		private Sprite _emptyStarSprite;

		[SerializeField]
		private Sprite _fullStarSprite;

		[SerializeField]
		private GameObject _hospitalDatePanel;

		[SerializeField]
		private TMP_Text _hospitalDateText;

		[SerializeField]
		private GameObject _currentSavePanel;

		[SerializeField]
		private Image _currentSaveScreenshot;

		[SerializeField]
		private TMP_Text _balanceValueLabel;

		[SerializeField]
		private TMP_Text _hospitalValueLabel;

		[SerializeField]
		private ProgressBarMaskable _reputationProgressBar;

		[SerializeField]
		private ProgressBarMaskable _prestigeProgressBar;

		[SerializeField]
		private TMP_Text _prestigeValueLabel;

		[SerializeField]
		private TMP_Text _saveDateAndTimeLabel;

		[SerializeField]
		private Localize _saveDateAndTimeLabelLocalize;

		[SerializeField]
		private GameObject _friendsPanel;

		[SerializeField]
		private PlayerAvatar[] _playerAvatars;

		[SerializeField]
		private DynamicButton _friendsPageLeftButton;

		[SerializeField]
		private DynamicButton _friendsPageRightButton;

		[SerializeField]
		private DynamicButton _button;

		[SerializeField]
		private Localize _buttonText;

		[SerializeField]
		private Sprite _buttonEnabledSprite;

		[SerializeField]
		private Sprite _buttonDisabledSprite;

		[SerializeField]
		private DynamicButton _startNewButton;

		[SerializeField]
		private Localize _startNewButtonText;

		[SerializeField]
		private GameObject _startNewButtonPanel;

		[SerializeField]
		private string _startNewButtonSFXDefault;

		[SerializeField]
		private string _startNewButtonSFXRemix;

		[SerializeField]
		private GameObject _remixModeTabRoot;

		[SerializeField]
		private DynamicButton[] _remixModeTabs;

		[SerializeField]
		private DynamicLayoutGroup[] _remixTabBackgrounds;

		[SerializeField]
		private LayoutElement _defaultBackground;

		[SerializeField]
		private GameObject _defaultBackgroundPadding;

		[SerializeField]
		private GameObject _remixBadgePanel;

		[SerializeField]
		private Image _remixBadgeImage;

		[SerializeField]
		private Sprite _emptyRemixBadgeSprite;

		[SerializeField]
		private Sprite _fullRemixBadgeSprite;

		[SerializeField]
		private GameObject _lockedRequirementsPanel;

		[SerializeField]
		private Image[] _prerequisiteStarIcons;

		[SerializeField]
		private TMP_Text[] _prerequisiteText;

		[SerializeField]
		private GameObject[] _prerequisiteContainers;

		[SerializeField]
		private GameObject _lockedIcon;

		private Callback<GameOverlayActivated_t> _gameOverlayCallback;

		private MetagameMap _metagameMap;

		private LevelConfig _levelConfig;

		private LevelConfig _defaultLevelConfig;

		private MetagameHospitalRecord _hospitalRecord;

		private OnlineMetadataManager _onlineMetadataManager;

		private SaveSystem _saveSystem;

		private Texture2D _saveThumbnailTexture;

		private bool _screenshotIsDirty;

		private bool _levelBankrupt;

		private int _currentFriendsPage;

		private ButtonSFX _buttonSFX;

		private MapPinUnlockMe _unlockMe;

		private Dictionary<LevelConfig, bool> _remixLevels = new Dictionary<LevelConfig, bool>();

		private void Start()
		{
			_saveThumbnailTexture = new Texture2D(1, 1, TextureFormat.DXT1, mipChain: false, linear: false);
		}

		public void Setup(LevelConfig levelConfig, MetagameHospitalRecord hospitalRecord, OnlineMetadataManager onlineMetadataManager, MetagameMap metagameMap, SaveSystem saveSystem)
		{
			_metagameMap = metagameMap;
			_defaultLevelConfig = levelConfig;
			_hospitalRecord = hospitalRecord;
			_onlineMetadataManager = onlineMetadataManager;
			_saveSystem = saveSystem;
			_unlockMe = null;
			SetupRemixTabs(levelConfig);
			SelectLevelConfig(_defaultLevelConfig);
		}

		public void SetupUnlockMe(MapPinUnlockMe unlockMePin, MetagameMap metagameMap)
		{
			_metagameMap = metagameMap;
			_levelConfig = null;
			_defaultLevelConfig = null;
			_hospitalRecord = null;
			_onlineMetadataManager = null;
			_saveSystem = null;
			_unlockMe = unlockMePin;
			GameObjectUtils.SetActive(_starsPanel, isActive: false);
			GameObjectUtils.SetActive(_hospitalDatePanel, isActive: false);
			GameObjectUtils.SetActive(_currentSavePanel, isActive: false);
			GameObjectUtils.SetActive(_friendsPanel, isActive: false);
			GameObjectUtils.SetActive(_startNewButtonPanel, isActive: false);
			GameObjectUtils.SetActive(_hospitalDescriptionPanel, isActive: true);
			_hospitalNameLabel.SetTerm(unlockMePin.GUIName.Term);
			if (DLCUtils.IsDLCInstalled(unlockMePin.RequiredDLC))
			{
				_buttonText.SetTerm("Menu/Metagame/Unlock_CS");
				_hospitalDescriptionText.text = unlockMePin.GUIDescription.Translation;
			}
			else
			{
				_buttonText.SetTerm("Misc/Purchase");
				_hospitalDescriptionText.text = GameStringUtils.GetDlcRequiredString(unlockMePin.RequiredDLC);
			}
			SetButtonEnabled(enabled: true);
			GameObjectUtils.SetActive(_remixBadgePanel, isActive: false);
			GameObjectUtils.SetActive(_remixModeTabRoot, isActive: false);
			DynamicLayoutGroup[] remixTabBackgrounds = _remixTabBackgrounds;
			for (int i = 0; i < remixTabBackgrounds.Length; i++)
			{
				GameObjectUtils.SetActive(remixTabBackgrounds[i].gameObject, isActive: false);
			}
			GameObjectUtils.SetActive(_defaultBackground.gameObject, isActive: true);
			GameObjectUtils.SetActive(_defaultBackgroundPadding, isActive: true);
		}

		public override void CloseMenu()
		{
			BackupSaveBox backupSave = _metagameMap.App.BackupSave;
			backupSave.OnBackupHandled = (Action)Delegate.Remove(backupSave.OnBackupHandled, new Action(OnBackupHandled));
			base.CloseMenu();
			_button.interactable = false;
			_startNewButton.interactable = false;
			if (!(_metagameMap != null) || _levelConfig == null)
			{
				return;
			}
			foreach (SharedInstance<ObjectiveDefinition> onlineChallenge in _levelConfig.GetLevelScriptConfig().OnlineChallenges)
			{
				if (onlineChallenge.Instance is OnlineChallengeDefinition { LeaderboardName: var leaderboardName })
				{
					_metagameMap.Metagame.OnlineChallengeViewRecord.LogView(leaderboardName);
				}
			}
			MapPinHospital pinForLevel = _metagameMap.MapUI.GetPinForLevel(_levelConfig);
			if (pinForLevel != null)
			{
				pinForLevel.Refresh();
			}
		}

		public void Refresh()
		{
			MetagameHospitalRecord hospitalRecord = _metagameMap.Metagame.GetHospitalRecord(_levelConfig);
			int num = hospitalRecord?.GetBalance() ?? 0;
			SaveFileHeader saveForLevel = _saveSystem.GetSaveForLevel(_levelConfig.UniqueId, returnBrokenSaves: true);
			bool flag = saveForLevel != null;
			if (flag && saveForLevel.IsBroken)
			{
				BackupSaveBox backupSave = _metagameMap.App.BackupSave;
				backupSave.OnBackupHandled = (Action)Delegate.Combine(backupSave.OnBackupHandled, new Action(OnBackupHandled));
				SaveFileHeader backupLevelHeader = null;
				if (_metagameMap.App.SaveSystem.TryGetBackupLevelSave(_levelConfig.UniqueId, out var saveData))
				{
					backupLevelHeader = saveData.LevelSaveFileHeader;
				}
				_metagameMap.App.BackupSave.ShowLevelBackup(_levelConfig, backupLevelHeader);
				flag = false;
			}
			if (flag)
			{
				num = saveForLevel.Balance;
			}
			bool flag2 = _metagameMap.Level != null && _metagameMap.Level.Config == _levelConfig;
			bool flag3 = DLCUtils.IsDLCInstalled(_levelConfig.GetRequiredDlcPack());
			int dateMonth = hospitalRecord?.GetHospitalDateMonth() ?? 0;
			int dateYear = hospitalRecord?.GetHospitalDateYear() ?? 0;
			if (_remixLevels.TryGetValue(_levelConfig, out var value))
			{
				GameObjectUtils.SetActive(_starsPanel, !value);
				GameObjectUtils.SetActive(_remixBadgePanel, value);
			}
			else
			{
				GameObjectUtils.SetActive(_starsPanel, isActive: true);
				GameObjectUtils.SetActive(_remixBadgePanel, isActive: false);
			}
			if (_hospitalDatePanel != null)
			{
				GameObjectUtils.SetActive(_hospitalDatePanel, isActive: false);
			}
			SetButtonEnabled(enabled: true);
			_buttonSFX = _button.GetComponent<ButtonSFX>();
			if (_levelConfig.DisplayNameLocalised.Term != null)
			{
				_hospitalNameLabel.SetTerm(_levelConfig.DisplayNameLocalised.Term);
			}
			if (_levelConfig.IsPlayable(_metagameMap.Metagame))
			{
				if (flag2)
				{
					GameObjectUtils.SetActive(_currentSavePanel, isActive: true);
					_balanceValueLabel.text = StringUtils.FormatCurrencyWithoutSymbol(_metagameMap.Level.FinanceManager.Balance);
					_hospitalValueLabel.text = StringUtils.FormatCurrencyWithoutSymbol(_metagameMap.Level.LevelStatsDatabase.HospitalValue);
					_reputationProgressBar.SetProgressSmooth(_metagameMap.Level.ReputationTracker.OverallReputation);
					_prestigeProgressBar.SetProgressSmooth(_metagameMap.Level.PrestigeTracker.Progress);
					_prestigeValueLabel.text = string.Format(ScriptLocalization.Misc.PrestigeLevel_CS, _metagameMap.Level.PrestigeTracker.Level);
					_saveDateAndTimeLabelLocalize.Term = "Misc/YouArePlayingThisLevel_CS";
					_screenshotIsDirty = true;
				}
				else if (flag)
				{
					GameObjectUtils.SetActive(_currentSavePanel, isActive: true);
					_balanceValueLabel.text = StringUtils.FormatCurrencyWithoutSymbol(saveForLevel.Balance);
					_hospitalValueLabel.text = StringUtils.FormatCurrencyWithoutSymbol(saveForLevel.HospitalValue);
					_reputationProgressBar.SetProgressSmooth(saveForLevel.Reputation);
					_prestigeProgressBar.SetProgressSmooth(saveForLevel.HospitalLevelProgress);
					_prestigeValueLabel.text = string.Format(ScriptLocalization.Misc.PrestigeLevel_CS, saveForLevel.HospitalLevel);
					_saveDateAndTimeLabelLocalize.Term = "-";
					_saveDateAndTimeLabel.text = saveForLevel.Date.ToString(CultureInfo.CurrentCulture);
					_screenshotIsDirty = true;
				}
				else
				{
					GameObjectUtils.SetActive(_currentSavePanel, isActive: false);
					_screenshotIsDirty = false;
				}
			}
			else
			{
				_hospitalDescriptionText.text = _levelConfig.GetPlayableRequiredDescription();
				GameObjectUtils.SetActive(_starsPanel, isActive: false);
				GameObjectUtils.SetActive(_currentSavePanel, isActive: false);
			}
			SetHospitalDateText(dateMonth, dateYear);
			_levelBankrupt = (flag2 ? _metagameMap.Level.FinanceManager.IsBankrupt : (num <= _levelConfig.FailStateBalanceGameOver));
			_startNewButtonText.SetTerm(_levelBankrupt ? "Misc/ReloadLastSave_CS" : "Misc/Restart_CS");
			_buttonText.SetTerm(_levelBankrupt ? "Misc/Restart_CS" : ((flag || flag2) ? "Misc/Continue_CS" : "Misc/Start_CS"));
			GameObjectUtils.SetActive(_startNewButtonPanel, (flag || flag2 || _levelBankrupt) && flag3);
			RefreshSteamAvatars(_currentFriendsPage);
			GameObjectUtils.SetActive(_hospitalDescriptionPanel, _hospitalDescriptionText.text != string.Empty);
		}

		private void OnBackupHandled()
		{
			Refresh();
			BackupSaveBox backupSave = _metagameMap.App.BackupSave;
			backupSave.OnBackupHandled = (Action)Delegate.Remove(backupSave.OnBackupHandled, new Action(OnBackupHandled));
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			_button.onPrimaryDown.AddListener(OnButtonPressed);
			_startNewButton.onPrimaryDown.AddListener(OnStartNewPressed);
			_friendsPageLeftButton.onPrimaryDown.AddListener(OnFriendsPageLeft);
			_friendsPageRightButton.onPrimaryDown.AddListener(OnFriendsPageRight);
			if (OnlineManager.IsInitialized())
			{
				_gameOverlayCallback = Callback<GameOverlayActivated_t>.Create(OnGameOverlayActivated);
			}
		}

		private void OnDisable()
		{
			_button.onPrimaryDown.RemoveListener(OnButtonPressed);
			_startNewButton.onPrimaryDown.RemoveListener(OnStartNewPressed);
			_friendsPageLeftButton.onPrimaryDown.RemoveListener(OnFriendsPageLeft);
			_friendsPageRightButton.onPrimaryDown.RemoveListener(OnFriendsPageRight);
			if (OnlineManager.IsInitialized())
			{
				_gameOverlayCallback.Unregister();
			}
		}

		public void SelectRemixLevel()
		{
			foreach (KeyValuePair<LevelConfig, bool> remixLevel in _remixLevels)
			{
				if (remixLevel.Value)
				{
					SelectLevelConfig(remixLevel.Key);
					break;
				}
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

		protected override void Update()
		{
			base.Update();
			if (_unlockMe != null)
			{
				return;
			}
			if (_levelConfig.IsPlayable(_metagameMap.Metagame))
			{
				GameObjectUtils.SetActive(_lockedIcon, isActive: false);
				GameObjectUtils.SetActive(_lockedRequirementsPanel, isActive: false);
				if (_buttonSFX != null)
				{
					_buttonSFX.enabled = true;
				}
				SetButtonEnabled(enabled: true);
				MetagameHospitalRecord hospitalRecord = _metagameMap.Metagame.GetHospitalRecord(_levelConfig);
				if (hospitalRecord != null)
				{
					int num = hospitalRecord.TotalStars();
					for (int i = 0; i < 3; i++)
					{
						_starImages[i].overrideSprite = ((i < num) ? _fullStarSprite : _emptyStarSprite);
					}
					_remixBadgeImage.overrideSprite = (hospitalRecord.HasRemixBadgePreviouslyBeenAwarded() ? _fullRemixBadgeSprite : _emptyRemixBadgeSprite);
					_hospitalDescriptionText.text = _levelConfig.GetDescriptionForNumStars(num);
				}
				SaveFileHeader saveForLevel = _saveSystem.GetSaveForLevel(_levelConfig.UniqueId);
				if (_screenshotIsDirty)
				{
					if (_metagameMap.Level != null && _metagameMap.Level.Config == _levelConfig && _metagameMap.Level.ThumbnailPNG != null)
					{
						_saveThumbnailTexture.LoadImage(_metagameMap.Level.ThumbnailPNG);
						_currentSaveScreenshot.overrideSprite = Sprite.Create(_saveThumbnailTexture, new Rect(0f, 0f, _saveThumbnailTexture.width, _saveThumbnailTexture.height), new Vector2(0f, 0f));
						_currentSaveScreenshot.color = Color.white;
						_screenshotIsDirty = false;
					}
					else if (saveForLevel != null && saveForLevel.ThumbnailPNG != null)
					{
						_saveThumbnailTexture.LoadImage(saveForLevel.ThumbnailPNG);
						_currentSaveScreenshot.overrideSprite = Sprite.Create(_saveThumbnailTexture, new Rect(0f, 0f, _saveThumbnailTexture.width, _saveThumbnailTexture.height), new Vector2(0f, 0f));
						_currentSaveScreenshot.color = Color.white;
						_screenshotIsDirty = false;
					}
				}
			}
			else
			{
				GameObjectUtils.SetActive(_lockedIcon, isActive: true);
				if (!DLCUtils.IsDLCInstalled(_levelConfig.GetRequiredDlcPack()))
				{
					if (_buttonSFX != null)
					{
						_buttonSFX.enabled = true;
					}
					_buttonText.SetTerm("Misc/Purchase");
					SetButtonEnabled(enabled: true);
					_hospitalDescriptionText.text = _levelConfig.GetPlayableRequiredDescription();
				}
				else
				{
					if (_buttonSFX != null)
					{
						_buttonSFX.enabled = false;
					}
					_buttonText.SetTerm("Misc/Locked_CS");
					SetButtonEnabled(enabled: false);
					int num2 = 0;
					if (_levelConfig.LevelPlayablePrerequisites != null)
					{
						LevelProgressPrerequisite[] levelPlayablePrerequisites = _levelConfig.LevelPlayablePrerequisites;
						for (int j = 0; j < levelPlayablePrerequisites.Length; j++)
						{
							if (!(levelPlayablePrerequisites[j] is LevelProgressLevelHasStars levelProgressLevelHasStars))
							{
								continue;
							}
							GameObjectUtils.SetActive(_lockedRequirementsPanel, isActive: true);
							SharedInstance<LevelConfig>[] levels = levelProgressLevelHasStars.Levels;
							foreach (SharedInstance<LevelConfig> sharedInstance in levels)
							{
								if (num2 < _prerequisiteContainers.Length)
								{
									GameObjectUtils.SetActive(_prerequisiteContainers[num2], isActive: true);
									_prerequisiteText[num2].text = LocalisedString.Replace(ScriptLocalization.Tooltip.LevelPrerequisite_LevelHasStars1_CS, new SubPair[1]
									{
										new SubPair("{[LEVEL1]}", sharedInstance.Instance.GetLocalisedDisplayName())
									});
									if (levelProgressLevelHasStars.IsLevelComplete(_metagameMap.Metagame, sharedInstance))
									{
										_prerequisiteStarIcons[num2].sprite = _fullStarSprite;
									}
									else
									{
										_prerequisiteStarIcons[num2].sprite = _emptyStarSprite;
									}
								}
								num2++;
							}
						}
						if (num2 < _prerequisiteContainers.Length)
						{
							for (int l = num2; l < _prerequisiteContainers.Length; l++)
							{
								GameObjectUtils.SetActive(_prerequisiteContainers[l], isActive: false);
							}
						}
					}
					if (num2 == 0)
					{
						_hospitalDescriptionText.text = _levelConfig.GetPlayableRequiredDescription();
					}
					else
					{
						_hospitalDescriptionText.text = string.Empty;
					}
				}
			}
			GameObjectUtils.SetActive(_hospitalDescriptionPanel, _hospitalDescriptionText.text != string.Empty);
		}

		private void RefreshSteamAvatars(int page)
		{
			if (!OnlineManager.IsInitializedAndLoggedOn() || !_onlineMetadataManager.LocalPlayerOnlineVisibility)
			{
				GameObjectUtils.SetActive(_friendsPanel, isActive: false);
				return;
			}
			List<OnlinePlayerID> list = new List<OnlinePlayerID>();
			foreach (KeyValuePair<OnlinePlayerID, OnlineMetadata> item in _onlineMetadataManager.GetMetadataCache())
			{
				if (item.Value.IsVisible() && item.Value.HasPlayedLevel(_levelConfig))
				{
					list.Add(item.Key);
				}
			}
			GameObjectUtils.SetActive(_friendsPanel, list.Count > 0);
			if (list.Count <= 0)
			{
				return;
			}
			int num = _currentFriendsPage * _playerAvatars.Length;
			int num2 = num + _playerAvatars.Length - 1;
			GameObjectUtils.SetActive(_friendsPageLeftButton.gameObject, page > 0);
			GameObjectUtils.SetActive(_friendsPageRightButton.gameObject, list.Count > num2 + 1);
			int num3 = 0;
			int num4 = num;
			while (num4 <= num2)
			{
				if (num4 >= list.Count)
				{
					GameObjectUtils.SetActive(_playerAvatars[num3].gameObject, isActive: false);
					_playerAvatars[num3].PlayerID = OnlinePlayerID.Nil;
				}
				else
				{
					_playerAvatars[num3].PlayerID = list[num4];
					_playerAvatars[num3].NumUnseenNotifications = _metagameMap.Metagame.OnlineChallengeViewRecord.GetNumUnseenEventsForOnlineChallengeInLevelForOnlinePlayerId(_levelConfig, list[num4]);
					GameObjectUtils.SetActive(_playerAvatars[num3].gameObject, isActive: true);
				}
				num4++;
				num3++;
			}
		}

		private void OnButtonPressed()
		{
			if (_unlockMe != null)
			{
				if (DLCUtils.IsDLCInstalled(_unlockMe.RequiredDLC))
				{
					_metagameMap.Metagame.TriggerUnlockMeTag(_unlockMe.UnlockMeTag);
					_metagameMap.Metagame.CutsceneEvents.SubmitCutsceneEventForLevel(_unlockMe.LevelConfigOfCutsceneToPlay);
					if (_metagameMap.StateMachine.TopState is MetagameStatePlayer metagameStatePlayer)
					{
						metagameStatePlayer.RunCutscenes();
					}
					_metagameMap.MapUI.RefreshMapPins();
					CloseMenu();
					_metagameMap.MapUI.ClearSelectedPin();
				}
				else if (OSManager.IsInitialised())
				{
					ExtraContentMenu.ShowBrowser(_unlockMe.RequiredDLC, _metagameMap.App.AnalyticsManager, _metagameMap.App.MessageBox);
				}
				return;
			}
			DLCItemDefinition requiredDlcPack = _levelConfig.GetRequiredDlcPack();
			if (!DLCUtils.IsDLCInstalled(requiredDlcPack))
			{
				if (OSManager.IsInitialised())
				{
					ExtraContentMenu.ShowBrowser(requiredDlcPack, _metagameMap.App.AnalyticsManager, _metagameMap.App.MessageBox);
				}
				return;
			}
			if (!_hospitalRecord.IsPlayable())
			{
				if (!_levelConfig.IsPlayable(_metagameMap.Metagame) || !_metagameMap.Metagame.CanAffordSilver(_levelConfig))
				{
					AudioManager.Instance.Play("PlaceObjectDenied");
					return;
				}
				_metagameMap.Metagame.UnlockItem(_levelConfig, spendSilver: true, showMessage: false);
			}
			if (_levelBankrupt)
			{
				TryTryRestartLevel();
			}
			else
			{
				TryStartLevel();
			}
		}

		private void OnStartNewPressed()
		{
			if (_levelBankrupt)
			{
				TryReloadLevelLastSave();
			}
			else
			{
				TryTryRestartLevel();
			}
		}

		private void TryReloadLevelLastSave()
		{
			SaveFileHeader saveForLevel = _metagameMap.SaveSystem.GetSaveForLevel(_levelConfig.UniqueId);
			if (saveForLevel != null && _metagameMap.App.ShowMessageBoxIfSaveHeaderCantLoad(saveForLevel, _levelConfig))
			{
				return;
			}
			if (_metagameMap.Metagame.CurrentLevel != null && _metagameMap.Metagame.CurrentLevel.Config != _levelConfig && !_metagameMap.Metagame.CurrentLevel.UserPreferences.Game.AutoSaveOnLevelChange)
			{
				_metagameMap.App.MessageBox.ShowAs2ChoiceAndCancel(ScriptLocalization.Menu_Messages.AreYouSureChangeLevel_Title_CS, OptionsMenu.AddLastSaveInfoIfAppropriate(OptionsMenu.ApplyLocalisationParam(ScriptLocalization.Menu_Messages.AreYouSureChangeLevel_CS, "CURRENT_LEVEL", _metagameMap.Metagame.CurrentLevel.Config.DisplayNameLocalised.Translation), _saveSystem), ScriptLocalization.Menu_Messages.ChangeLevelSave_CS, ScriptLocalization.Menu_Messages.ChangeLevelDontSave_CS, ScriptLocalization.Menu_Messages.Cancel_Button_CS, delegate
				{
					ReloadLevelLastSave();
				}, delegate
				{
					ReloadLevelLastSave(saveOldLevel: false);
				});
			}
			else
			{
				ReloadLevelLastSave();
			}
		}

		private void ReloadLevelLastSave(bool saveOldLevel = true)
		{
			if (_metagameMap.StateMachine.TopState is MetagameStatePlayer metagameStatePlayer)
			{
				metagameStatePlayer.LaunchHospital(_levelConfig, restartLevel: false, saveOldLevel);
			}
			CloseMenuImmediately();
		}

		private void TryStartLevel()
		{
			SaveFileHeader saveForLevel = _metagameMap.SaveSystem.GetSaveForLevel(_levelConfig.UniqueId);
			if (saveForLevel != null && _metagameMap.App.ShowMessageBoxIfSaveHeaderCantLoad(saveForLevel, _levelConfig))
			{
				return;
			}
			if (_metagameMap.Metagame.CurrentLevel != null && _metagameMap.Metagame.CurrentLevel.Config != _levelConfig && !_metagameMap.Metagame.CurrentLevel.UserPreferences.Game.AutoSaveOnLevelChange)
			{
				_metagameMap.App.MessageBox.ShowAs2ChoiceAndCancel(ScriptLocalization.Menu_Messages.AreYouSureChangeLevel_Title_CS, OptionsMenu.AddLastSaveInfoIfAppropriate(OptionsMenu.ApplyLocalisationParam(ScriptLocalization.Menu_Messages.AreYouSureChangeLevel_CS, "CURRENT_LEVEL", _metagameMap.Metagame.CurrentLevel.Config.DisplayNameLocalised.Translation), _saveSystem), ScriptLocalization.Menu_Messages.ChangeLevelSave_CS, ScriptLocalization.Menu_Messages.ChangeLevelDontSave_CS, ScriptLocalization.Menu_Messages.Cancel_Button_CS, delegate
				{
					StartLevel();
				}, delegate
				{
					StartLevel(saveOldLevel: false);
				});
			}
			else
			{
				StartLevel();
			}
		}

		private void StartLevel(bool saveOldLevel = true)
		{
			if (_metagameMap.StateMachine.TopState is MetagameStatePlayer metagameStatePlayer)
			{
				metagameStatePlayer.LaunchHospital(_levelConfig, restartLevel: false, saveOldLevel);
			}
			CloseMenuImmediately();
		}

		private void TryTryRestartLevel()
		{
			_metagameMap.App.MessageBox.ShowAsYesNo(ScriptLocalization.Misc.RestartHospital_CS, ScriptLocalization.Misc.RestartHospitalWarning_CS, ScriptLocalization.Misc.Restart_CS, ScriptLocalization.Misc.Cancel_CS, TryRestartLevel);
		}

		private void TryRestartLevel()
		{
			if (_metagameMap.Metagame.CurrentLevel != null && _metagameMap.Metagame.CurrentLevel.Config != _levelConfig && !_metagameMap.Metagame.CurrentLevel.UserPreferences.Game.AutoSaveOnLevelChange)
			{
				_metagameMap.App.MessageBox.ShowAs2ChoiceAndCancel(ScriptLocalization.Menu_Messages.AreYouSureChangeLevel_Title_CS, OptionsMenu.AddLastSaveInfoIfAppropriate(OptionsMenu.ApplyLocalisationParam(ScriptLocalization.Menu_Messages.AreYouSureChangeLevel_CS, "CURRENT_LEVEL", _metagameMap.Metagame.CurrentLevel.Config.DisplayNameLocalised.Translation), _saveSystem), ScriptLocalization.Menu_Messages.ChangeLevelSave_CS, ScriptLocalization.Menu_Messages.ChangeLevelDontSave_CS, ScriptLocalization.Menu_Messages.Cancel_Button_CS, delegate
				{
					RestartLevel();
				}, delegate
				{
					RestartLevel(saveOldLevel: false);
				});
			}
			else
			{
				RestartLevel();
			}
		}

		private void RestartLevel(bool saveOldLevel = true)
		{
			if (_hospitalRecord.IsPlayable() && _metagameMap.StateMachine.TopState is MetagameStatePlayer metagameStatePlayer)
			{
				_metagameMap.Metagame.ResetShares(_hospitalRecord);
				_metagameMap.Metagame.IssueSharesForLevel(_levelConfig);
				MetagameHospitalRecord hospitalRecord = _metagameMap.Metagame.GetHospitalRecord(_levelConfig);
				if (_levelConfig.IsRemixLevel)
				{
					AudioManager.Instance.Play(_startNewButtonSFXRemix);
				}
				hospitalRecord?.Replay();
				metagameStatePlayer.LaunchHospital(_levelConfig, restartLevel: true, saveOldLevel);
			}
			CloseMenuImmediately();
		}

		private void OnFriendsPageLeft()
		{
			_currentFriendsPage = Mathf.Max(_currentFriendsPage - 1, 0);
			RefreshSteamAvatars(_currentFriendsPage);
		}

		private void OnFriendsPageRight()
		{
			_currentFriendsPage++;
			RefreshSteamAvatars(_currentFriendsPage);
		}

		private void OnGameOverlayActivated(GameOverlayActivated_t callback)
		{
			if (callback.m_bActive == 0)
			{
				if (_unlockMe != null)
				{
					SetupUnlockMe(_unlockMe, _metagameMap);
				}
				else
				{
					Refresh();
				}
			}
		}

		private void OnPlayfabConnectionLost()
		{
			if (_metagameMap != null && _metagameMap.HUD != null)
			{
				_metagameMap.HUD.CloseAllMenusAllowingEscapeClose();
			}
		}

		private void SelectLevelConfig(LevelConfig levelConfig)
		{
			if (_levelConfig != levelConfig)
			{
				_levelConfig = levelConfig;
				_currentFriendsPage = 0;
				PlayerAvatar[] playerAvatars = _playerAvatars;
				for (int i = 0; i < playerAvatars.Length; i++)
				{
					playerAvatars[i].SetupForChallengeTooltip(levelConfig, _onlineMetadataManager, _metagameMap.Metagame.CareerStatsManager);
				}
				Refresh();
			}
		}

		private void SetupRemixTabs(LevelConfig levelConfig)
		{
			LevelConfig remixLevel = GetRemixLevel(levelConfig);
			_remixLevels.Clear();
			if (remixLevel != null)
			{
				AddRemixTab(_defaultLevelConfig, isRemixLevel: false);
				while (remixLevel != null)
				{
					AddRemixTab(remixLevel, isRemixLevel: true);
					remixLevel = GetRemixLevel(remixLevel);
				}
			}
			if (_remixLevels.Count == 0)
			{
				GameObjectUtils.SetActive(_remixModeTabRoot, isActive: false);
				DynamicLayoutGroup[] remixTabBackgrounds = _remixTabBackgrounds;
				for (int i = 0; i < remixTabBackgrounds.Length; i++)
				{
					GameObjectUtils.SetActive(remixTabBackgrounds[i].gameObject, isActive: false);
				}
				GameObjectUtils.SetActive(_defaultBackground.gameObject, isActive: true);
				GameObjectUtils.SetActive(_defaultBackgroundPadding, isActive: true);
			}
			else
			{
				GameObjectUtils.SetActive(_defaultBackground.gameObject, isActive: false);
				GameObjectUtils.SetActive(_defaultBackgroundPadding, isActive: false);
				int num = 0;
				for (int j = 0; j < _remixTabBackgrounds.Length; j++)
				{
					GameObjectUtils.SetActive(_remixTabBackgrounds[j].gameObject, j == 0);
				}
				foreach (KeyValuePair<LevelConfig, bool> level in _remixLevels)
				{
					if (num >= _remixModeTabs.Length)
					{
						continue;
					}
					int tabIndex = num;
					DynamicButton obj = _remixModeTabs[num];
					obj.onPrimaryDown.RemoveAllListeners();
					ButtonSFX component = obj.GetComponent<ButtonSFX>();
					if ((bool)component)
					{
						component.UpdateListeners();
					}
					obj.onPrimaryDown.AddListener(delegate
					{
						for (int k = 0; k < _remixModeTabs.Length; k++)
						{
							ButtonAnimator component3 = _remixModeTabs[k].gameObject.GetComponent<ButtonAnimator>();
							if (component3 != null)
							{
								component3.CurrentState = ((tabIndex == k) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
							}
							if (_remixTabBackgrounds.Length > k && _remixTabBackgrounds[k] != null)
							{
								GameObjectUtils.SetActive(_remixTabBackgrounds[k].gameObject, (tabIndex == k) ? true : false);
							}
						}
						ButtonSFX component4 = _button.GetComponent<ButtonSFX>();
						if (level.Value)
						{
							component4.SetCustomAudioEvent(_startNewButtonSFXRemix);
							component4.SetSelectedAudioEvent(_startNewButtonSFXRemix);
						}
						else
						{
							component4.SetCustomAudioEvent(_startNewButtonSFXDefault);
							component4.SetSelectedAudioEvent(_startNewButtonSFXDefault);
						}
						SelectLevelConfig(level.Key);
					});
					num++;
				}
				for (int num2 = 0; num2 < _remixModeTabs.Length; num2++)
				{
					GameObjectUtils.SetActive(_remixModeTabs[num2].gameObject.transform.parent.gameObject, num2 < num);
				}
				GameObjectUtils.SetActive(_remixModeTabRoot, isActive: true);
			}
			int num3 = 0;
			DynamicButton[] remixModeTabs = _remixModeTabs;
			foreach (DynamicButton dynamicButton in remixModeTabs)
			{
				if (dynamicButton != null && dynamicButton.gameObject != null)
				{
					ButtonAnimator component2 = dynamicButton.gameObject.GetComponent<ButtonAnimator>();
					if (component2 != null)
					{
						if (num3 == 0)
						{
							component2.CurrentState = ButtonAnimator.State.Selected;
						}
						else
						{
							component2.CurrentState = ButtonAnimator.State.Selectable;
						}
					}
				}
				num3++;
			}
		}

		private LevelConfig GetRemixLevel(LevelConfig levelConfig)
		{
			if (levelConfig.RemixLevelConfig.NotNull())
			{
				LevelConfig instance = levelConfig.RemixLevelConfig.Instance;
				MetagameHospitalRecord hospitalRecord = _metagameMap.Metagame.GetHospitalRecord(instance);
				if (instance.IsVisible(_metagameMap.Metagame) || (hospitalRecord != null && hospitalRecord.IsVisible()))
				{
					return instance;
				}
			}
			return null;
		}

		private void AddRemixTab(LevelConfig levelConfig, bool isRemixLevel)
		{
			_remixLevels.Add(levelConfig, isRemixLevel);
		}

		private void SetButtonEnabled(bool enabled)
		{
			_button.enabled = true;
			_button.image.sprite = (enabled ? _buttonEnabledSprite : _buttonDisabledSprite);
		}
	}
}
