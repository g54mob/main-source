using FullInspector;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDiagnosePatientsDefinition : SubGoalDefinition
	{
		public int DiagnoseCount;

		public SharedInstance<IllnessDefinition> Illness;

		public SharedInstance<RoomDefinition> Room;

		public SharedInstance<StaffDefinition> Staff;

		public LocalisedString StaffText;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalDiagnosePatients(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			bool flag = Room != null && Room.Instance != null;
			bool flag2 = Illness != null && Illness.Instance != null;
			string text = ((Staff != null && Staff.Instance != null && !StaffText.IsNull()) ? StaffText.Translation : ((flag && flag2) ? ScriptLocalization.Challenges_SubGoals.DiagnosePatientsIllnessRoom_Goal_CS : (flag ? ScriptLocalization.Challenges_SubGoals.DiagnosePatientsRoom_Goal_CS : ((!flag2) ? ScriptLocalization.Challenges_SubGoals.DiagnosePatients_Goal_CS : ScriptLocalization.Challenges_SubGoals.DiagnosePatientsIllness_Goal_CS))));
			LocalisationParams.Set("COUNT", DiagnoseCount);
			LocalisationParams.Localise(ref text);
			if (flag)
			{
				text = text.Replace("{[ROOM]}", Room.Instance.GetLocalisedName());
			}
			if (flag2)
			{
				text = text.Replace("{[ILLNESS]}", Illness.Instance.Name.Translation);
			}
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}

		public bool ValidRoom(RoomDefinition room)
		{
			if (!(Room == null) && Room.Instance != null)
			{
				return Room.Instance == room;
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

		public bool ValidStaff(Staff staff)
		{
			if (Staff == null || Staff.Instance == null)
			{
				return true;
			}
			return staff.Definition == Staff.Instance;
		}
	}
}
