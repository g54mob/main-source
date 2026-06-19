using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTC
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CanAcceptPatient : CharacterConditional
	{
		[Tooltip("Room")]
		public SharedRoomRef _room;

		public override TaskStatus OnUpdate()
		{
			if (_room.IsValid() && base.Character != null)
			{
				Room get = _room.Get;
				if (get.IsFunctional() && get.IsStaffed() && !get.IsAtMaxCapacity() && get.FloorPlan.Door != null && base.Character is Patient patient && get.CanPatientBeAccepted(patient))
				{
					return TaskStatus.Success;
				}
			}
			return TaskStatus.Failure;
		}
	}
}
