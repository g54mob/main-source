using System;
using System.Collections.Generic;
using FullInspector;

namespace TH20
{
	public abstract class Challenge : LevelObjective
	{
		public enum ChallengeState
		{
			Unstarted = 0,
			WaitingForNoticeResponse = 1,
			WaitingToStart = 2,
			InProgress = 3,
			WaitingToIssueDebrief = 4,
			WaitingForDebriefResponse = 5,
			Finished = 6
		}

		private int _daysUntilStartingChallenge;

		private int _daysUntilIssuingDebrief;

		protected ChallengeRewardOption _challengeReward;

		protected readonly ChallengeConfig _definition;

		protected ChallengeState _challengeState;

		protected NotificationDynamicMessage _challengeNotice;

		protected NotificationChallenge _challengeDebriefNotice;

		public int DaysUntilStartingChallenge => _daysUntilStartingChallenge;

		public int DaysUntilIssuingDebrief => _daysUntilIssuingDebrief;

		public ChallengeState ChallengeStatus => _challengeState;

		public T GetConfig<T>() where T : ChallengeConfig
		{
			return _definition as T;
		}

		protected Challenge(ChallengeConfig definition, Level level)
			: base(level, string.Empty, definition, definition.DisplayOnHUD, !definition.IssueChallengeNotice || !definition.PlayerCanRejectChallengeNotice, isReplayable: false, !definition.IssueChallengeNotice)
		{
			_definition = definition;
			_challengeState = ChallengeState.Unstarted;
			_daysUntilStartingChallenge = _definition.DaysUntilChallengeStart;
			_daysUntilIssuingDebrief = _definition.DaysUntilIssuingDebrief;
			level.AddTimelineUpdateListener(OnChallengeTimelineUpdated);
			if (definition.IssueChallengeNotice)
			{
				IssueChallengeNotice();
			}
		}

		public override void RestoreFromSave()
		{
			if (_challengeNotice != null)
			{
				Level level = base.Level;
				level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, (Action)delegate
				{
					base.Level.Notifications.Remove(_challengeNotice, bInvokeRemovedDelegate: false);
					CreateChallengeNotice();
				});
			}
			if (_challengeDebriefNotice != null)
			{
				_challengeDebriefNotice.RestoreResponseDelegate(HandleChallengeDebriefResponse);
			}
			base.Level.AddTimelineUpdateListener(OnChallengeTimelineUpdated);
			base.RestoreFromSave();
		}

		public override void Destroy()
		{
			base.Destroy();
			base.Level.RemoveTimelineUpdateListener(OnChallengeTimelineUpdated);
		}

		protected override void OnStart()
		{
			base.OnStart();
			_challengeState = ChallengeState.InProgress;
			OnChallengeStarted();
			DismissChallengeNotices();
			base.Level.ChallengeEvents.OnChallengeStarted.InvokeSafe(this);
		}

		public override void CheckForObjectiveCompletion()
		{
			if (base.Definition.IsTimed && DaysElapsed >= base.Definition.TimeLength)
			{
				FinishChallenge();
			}
		}

		public override void ForceSuccess()
		{
			base.CompletionResult = CompletionType.Successful;
			FinishChallenge();
		}

		public override void Abandon()
		{
			base.CompletionResult = CompletionType.Abandoned;
			FinishChallenge();
		}

		public void OnBecameInvalid()
		{
			base.CompletionResult = CompletionType.Invalid;
			FinishChallenge();
		}

		protected void FinishChallenge()
		{
			if (IsComplete())
			{
				return;
			}
			_challengeReward = ((base.CompletionResult == CompletionType.Invalid) ? null : _definition.Reward.FindRewardForScore(CalculateChallengeScore()));
			if (_challengeReward != null)
			{
				ShowAdvisorMessage(_challengeReward.AdvisorMessage, _challengeReward.AdvisorIcon, _challengeReward.Rewards);
			}
			OnChallengeFinished();
			DismissChallengeNotices();
			if (base.CompletionResult == CompletionType.Invalid)
			{
				return;
			}
			TryRadioLineInjection();
			if (_definition.IssueDebrief)
			{
				_challengeState = ChallengeState.WaitingToIssueDebrief;
				return;
			}
			IssueChallengeReward();
			if (base.CompletionResult != CompletionType.Abandoned)
			{
				base.Level.ChallengeEvents.OnChallengeCompleted.InvokeSafe(this);
			}
		}

		protected override void OnFinish(CompletionType completionType)
		{
			base.OnFinish(completionType);
			if (completionType == CompletionType.Abandoned || completionType == CompletionType.Invalid)
			{
				base.Level.ChallengeEvents.OnChallengeCompleted.InvokeSafe(this);
			}
		}

