using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventMarketingCampaignEnd : HospitalEvent
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				MarketingManager marketingManager = _level.MarketingManager;
				marketingManager.OnCampaignEnded = (Action<MarketingCampaignComponent, bool>)Delegate.Combine(marketingManager.OnCampaignEnded, new Action<MarketingCampaignComponent, bool>(OnCampaignEnded));
			}

			public override void UnregisterEvents()
			{
				MarketingManager marketingManager = _level.MarketingManager;
				marketingManager.OnCampaignEnded = (Action<MarketingCampaignComponent, bool>)Delegate.Remove(marketingManager.OnCampaignEnded, new Action<MarketingCampaignComponent, bool>(OnCampaignEnded));
			}

			private void OnCampaignEnded(MarketingCampaignComponent marketingCampaignComponent, bool cancelled)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventMarketingCampaignEnd
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_campaignName = marketingCampaignComponent.ActiveCampaign.NameLocalised
				});
			}
		}

		private LocalisedString _campaignName;

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.MarketingCampaignEnd_CS.Replace("{[CAMPAIGN]}", _campaignName.Translation);
		}
	}
}
