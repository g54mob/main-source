using BehaviorDesigner.Runtime.Tasks;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/CrossIcon.png")]
	public class ExpireAction : ExpiringLevelAction
	{
		public ExpiringLevelAction[] ActionsToExpire;

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			if (ActionsToExpire != null)
			{
				for (int i = 0; i < ActionsToExpire.Length; i++)
				{
					base.Owner.LogExpiredTask(ActionsToExpire[i]);
				}
			}
			return TaskStatus.Success;
		}
	}
}
