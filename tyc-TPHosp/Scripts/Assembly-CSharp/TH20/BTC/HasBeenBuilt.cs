using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTC
{
	[TaskCategory(" TH20/Room")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HasBeenBuilt : CharacterConditional
	{
		[Tooltip("Room Types")]
		public SharedRoomTypeListRef _roomTypes;

		[Tooltip("Room")]
		public SharedRoomRef _room;

		public override TaskStatus OnUpdate()
		{
			if (!_roomTypes.IsValid())
			{
				return TaskStatus.Failure;
			}
			WorldState worldState = base.Character.Level.WorldState;
			RoomUseType useRoomType = base.Character.GetUseRoomType();
			foreach (RoomDefinition.Type item in _roomTypes.Value.Get)
			{
				Room bestRoomOfType = GameAlgorithms.GetBestRoomOfType(worldState, item, useRoomType, base.Character);
				if (bestRoomOfType != null)
				{
					_room.Value = new RoomRef(bestRoomOfType);
					return TaskStatus.Success;
				}
			}
			return TaskStatus.Running;
		}
	}
}
