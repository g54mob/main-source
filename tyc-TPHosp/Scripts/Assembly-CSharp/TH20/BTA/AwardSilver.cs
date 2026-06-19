using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/DollarIcon.png")]
	public class AwardSilver : ExpiringLevelAction
	{
		[UsedImplicitly]
		public int _amount;

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			base.Owner.Level.Metagame.AwardSilver(_amount);
			return TaskStatus.Success;
		}
	}
}
