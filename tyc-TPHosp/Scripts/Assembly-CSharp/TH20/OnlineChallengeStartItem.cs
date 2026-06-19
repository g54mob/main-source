using System;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class OnlineChallengeStartItem : MonoBehaviour
	{
		[SerializeField]
		private Localize _objectiveNameLabel;

		[SerializeField]
		private DynamicButton _startButton;

		[SerializeField]
		private UnseenNotificationsIcon _unseenNotificationsIcon;

		private OnlineChallengeObjective _levelObjective;

		private OnlineObjectivesTab _objectivesTab;

		private ObjectiveEvents _objectiveEvents;

		public UnseenNotificationsIcon UnseenNotificationsIcon => _unseenNotificationsIcon;

		private void OnEnable()
		{
			_startButton.onPrimaryDown.AddListener(OnStartPressed);
		}

		private void OnDisable()
		{
			_startButton.onPrimaryDown.RemoveListener(OnStartPressed);
		}

		private void OnDestroy()
		{
			if (_objectiveEvents != null)
			{
				ObjectiveEvents objectiveEvents = _objectiveEvents;
				objectiveEvents.OnFriendDataUpdated = (Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeData>)Delegate.Remove(objectiveEvents.OnFriendDataUpdated, new Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeData>(OnFriendDataUpdated));
				ObjectiveEvents objectiveEvents2 = _objectiveEvents;
				objectiveEvents2.OnOnlineChallengeNotificationsViewed = (Action<OnlineChallengeObjective>)Delegate.Remove(objectiveEvents2.OnOnlineChallengeNotificationsViewed, new Action<OnlineChallengeObjective>(OnOnlineChallengeNotificationsViewed));
			}
		}

		public void Initialise(OnlineObjectivesTab objectivesTab, OnlineChallengeObjective levelObjective)
		{
			_objectivesTab = objectivesTab;
			_levelObjective = levelObjective;
			if (_objectiveEvents == null)
			{
				_objectiveEvents = levelObjective.Level.ObjectiveEvents;
				ObjectiveEvents objectiveEvents = _objectiveEvents;
				objectiveEvents.OnFriendDataUpdated = (Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeData>)Delegate.Combine(objectiveEvents.OnFriendDataUpdated, new Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeData>(OnFriendDataUpdated));
				ObjectiveEvents objectiveEvents2 = _objectiveEvents;
				objectiveEvents2.OnOnlineChallengeNotificationsViewed = (Action<OnlineChallengeObjective>)Delegate.Combine(objectiveEvents2.OnOnlineChallengeNotificationsViewed, new Action<OnlineChallengeObjective>(OnOnlineChallengeNotificationsViewed));
			}
			_objectiveNameLabel.SetTerm(levelObjective.Definition.NameLocalised.Term);
		}

		private void OnOnlineChallengeNotificationsViewed(OnlineChallengeObjective objective)
		{
			if (objective == _levelObjective)
			{
				_unseenNotificationsIcon.UnseenNotifications = objective.GetNumUnseenNotifications();
			}
		}

		private void OnFriendDataUpdated(OnlineChallengeObjective objective, OnlinePlayerID onlinePlayerID, OnlineChallengeData data)
		{
			if (objective == _levelObjective)
			{
				_unseenNotificationsIcon.UnseenNotifications = objective.GetNumUnseenNotifications();
			}
		}

		public void OnStartPressed()
		{
			OnlineAnalyticsManager.OnOnlineFeatureUsed.InvokeSafe(OnlineAnalyticsManager.OnlineFeature.MultiplayerChallenge);
			_objectivesTab.OpenChallengeSetupMenu(_levelObjective);
		}
	}
}
