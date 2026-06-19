using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Interaction")]
	[TaskIcon("{SkinColor}WaitIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class WaitForCharacterToInteract : CharacterAction
	{
		[Tooltip("Room Item")]
		public SharedItemRef _roomItem;

		public override TaskStatus OnUpdate()
		{
			if (_roomItem.IsValid() && !base.Character.HasBeenDestroyed() && !_roomItem.Value.Get.HasBeenDestroyed())
			{
				if (base.Character.Interaction != null && base.Character.Interaction.ParentRoomItem == _roomItem.Get)
				{
					return TaskStatus.Success;
				}
				return TaskStatus.Running;
			}
			return TaskStatus.Failure;
		}
	}
}
