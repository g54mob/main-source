#define LOG_LEVEL_VERBOSE
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/DollarIcon.png")]
	public class AwardGold : ExpiringLevelAction
	{
		[UsedImplicitly]
		public MetagameHospitalRecord.StarIndex _star;

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			Logging.AlwaysLog(LogChannels.Metagame, "AwardGold:OnUpdate() Awarding star {0} to metagame with guid {1}", _star, base.Owner.Level.Metagame.GetRefId());
			base.Owner.Level.Metagame.AwardStar(_star, base.Owner.Level.Config, debug: false);
			return TaskStatus.Success;
		}
	}
}
