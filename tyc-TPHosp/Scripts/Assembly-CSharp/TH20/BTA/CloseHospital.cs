using BehaviorDesigner.Runtime.Tasks;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/CloseHospitalIcon.png")]
	public class CloseHospital : ExpiringLevelAction
	{
		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			base.Owner.Level.HospitalEvents.OnHospitalClosed.InvokeSafe();
			return TaskStatus.Success;
		}
	}
}
