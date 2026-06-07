namespace OneUseScripts
{
	public struct PatreonHistoryInfo
	{
		public string patreonName;

		public int totalPledge;

		public string latinized;

		public PatreonHistoryInfo(string name, int total, string latin)
		{
			patreonName = name;
			totalPledge = total;
			latinized = latin;
		}
	}
}
