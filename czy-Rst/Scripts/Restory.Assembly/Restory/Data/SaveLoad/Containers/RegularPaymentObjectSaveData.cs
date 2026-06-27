using System;
using Restory.Data.RegularPayments;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class RegularPaymentObjectSaveData
	{
		public string ID;

		public RegularPaymentInfo RegularPaymentInfo;
	}
}
