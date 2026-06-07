using System;

namespace CTS
{
	[Serializable]
	public struct CustomerImportData
	{
		public string Id;

		public int MinStartMoney;

		public int MaxStartMoney;

		public int Credibility;

		public int MinimumPrestigeRequired;
	}
}
