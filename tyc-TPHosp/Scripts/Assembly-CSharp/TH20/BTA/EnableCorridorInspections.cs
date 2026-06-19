using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/VIP")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/InspectIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class EnableCorridorInspections : CharacterAction
	{
		[SerializeField]
		private bool _enable;

		private VIPComponent _vipComponent;

		public override TaskStatus OnUpdate()
		{
			_vipComponent = base.Character.GetComponent<VIPComponent>();
			if (_vipComponent == null)
			{
				return TaskStatus.Failure;
			}
			_vipComponent.CanInspectCorridor = _enable;
			return TaskStatus.Success;
		}
	}
}
