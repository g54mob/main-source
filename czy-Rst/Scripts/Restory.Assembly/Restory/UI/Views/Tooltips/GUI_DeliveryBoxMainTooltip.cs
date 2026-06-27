using TMPro;
using UnityEngine;

namespace Restory.UI.Views.Tooltips
{
	public sealed class GUI_DeliveryBoxMainTooltip : TooltipView
	{
		[SerializeField]
		private TMP_Text clientNameText;

		[SerializeField]
		private TMP_Text priceText;

		[SerializeField]
		private TMP_Text messageText;

		public void SetUp(string clientName, Transform followTransform)
		{
			clientNameText.text = clientName;
			priceText.text = "";
			messageText.gameObject.SetActive(value: false);
			SetFollowTransform(followTransform);
		}

		public void SetUp(string clientName, int price, Transform followTransform)
		{
			clientNameText.text = clientName;
			priceText.text = string.Format("{0}{1}", "¥", price);
			messageText.gameObject.SetActive(value: false);
			SetFollowTransform(followTransform);
		}

		public void SetUp(string clientName, int price, string message, Transform followTransform)
		{
			clientNameText.text = clientName;
			priceText.text = string.Format("{0}{1}", "¥", price);
			messageText.text = message;
			messageText.gameObject.SetActive(value: true);
			SetFollowTransform(followTransform);
		}
	}
}
