using System.Collections.Generic;
using System.Text;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ObjectiveDefinition
	{
		public LocalisedString NameLocalised;

		public LocalisedString DescriptionLocalised;

		[InspectorMargin(4)]
		[InspectorDivider]
		[InspectorHeader("Objective Type")]
		[InspectorTooltip("Standard = Complete when sub-goals all completed. TimedStandard = Complete when sub-goals all completed. Fails if all subgoals aren't completed by time expire.  TimedHiScore = Complete when timer ends, unless RequiredHiScore is set.  In which case it completes when RequiredHiScore is met and fail on time expired.  HiScore = Completes when RequiredHiScore hit.")]
		public Objective.ObjectiveScoring ScoreType;

		[InspectorHeader("Objective GUI")]
		public GameObject OverrideObjectivePrefab;

		[InspectorHeader("Functionality")]
		public bool NotDismissable;

		[InspectorShowIf("IsHiScore")]
		public int RequiredHighScore = -1;

		[InspectorShowIf("IsTimed")]
		public int TimeLength = -1;

		[InspectorShowIf("IsTimed")]
		public bool EvaluateOnTimeElapse;

		[InspectorMargin(4)]
		[InspectorDivider]
		[InspectorHeader("Goals and Rewards")]
		[FullInspector.InspectorName("Sub Goals")]
		public List<SubGoalDefinition> SubGoalDefinitions;

		public IReward[] AbandonRewards;

		public IReward[] FailRewards;

		public IReward[] CompletionRewards;

		[InspectorHeader("Notifications")]
		public SharedInstance<NotificationMessages.Definition> SuccessMessage;

		public SharedInstance<NotificationMessages.Definition> FailMessage;

		public LocalisedString AdvisorMessageFail;

		public Sprite AdvisorIconFail;

		public LocalisedString AdvisorMessageSuccess;

		public Sprite AdvisorIconSuccess;

		public bool IsTimed
		{
			get
			{
				if (ScoreType != Objective.ObjectiveScoring.TimedHiScore)
				{
					return ScoreType == Objective.ObjectiveScoring.TimedStandard;
				}
				return true;
			}
		}

		public bool IsHiScore
		{
			get
			{
				if (ScoreType != Objective.ObjectiveScoring.TimedHiScore)
				{
					return ScoreType == Objective.ObjectiveScoring.HiScore;
				}
				return true;
			}
		}

		public override string ToString()
		{
			return NameLocalised.ToString();
		}

		public string GetTimeLimitString()
		{
			if (!IsTimed)
			{
				return string.Empty;
			}
			return ScriptLocalization.Notification.StaffChallenge_TimeLimitText_CS.Replace("{[DAYS]}", TimeLength.ToString());
		}

		public string GetRewardsString(Objective objective, IReward[] rewards)
		{
			string fullRewardString = RewardUtils.GetFullRewardString(objective, rewards, ", ");
			if (!fullRewardString.IsNullOrEmpty())
			{
				return fullRewardString;
			}
			return ScriptLocalization.Challenges.RewardsNone_CS;
		}

		public virtual string GetDescriptionString(Objective objective, IReward[] rewards)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (SubGoalDefinitions != null)
			{
				foreach (SubGoalDefinition subGoalDefinition in SubGoalDefinitions)
				{
					string value = subGoalDefinition.GoalText(objective);
					if (!value.IsNullOrEmpty())
					{
						stringBuilder.AppendLine(value);
					}
				}
			}
			return LocalisedString.Replace(ScriptLocalization.Notification.StaffChallenge_ChallengeText_CS, new SubPair[4]
			{
				new SubPair("{[OBJECTIVE]}", stringBuilder.ToString()),
				new SubPair("{[TIMELIMIT]}", GetTimeLimitString()),
				new SubPair("{[REWARDS]}", GetRewardsString(objective, rewards)),
				new SubPair("\\n", "\n")
			});
		}

		public bool HasGoalBeenAchieved(Level level, Objective objective = null)
		{
			if (SubGoalDefinitions.Count == 0)
			{
				return false;
			}
			foreach (SubGoalDefinition subGoalDefinition in SubGoalDefinitions)
			{
				if (!subGoalDefinition.HasBeenAchieved(level))
				{
					return false;
				}
			}
			return true;
		}
	}
}
