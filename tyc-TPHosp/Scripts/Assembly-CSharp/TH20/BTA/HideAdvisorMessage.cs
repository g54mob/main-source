using BehaviorDesigner.Runtime.Tasks;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/AdvisorIcon.png")]
	public class HideAdvisorMessage : ExpiringLevelAction
	{
		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			base.Owner.Level.Advisor.HideMessage();
			return TaskStatus.Success;
		}
	}
}
