using System;

namespace Restory.Data.Email
{
	[Serializable]
	public class EmailButtonSubtractMoneySettings : EmailBlockableButtonSettingsBase
	{
		public int SumToSubtract;
	}
}
