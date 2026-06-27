using System;
using Restory.Data.RegularPayments;

namespace Restory.Gameplay.RegularPayments
{
	[Serializable]
	public class RegularPaymentRecord
	{
		public RegularPaymentInfo PaymentInfo;

		public int NextPaymentDayNumber;
	}
}
