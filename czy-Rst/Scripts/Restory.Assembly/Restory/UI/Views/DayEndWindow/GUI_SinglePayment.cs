using Helpers.Extensions;
using Restory.UserInterface;
using TMPro;
using UnityEngine;

namespace Restory.UI.Views.DayEndWindow
{
	public class GUI_SinglePayment : MonoBehaviour
	{
		[SerializeField]
		private GUI_LocalisedText paymentNameText;

		[SerializeField]
		private TMP_Text paymentAmountText;

		public void SetUp(string paymentNameLocalizationKey, int paymentAmount, Color paymentAmountTextColor)
		{
			paymentNameText.LocalizationID = paymentNameLocalizationKey;
			paymentAmountText.text = "- ¥" + paymentAmount.ToReadableString();
			paymentAmountText.color = paymentAmountTextColor;
		}
	}
}
