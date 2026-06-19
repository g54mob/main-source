using System;
using System.Collections.Generic;
using FullInspector;
using I2.Loc;

namespace TH20
{
	public class MetagameObjective : Objective
	{
		[NotSerialized]
		public Metagame Metagame { get; private set; }

		public MetagameObjectiveDefinition MetagameObjectiveDefinition => base.Definition as MetagameObjectiveDefinition;

		public MetagameObjective(Metagame metagame, ObjectiveDefinition definition, bool isVisible, bool isDiscovered, bool isReplayable, bool startImmediately)
			: base(string.Empty, definition, isVisible, isDiscovered, isReplayable, startImmediately)
		{
			Metagame = metagame;
		}

		public override void Destroy()
		{
			if (Metagame != null && base.Definition != null && base.Definition.IsTimed && base.State == ObjectiveState.Active)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnTimelineUpdated = (Action<int, int, int>)Delegate.Remove(levelEventsIntermediary.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			}
			base.Destroy();
		}

		public virtual void RestoreFromSave(Metagame metagame)
		{
			Metagame = metagame;
			if (SubGoals != null)
			{
				foreach (ObjectiveSubGoal subGoal in SubGoals)
				{
					if (subGoal is MetagameObjectiveSubGoal metagameObjectiveSubGoal)
					{
						metagameObjectiveSubGoal.RestoreFromSave();
						metagameObjectiveSubGoal.SetMetagame(metagame);
					}
				}
			}
			if (Metagame != null && base.Definition.IsTimed && base.State == ObjectiveState.Active)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(levelEventsIntermediary.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			}
		}

		public void SetMetagame(Metagame metagame)
		{
			Metagame = metagame;
			if (Metagame == null)
			{
				return;
			}
			if (SubGoals != null)
			{
				foreach (ObjectiveSubGoal subGoal in SubGoals)
				{
					if (subGoal is MetagameObjectiveSubGoal metagameObjectiveSubGoal)
					{
						metagameObjectiveSubGoal.SetMetagame(metagame);
					}
				}
			}
			if (base.Definition != null && base.Definition.IsTimed && base.State == ObjectiveState.Active)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(levelEventsIntermediary.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			}
		}

		protected override void CreateSubGoals()
		{
			SubGoals.ClearAndCallDestroy();
			SubGoals = new List<ObjectiveSubGoal>();
			if (base.Definition.SubGoalDefinitions != null)
			{
				foreach (SubGoalDefinition subGoalDefinition in base.Definition.SubGoalDefinitions)
				{
					SubGoals.Add(subGoalDefinition.CreateSubGoal(this));
				}
			}
			base.CreateSubGoals();
		}

		protected override void OnDiscover()
		{
			base.OnDiscover();
			if (Metagame != null)
			{
				Metagame.ObjectiveEvents.OnObjectiveDiscovered.InvokeSafe(this);
			}
		}

		protected override void OnStart()
		{
			base.OnStart();
			if (base.Definition.IsTimed)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(levelEventsIntermediary.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			}
			if (Metagame != null)
			{
				Metagame.ObjectiveEvents.OnObjectiveStarted.InvokeSafe(this);
			}
		}

		protected override void OnFinish(CompletionType completionType)
		{
			base.OnFinish(completionType);
			if (Metagame == null)
			{
				return;
			}
			if (base.Definition.IsTimed)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnTimelineUpdated = (Action<int, int, int>)Delegate.Remove(levelEventsIntermediary.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			}
			if (Metagame.CurrentLevel != null && !(this is ResearchProjectObjective) && !(this is SuperBugObjective))
			{
				string text = base.Definition.SubGoalDefinitions[0].GoalText(this);
				if (text.Length > 0)
				{
					Metagame.CurrentLevel.Advisor.PushMessage(new AdvisorMessageDefinition
					{
						Message = ScriptLocalization.Advisor.CareerGoalComplete_CS.Replace("{[OBJECTIVE]}", text),
						Duration = 10f,
						UserCanDismiss = true
					}, interrupt: true, Advisor.PriorityLevel.Medium);
				}
			}
			Metagame.ObjectiveEvents.OnObjectiveCompleted.InvokeSafe(this, completionType);
		}

		protected override void OnRestart()
		{
			base.OnRestart();
			if (Metagame != null)
			{
				Metagame.ObjectiveEvents.OnObjectiveRestarting.InvokeSafe(this);
				if (base.Definition.IsTimed)
				{
					LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
					levelEventsIntermediary.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(levelEventsIntermediary.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
				}
			}
		}

		protected override void OnReadyToDestroy()
		{
			Metagame.ObjectiveEvents.OnObjectiveReadyForDestroy.InvokeSafe(this);
		}

		protected override void OnSubGoalUpdated(ObjectiveSubGoal subGoal)
		{
			base.OnSubGoalUpdated(subGoal);
			if (Metagame != null)
			{
				Metagame.ObjectiveEvents.OnSubGoalUpdated.InvokeSafe(subGoal);
			}
		}

		protected override void OnSubGoalCompleted(ObjectiveSubGoal subGoal)
		{
			base.OnSubGoalCompleted(subGoal);
			if (Metagame != null)
			{
				Metagame.ObjectiveEvents.OnSubGoalCompleted.InvokeSafe(subGoal);
			}
		}

		private void OnTimelineUpdated(int day, int month, int year)
		{
			if (base.State == ObjectiveState.Active)
			{
				DaysElapsed++;
				if (DaysElapsed >= base.Definition.TimeLength)
				{
					CheckForObjectiveCompletion();
				}
				if (Metagame != null)
				{
					Metagame.ObjectiveEvents.OnObjectiveUpdated.InvokeSafe(this);
				}
			}
		}

		public override bool ShouldAddToExpiredObjectivesList()
		{
			return false;
		}

		public override bool CanDismiss()
		{
			return true;
		}

		public override bool GiveRewardOnComplete()
		{
			return false;
		}

		public override void GiveRewards(CompletionType completionType)
		{
			base.GiveRewards(completionType);
			if (Metagame != null)
			{
				RewardUtils.GiveAllRewards(this, GetRewards(completionType), Metagame);
			}
		}

		private bool PrerequisitesMet()
		{
			MetagameObjectiveDefinition metagameObjectiveDefinition = MetagameObjectiveDefinition;
			if (metagameObjectiveDefinition.Prerequisites != null && metagameObjectiveDefinition.Prerequisites.Length != 0)
			{
				SharedInstance<MetagameObjectiveDefinition>[] prerequisites = metagameObjectiveDefinition.Prerequisites;
				foreach (SharedInstance<MetagameObjectiveDefinition> sharedInstance in prerequisites)
				{
					MetagameObjective objectiveFromDefinition = Metagame.ObjectiveManager.GetObjectiveFromDefinition(sharedInstance.Instance);
					if (objectiveFromDefinition.State != ObjectiveState.Finished || !objectiveFromDefinition.IsRewardCollected)
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool ShouldBeDisplayed()
		{
			if (MetagameObjectiveDefinition.HideUntilProgressAboveZero)
			{
				foreach (ObjectiveSubGoal subGoal in SubGoals)
				{
					if (subGoal.PercentComplete() <= 0f)
					{
						return false;
					}
				}
			}
			if (!PrerequisitesMet())
			{
				return false;
			}
			if (base.State == ObjectiveState.Finished && base.IsRewardCollected)
			{
				return false;
			}
			return true;
		}
	}
}
