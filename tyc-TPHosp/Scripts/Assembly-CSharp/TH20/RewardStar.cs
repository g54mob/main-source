#define LOG_LEVEL_VERBOSE
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardStar : IRewardMetagame
	{
		[SerializeField]
		private MetagameHospitalRecord.StarIndex _star;

		public MetagameHospitalRecord.StarIndex Star => _star;

		public override void Apply(Metagame metagame)
		{
			Logging.AlwaysLog(LogChannels.Metagame, "RewardStar:Apply() Awarding star {0} to metagame with guid {1}", _star, metagame.GetRefId());
			metagame.AwardStar(_star, metagame.CurrentLevel.Config, debug: false);
		}

		public override string Description(Objective objective)
		{
			return null;
		}
	}
}
