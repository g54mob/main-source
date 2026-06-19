using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Room")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GetOtherStaffMember : CharacterAction
	{
		[Tooltip("Room")]
		public SharedRoomRef _room;

		[Tooltip("Other Staff Member")]
		public SharedStaffRef _otherMember;

		public override TaskStatus OnUpdate()
		{
			if (_room.IsValid())
			{
				List<Staff> staffWorkingInRoom = _room.Get.StaffWorkingInRoom;
				if (staffWorkingInRoom.Count > 1)
				{
					foreach (Staff item in staffWorkingInRoom)
					{
						if (item != base.Character)
						{
							_otherMember.Value = new StaffRef(item);
							return TaskStatus.Success;
						}
					}
				}
			}
			return TaskStatus.Failure;
		}
	}
}
