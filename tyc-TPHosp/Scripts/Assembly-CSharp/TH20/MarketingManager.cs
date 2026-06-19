using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	public class MarketingManager : IGameEventsBase
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public SharedInstance<GeneralMarketingCampaignDefinition>[] GeneralCampaigns;

			public SharedInstance<RecruitmentMarketingCampaignDefinition>[] RecruitmentCampaigns;
		}

		private Level _level;

		private Config _config;

		public Action<MarketingCampaignComponent> OnCampaignStarted;

		public Action<MarketingCampaignComponent> OnCampaignUpdated;

		public Action<MarketingCampaignComponent, bool> OnCampaignEnded;

		public Action<GeneralMarketingCampaignDefinition, float> OnApplyGeneralCampaign;

		public Action<IllnessMarketingCampaignDefinition, float> OnApplyIllnessCampaign;

		public MarketingManager(Config config, Level level)
		{
			GameEventsRegistry.RegisterLevelEvent(this);
			_level = level;
			_config = config;
		}

		public void VerifyEvents()
		{
			OnCampaignStarted.VerifyIsNull();
			OnCampaignUpdated.VerifyIsNull();
			OnCampaignEnded.VerifyIsNull();
			OnApplyGeneralCampaign.VerifyIsNull();
			OnApplyIllnessCampaign.VerifyIsNull();
		}

		public List<MarketingCampaignDefinition> GetCampaigns(MarketingCampaignType type)
		{
			List<MarketingCampaignDefinition> list = new List<MarketingCampaignDefinition>();
			switch (type)
			{
			case MarketingCampaignType.General:
				if (_config.GeneralCampaigns != null)
				{
					SharedInstance<GeneralMarketingCampaignDefinition>[] generalCampaigns = _config.GeneralCampaigns;
					foreach (SharedInstance<GeneralMarketingCampaignDefinition> sharedInstance2 in generalCampaigns)
					{
						list.AddUnique(sharedInstance2.Instance);
					}
				}
				break;
			case MarketingCampaignType.Recruitment:
				if (_config.RecruitmentCampaigns != null)
				{
					SharedInstance<RecruitmentMarketingCampaignDefinition>[] recruitmentCampaigns = _config.RecruitmentCampaigns;
					foreach (SharedInstance<RecruitmentMarketingCampaignDefinition> sharedInstance in recruitmentCampaigns)
					{
						list.AddUnique(sharedInstance.Instance);
					}
				}
				break;
			case MarketingCampaignType.Illness:
				foreach (IllnessDefinition discoveredIllness in _level.GameplayStatsTracker.DiscoveredIllnesses)
				{
					if (discoveredIllness.MarketingCampaign != null)
					{
						list.AddUnique(discoveredIllness.MarketingCampaign.Instance);
					}
				}
				break;
			default:
				throw new ArgumentOutOfRangeException("type", type, null);
			}
			return list;
		}
	}
}
