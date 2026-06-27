using System;
using Restory.Gameplay.RegularPayments;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class RegularPaymentsServiceSaveData
	{
		public RegularPaymentRecord[] Payments;
	}
}
