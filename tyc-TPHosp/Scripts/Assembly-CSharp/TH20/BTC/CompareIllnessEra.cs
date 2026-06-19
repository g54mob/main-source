using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.BTC
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CompareIllnessEra : CharacterConditional
	{
		[SerializeField]
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Comparison value")]
		private IllnessEraType _value;

		public override TaskStatus OnUpdate()
		{
			if (base.Character is Patient patient)
			{
				AnachronisticTreatmentComponent component = patient.GetComponent<AnachronisticTreatmentComponent>();
				if (component != null)
				{
					UnityEngine.Debug.Log($"CompareIllnessEra: patient = {patient.Name}, era = {component.EraType.ToString()}, BTC era = {_value.ToString()}");
					if (component.EraType == _value)
					{
						return TaskStatus.Success;
					}
				}
			}
			return TaskStatus.Failure;
		}
	}
}
