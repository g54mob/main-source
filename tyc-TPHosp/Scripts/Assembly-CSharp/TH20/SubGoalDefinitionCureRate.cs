using FullInspector;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionCureRate : SubGoalDefinition
	{
		public float TargetCureRate;

		public SharedInstance<IllnessDefinition> Illness;

		public SharedInstance<RoomDefinition> Room;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalCureRate(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			if (Illness.NotNull())
			{
				return ScriptLocalization.Challenges_SubGoals.CureRateIllness_Goal_CS.Replace("{[ILLNESS]}", Illness.Instance.Name.Translation).Replace("{[SCORE]}", StringUtils.FormatPercentageValue(TargetCureRate / 100f));
			}
			if (Room.NotNull())
			{
				return ScriptLocalization.Challenges_SubGoals.CureRateRoom_Goal_CS.Replace("{[ROOM]}", Room.Instance.GetLocalisedName()).Replace("{[SCORE]}", StringUtils.FormatPercentageValue(TargetCureRate / 100f));
			}
			return ScriptLocalization.Challenges_SubGoals.CureRate_Goal_CS.Replace("{[SCORE]}", StringUtils.FormatPercentageValue(TargetCureRate / 100f));
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}

		public bool IsValid(IllnessDefinition illness, Room room)
		{
			RoomDefinition roomDefinition = room?.Definition;
			bool flag = Room.NotNull();
			bool flag2 = Illness.NotNull();
			if ((flag || flag2) && (!flag || Room.Instance != roomDefinition))
			{
				if (flag2)
				{
					return Illness.Instance == illness;
				}
				return false;
			}
			return true;
		}
	}
}
