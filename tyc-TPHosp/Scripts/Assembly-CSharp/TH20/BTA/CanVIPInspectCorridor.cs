using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/VIP")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/InspectQuestionIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CanVIPInspectCorridor : Conditional
	{
		[SerializeField]
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Character")]
		private SharedCharacterRef _character;

		private VIPComponent _vipComponent;

		public override TaskStatus OnUpdate()
		{
			if (_character == null || _character.Get == null)
			{
				return TaskStatus.Failure;
			}
			_vipComponent = _character.Get.GetComponent<VIPComponent>();
			if (_vipComponent == null)
			{
				return TaskStatus.Failure;
			}
			if (!_vipComponent.CanInspectCorridor)
			{
				return TaskStatus.Failure;
			}
			return TaskStatus.Success;
		}
	}
}
