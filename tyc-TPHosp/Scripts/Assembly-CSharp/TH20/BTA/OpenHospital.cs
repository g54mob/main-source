using BehaviorDesigner.Runtime.Tasks;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/OpenHospitalIcon.png")]
	public class OpenHospital : ExpiringLevelAction
	{
		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			base.Owner.Level.HospitalEvents.OnHospitalOpened.InvokeSafe();
			return TaskStatus.Success;
		}
	}
}
