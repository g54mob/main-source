using TMPro;
using UnityEngine;

namespace Restory.UI.Views.Tooltips
{
	public sealed class GUI_DeliveryBoxInitialTooltip : TooltipView
	{
		[SerializeField]
		private TMP_Text mainText;

		[SerializeField]
		private TMP_Text priceText;

		public void SetUp(string text, int price, Transform followTransform)
		{
			mainText.text = text;
			priceText.text = string.Format("{0}{1}", "¥", price);
			SetFollowTransform(followTransform);
		}

		public void SetUpTextOnly(string text, Transform followTransform)
		{
			mainText.text = text;
			priceText.text = string.Empty;
			SetFollowTransform(followTransform);
		}
	}
}
