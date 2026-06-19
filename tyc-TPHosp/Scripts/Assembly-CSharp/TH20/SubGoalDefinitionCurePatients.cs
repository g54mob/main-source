using System.Collections.Generic;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionCurePatients : SubGoalDefinition
	{
		public int CureCount;

		public SharedInstance<IllnessDefinition> Illness;

		public SharedInstance<RoomDefinition> Room;

		public SharedInstance<StaffDefinition> Staff;

		public LocalisedString StaffText;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalCurePatients(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			bool flag = Room != null && Room.Instance != null;
			bool flag2 = Illness != null && Illness.Instance != null;
			bool num = Staff != null && Staff.Instance != null;
			bool flag3 = objective is ChallengeSpecialPatient challengeSpecialPatient && challengeSpecialPatient.InitialDiagnosisCertainty < 100f;
			string text = ((num && !StaffText.IsNull()) ? StaffText.Translation : (flag3 ? ((!flag) ? ScriptLocalization.Challenges_SubGoals.DiagnoseCurePatients_Goal_CS : ScriptLocalization.Challenges_SubGoals.DiagnoseCurePatientsInRoom_Goal_CS) : ((flag && flag2) ? ScriptLocalization.Challenges_SubGoals.CurePatientsWithIllnessInRoom_Goal_CS : (flag ? ScriptLocalization.Challenges_SubGoals.CurePatientsInRoom_Goal_CS : ((!flag2) ? ScriptLocalization.Challenges_SubGoals.CurePatients_Goal_CS : ScriptLocalization.Challenges_SubGoals.CurePatientsWithIllness_Goal_CS)))));
			LocalisationParams.Set("COUNT", CureCount);
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

		public bool ValidStaff(IEnumerable<Staff> involvedStaff)
		{
			if (Staff == null || Staff.Instance == null)
			{
				return true;
			}
			foreach (Staff item in involvedStaff)
			{
				if (item.Definition == Staff.Instance)
				{
					return true;
				}
			}
			return false;
		}
	}
}
