using Presentation.Locators;
using Presentation.UI.Objectives;
using TMPro;
using UnityEngine;

namespace Presentation.UI.Overlays.Notifications
{
	public class InGameDeliveriesNotificationWidget : InGameNotificationWidget
	{
		[Header("Deliveries UI")]
		[SerializeField]
		private TierLabel _tierLabel;

		[SerializeField]
		private TextMeshProUGUI _xpText;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		protected override void UpdateNotification(InGameNotificationDto inGameNotificationDto)
		{
			base.UpdateNotification(inGameNotificationDto);
			_labelText.color = inGameNotificationDto.DeliveriesDto.Color;
			_tierLabel.Initialize(inGameNotificationDto.DeliveriesDto.Color);
			_tierLabel.SetTier(inGameNotificationDto.DeliveriesDto.Tier, 9);
			_xpText.text = string.Format(LocalizationUtility.GetLocalizedText("Objectives.xpLabel").ToUpper(), $"{inGameNotificationDto.DeliveriesDto.XpAmount} ");
		}
	}
}
