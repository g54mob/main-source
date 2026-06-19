using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SetCharacterState : CharacterAction
	{
		[SerializeField]
		private string _state;

		public override TaskStatus OnUpdate()
		{
			base.Character.SetState(_state);
			return TaskStatus.Success;
		}
	}
}
