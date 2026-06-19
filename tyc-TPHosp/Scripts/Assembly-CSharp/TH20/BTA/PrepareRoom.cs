using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class PrepareRoom : CharacterAction
	{
		[Tooltip("Room")]
		public SharedRoomRef _room;

		public override void OnStart()
		{
			if (base.Character is Patient patient && _room.IsValid())
			{
				_room.Get.AttemptRoomPreparation(patient);
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (base.Character is Patient && _room.IsValid())
			{
				return _room.Get.GetRoomPreparationStatus();
			}
			return TaskStatus.Failure;
		}
	}
}
