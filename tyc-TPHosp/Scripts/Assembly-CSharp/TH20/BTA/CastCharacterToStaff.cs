using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CastCharacterToStaff : CharacterAction
	{
		[Tooltip("Character")]
		public SharedCharacterRef _character;

		[Tooltip("Staff")]
		public SharedStaffRef _staff;

		public override TaskStatus OnUpdate()
		{
			if (_character.Get is Staff staff)
			{
				_staff.Value = new StaffRef(staff);
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
	}
}
