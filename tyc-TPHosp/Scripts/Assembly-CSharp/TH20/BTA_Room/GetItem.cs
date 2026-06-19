using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA_Room
{
	[TaskCategory(" TH20/Room")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GetItem : Action
	{
		[Tooltip("Type of item to find")]
		public RoomItemDefinition.Type _type;

		[Tooltip("Type of item to find")]
		public SharedInstance_TH20TH20_RoomItemDefinition _definition;

		[Tooltip("Room")]
		public SharedRoomRef _room;

		[Tooltip("Item")]
		public SharedItemRef _item;

		public override TaskStatus OnUpdate()
		{
			if (_room.IsValid())
			{
				RoomItem roomItem = (_definition.NotNull() ? _room.Get.GetFirstItemOfType(_definition.Instance) : _room.Get.GetFirstItemOfType(_type));
				if (roomItem != null)
				{
					_item.Value = new ItemRef(roomItem);
					return TaskStatus.Success;
				}
			}
			return TaskStatus.Failure;
		}
	}
}
