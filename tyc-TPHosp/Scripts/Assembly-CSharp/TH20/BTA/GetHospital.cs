using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Room")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GetHospital : CharacterAction
	{
		[Tooltip("Room")]
		public SharedRoomRef _room;

		public override TaskStatus OnUpdate()
		{
			if (base.Character.RoomUsing != null)
			{
				_room.Value = new RoomRef(base.Character.RoomUsing.FloorPlan.HospitalMap.Room);
			}
			else
			{
				_room.Value = new RoomRef(base.Character.Level.WorldState.OwnedHospitalMaps.RandomItem().Room);
			}
			return TaskStatus.Success;
		}
	}
}
