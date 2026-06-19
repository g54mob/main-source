using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionCameraMovement : SubGoalDefinition
	{
		public enum Type
		{
			Pan = 0,
			Rotate = 1,
			Zoom = 2,
			Pitch = 3
		}

		public Type MovementType;

		public float Threshold = 100f;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalCameraMovement(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return MovementType switch
			{
				Type.Pan => ScriptLocalization.Challenges_SubGoals.MoveCamera_Pan_Goal_CS, 
				Type.Rotate => ScriptLocalization.Challenges_SubGoals.MoveCamera_Rotate_Goal_CS, 
				Type.Zoom => ScriptLocalization.Challenges_SubGoals.MoveCamera_Zoom_Goal_CS, 
				Type.Pitch => ScriptLocalization.Challenges_SubGoals.MoveCamera_Pitch_Goal_CS, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
