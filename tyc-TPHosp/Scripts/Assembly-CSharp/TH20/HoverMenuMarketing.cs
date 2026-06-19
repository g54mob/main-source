using System;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HoverMenuMarketing : HoverMenuRoomItem
	{
		[SerializeField]
		private TMP_Text _campaignName;

		[SerializeField]
		private ProgressBarMaskable _progressBar;

		private MarketingCampaignComponent _campaignComponent;

		public override void Setup(RoomItem roomItem, Level level)
		{
			base.Setup(roomItem, level);
			_campaignComponent = _roomItem.GetComponent<MarketingCampaignComponent>();
			MarketingCampaignDefinition activeCampaign = _campaignComponent.ActiveCampaign;
			if (activeCampaign == null)
			{
				_campaignName.text = ScriptLocalization.Menu.Hover_Marketing_LaunchCampaign_CS;
				GameObjectUtils.SetActive(_progressBar.gameObject, isActive: false);
				return;
			}
			_campaignName.text = activeCampaign.NameLocalised.Translation;
			MarketingManager marketingManager = base.Level.MarketingManager;
			marketingManager.OnCampaignEnded = (Action<MarketingCampaignComponent, bool>)Delegate.Combine(marketingManager.OnCampaignEnded, new Action<MarketingCampaignComponent, bool>(OnCampaignEnded));
			MarketingCampaignComponent campaignComponent = _campaignComponent;
			campaignComponent.OnTimeRemainingChanged = (Action)Delegate.Combine(campaignComponent.OnTimeRemainingChanged, new Action(OnTimeRemainingChanged));
			OnTimeRemainingChanged();
		}

		public override void Destroy()
		{
			MarketingManager marketingManager = base.Level.MarketingManager;
			marketingManager.OnCampaignEnded = (Action<MarketingCampaignComponent, bool>)Delegate.Remove(marketingManager.OnCampaignEnded, new Action<MarketingCampaignComponent, bool>(OnCampaignEnded));
			MarketingCampaignComponent campaignComponent = _campaignComponent;
			campaignComponent.OnTimeRemainingChanged = (Action)Delegate.Remove(campaignComponent.OnTimeRemainingChanged, new Action(OnTimeRemainingChanged));
			base.Destroy();
		}

		private void OnTimeRemainingChanged()
		{
			int durationInDays = _campaignComponent.DurationInDays;
			int durationInMonths = _campaignComponent.DurationInMonths;
			int timeRemainingInDays = _campaignComponent.TimeRemainingInDays;
			int timeRemainingInMonths = _campaignComponent.TimeRemainingInMonths;
			string hover_Marketing_TimeLeft_CS = ScriptLocalization.Menu.Hover_Marketing_TimeLeft_CS;
			hover_Marketing_TimeLeft_CS = hover_Marketing_TimeLeft_CS.Replace("{[ELAPSED]}", (durationInMonths - timeRemainingInMonths).ToString());
			hover_Marketing_TimeLeft_CS = hover_Marketing_TimeLeft_CS.Replace("{[DURATION]}", durationInMonths.ToString());
			_progressBar.LabelText = hover_Marketing_TimeLeft_CS;
			_progressBar.Progress = 1f - (float)timeRemainingInDays / (float)durationInDays;
		}

		private void OnCampaignEnded(MarketingCampaignComponent campaign, bool cancelled)
		{
			CloseMenu();
		}
	}
}
