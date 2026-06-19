using System;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengeComponent : EntityTickComponent
	{
		private StaffChallenge _challenge;

		protected override Type ValidEntityType()
		{
			return typeof(Staff);
		}

		public override void Tick()
		{
			base.Tick();
			if (_challenge.State != Objective.ObjectiveState.Active)
			{
				base.Level.StatusIconManager.ShowStatusIcon(GetOwner<Staff>(), StatusIcon.Type.StaffChallenge);
			}
		}

		public void Setup(StaffChallenge challenge)
		{
			_challenge = challenge;
		}
	}
}
