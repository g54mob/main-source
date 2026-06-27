using System;
using Restory.Data.RegularPayments;
using UnityEngine.Serialization;

namespace Restory.Data.Email
{
	[Serializable]
	public class EmailButtonPaymentBillSettings : EmailButtonSettingsBase
	{
		public RegularPaymentInfo TargetBill;

		[FormerlySerializedAs("Option")]
		public EmailButtonPaymentBillOptions BillProcessingOption;
	}
}
