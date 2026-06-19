using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public abstract class SubGoalDefinition
	{
		public bool Deprecated;

		public float HiScoreWeight = 1f;

		public LocalisedString AdviceText;

		public bool DisplayOnHUD = true;

		public bool OnceCompleteStayComplete;

		public abstract ObjectiveSubGoal CreateSubGoal(Objective owner);

		public abstract string GoalText(Objective objective);

		public abstract bool HasBeenAchieved(Level level);
	}
}
