using FullInspector;
using I2.Loc;

namespace TH20
{
	public class MetagameSubGoalDefinitionCurePatientsStreak : SubGoalDefinition
	{
		public SharedInstance<IllnessDefinition> Illness;

		public SharedInstance<RoomDefinition> Room;

		public int TargetCureStreak;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new MetagameSubGoalCurePatientsStreak(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			bool num = Room != null && Room.Instance != null;
			bool flag = Illness != null && Illness.Instance != null;
			string text = (num ? ScriptLocalization.Challenges_SubGoals.CurePatientStreakInRoom_Goal_CS : ((!flag) ? ScriptLocalization.Challenges_SubGoals.CurePatientsStreak_Goal_CS : ScriptLocalization.Challenges_SubGoals.CurePatientsStreakWithIllness_Goal_CS));
			if (num)
			{
				text = text.Replace("{[ROOM]}", Room.Instance.GetLocalisedName());
			}
			if (flag)
			{
				text = text.Replace("{[ILLNESS]}", Illness.Instance.Name.Translation);
			}
			LocalisationParams.Set("COUNT", TargetCureStreak);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
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
