using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public abstract class Objective : MustCallDestroy
	{
		public enum ObjectiveState
		{
			Undiscovered = 0,
			Unstarted = 1,
			Active = 2,
			Finished = 3
		}

		public enum ObjectiveScoring
		{
			Standard = 0,
			HiScore = 1,
			TimedStandard = 2,
			TimedHiScore = 3
		}

		public enum CompletionType
		{
			Incomplete = 0,
			Abandoned = 1,
			Failed = 2,
			Successful = 3,
			Invalid = 4
		}

		public List<ObjectiveSubGoal> SubGoals;

		public string UniqueReference;

		public bool IsVisible;

		public bool IsDiscovered;

		public bool IsReplayable;

		public bool StartImmediately;

		private bool _canDismiss;

		[NonSerialized]
		private bool _progressHasBeenUpdated;

		public int DaysElapsed;

		public int CurrentHiScore;

		[SerializeField]
		public ObjectiveDefinition Definition { get; private set; }

		[SerializeField]
		public ObjectiveState State { get; protected set; }

		public string Name => Definition.NameLocalised.Translation;

		public bool IsRewardCollected { get; private set; }

		public CompletionType CompletionResult { get; protected set; }

		protected Objective(string uniqueReference, ObjectiveDefinition definition, bool isVisible, bool isDiscovered, bool isReplayable, bool startImmediately, bool canDismiss = false)
		{
			UniqueReference = uniqueReference;
			Definition = definition;
			IsVisible = isVisible;
			IsDiscovered = isDiscovered;
			IsReplayable = isReplayable;
			StartImmediately = startImmediately;
			_canDismiss = canDismiss;
			State = ObjectiveState.Undiscovered;
		}

		public void Initialise()
		{
			DaysElapsed = 0;
			CurrentHiScore = 0;
			CompletionResult = CompletionType.Incomplete;
			CreateSubGoals();
			State = ObjectiveState.Undiscovered;
			if (IsDiscovered || StartImmediately)
			{
				Discover();
			}
			if (StartImmediately)
			{
				Start();
			}
		}

		public override void Destroy()
		{
			SubGoals.ClearAndCallDestroy();
			base.Destroy();
		}

		protected virtual void CreateSubGoals()
		{
		}

		public virtual void Update(float timeDelta, float unscaledTimeDelta)
		{
			if (State == ObjectiveState.Active)
			{
				for (int i = 0; i < SubGoals.Count; i++)
				{
					SubGoals[i].OnUpdate(timeDelta, unscaledTimeDelta);
				}
				if (_progressHasBeenUpdated)
				{
					CheckForObjectiveCompletion();
					_progressHasBeenUpdated = false;
				}
			}
		}

		public void Discover()
		{
			IsDiscovered = true;
			State = ObjectiveState.Unstarted;
			OnDiscover();
		}

		public void Start()
		{
			foreach (ObjectiveSubGoal subGoal in SubGoals)
			{
				subGoal.Start();
			}
			State = ObjectiveState.Active;
			OnStart();
		}

		public virtual void ForceSuccess()
		{
			Finish(CompletionType.Successful);
		}

		public virtual void Abandon()
		{
			Finish(CompletionType.Abandoned);
		}

		public void ForceFail()
		{
			Finish(CompletionType.Failed);
		}

		public ObjectiveSubGoal GetMostImportantUnfinishedSubGoal()
		{
			ObjectiveSubGoal result = null;
			foreach (ObjectiveSubGoal subGoal in SubGoals)
			{
				if (!subGoal.Completed() && !subGoal.Failed())
				{
					result = subGoal;
					break;
				}
			}
			return result;
		}

		public void Restart()
		{
			if (!IsReplayable && !Definition.IsTimed)
			{
				return;
			}
			foreach (ObjectiveSubGoal subGoal in SubGoals)
			{
				subGoal.Destroy();
			}
			SubGoals = null;
			DaysElapsed = 0;
			CurrentHiScore = 0;
			CreateSubGoals();
			if (SubGoals != null)
			{
				foreach (ObjectiveSubGoal subGoal2 in SubGoals)
				{
					subGoal2.Start();
				}
			}
			State = ObjectiveState.Active;
			OnRestart();
		}

		public void Finish(CompletionType completionType)
		{
			State = ObjectiveState.Finished;
			CompletionResult = completionType;
			if (SubGoals != null)
			{
				foreach (ObjectiveSubGoal subGoal in SubGoals)
				{
					subGoal.End();
				}
			}
			if (GiveRewardOnComplete())
			{
				GiveRewards(CompletionResult);
			}
			OnFinish(completionType);
			if (ReadyToDestroyOnComplete())
			{
				ReadyToDestroy();
			}
		}

		public void ReadyToDestroy()
		{
			OnReadyToDestroy();
		}

		protected virtual void OnDiscover()
		{
		}

		protected virtual void OnStart()
		{
		}

		protected virtual void OnFinish(CompletionType completionType)
		{
		}

		protected virtual void OnRestart()
		{
		}

		protected virtual void OnReadyToDestroy()
		{
		}

		public void ReportSubGoalProgress(ObjectiveSubGoal subGoal)
		{
			_progressHasBeenUpdated = true;
			OnSubGoalUpdated(subGoal);
		}

		public void ReportSubGoalCompleted(ObjectiveSubGoal subGoal)
		{
			OnSubGoalCompleted(subGoal);
		}

		protected virtual void OnSubGoalUpdated(ObjectiveSubGoal subGoal)
		{
		}

		protected virtual void OnSubGoalCompleted(ObjectiveSubGoal subGoal)
		{
		}

		public virtual bool CanComplete()
		{
			if (Definition.EvaluateOnTimeElapse)
			{
				return DaysElapsed >= Definition.TimeLength;
			}
			return true;
		}

		public virtual void CheckForObjectiveCompletion()
		{
			if (Definition.IsHiScore)
			{
				CurrentHiScore = 0;
				foreach (ObjectiveSubGoal subGoal in SubGoals)
				{
					CurrentHiScore += (int)((float)subGoal.Score() * subGoal.HiScoreWeight);
				}
				if (Definition.RequiredHighScore > 0 && Definition.RequiredHighScore >= CurrentHiScore)
				{
					Finish(CompletionType.Successful);
					return;
				}
			}
			bool flag = true;
			foreach (ObjectiveSubGoal subGoal2 in SubGoals)
			{
				if (subGoal2.Failed())
				{
					Finish(CompletionType.Failed);
					return;
				}
				if (!subGoal2.Completed())
				{
					flag = false;
				}
			}
			if (!Definition.IsHiScore && flag)
			{
				Finish(CompletionType.Successful);
			}
			else if (Definition.IsTimed && DaysElapsed >= Definition.TimeLength)
			{
				if (Definition.IsHiScore && Definition.RequiredHighScore <= 0)
				{
					Finish(CompletionType.Successful);
				}
				else
				{
					Finish(CompletionType.Failed);
				}
			}
		}

		public virtual string GetTitleText()
		{
			return Definition.NameLocalised.Translation;
		}

		public virtual string GetDescriptionText()
		{
			return Definition.DescriptionLocalised.Translation;
		}

		public virtual void OnMouseSelect()
		{
		}

		public virtual void GiveRewards(CompletionType completionType)
		{
			IsRewardCollected = true;
		}

		public virtual IReward[] GetRewards(CompletionType completionType)
		{
			return completionType switch
			{
				CompletionType.Abandoned => Definition.AbandonRewards, 
				CompletionType.Failed => Definition.FailRewards, 
				CompletionType.Successful => Definition.CompletionRewards, 
				_ => null, 
			};
		}

		public virtual bool ShouldShowTooltip()
		{
			if (Definition.DescriptionLocalised.Term != string.Empty)
			{
				return true;
			}
			IReward[] rewards = GetRewards(CompletionType.Successful);
			if (rewards != null && rewards.Length != 0)
			{
				return true;
			}
			return false;
		}

		public virtual string GetObjectiveMenuItemTooltip()
		{
			string text = Definition.DescriptionLocalised.Translation;
			if (text != string.Empty)
			{
				string rewardsHUDString = GetRewardsHUDString(CompletionType.Successful);
				if (rewardsHUDString != string.Empty)
				{
					text += "\n\n";
					text += rewardsHUDString;
				}
			}
			return text;
		}

		public string GetRewardsHUDString(CompletionType completionType)
		{
			IReward[] rewards = GetRewards(completionType);
			if (rewards != null && rewards.Length != 0)
			{
				string arg = ((completionType == CompletionType.Successful) ? "Rewards" : "RewardsNegative");
				string text = ((completionType == CompletionType.Successful) ? ScriptLocalization.Notification.Challenge_ChallengeText_CS : ScriptLocalization.Notification.Challenge_PenaltyText_CS);
				string rewardsString = Definition.GetRewardsString(this, rewards);
				return string.Format("<style=\"{1}\">{0}</style>", text.Replace("{[REWARDS]}", rewardsString), arg);
			}
			return string.Empty;
		}

		public virtual bool ShouldAddToExpiredObjectivesList()
		{
			return true;
		}

		public virtual bool ShowGUIOnDiscover()
		{
			return IsReplayable;
		}

		public virtual bool CanDismiss()
		{
			if (State != ObjectiveState.Unstarted)
			{
				return _canDismiss;
			}
			return true;
		}

		public virtual bool GiveRewardOnComplete()
		{
			return true;
		}

		public virtual bool ReadyToDestroyOnComplete()
		{
			return true;
		}
	}
}
