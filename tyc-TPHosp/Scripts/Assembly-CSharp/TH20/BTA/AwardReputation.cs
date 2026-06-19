using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/DollarIcon.png")]
	public class AwardReputation : ExpiringLevelAction
	{
		[UsedImplicitly]
		public float _amount;

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			base.Owner.Level.ReputationTracker.AwardReputation(_amount);
			return TaskStatus.Success;
		}
	}
}
