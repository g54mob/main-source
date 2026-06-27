using Restory.Data.Localization;
using Restory.Data.Metrics;
using UnityEngine;

namespace Restory.Data.Tooltips
{
	[CreateAssetMenu(fileName = "RegularPaymentObjectTooltipsSettings", menuName = "Restory/TooltipsSettings/RegularPaymentObjectTooltipsSettings")]
	public class RegularPaymentObjectTooltipsSettings : ScriptableObject
	{
		[SerializeField]
		[LocalizationKey]
		private string paymentIsOverdueLocalizationId;

		[SerializeField]
		private MetricInfo metricAffectedByOverduePayment;

		public string PaymentIsOverdueLocalizationId => paymentIsOverdueLocalizationId;

		public MetricInfo MetricAffectedByOverduePayment => metricAffectedByOverduePayment;
	}
}
