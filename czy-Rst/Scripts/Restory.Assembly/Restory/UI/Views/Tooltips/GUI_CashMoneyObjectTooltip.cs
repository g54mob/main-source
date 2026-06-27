using TMPro;
using UnityEngine;

namespace Restory.UI.Views.Tooltips
{
	public sealed class GUI_CashMoneyObjectTooltip : TooltipView
	{
		[SerializeField]
		private TMP_Text mainText;

		public void SetUp(int moneyAmount, Transform followTransform)
		{
			mainText.text = string.Format("{0}{1}", "¥", moneyAmount);
			SetFollowTransform(followTransform);
		}
	}
}
