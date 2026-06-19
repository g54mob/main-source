using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTC
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CanUseRoom : CharacterConditional
	{
		[Tooltip("Room")]
		public SharedRoomRef _room;

		public override TaskStatus OnUpdate()
		{
			if (_room.IsValid() && base.Character != null)
			{
				Room get = _room.Get;
				if (get.Definition.IsHospitalOrBay)
				{
					return TaskStatus.Success;
				}
				if (get.IsFunctional() && get.IsStaffed() && !get.IsAtMaxCapacity() && get.FloorPlan.Door != null && (get.IsFrontOfQueue(base.Character) || !get.Definition._hasQueue))
				{
					return TaskStatus.Success;
				}
			}
			return TaskStatus.Failure;
		}
	}
}
