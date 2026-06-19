using BehaviorDesigner.Runtime.Tasks;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Advisor")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/AdvisorIcon.png")]
	public class ClearAllAdvisorTriggers : ExpiringLevelAction
	{
		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			base.Owner.Level.Advisor.ClearAllTriggers();
			return TaskStatus.Success;
		}
	}
}
