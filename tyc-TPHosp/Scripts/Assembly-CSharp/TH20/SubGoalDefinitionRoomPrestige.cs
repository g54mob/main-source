using FullInspector;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionRoomPrestige : SubGoalDefinition
	{
		public SharedInstance<RoomDefinition> RoomDefinition;

		public int TargetLevel = 1;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalRoomPrestige(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			if (RoomDefinition.NotNull())
			{
				return ScriptLocalization.Challenges_SubGoals.RoomPrestige_CS.Replace("{[ROOM]}", RoomDefinition.Instance.GetLocalisedName()).Replace("{[LEVEL]}", TargetLevel.ToString());
			}
			return ScriptLocalization.Challenges_SubGoals.RoomPrestigeAny_CS.Replace("{[LEVEL]}", TargetLevel.ToString());
		}

		public bool IsValidRoom(FloorPlan floorPlan)
		{
			if (floorPlan is BlueprintFloorPlan)
			{
				return false;
			}
			if (floorPlan.Definition.IsHospitalOrBay)
			{
				return false;
			}
			if (!RoomDefinition.IsNull())
			{
				return floorPlan.Definition == RoomDefinition.Instance;
			}
			return true;
		}

		public override bool HasBeenAchieved(Level level)
		{
			foreach (Room allRoom in level.WorldState.AllRooms)
			{
				FloorPlan floorPlan = allRoom.FloorPlan;
				if (IsValidRoom(floorPlan) && GameAlgorithms.CalculateRoomPrestige(floorPlan).Level >= TargetLevel)
				{
					return true;
				}
			}
			return false;
		}
	}
}
