using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Challenges")]
	[TaskName("Disable Challenge Schedule")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengeDisableSchedule : ExpiringLevelAction
	{
		[SerializeField]
		private string _scheduleName;

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			base.Owner.Level.ChallengeManager.DisableChallengeSchedule(_scheduleName);
			return TaskStatus.Success;
		}
	}
}
