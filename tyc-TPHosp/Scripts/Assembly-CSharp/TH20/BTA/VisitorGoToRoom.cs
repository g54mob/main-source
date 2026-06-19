using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Visitor")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class VisitorGoToRoom : CharacterAction
	{
		[Tooltip("Visitor")]
		public SharedVisitorRef _visitor;

		[Tooltip("Room")]
		public SharedRoomRef _room;

		[Tooltip("Reason")]
		public SharedReasonUseRoomRef _reason;

		public override TaskStatus OnUpdate()
		{
			if (_room.IsValid() && _visitor.IsValid())
			{
				ReasonUseRoom reason = (_reason.IsValid() ? _reason.Get : ReasonUseRoom.Inspection);
				_visitor.Get.GotoRoom(_room.Get, reason, setByPlayer: false);
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
	}
}
