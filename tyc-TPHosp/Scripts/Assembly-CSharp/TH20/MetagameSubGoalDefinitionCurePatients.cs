using FullInspector;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class MetagameSubGoalDefinitionCurePatients : SubGoalDefinition
	{
		public int CureCount;

		public SharedInstance<IllnessDefinition> Illness;

		public SharedInstance<RoomDefinition> Room;

		public override string GoalText(Objective objective)
		{
			bool flag = Room != null && Room.Instance != null;
			bool flag2 = Illness != null && Illness.Instance != null;
			string text = ((flag && flag2) ? ScriptLocalization.Challenges_SubGoals.CurePatientsWithIllnessInRoom_Goal_CS : (flag ? ScriptLocalization.Challenges_SubGoals.CurePatientsInRoom_Goal_CS : ((!flag2) ? ScriptLocalization.Challenges_SubGoals.CurePatients_Goal_CS : ScriptLocalization.Challenges_SubGoals.CurePatientsWithIllness_Goal_CS)));
			if (flag)
			{
				text = text.Replace("{[ROOM]}", Room.Instance.GetLocalisedName());
			}
			if (flag2)
			{
				text = text.Replace("{[ILLNESS]}", Illness.Instance.Name.Translation);
			}
			LocalisationParams.Set("COUNT", CureCount);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new MetagameSubGoalCurePatients(owner, this);
		}

		public bool ValidRoom(Room room)
		{
			if (!(Room == null) && Room.Instance != null)
			{
				if (room != null)
				{
					return Room.Instance == room.Definition;
				}
				return false;
			}
			return true;
		}

		public bool ValidIllness(IllnessDefinition illness)
		{
			if (!(Illness == null) && Illness.Instance != null)
			{
				return Illness.Instance == illness;
			}
			return true;
		}
	}
}
