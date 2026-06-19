using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengeSubGoalDefinitionProcessPatients : SubGoalDefinition
	{
		public int NumToProcess;

		public SharedInstance<RoomDefinition> Room;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new StaffChallengeLevelObjectiveProcessPatients(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ((!Room.NotNull()) ? ScriptLocalization.Challenges_SubGoals.ProcessPatients_Goal_CS : LocalisedString.Replace(ScriptLocalization.Challenges_SubGoals.ProcessPatientsInRoom_Goal_CS, "{[ROOM]}", Room.Instance.GetLocalisedName()));
			LocalisationParams.Set("COUNT", NumToProcess);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
