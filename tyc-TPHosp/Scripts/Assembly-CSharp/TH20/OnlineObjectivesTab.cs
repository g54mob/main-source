using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using TH20.Analytics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class OnlineObjectivesTab : MonoBehaviour
	{
		[SerializeField]
		private GameObject _onlineObjectiveHolderPrefab;

		[SerializeField]
		private GameObject _onlineObjectivesList;

		[SerializeField]
		private Localize _onlineObjectivesLabel;

		[SerializeField]
		private OnlineChallengeView _onlineChallengeView;

		private Level _level;

		private App _app;

		private LevelScriptManager _levelScriptManager;

		private ObjectiveEvents _objectiveEvents;

		private readonly Dictionary<OnlineChallengeObjective, OnlineChallengeStartItem> _onlineObjectiveStartItems = new Dictionary<OnlineChallengeObjective, OnlineChallengeStartItem>();

		public bool HasActiveChallenge => _levelScriptManager.ActiveOnlineChallenge != null;

		public void Setup(Level level, App app)
		{
			_level = level;
			_levelScriptManager = level.LevelScriptManager;
			_app = app;
			_objectiveEvents = level.ObjectiveEvents;
			ObjectiveEvents objectiveEvents = _objectiveEvents;
			objectiveEvents.OnObjectiveDiscovered = (Action<Objective>)Delegate.Combine(objectiveEvents.OnObjectiveDiscovered, new Action<Objective>(OnObjectiveDiscovered));
			ObjectiveEvents objectiveEvents2 = _objectiveEvents;
			objectiveEvents2.OnObjectiveStarted = (Action<Objective>)Delegate.Combine(objectiveEvents2.OnObjectiveStarted, new Action<Objective>(OnObjectiveStarted));
			ObjectiveEvents objectiveEvents3 = _objectiveEvents;
			objectiveEvents3.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents3.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			ObjectiveEvents objectiveEvents4 = _objectiveEvents;
			objectiveEvents4.OnActiveOnlineChallengeChanged = (Action)Delegate.Combine(objectiveEvents4.OnActiveOnlineChallengeChanged, new Action(OnActiveOnlineChallengeChanged));
			ObjectiveEvents objectiveEvents5 = _objectiveEvents;
			objectiveEvents5.OnNewOnlineDataReceived = (Action<OnlineChallengeObjective, OnlinePlayerID>)Delegate.Combine(objectiveEvents5.OnNewOnlineDataReceived, new Action<OnlineChallengeObjective, OnlinePlayerID>(OnNewOnlineDataReceived));
			_onlineChallengeView.Initialise(_level, _app);
			if (_levelScriptManager.ActiveOnlineChallenge != null && _levelScriptManager.ActiveOnlineChallenge.State != Objective.ObjectiveState.Unstarted)
			{
				_onlineChallengeView.SetupForOnlineChallenge(_levelScriptManager.ActiveOnlineChallenge);
			}
			foreach (OnlineChallengeObjective onlineChallenge in _levelScriptManager.OnlineChallenges)
			{
				if (onlineChallenge.State >= Objective.ObjectiveState.Unstarted)
				{
					InstantiateOnlineChallengeStartItem(onlineChallenge);
				}
			}
			Refresh();
		}

		private void OnEnable()
		{
			if (_level != null)
			{
				Refresh();
			}
		}

		private void OnDisable()
		{
			if (_levelScriptManager.ActiveOnlineChallenge != null && _levelScriptManager.ActiveOnlineChallenge.State <= Objective.ObjectiveState.Unstarted)
			{
				_levelScriptManager.SetActiveOnlineChallenge(null);
			}
		}

		public void Destroy()
		{
			DestroyOnlineChallengeStartItems();
			if (_onlineChallengeView != null)
			{
				_onlineChallengeView.Destroy();
			}
			if (_objectiveEvents != null)
			{
				ObjectiveEvents objectiveEvents = _objectiveEvents;
				objectiveEvents.OnObjectiveDiscovered = (Action<Objective>)Delegate.Remove(objectiveEvents.OnObjectiveDiscovered, new Action<Objective>(OnObjectiveDiscovered));
				ObjectiveEvents objectiveEvents2 = _objectiveEvents;
				objectiveEvents2.OnObjectiveStarted = (Action<Objective>)Delegate.Remove(objectiveEvents2.OnObjectiveStarted, new Action<Objective>(OnObjectiveStarted));
				ObjectiveEvents objectiveEvents3 = _objectiveEvents;
				objectiveEvents3.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Remove(objectiveEvents3.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
				ObjectiveEvents objectiveEvents4 = _objectiveEvents;
				objectiveEvents4.OnActiveOnlineChallengeChanged = (Action)Delegate.Remove(objectiveEvents4.OnActiveOnlineChallengeChanged, new Action(OnActiveOnlineChallengeChanged));
				ObjectiveEvents objectiveEvents5 = _objectiveEvents;
				objectiveEvents5.OnNewOnlineDataReceived = (Action<OnlineChallengeObjective, OnlinePlayerID>)Delegate.Remove(objectiveEvents5.OnNewOnlineDataReceived, new Action<OnlineChallengeObjective, OnlinePlayerID>(OnNewOnlineDataReceived));
			}
		}

		public void OpenChallengeSetupMenu(OnlineChallengeObjective objective)
		{
			_level.HospitalHUDManager.TryOpenMenu(delegate
			{
				OnlineChallengeSetupMenu onlineChallengeSetupMenu = _level.HUD.FindMenu<OnlineChallengeSetupMenu>();
				if (onlineChallengeSetupMenu == null)
				{
					onlineChallengeSetupMenu = _level.HUD.CreateMenu<OnlineChallengeSetupMenu>();
					onlineChallengeSetupMenu.Initialise(_level, _level.ObjectiveEvents);
				}
				onlineChallengeSetupMenu.Setup(objective, _app.Metagame.OnlineMetadataManager);
			});
		}

		private void Refresh()
		{
			bool flag = _levelScriptManager.ActiveOnlineChallenge != null;
			GameObjectUtils.SetActive(_onlineChallengeView.gameObject, flag);
			GameObjectUtils.SetActive(_onlineObjectivesLabel.gameObject, !flag);
			foreach (KeyValuePair<OnlineChallengeObjective, OnlineChallengeStartItem> onlineObjectiveStartItem in _onlineObjectiveStartItems)
			{
				GameObjectUtils.SetActive(onlineObjectiveStartItem.Value.gameObject, !flag);
				onlineObjectiveStartItem.Value.UnseenNotificationsIcon.UnseenNotifications = onlineObjectiveStartItem.Key.GetNumUnseenNotifications();
			}
		}

		private void OnObjectiveDiscovered(Objective objective)
		{
			if (objective is OnlineChallengeObjective onlineChallenge)
			{
				InstantiateOnlineChallengeStartItem(onlineChallenge);
				Refresh();
			}
		}

		private void OnObjectiveStarted(Objective objective)
		{
			if (objective is OnlineChallengeObjective onlineChallengeObjective && onlineChallengeObjective.IsVisible)
			{
				GameObjectUtils.SetActive(_onlineChallengeView.gameObject, isActive: true);
				_onlineChallengeView.SetupForOnlineChallenge(onlineChallengeObjective);
				GameEvent gameEvent = new GameEvent(_app.AnalyticsManager.Config.MultiplayerChallengeStarted).AddLevelHeader(onlineChallengeObjective.Level).AddParam("leaderboardName", onlineChallengeObjective.Definition.LeaderboardName);
				_app.AnalyticsManager.RecordEvent(gameEvent);
			}
		}

		private void OnObjectiveCompleted(Objective objective, Objective.CompletionType completionType)
		{
			if (objective is OnlineChallengeObjective onlineChallengeObjective)
			{
				if (completionType != Objective.CompletionType.Successful || !onlineChallengeObjective.IsReplayable)
				{
					RemoveObjective(onlineChallengeObjective);
				}
				GameEvent gameEvent = new GameEvent(_app.AnalyticsManager.Config.MultiplayerChallengeCompleted).AddLevelHeader(onlineChallengeObjective.Level).AddParam("leaderboardName", onlineChallengeObjective.Definition.LeaderboardName).AddParam("completionType", (int)completionType);
				_app.AnalyticsManager.RecordEvent(gameEvent);
			}
		}

		private void OnActiveOnlineChallengeChanged()
		{
			_ = _levelScriptManager.ActiveOnlineChallenge;
			Refresh();
		}

		private void RemoveObjective(OnlineChallengeObjective objective)
		{
			if (objective.IsVisible)
			{
				Refresh();
			}
		}

		protected void Update()
		{
			foreach (RaycastResult raycastResult in _level.InputManager.RaycastResults)
			{
				ObjectiveMenuItem component = raycastResult.gameObject.GetComponent<ObjectiveMenuItem>();
				if (component != null)
				{
					if (_level.InputManager.GetMouseDown(MouseButton.Left))
					{
						component.OnClicked();
					}
					break;
				}
			}
		}

		private void OnNewOnlineDataReceived(OnlineChallengeObjective levelObjective, OnlinePlayerID onlinePlayerID)
		{
			Refresh();
		}

		private void InstantiateOnlineChallengeStartItem(OnlineChallengeObjective onlineChallenge)
		{
			if (!_onlineObjectiveStartItems.ContainsKey(onlineChallenge))
			{
				GameObject obj = UnityEngine.Object.Instantiate(_onlineObjectiveHolderPrefab);
				obj.transform.SetParent(_onlineObjectivesList.transform, worldPositionStays: false);
				OnlineChallengeStartItem component = obj.GetComponent<OnlineChallengeStartItem>();
				component.Initialise(this, onlineChallenge);
				_onlineObjectiveStartItems[onlineChallenge] = component;
			}
		}

		private void DestroyOnlineChallengeStartItems()
		{
			foreach (OnlineChallengeStartItem value in _onlineObjectiveStartItems.Values)
			{
				UnityEngine.Object.Destroy(value.gameObject);
			}
			_onlineObjectiveStartItems?.Clear();
		}
	}
}
