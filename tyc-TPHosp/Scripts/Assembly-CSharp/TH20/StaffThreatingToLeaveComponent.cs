using System;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffThreatingToLeaveComponent : EntityComponent
	{
		public StaffChallengeResignation Challenge { get; private set; }

		protected override Type ValidEntityType()
		{
			return typeof(Staff);
		}

		public void Setup(ObjectiveDefinition definition)
		{
			Staff owner = GetOwner<Staff>();
			Challenge = new StaffChallengeResignation(base.Level, definition, owner);
			base.Level.LevelScriptManager.AddObjective(Challenge);
		}
	}
}
