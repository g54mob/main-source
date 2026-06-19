using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Room")]
	[TaskIcon("{SkinColor}WaitIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class WaitForCharacterToExit : CharacterAction
	{
		[Tooltip("Room")]
		public SharedRoomRef _room;

		public override TaskStatus OnUpdate()
		{
			if (base.CharacterUnsafe != null && _room.IsValid() && !base.Character.HasBeenDestroyed())
			{
				Room get = _room.Value.Get;
				if (base.Character.RoomUsing == _room.Get || get.CharactersUsing.Contains(base.Character))
				{
					return TaskStatus.Running;
				}
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
	}
}
