using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	public class UnlockLevel : ExpiringLevelAction
	{
		[UsedImplicitly]
		public SharedInstance_TH20TH20_LevelConfig _level;

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			base.Owner.Level.Metagame.MakeHospitalVisible(_level.Instance);
			return TaskStatus.Success;
		}
	}
}
