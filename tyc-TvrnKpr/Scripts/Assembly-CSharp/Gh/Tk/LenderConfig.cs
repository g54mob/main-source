using System;

namespace Gh.Tk
{
	[Serializable]
	public class LenderConfig
	{
		public string name;

		public int minTavernTier;

		public int minAmount;

		public int maxAmount;

		public int minInterestRate;

		public int maxInterestRate;

		public int minLength;

		public int maxLength;
	}
}
