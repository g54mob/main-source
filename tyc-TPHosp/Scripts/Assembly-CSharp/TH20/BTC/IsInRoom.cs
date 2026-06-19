using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTC
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class IsInRoom : CharacterConditional
	{
		[Tooltip("Room. Leave blank if you just want to check room type")]
		public SharedRoomRef _room;

		[Tooltip("Room Type")]
		public SharedInstance_TH20TH20_RoomDefinition _roomDefinition;

		public override TaskStatus OnUpdate()
		{
			Character characterUnsafe = base.CharacterUnsafe;
			if (characterUnsafe != null)
			{
				Room roomUsing = characterUnsafe.RoomUsing;
				if (roomUsing != null)
				{
					if (_room.IsValid() && roomUsing == _room.Get)
					{
						return TaskStatus.Success;
					}
					if (_roomDefinition != null && _roomDefinition.Instance != null && roomUsing.Definition == _roomDefinition.Instance)
					{
						return TaskStatus.Success;
					}
				}
			}
			return TaskStatus.Failure;
		}
	}
}
