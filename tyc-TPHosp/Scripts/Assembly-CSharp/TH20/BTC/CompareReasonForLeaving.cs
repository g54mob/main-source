using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.BTC
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CompareReasonForLeaving : CharacterConditional
	{
		[SerializeField]
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Comparison value")]
		private Character.ReasonForLeavingHospital _value;

		public override TaskStatus OnUpdate()
		{
			if (base.Character.ReasonForLeaving == _value)
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
	}
}
