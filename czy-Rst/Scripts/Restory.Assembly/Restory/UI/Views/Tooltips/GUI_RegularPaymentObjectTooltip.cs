using TMPro;
using UnityEngine;

namespace Restory.UI.Views.Tooltips
{
	public sealed class GUI_RegularPaymentObjectTooltip : TooltipView
	{
		[SerializeField]
		private TMP_Text mainText;

		[SerializeField]
		private TMP_Text metricChangeText;

		[SerializeField]
		private GameObject metricChangeGameObject;

		private bool isOverdue;

		public bool IsOverdue => isOverdue;

		public void SetUpNormalBill(string text, Transform followTransform)
		{
			mainText.text = text;
			metricChangeText.text = string.Empty;
			metricChangeGameObject.SetActive(value: false);
			isOverdue = false;
			SetFollowTransform(followTransform);
		}

		public void SetUpOverdueBill(string text, string affectedMetricName, int metricModifyingAmount, Transform followTransform)
		{
			mainText.text = text;
			metricChangeText.text = $"{affectedMetricName} {metricModifyingAmount}";
			metricChangeGameObject.SetActive(value: true);
			isOverdue = true;
			SetFollowTransform(followTransform);
		}
	}
}