		private void ConstructChallengeNotice(out NotificationMessages.Definition outMessageDef)
		{
			ChallengeNoticeDef noticeDef = _definition.NoticeDef;
			LocalisedString localisedString = noticeDef.MainBodyLocalised;
			if (noticeDef.MainBodyAlternativesLocalised != null && noticeDef.MainBodyAlternativesLocalised.Count > 0)
			{
				localisedString = new List<LocalisedString>(noticeDef.MainBodyAlternativesLocalised) { localisedString }.RandomItem(RandomUtils.GlobalRandomInstance);
			}
			outMessageDef = new NotificationMessages.Definition
			{
				LocalisedTitle = noticeDef.TitleLocalised,
				LocalisedText = localisedString,
				_icon = noticeDef.Icon,
				TimeoutInSeconds = noticeDef.TimeOutSeconds,
				DefaultChoice = noticeDef.DefaultChoice,
				UseScaledTime = true,
				_showImmediately = noticeDef.ShowImmediately
			};
			if (_definition.PlayerCanRejectChallengeNotice)
			{
				outMessageDef.Choices = new LocalisedString[2] { noticeDef.ButtonAcceptTextLocalised, noticeDef.ButtonDeclineTextLocalised };
			}
			else
			{
				outMessageDef.Choices = new LocalisedString[1] { noticeDef.ButtonAcceptTextLocalised };
			}
		}

		protected abstract int CalculateChallengeScore();

		protected virtual void InitMenu()
		{
		}

		protected virtual void OnChallengeStarted()
		{
			PlayTannoy(_definition.TannoyOnStart);
			if (!string.IsNullOrEmpty(_definition.AdvisorMessageOnArrivalLocalised.Term))
			{
				base.Level.Advisor.PushMessage(new AdvisorMessageDefinition
				{
					LocalisedMessage = _definition.AdvisorMessageOnArrivalLocalised,
					Icon = _definition.AdvisorIconOnArrival,
					Duration = 10f,
					UserCanDismiss = true
				}, interrupt: true, Advisor.PriorityLevel.Medium);
			}
		}

		protected virtual void OnChallengeFinished()
		{
			if (base.CompletionResult == CompletionType.Successful)
			{
				PlayTannoy(_definition.TannoyOnSuccess);
			}
			if (base.CompletionResult == CompletionType.Failed)
			{
				PlayTannoy(_definition.TannoyOnFailed);
			}
			base.Level.ChallengeEvents.OnChallengeFinished.InvokeSafe(this);
			Finish(base.CompletionResult);
		}

		private static void PlayTannoy(string[] announcements)
		{
			if (announcements != null && announcements.Length != 0)
			{
				TannoyManager.OnAnnouncementQueueRequest.InvokeSafe(announcements.RandomItem());
			}
		}

		private void IssueChallengeNotice()
		{
			CreateChallengeNotice();
			if (_definition.WaitForNoticeResponseBeforeStartingChallenge)
			{
				_challengeState = ChallengeState.WaitingForNoticeResponse;
			}
			else
			{
				_challengeState = ChallengeState.WaitingToStart;
			}
			if (!string.IsNullOrEmpty(_definition.AdvisorMessageOnIssue.Term))
			{
				base.Level.Advisor.PushMessage(new AdvisorMessageDefinition
				{
					LocalisedMessage = _definition.AdvisorMessageOnIssue,
					Icon = _definition.AdvisorIconOnIssue,
					Duration = 10f,
					UserCanDismiss = true
				}, interrupt: true, Advisor.PriorityLevel.Medium);
			}
		}

		private void CreateChallengeNotice()
		{
			ConstructChallengeNotice(out var outMessageDef);
			_challengeNotice = new NotificationDynamicMessage(outMessageDef, HandleChallengeNoticeResponse, base.Level);
			NotificationDynamicMessage challengeNotice = _challengeNotice;
			challengeNotice.FuncGetMessage = (Func<string>)Delegate.Combine(challengeNotice.FuncGetMessage, new Func<string>(GetChallengeMessage));
			base.Level.Notifications.Send(_challengeNotice);
		}

		private string GetChallengeMessage()
		{
			string text = _challengeNotice.Definition.LocalisedText.Translation;
			ChallengeRewardOption challengeRewardOption = _definition.Reward.FindRewardForScore(_definition.RewardSuccessScore);
			if (challengeRewardOption != null)
			{
				text += "\n\n";
				text += _definition.GetDescriptionString(this, challengeRewardOption.Rewards);
			}
			return text;
		}

		private void DismissChallengeNotices()
		{
			if (_challengeNotice != null)
			{
				base.Level.Notifications.Remove(_challengeNotice);
				_challengeNotice = null;
			}
			if (_challengeDebriefNotice != null)
			{
				base.Level.Notifications.Remove(_challengeDebriefNotice);
				_challengeDebriefNotice = null;
			}
		}

