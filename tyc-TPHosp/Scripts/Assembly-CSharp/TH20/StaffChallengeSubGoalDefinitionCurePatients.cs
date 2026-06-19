using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengeSubGoalDefinitionCurePatients : SubGoalDefinition
	{
		public int NumToCure;

		public SharedInstance<IllnessDefinition> Illness;

		public SharedInstance<RoomDefinition> Room;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new StaffChallengeLevelObjectiveCurePatients(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			bool flag = Room != null && Room.Instance != null;
			bool flag2 = Illness != null && Illness.Instance != null;
			string text = ((flag && flag2) ? ScriptLocalization.Challenges_SubGoals.CurePatientsWithIllnessInRoom_Goal_CS : (flag ? ScriptLocalization.Challenges_SubGoals.CurePatientsInRoom_Goal_CS : ((!flag2) ? ScriptLocalization.Challenges_SubGoals.CurePatients_Goal_CS : ScriptLocalization.Challenges_SubGoals.CurePatientsWithIllness_Goal_CS)));
			LocalisationParams.Set("COUNT", NumToCure);
			LocalisationParams.Localise(ref text);
			if (flag)
			{
				text = LocalisedString.Replace(text, "{[ROOM]}", Room.Instance.GetLocalisedName());
			}
			if (flag2)
			{
				text = LocalisedString.Replace(text, "{[ILLNESS]}", Illness.Instance.Name.Translation);
			}
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
