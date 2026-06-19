using System.Collections.Generic;
using FullInspector;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace TH20
{
	public class StarAwardNotificationUI : LevelObjectiveNotificationUI, IPauseTimeMenu
	{
		[InspectorHeader("Buttons")]
		[SerializeField]
		private Button _continueButton;

		[SerializeField]
		private Button _openMapButton;

		[SerializeField]
		private Button _viewCreditsButton;

		[InspectorHeader("Credits")]
		[SerializeField]
		private GameObject _creditsPrefab;

		[InspectorHeader("Rewards")]
		[SerializeField]
		private TMP_Text _rewardMoneyText;

		[SerializeField]
		private GameObject _rewardMoneyGameObject;

		[SerializeField]
		private TMP_Text _rewardSilverText;

		[SerializeField]
		private GameObject _rewardSilverGameObject;

		[SerializeField]
		private TMP_Text _rewardReputationText;

		[SerializeField]
		private GameObject _rewardReputationGameObject;

		[SerializeField]
		private TMP_Text _rewardResearchPointsText;

		[SerializeField]
		private GameObject _rewardResearchPointsGameObject;

		[InspectorHeader("Unlocks")]
		[SerializeField]
		private ScrollRect _unlocksScroll;

		[SerializeField]
		private GameObject _unlockItemPrefab;

		[InspectorHeader("Icons")]
		[SerializeField]
		private Sprite _unlockHospitalSprite;

		[SerializeField]
		private Sprite _unlockSandboxSprite;

		private VideoClip _videoClipToPlayAfter;

		private string _audioClipToPlayAfter;

		private bool _notificationAudioExclusiveMode;

		private Level _level;

		private readonly List<StarAwardNotificationUnlockListItem> _unlockItemsList = new List<StarAwardNotificationUnlockListItem>();

		public override void Setup(NotificationMessage message, Level level, Notifications notifications)
		{
			base.Setup(message, level, notifications);
			_level = level;
			if (_openMapButton != null)
			{
				_openMapButton.onClick.AddListener(delegate
				{
					level.MetagameMap.Open();
				});
			}
			if (_viewCreditsButton != null)
			{
				_viewCreditsButton.onClick.RemoveAllListeners();
				_viewCreditsButton.onClick.AddListener(delegate
				{
					Object.Instantiate(_creditsPrefab, level.HUD.MenusTransform, worldPositionStays: false);
				});
			}
			NotificationObjectiveComplete notificationObjectiveComplete = (NotificationObjectiveComplete)message;
			if (notificationObjectiveComplete == null)
			{
				return;
			}
			_videoClipToPlayAfter = notificationObjectiveComplete.VideoToPlayAfter;
			_audioClipToPlayAfter = notificationObjectiveComplete.AudioToPlayAfter;
			_notificationAudioExclusiveMode = notificationObjectiveComplete.NotificationAudioExclusiveMode;
			GameObjectUtils.SetActive(_rewardMoneyGameObject, notificationObjectiveComplete.CashReward > 0);
			_rewardMoneyText.text = StringUtils.FormatCurrencyWithoutSymbol(notificationObjectiveComplete.CashReward);
			GameObjectUtils.SetActive(_rewardSilverGameObject, notificationObjectiveComplete.SilverReward > 0);
			_rewardSilverText.text = StringUtils.FormatCurrencyWithoutSymbol(notificationObjectiveComplete.SilverReward);
			GameObjectUtils.SetActive(_rewardReputationGameObject, notificationObjectiveComplete.ReputationReward > 0f);
			_rewardReputationText.text = StringUtils.FormatPercentageValue(notificationObjectiveComplete.ReputationReward);
			GameObjectUtils.SetActive(_rewardResearchPointsGameObject, notificationObjectiveComplete.ResearchPointsReward > 0f);
			_rewardResearchPointsText.text = StringUtils.FormatFloat(notificationObjectiveComplete.ResearchPointsReward, prefixPlus: true);
			if (notificationObjectiveComplete.IsSandboxReward && !level.App.UserProfile.IsSandboxUnlocked)
			{
				AddUnlockableToGUI(_unlockSandboxSprite, LocalizationManager.GetTranslation("Menu/Sandbox/Title"));
			}
			if (notificationObjectiveComplete.IsCollaborativePortfolioReward && !level.App.UserProfile.IsCollaborativeProjectsUnlocked)
			{
				AddUnlockableToGUI(_unlockSandboxSprite, "Collaborative Portfolios");
			}
			foreach (LevelConfig andClearNewlyUnlockedLevel in level.Metagame.GetAndClearNewlyUnlockedLevels())
			{
				if (!andClearNewlyUnlockedLevel.IsRemixLevel)
				{
					AddUnlockableToGUI(_unlockHospitalSprite, andClearNewlyUnlockedLevel.GetLocalisedDisplayName());
				}
			}
			foreach (SharedInstance<RoomDefinition> item in notificationObjectiveComplete.RoomsUnlocked)
			{
				if (!item.IsNull())
				{
					RoomDefinition instance = item.Instance;
					AddUnlockableToGUI(instance._icon, instance.GetLocalisedName());
				}
			}
			foreach (SharedInstance<RoomItemDefinition> item2 in notificationObjectiveComplete.RoomItemsUnlocked)
			{
				if (!item2.IsNull())
				{
					RoomItemDefinition instance2 = item2.Instance;
					AddUnlockableToGUI(instance2.GetIcon(), instance2.GetLocalisedName());
				}
			}
			foreach (SharedInstance<RoomItemUpgradeDefinition> item3 in notificationObjectiveComplete.RoomItemUpgradesUnlocked)
			{
				if (!item3.IsNull())
				{
					RoomItemUpgradeDefinition instance3 = item3.Instance;
					AddUnlockableToGUI(instance3.Icon, instance3.LocalisedName.Translation);
				}
			}
		}

		protected override void Update()
		{
			base.Update();
			base.transform.SetAsLastSibling();
		}

		private void AddUnlockableToGUI(Sprite sprite, string text)
		{
			StarAwardNotificationUnlockListItem component = Object.Instantiate(_unlockItemPrefab).GetComponent<StarAwardNotificationUnlockListItem>();
			component.Setup(sprite, text);
			_unlockItemsList.Add(component);
			component.transform.SetParent(_unlocksScroll.content, worldPositionStays: false);
		}

		protected override void CloseMessage(int choice)
		{
			if (_videoClipToPlayAfter != null && _level != null)
			{
				VideoCutsceneMenu videoCutsceneMenu = _level.HUD.FindMenu<VideoCutsceneMenu>();
				if (videoCutsceneMenu == null)
				{
					videoCutsceneMenu = _level.HUD.CreateMenu<VideoCutsceneMenu>();
				}
				videoCutsceneMenu.Setup(_videoClipToPlayAfter, loop: false);
			}
			if (!_audioClipToPlayAfter.IsNullOrEmpty() && _level != null)
			{
				AudioEmitter audioEmitter = AudioManager.Instance.Play(_audioClipToPlayAfter);
				if (_notificationAudioExclusiveMode)
				{
					_level.AddNotificationAudioExclusiveModeEmitter(audioEmitter);
				}
			}
			base.CloseMessage(choice);
		}
	}
}
