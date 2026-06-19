using System;
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
	public class OnlineChallengeView : MonoBehaviour
	{
		public enum Mode
		{
			Scores = 0,
			Info = 1,
			Log = 2
		}

		[InspectorHeader("Header")]
		[SerializeField]
		private TMP_Text _challengeNameLabel;

		[SerializeField]
		private Image _connectionStatusIcon;

		[SerializeField]
		private TooltipSpawner _connectionTooltip;

		[SerializeField]
		private ButtonAnimator _scoresButton;

		[SerializeField]
		private ButtonAnimator _infoButton;

		[SerializeField]
		private ButtonAnimator _logButton;

		[SerializeField]
		private Color _connectionStatusOnlineColor;

		[SerializeField]
		private Color _connectionStatusOfflineColor;

		[SerializeField]
		private TooltipSpawner _objectiveActionTooltip;

		[SerializeField]
		private ButtonAnimator _objectiveActionButton;

		[SerializeField]
		private DynamicButton _closeButton;

		[SerializeField]
		private Sprite _abandonButtonSprite;

		[SerializeField]
		private Sprite _finishButtonSprite;

		[InspectorHeader("Footer")]
		[SerializeField]
		private TMP_Text _timeLimitLabel;

		[SerializeField]
		private ProgressBarMaskable _timeLimitProgressBar;

		[InspectorHeader("Data Views")]
		[SerializeField]
		private OnlineChallengePlayers _infoPanel;

		[SerializeField]
		private OnlineChallengeScores _scoresPanel;

		[SerializeField]
		private OnlineChallengeEventLog _eventLogPanel;

		[InspectorHeader("Screenshot View")]
		[SerializeField]
		private GameObject _screenshotPanel;

		[SerializeField]
		private RawImage _screenshotImage;

		[SerializeField]
		private Text _screenshotCaption;

		[SerializeField]
		private Text _screenshotCaptionBackground;

		[SerializeField]
		private DynamicButton _screenshotPanelCloseButton;

		[SerializeField]
		private PlayerAvatar _screenshotAvatar;

		[SerializeField]
		private float _screenshotDisplayTime;

		[InspectorHeader("Newsflash")]
		[SerializeField]
		private float _minTimeBetweenNewsflash;

		[SerializeField]
		private float _newsflashDisplayTime = 5f;

		[HideInInspector]
		public OnlineChallengeObjective OnlineChallengeObjective;

		private Mode _currentMode;

		private Level _level;

		private float _timeSinceNewsflash;

		private Queue<OnlineScreenshotData.Screenshot> _screenshotsToShow = new Queue<OnlineScreenshotData.Screenshot>();

		private float _screenshotDisplayElapsedTime;

		private float _percentageCompleted;

		private bool _canShowScreenshotUI;

		private const PlatformFeatureSupport.FeatureType ScreenshotRequiredFeature = PlatformFeatureSupport.FeatureType.OnlineChallengeScreenshots;

		public void Initialise(Level level, App app)
		{
			_level = level;
			OnlineManager.RegisterOnServerConnectionChanged(OnServerConnectionChanged);
			_canShowScreenshotUI = PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.OnlineChallengeScreenshots);
			_scoresButton.Button.onPrimaryDown.AddListener(OnScoresTabPressed);
			_infoButton.Button.onPrimaryDown.AddListener(OnInfoTabPressed);
			_logButton.Button.onPrimaryDown.AddListener(OnLogTabPressed);
			_objectiveActionButton.Button.onPrimaryDown.AddListener(OnAbandonPressed);
			_closeButton.onPrimaryDown.AddListener(OnClosePressed);
			if (_canShowScreenshotUI)
			{
				_screenshotPanelCloseButton.onPrimaryDown.AddListener(OnScreenshotPanelClosePressed);
			}
			_objectiveActionTooltip.SetDataProvider(OnObjectiveActionTooltip);
			ObjectiveEvents objectiveEvents = _level.ObjectiveEvents;
			objectiveEvents.OnObjectiveUpdated = (Action<Objective>)Delegate.Combine(objectiveEvents.OnObjectiveUpdated, new Action<Objective>(OnObjectiveUpdated));
			ObjectiveEvents objectiveEvents2 = _level.ObjectiveEvents;
			objectiveEvents2.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents2.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			ObjectiveEvents objectiveEvents3 = _level.ObjectiveEvents;
			objectiveEvents3.OnFriendDataUpdated = (Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeData>)Delegate.Combine(objectiveEvents3.OnFriendDataUpdated, new Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeData>(OnFriendDataUpdated));
			ObjectiveEvents objectiveEvents4 = _level.ObjectiveEvents;
			objectiveEvents4.OnLocalPlayerDataUpdated = (Action<OnlineChallengeObjective, OnlineChallengeData>)Delegate.Combine(objectiveEvents4.OnLocalPlayerDataUpdated, new Action<OnlineChallengeObjective, OnlineChallengeData>(OnLocalPlayerDataUpdated));
			ObjectiveEvents objectiveEvents5 = _level.ObjectiveEvents;
			objectiveEvents5.OnEventReceived = (Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeEvent>)Delegate.Combine(objectiveEvents5.OnEventReceived, new Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeEvent>(OnEventReceived));
			ObjectiveEvents objectiveEvents6 = _level.ObjectiveEvents;
			objectiveEvents6.OnFriendScreenshotUpdated = (Action<OnlineChallengeObjective, OnlinePlayerID, OnlineScreenshotData>)Delegate.Combine(objectiveEvents6.OnFriendScreenshotUpdated, new Action<OnlineChallengeObjective, OnlinePlayerID, OnlineScreenshotData>(OnFriendScreenshotUpdated));
			_connectionTooltip.SetDataProvider(OnShowConnectionTooltip);
			GameObjectUtils.SetActive(_screenshotPanel, isActive: false);
			RefreshTabSelectedState();
		}

		public void Destroy()
		{
			OnlineManager.UnregisterOnServerConnectionChanged(OnServerConnectionChanged);
			if (_level != null)
			{
				ObjectiveEvents objectiveEvents = _level.ObjectiveEvents;
				objectiveEvents.OnObjectiveUpdated = (Action<Objective>)Delegate.Remove(objectiveEvents.OnObjectiveUpdated, new Action<Objective>(OnObjectiveUpdated));
				ObjectiveEvents objectiveEvents2 = _level.ObjectiveEvents;
				objectiveEvents2.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Remove(objectiveEvents2.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
				ObjectiveEvents objectiveEvents3 = _level.ObjectiveEvents;
				objectiveEvents3.OnFriendDataUpdated = (Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeData>)Delegate.Remove(objectiveEvents3.OnFriendDataUpdated, new Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeData>(OnFriendDataUpdated));
				ObjectiveEvents objectiveEvents4 = _level.ObjectiveEvents;
				objectiveEvents4.OnLocalPlayerDataUpdated = (Action<OnlineChallengeObjective, OnlineChallengeData>)Delegate.Remove(objectiveEvents4.OnLocalPlayerDataUpdated, new Action<OnlineChallengeObjective, OnlineChallengeData>(OnLocalPlayerDataUpdated));
				ObjectiveEvents objectiveEvents5 = _level.ObjectiveEvents;
				objectiveEvents5.OnEventReceived = (Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeEvent>)Delegate.Remove(objectiveEvents5.OnEventReceived, new Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeEvent>(OnEventReceived));
				ObjectiveEvents objectiveEvents6 = _level.ObjectiveEvents;
				objectiveEvents6.OnFriendScreenshotUpdated = (Action<OnlineChallengeObjective, OnlinePlayerID, OnlineScreenshotData>)Delegate.Remove(objectiveEvents6.OnFriendScreenshotUpdated, new Action<OnlineChallengeObjective, OnlinePlayerID, OnlineScreenshotData>(OnFriendScreenshotUpdated));
			}
			_scoresButton.Button.onPrimaryDown.RemoveListener(OnScoresTabPressed);
			_infoButton.Button.onPrimaryDown.RemoveListener(OnInfoTabPressed);
			_logButton.Button.onPrimaryDown.RemoveListener(OnLogTabPressed);
			_objectiveActionButton.Button.onPrimaryDown.RemoveListener(OnAbandonPressed);
			_closeButton.onPrimaryDown.RemoveListener(OnClosePressed);
			if (_canShowScreenshotUI)
			{
				_screenshotPanelCloseButton.onPrimaryDown.RemoveListener(OnScreenshotPanelClosePressed);
			}
			_connectionTooltip.SetDataProvider(null);
			_objectiveActionTooltip.SetDataProvider(null);
			_level?.RemoveTimelineUpdateListener(OnTimelineUpdated);
			_level = null;
		}

		public void SetupForOnlineChallenge(OnlineChallengeObjective onlineChallengeObjective)
		{
			OnlineChallengeObjective = onlineChallengeObjective;
			ChangeMode(Mode.Scores);
			_challengeNameLabel.text = onlineChallengeObjective.Definition.NameLocalised.Translation;
			_scoresPanel.Setup(OnlineChallengeObjective, _level);
			_infoPanel.SetupForChallenge(OnlineChallengeObjective, _scoresPanel, _level);
			_eventLogPanel.Setup(OnlineChallengeObjective);
			_timeSinceNewsflash = _minTimeBetweenNewsflash;
			_infoPanel.OnFriendDataUpdated();
			_scoresPanel.OnFriendDataReceived();
			_eventLogPanel.OnFriendDataUpdated();
			_infoPanel.OnFriendScreenDataUpdated();
			_scoresPanel.Refresh();
			_infoPanel.RefreshAll();
			Refresh();
		}

		private void OnEnable()
		{
			OnServerConnectionChanged(OnlineManager.IsConnected());
			if (_level != null)
			{
				_level.AddTimelineUpdateListener(OnTimelineUpdated);
			}
		}

		private void OnDisable()
		{
			_level?.RemoveTimelineUpdateListener(OnTimelineUpdated);
			_screenshotDisplayElapsedTime = 0f;
			GameObjectUtils.SetActive(_screenshotPanel, isActive: false);
			StopAllCoroutines();
		}

		private void Update()
		{
			if (_timeSinceNewsflash < _minTimeBetweenNewsflash)
			{
				_timeSinceNewsflash += Time.unscaledDeltaTime;
			}
			if (!_canShowScreenshotUI)
			{
				return;
			}
			if (_screenshotDisplayElapsedTime <= 0f)
			{
				if (_screenshotsToShow.Count > 0)
				{
					OnlineScreenshotData.Screenshot screenshot = _screenshotsToShow.Dequeue();
					_screenshotCaption.text = screenshot.Caption;
					_screenshotCaptionBackground.text = screenshot.Caption;
					_screenshotAvatar.PlayerID = screenshot.playerID;
					_screenshotImage.texture = screenshot.GetTexture();
					_screenshotDisplayElapsedTime = _screenshotDisplayTime;
					GameObjectUtils.SetActive(_screenshotPanel, isActive: true);
				}
				else
				{
					GameObjectUtils.SetActive(_screenshotPanel, isActive: false);
				}
			}
			else
			{
				_screenshotDisplayElapsedTime -= Time.unscaledDeltaTime;
			}
		}

		public void Refresh()
		{
			if (OnlineChallengeObjective.Definition.IsTimed)
			{
				_timeLimitProgressBar.SetProgressSmooth(_percentageCompleted);
				if (OnlineChallengeObjective.State == Objective.ObjectiveState.Finished)
				{
					_timeLimitLabel.text = ScriptLocalization.Online.Completed_CS;
					_objectiveActionButton.Button.image.overrideSprite = _finishButtonSprite;
					return;
				}
				int num = Mathf.Min(OnlineChallengeObjective.DaysElapsed + 1, OnlineChallengeObjective.Definition.TimeLength);
				_timeLimitLabel.text = LocalisedString.GetTranslationPlural("Online/DayCountdown_CS", num);
				_timeLimitLabel.text = string.Format(_timeLimitLabel.text, num, OnlineChallengeObjective.Definition.TimeLength);
				_objectiveActionButton.Button.image.overrideSprite = _abandonButtonSprite;
			}
		}

		private void ChangeMode(Mode newMode)
		{
			if (_currentMode != newMode)
			{
				switch (_currentMode)
				{
				case Mode.Scores:
					GameObjectUtils.SetActive(_scoresPanel.gameObject, isActive: false);
					break;
				case Mode.Info:
					GameObjectUtils.SetActive(_infoPanel.gameObject, isActive: false);
					break;
				case Mode.Log:
					GameObjectUtils.SetActive(_eventLogPanel.gameObject, isActive: false);
					break;
				}
				_currentMode = newMode;
				RefreshTabSelectedState();
				switch (_currentMode)
				{
				case Mode.Scores:
					GameObjectUtils.SetActive(_scoresPanel.gameObject, isActive: true);
					_scoresPanel.Refresh();
					break;
				case Mode.Info:
					GameObjectUtils.SetActive(_infoPanel.gameObject, isActive: true);
					_infoPanel.RefreshAll();
					break;
				case Mode.Log:
					GameObjectUtils.SetActive(_eventLogPanel.gameObject, isActive: true);
					_eventLogPanel.Refresh();
					break;
				}
			}
		}

		private void RefreshTabSelectedState()
		{
			_scoresButton.CurrentState = ((_currentMode == Mode.Scores) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
			_infoButton.CurrentState = ((_currentMode == Mode.Info) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
			_logButton.CurrentState = ((_currentMode == Mode.Log) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
		}

		private void OnObjectiveUpdated(Objective objective)
		{
			if (objective == OnlineChallengeObjective)
			{
				_scoresPanel.OnSubGoalUpdated(objective.SubGoals[0]);
				_percentageCompleted = (float)OnlineChallengeObjective.DaysElapsed / (float)OnlineChallengeObjective.Definition.TimeLength;
				Refresh();
			}
		}

		private void OnObjectiveCompleted(Objective objective, Objective.CompletionType completionState)
		{
			if (OnlineChallengeObjective == objective)
			{
				Refresh();
			}
		}

		private void OnLocalPlayerDataUpdated(OnlineChallengeObjective objective, OnlineChallengeData localPlayerData)
		{
		}

		private void OnFriendDataUpdated(OnlineChallengeObjective objective, OnlinePlayerID playerID, OnlineChallengeData data)
		{
			if (objective == OnlineChallengeObjective)
			{
				_infoPanel.OnFriendDataUpdated();
				_scoresPanel.OnFriendDataReceived();
				_eventLogPanel.OnFriendDataUpdated();
			}
		}

		private void OnFriendScreenshotUpdated(OnlineChallengeObjective objective, OnlinePlayerID playerID, OnlineScreenshotData data)
		{
			if (objective == OnlineChallengeObjective)
			{
				_infoPanel.OnFriendScreenDataUpdated();
			}
		}

		private void OnEventReceived(OnlineChallengeObjective objective, OnlinePlayerID playerID, OnlineChallengeEvent challengeEvent)
		{
			if (objective == OnlineChallengeObjective)
			{
				_eventLogPanel.OnEventReceived(playerID, challengeEvent);
				if (base.gameObject.activeInHierarchy && !(_timeSinceNewsflash < _minTimeBetweenNewsflash) && !(playerID == OnlineChallengeObjective.LocalPlayerID) && challengeEvent.Type != OnlineChallengeEvent.Event.Challenge && challengeEvent.Type != OnlineChallengeEvent.Event.Score)
				{
					_timeSinceNewsflash = 0f;
					ShowNewsflash(playerID, challengeEvent);
				}
			}
		}

		private void OnTimelineUpdated(int day, int month, int year)
		{
			_infoPanel.OnTimelineUpdated();
			_eventLogPanel.OnTimelineUpdated();
			_scoresPanel.OnTimelineUpdate();
			if (!_canShowScreenshotUI)
			{
				return;
			}
			foreach (KeyValuePair<OnlinePlayerID, OnlineChallengeObjective.PlayerInfo> item in OnlineChallengeObjective.PlayerInfoDictionary)
			{
				OnlineChallengeObjective.PlayerInfo value = item.Value;
				if (value.ScreenshotData != null)
				{
					OnlineScreenshotData.Screenshot screenshot = value.ScreenshotData.GetScreenshot(OnlineChallengeObjective.DaysElapsed);
					if (screenshot != null)
					{
						_screenshotsToShow.Enqueue(screenshot);
					}
				}
			}
		}

		private void OnScoresTabPressed()
		{
			ChangeMode(Mode.Scores);
		}

		private void OnInfoTabPressed()
		{
			ChangeMode(Mode.Info);
		}

		private void OnLogTabPressed()
		{
			ChangeMode(Mode.Log);
		}

		private void OnAbandonPressed()
		{
			if (OnlineChallengeObjective.State == Objective.ObjectiveState.Finished)
			{
				_level.LevelScriptManager.SetActiveOnlineChallenge(null);
			}
			else
			{
				OnlineChallengeObjective.Abandon();
			}
		}

		private void OnClosePressed()
		{
			GameObjectUtils.SetActive(base.gameObject, isActive: false);
			if (OnlineChallengeObjective.State == Objective.ObjectiveState.Finished)
			{
				_level.LevelScriptManager.SetActiveOnlineChallenge(null);
				return;
			}
			GeneralNotificationMenu generalNotificationMenu = _level.HUD.FindMenu<GeneralNotificationMenu>();
			if (generalNotificationMenu != null)
			{
				generalNotificationMenu.ToggleMode(GeneralNotificationMenu.Category.LevelObjectives);
			}
		}

		private void OnShowConnectionTooltip(Tooltip tooltip)
		{
			if (OnlineManager.IsConnected())
			{
				tooltip.Text = ScriptLocalization.Online.Status_Online_CS;
				return;
			}
			bool flag = Application.internetReachability == NetworkReachability.NotReachable;
			tooltip.Text = $"{ScriptLocalization.Online.Status_Offline_CS} - {(flag ? ScriptLocalization.Online.Status_OfflineReason_NoNetwork_CS : ScriptLocalization.Online.Status_OfflineReason_CantFindSteam_CS)}";
		}

		private void ShowNewsflash(OnlinePlayerID onlinePlayerID, OnlineChallengeEvent challengeEvent)
		{
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				OnlineChallengeObjective.PlayerInfo playerInfo = OnlineChallengeObjective.GetPlayerInfo(onlinePlayerID);
				if (playerInfo != null)
				{
					string message = _eventLogPanel.CreateActivityLogString(playerInfo.PlayerName, playerInfo.IsLocalPlayer, challengeEvent, showDay: false, colored: false);
					Sprite avatar = OnlineManager.GetAvatar(onlinePlayerID);
					AdvisorMessageDefinition definition = new AdvisorMessageDefinition
					{
						Duration = _newsflashDisplayTime,
						Icon = avatar,
						Message = message,
						UserCanDismiss = true
					};
					_level.Advisor.PushMessage(definition, interrupt: false, Advisor.PriorityLevel.Low);
				}
			}
		}

		private void OnServerConnectionChanged(bool connectionStatus)
		{
			_connectionStatusIcon.color = (connectionStatus ? _connectionStatusOnlineColor : _connectionStatusOfflineColor);
		}

		private void OnScreenshotPanelClosePressed()
		{
			_screenshotDisplayElapsedTime = 0f;
		}

		private void OnObjectiveActionTooltip(Tooltip tooltip)
		{
			if (OnlineChallengeObjective.State == Objective.ObjectiveState.Finished)
			{
				tooltip.Text = "Finish Challenge";
			}
			else
			{
				tooltip.Text = ScriptLocalization.Misc.ButtonAbandonChallenge;
			}
		}
	}
}
