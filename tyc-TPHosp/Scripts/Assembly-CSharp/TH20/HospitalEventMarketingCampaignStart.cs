using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventMarketingCampaignStart : HospitalEvent, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				MarketingManager marketingManager = _level.MarketingManager;
				marketingManager.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Combine(marketingManager.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStarted));
			}

			public override void UnregisterEvents()
			{
				MarketingManager marketingManager = _level.MarketingManager;
				marketingManager.OnCampaignStarted = (Action<MarketingCampaignComponent>)Delegate.Remove(marketingManager.OnCampaignStarted, new Action<MarketingCampaignComponent>(OnCampaignStarted));
			}

			private void OnCampaignStarted(MarketingCampaignComponent marketingCampaignComponent)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventMarketingCampaignStart
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_value = -marketingCampaignComponent.Cost,
					_campaignName = marketingCampaignComponent.ActiveCampaign.NameLocalised
				});
			}
		}

		private int _value;

		private LocalisedString _campaignName;

		public int GetFinanceValue()
		{
			return _value;
		}

		public bool IsFinanceValueValid()
		{
			return GetFinanceValue() != 0;
		}

		public bool ShowOnStatement()
		{
			return true;
		}

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.MarketingCampaignStart_CS.Replace("{[CAMPAIGN]}", _campaignName.Translation);
		}
	}
}
