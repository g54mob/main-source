using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionBuildRoom : SubGoalDefinition
	{
		public SharedInstance<RoomDefinition> RoomDefinition;

		public bool IncludeExisting = true;

		public int RequiredCount = 1;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalBuildRoom(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return LocalisedString.Replace(LocalisedString.GetTranslationPlural("Challenges/SubGoals/BuildRoom_Goal_CS", RequiredCount), new SubPair[2]
			{
				new SubPair("{[COUNT]}", RequiredCount.ToString()),
				new SubPair("{[ROOM]}", RoomDefinition.Instance.GetLocalisedNamePlural(RequiredCount))
			});
		}

		public override bool HasBeenAchieved(Level level)
		{
			if (IncludeExisting)
			{
				int roomCount = 0;
				level.WorldState.IterateRoomsOfType(RoomDefinition.Instance, includeClosed: true, delegate
				{
					roomCount++;
				});
				return roomCount >= RequiredCount;
			}
			return false;
		}
	}
}
