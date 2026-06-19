#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class LevelObjective : Objective
	{
		public Level Level { get; private set; }

		public LevelObjective(Level level, string uniqueReference, ObjectiveDefinition definition, bool isVisible, bool isDiscovered, bool isReplayable, bool startImmediately, bool canDismiss = false)
			: base(uniqueReference, definition, isVisible, isDiscovered, isReplayable, startImmediately, canDismiss)
		{
			Level = level;
		}

		public override void Destroy()
		{
			if (base.Definition.IsTimed && base.State == ObjectiveState.Active)
			{
				Level.RemoveTimelineUpdateListener(OnTimelineUpdated);
			}
			base.Destroy();
		}

		protected override void CreateSubGoals()
		{
			SubGoals.ClearAndCallDestroy();
			SubGoals = new List<ObjectiveSubGoal>();
			if (base.Definition.SubGoalDefinitions != null)
			{
				foreach (SubGoalDefinition subGoalDefinition in base.Definition.SubGoalDefinitions)
				{
					if (!subGoalDefinition.Deprecated)
					{
						SubGoals.Add(subGoalDefinition.CreateSubGoal(this));
					}
				}
			}
			base.CreateSubGoals();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (SubGoals != null)
			{
				int num = 0;
				foreach (SubGoalDefinition subGoalDefinition in base.Definition.SubGoalDefinitions)
				{
					if (!subGoalDefinition.Deprecated)
					{
						num++;
					}
				}
				bool flag = SubGoals.Count != num;
				foreach (ObjectiveSubGoal subGoal in SubGoals)
				{
					if (!subGoal.IsDefinitionValid())
					{
						flag = true;
					}
				}
				if (flag)
				{
					Logging.Warning(LogChannels.Objective, "Objective sub goal mismatch found in {0}, fixing up sub goals", base.Definition.NameLocalised);
					List<ObjectiveSubGoal> list = new List<ObjectiveSubGoal>();
					List<ObjectiveSubGoal> list2 = new List<ObjectiveSubGoal>();
					List<SubGoalDefinition> list3 = new List<SubGoalDefinition>();
					foreach (ObjectiveSubGoal subGoal2 in SubGoals)
					{
						if (base.Definition.SubGoalDefinitions.Contains(subGoal2.Definition))
						{
							list3.Add(subGoal2.Definition);
						}
						else
						{
							list2.Add(subGoal2);
						}
					}
					foreach (ObjectiveSubGoal item2 in list2)
					{
						item2.Destroy();
						SubGoals.Remove(item2);
					}
					foreach (SubGoalDefinition subGoalDefinition2 in base.Definition.SubGoalDefinitions)
					{
						if (!subGoalDefinition2.Deprecated && !list3.Contains(subGoalDefinition2))
						{
							ObjectiveSubGoal item = subGoalDefinition2.CreateSubGoal(this);
							list.Add(item);
							SubGoals.Add(item);
						}
					}
					if (base.State == ObjectiveState.Active)
					{
						foreach (ObjectiveSubGoal item3 in list)
						{
							item3.Start();
						}
					}
					foreach (ObjectiveSubGoal subGoal3 in SubGoals)
					{
						if (!list.Contains(subGoal3) && subGoal3 is LevelObjectiveSubGoal levelObjectiveSubGoal)
						{
							levelObjectiveSubGoal.RestoreFromSave();
						}
					}
				}
				else
				{
					foreach (ObjectiveSubGoal subGoal4 in SubGoals)
					{
						if (subGoal4 is LevelObjectiveSubGoal levelObjectiveSubGoal2)
						{
							levelObjectiveSubGoal2.RestoreFromSave();
						}
					}
				}
				for (int i = 0; i < SubGoals.Count; i++)
				{
					SubGoalDefinition definition = SubGoals[i].Definition;
					if (definition.Deprecated)
					{
						SubGoals[i].Destroy();
						SubGoals[i] = null;
						Logging.Warning(LogChannels.Objective, "Found deprecated sub goal {0} in {1}", definition, base.Definition.NameLocalised);
					}
				}
				SubGoals.RemoveAll((ObjectiveSubGoal goal) => goal == null);
			}
			if (base.Definition.IsTimed && base.State == ObjectiveState.Active)
			{
				Level.AddTimelineUpdateListener(OnTimelineUpdated);
			}
		}

		protected override void OnDiscover()
		{
			base.OnDiscover();
			Level.ObjectiveEvents.OnObjectiveDiscovered.InvokeSafe(this);
		}

		protected override void OnStart()
		{
			base.OnStart();
			if (base.Definition.IsTimed)
			{
				Level.AddTimelineUpdateListener(OnTimelineUpdated);
			}
			Level.ObjectiveEvents.OnObjectiveStarted.InvokeSafe(this);
		}

		protected override void OnFinish(CompletionType completionType)
		{
			base.OnFinish(completionType);
			if (base.Definition.IsTimed)
			{
				Level.RemoveTimelineUpdateListener(OnTimelineUpdated);
			}
			Level.ObjectiveEvents.OnObjectiveCompleted.InvokeSafe(this, completionType);
			if (completionType != CompletionType.Abandoned && completionType != CompletionType.Invalid)
			{
				DisplayCompletedMessage(completionType == CompletionType.Successful);
			}
		}

		protected virtual void DisplayCompletedMessage(bool success)
		{
			NotificationMessages.Definition definition = null;
			IReward[] rewards;
			if (success)
			{
				rewards = base.Definition.CompletionRewards;
				if (base.Definition.SuccessMessage.NotNull())
				{
					definition = base.Definition.SuccessMessage.Instance;
				}
			}
			else
			{
				rewards = base.Definition.FailRewards;
				if (base.Definition.FailMessage.NotNull())
				{
					definition = base.Definition.FailMessage.Instance;
				}
			}
			if (definition != null)
			{
				Level.Notifications.Send(new NotificationObjectiveComplete(definition, rewards, GetScoreText(), null, Level, this));
			}
			CompletionType completionType = (success ? CompletionType.Successful : CompletionType.Failed);
			ShowAdvisorMessage(GetRewardAdvisorMessage(completionType), GetRewardAdvisorIcon(completionType), rewards);
		}

		public virtual string GetScoreText()
		{
			return null;
		}

		protected override void OnRestart()
		{
			base.OnRestart();
			Level.ObjectiveEvents.OnObjectiveRestarting.InvokeSafe(this);
			if (base.Definition.IsTimed)
			{
				Level.AddTimelineUpdateListener(OnTimelineUpdated);
			}
		}

		protected override void OnReadyToDestroy()
		{
			Level.ObjectiveEvents.OnObjectiveReadyForDestroy.InvokeSafe(this);
			Level.LevelScriptManager.DestroyObjective(this);
		}

		protected override void OnSubGoalUpdated(ObjectiveSubGoal subGoal)
		{
			base.OnSubGoalUpdated(subGoal);
			Level.ObjectiveEvents.OnSubGoalUpdated.InvokeSafe(subGoal);
		}

		protected override void OnSubGoalCompleted(ObjectiveSubGoal subGoal)
		{
			base.OnSubGoalCompleted(subGoal);
			Level.ObjectiveEvents.OnSubGoalCompleted.InvokeSafe(subGoal);
		}

		public override void GiveRewards(CompletionType completionType)
		{
			base.GiveRewards(completionType);
			RewardUtils.GiveAllRewards(this, GetRewards(completionType), Level.Metagame);
		}

		protected virtual void OnTimelineUpdated(int day, int month, int year)
		{
			if (base.State == ObjectiveState.Active)
			{
				DaysElapsed++;
				if (DaysElapsed >= base.Definition.TimeLength)
				{
					CheckForObjectiveCompletion();
				}
				Level.ObjectiveEvents.OnObjectiveUpdated.InvokeSafe(this);
			}
		}

		private LocalisedString GetRewardAdvisorMessage(CompletionType completionType)
		{
			return completionType switch
			{
				CompletionType.Failed => base.Definition.AdvisorMessageFail, 
				CompletionType.Successful => base.Definition.AdvisorMessageSuccess, 
				_ => default(LocalisedString), 
			};
		}

		private Sprite GetRewardAdvisorIcon(CompletionType completionType)
		{
			return completionType switch
			{
				CompletionType.Failed => base.Definition.AdvisorIconFail, 
				CompletionType.Successful => base.Definition.AdvisorIconSuccess, 
				_ => null, 
			};
		}

		protected void ShowAdvisorMessage(LocalisedString message, Sprite icon, IReward[] rewards)
		{
			if (!message.Term.IsNullOrEmpty())
			{
				string fullRewardString = RewardUtils.GetFullRewardString(this, rewards, ", ");
				string message2 = LocalisedString.Replace(message.Translation, new SubPair[2]
				{
					new SubPair("{[NAME]}", base.Name),
					new SubPair("{[REWARDS]}", fullRewardString.IsNullOrEmpty() ? ScriptLocalization.Challenges.RewardsNone_CS : fullRewardString)
				});
				Level.Advisor.PushMessage(new AdvisorMessageDefinition
				{
					Message = message2,
					Icon = icon,
					Duration = 10f,
					UserCanDismiss = true
				}, interrupt: true, Advisor.PriorityLevel.Medium);
			}
		}
	}
}
