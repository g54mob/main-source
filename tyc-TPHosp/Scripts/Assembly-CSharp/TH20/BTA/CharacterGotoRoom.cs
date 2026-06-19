using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterGotoRoom : Action
	{
		[Tooltip("Character")]
		public SharedCharacterRef _character;

		[Tooltip("Room")]
		public SharedRoomRef _room;

		[Tooltip("Reason")]
		public SharedReasonUseRoomRef _reason;

		public override TaskStatus OnUpdate()
		{
			if (_room.IsValid() && _character.IsValid())
			{
				ReasonUseRoom reason = (_reason.IsValid() ? _reason.Get : ReasonUseRoom.Diagnosis);
				_character.Get.GotoRoom(_room.Get, reason, setByPlayer: false);
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
	}
}
