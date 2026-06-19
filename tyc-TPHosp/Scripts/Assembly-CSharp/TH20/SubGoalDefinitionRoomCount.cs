using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionRoomCount : SubGoalDefinition
	{
		public int TargetAmount;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalRoomCount(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.RoomCount_Goal_CS.Replace("{[COUNT]}", StringUtils.FormatNumber(TargetAmount));
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
