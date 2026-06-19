using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StatusIconMarketingCampaign : StatusIcon
	{
		[SerializeField]
		private Image _image;

		[SerializeField]
		private ProgressBar _progressBar;

		private RoomItem _item;

		public override void Initialise(IStatusIconEmitter emitter, Level level, int priority)
		{
			base.Initialise(emitter, level, priority);
			_item = emitter as RoomItem;
		}

		private void Update()
		{
			if (_item == null)
			{
				return;
			}
			MarketingCampaignComponent component = _item.GetComponent<MarketingCampaignComponent>();
			if (component != null && component.ActiveCampaign != null)
			{
				int durationInDays = component.DurationInDays;
				int timeRemainingInDays = component.TimeRemainingInDays;
				if (component.ActiveCampaign.Icon != null)
				{
					_image.sprite = component.ActiveCampaign.Icon;
				}
				_progressBar.Progress = 1f - (float)timeRemainingInDays / (float)durationInDays;
			}
		}

		public override bool HasTimedOut()
		{
			if (_item != null)
			{
				MarketingCampaignComponent component = _item.GetComponent<MarketingCampaignComponent>();
				if (component != null)
				{
					return component.ActiveCampaign == null;
				}
				return false;
			}
			return true;
		}
	}
}
