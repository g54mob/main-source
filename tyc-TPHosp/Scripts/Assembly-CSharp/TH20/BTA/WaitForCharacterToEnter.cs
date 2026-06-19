#define LOG_LEVEL_VERBOSE
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Room")]
	[TaskIcon("{SkinColor}WaitIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class WaitForCharacterToEnter : CharacterAction
	{
		[Tooltip("Room")]
		public SharedRoomRef _room;

		public override TaskStatus OnUpdate()
		{
			if (!_room.IsValid())
			{
				return TaskStatus.Failure;
			}
			Room get = _room.Get;
			Character characterUnsafe = base.CharacterUnsafe;
			if (characterUnsafe == null || characterUnsafe.HasBeenDestroyed())
			{
				Logging.Warning(LogChannels.Behaviour, "Character variable is NULL waiting for character to enter {0}", get);
				return TaskStatus.Failure;
			}
			if (characterUnsafe.Interaction == null && characterUnsafe.RoomUsing == get && get.CharactersUsing.Contains(characterUnsafe))
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Running;
		}
	}
}