		private void IssueChallengeDebrief()
		{
			if (_challengeReward != null)
			{
				_challengeDebriefNotice = new NotificationChallenge(_challengeReward, this, HandleChallengeDebriefResponse, base.Level);
				base.Level.Notifications.Send(_challengeDebriefNotice);
			}
			if (_definition.WaitForDebriefResponseBeforeIssuingReward)
			{
				_challengeState = ChallengeState.WaitingForDebriefResponse;
				return;
			}
			_challengeState = ChallengeState.Finished;
			IssueChallengeReward();
		}

		private void IssueChallengeReward()
		{
			if (_challengeReward != null)
			{
				RewardUtils.GiveAllRewards(this, _challengeReward.Rewards, base.Level.Metagame);
			}
		}

		public virtual void Update(float timeDelta)
		{
			switch (_challengeState)
			{
			case ChallengeState.WaitingToStart:
				if (_daysUntilStartingChallenge <= 0)
				{
					Start();
				}
				break;
			case ChallengeState.WaitingToIssueDebrief:
				if (_daysUntilIssuingDebrief <= 0)
				{
					IssueChallengeDebrief();
				}
				break;
			case ChallengeState.InProgress:
				UpdateChallenge(timeDelta);
				break;
			}
		}

		protected virtual void UpdateChallenge(float timeDelta)
		{
		}

		private void HandleChallengeNoticeResponse(int response)
		{
			bool num = response == 0;
			_challengeNotice = null;
			if (num)
			{
				if (_definition.WaitForNoticeResponseBeforeStartingChallenge)
				{
					_challengeState = ChallengeState.WaitingToStart;
					if (_definition.PlayerCanRejectChallengeNotice)
					{
						Discover();
					}
				}
			}
			else
			{
				Abandon();
			}
		}

		private void HandleChallengeDebriefResponse(int response)
		{
			if (_challengeDebriefNotice != null)
			{
				_challengeDebriefNotice = null;
				if (_definition.WaitForDebriefResponseBeforeIssuingReward)
				{
					IssueChallengeReward();
				}
				ReadyToDestroy();
				base.Level.ChallengeEvents.OnChallengeCompleted.InvokeSafe(this);
			}
		}

		private void TryRadioLineInjection()
		{
			if (_definition.LineInjectionsOnCompletion == null || _definition.ChanceOfLineInjection < RandomUtils.GlobalRandomInstance.NextFloat(0f, 1f))
			{
				return;
			}
			Dictionary<RadioDJDefinition, RadioDJQuote> dictionary = new Dictionary<RadioDJDefinition, RadioDJQuote>();
			foreach (KeyValuePair<SharedInstance<RadioDJDefinition>, RadioDJQuote> item in _definition.LineInjectionsOnCompletion)
			{
				dictionary[item.Key.Instance] = item.Value;
			}
			base.Level.Radio.SuggestLineInjection(dictionary);
		}

		protected virtual void OnChallengeTimelineUpdated(int day, int month, int year)
		{
			if (_challengeState == ChallengeState.WaitingToStart)
			{
				_daysUntilStartingChallenge--;
			}
			if (_challengeState == ChallengeState.WaitingToIssueDebrief)
			{
				_daysUntilIssuingDebrief--;
			}
		}

		public virtual string PrintChallengeScoreBreakdown()
		{
			return "Challenge Score = " + CalculateChallengeScore();
		}

		public override bool ShouldAddToExpiredObjectivesList()
		{
			return false;
		}

		protected bool IsComplete()
		{
			if (base.State != ObjectiveState.Finished && _challengeState != ChallengeState.WaitingForDebriefResponse)
			{
				return _challengeState == ChallengeState.WaitingToIssueDebrief;
			}
			return true;
		}

		public override IReward[] GetRewards(CompletionType completionType)
		{
			if (completionType == CompletionType.Invalid)
			{
				return null;
			}
			if (_challengeReward == null)
			{
				switch (completionType)
				{
				case CompletionType.Successful:
					return _definition.Reward.FindRewardForScore(_definition.RewardSuccessScore)?.Rewards;
				case CompletionType.Abandoned:
					return _definition.Reward.FindRewardForScore(CalculateChallengeScore())?.Rewards;
				}
			}
			if (_challengeReward == null)
			{
				return null;
			}
			return _challengeReward.Rewards;
		}

		public override bool ReadyToDestroyOnComplete()
		{
			if (base.CompletionResult != CompletionType.Abandoned && base.CompletionResult != CompletionType.Invalid)
			{
				return !_definition.IssueDebrief;
			}
			return true;
		}

		public override bool GiveRewardOnComplete()
		{
			return !_definition.WaitForDebriefResponseBeforeIssuingReward;
		}
	}
}
