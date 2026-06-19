using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	public class GetNumStaff : GetNumBase
	{
		[UsedImplicitly]
		public SharedInstance_TH20TH20_StaffDefinition _staff;

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			if (!CompareValues(base.Owner.Level.CharacterManager.GetStaffOfType((_staff != null) ? _staff.Instance : null).Count))
			{
				if (!_waitForSuccess)
				{
					return TaskStatus.Failure;
				}
				return TaskStatus.Running;
			}
			return TaskStatus.Success;
		}
	}
}
