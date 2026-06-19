using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Room")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GetRoomUsing : CharacterAction
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Room")]
		[SerializeField]
		private SharedRoomRef _outRoom;

		public override TaskStatus OnUpdate()
		{
			if (base.Character != null)
			{
				_outRoom.Value = new RoomRef(base.Character.RoomUsing);
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
	}
}
