using System;

namespace TH20
{
	public class ObjectiveEvents : IGameEventsBase
	{
		public Action<Objective> OnObjectiveDiscovered;

		public Action<Objective> OnObjectiveStarted;

		public Action<Objective> OnObjectiveRestarting;

		public Action<Objective> OnObjectiveUpdated;

		public Action<Objective, Objective.CompletionType> OnObjectiveCompleted;

		public Action<Objective> OnObjectiveReadyForDestroy;

		public Action OnActiveOnlineChallengeChanged;

		public Action<OnlineChallengeObjective, OnlinePlayerID> OnNewOnlineDataReceived;

		public Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeEvent> OnEventReceived;

		public Action<OnlineChallengeObjective, OnlineChallengeData> OnLocalPlayerDataUpdated;

		public Action<OnlineChallengeObjective, OnlineScreenshotData> OnLocalPlayerScreenshotUpdated;

		public Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeData> OnFriendDataUpdated;

		public Action<OnlineChallengeObjective, OnlinePlayerID, OnlineScreenshotData> OnFriendScreenshotUpdated;

		public Action<OnlineChallengeObjective> OnOnlineChallengeNotificationsViewed;

		public Action<ObjectiveSubGoal> OnSubGoalUpdated;

		public Action<ObjectiveSubGoal> OnSubGoalCompleted;

		public Action<ObjectiveGameEvent> OnGameEvent;

		public Action<ResearchProjectObjective> OnObjectiveKickStateChanged;

		public void Initialise()
		{
			GameEventsRegistry.RegisterLevelEvent(this);
		}

		public void VerifyEvents()
		{
			OnObjectiveDiscovered.VerifyIsNull();
			OnObjectiveStarted.VerifyIsNull();
			OnObjectiveRestarting.VerifyIsNull();
			OnObjectiveUpdated.VerifyIsNull();
			OnObjectiveCompleted.VerifyIsNull();
			OnObjectiveReadyForDestroy.VerifyIsNull();
			OnSubGoalUpdated.VerifyIsNull();
			OnSubGoalCompleted.VerifyIsNull();
			OnEventReceived.VerifyIsNull();
			OnLocalPlayerDataUpdated.VerifyIsNull();
			OnLocalPlayerScreenshotUpdated.VerifyIsNull();
			OnFriendDataUpdated.VerifyIsNull();
			OnFriendScreenshotUpdated.VerifyIsNull();
			OnOnlineChallengeNotificationsViewed.VerifyIsNull();
			OnActiveOnlineChallengeChanged.VerifyIsNull();
			OnNewOnlineDataReceived.VerifyIsNull();
			OnGameEvent.VerifyIsNull();
			OnObjectiveKickStateChanged.VerifyIsNull();
		}
	}
}
