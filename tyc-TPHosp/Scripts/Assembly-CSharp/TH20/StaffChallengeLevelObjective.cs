using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public abstract class StaffChallengeLevelObjective : LevelObjectiveSubGoal
	{
		protected StaffChallenge _challenge;

		protected StaffChallengeLevelObjective(Objective owner, SubGoalDefinition definition)
			: base(owner, definition)
		{
			_challenge = (StaffChallenge)owner;
		}
	}
}
