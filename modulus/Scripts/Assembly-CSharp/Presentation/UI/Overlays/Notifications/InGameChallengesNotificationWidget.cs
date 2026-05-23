using Data.Objectives;
using Presentation.Locators;
using Presentation.UI.Objectives;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Overlays.Notifications
{
	public class InGameChallengesNotificationWidget : InGameNotificationWidget
	{
		[Header("Deliveries UI")]
		[SerializeField]
		private TierLabel _tierLabel;

		[SerializeField]
		private TextMeshProUGUI _xpText;

		[SerializeField]
		private TextMeshProUGUI _currencyText;

		[SerializeField]
		private Image _currentIcon;

		[SerializeField]
		private Image _border;

		[SerializeField]
		private ChallengesUILibrary _challengesUILibrary;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		protected override void UpdateNotification(InGameNotificationDto inGameNotificationDto)
		{
			base.UpdateNotification(inGameNotificationDto);
			_labelText.color = _challengesUILibrary.ChallengeUIs[inGameNotificationDto.DeliveriesDto.Tier].textColor;
			_border.color = _challengesUILibrary.ChallengeUIs[inGameNotificationDto.DeliveriesDto.Tier].borderColor;
			_tierLabel.Initialize(_challengesUILibrary.ChallengeUIs[inGameNotificationDto.DeliveriesDto.Tier].backgroundColor);
			_tierLabel.SetTier(inGameNotificationDto.DeliveriesDto.Tier, 3);
			_xpText.text = string.Format(LocalizationUtility.GetLocalizedText("Objectives.xpLabel"), inGameNotificationDto.DeliveriesDto.XpAmount) + " -";
			_currencyText.text = inGameNotificationDto.DeliveriesDto.CurrencyAmount.ToString();
			_currentIcon.sprite = inGameNotificationDto.DeliveriesDto.CurrencyIcon;
		}
	}
}
