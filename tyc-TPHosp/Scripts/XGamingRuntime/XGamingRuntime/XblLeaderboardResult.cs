using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblLeaderboardResult
	{
		public uint TotalRowCount { get; }

		public XblLeaderboardColumn[] Columns { get; }

		public XblLeaderboardRow[] Rows { get; }

		public bool HasNext { get; }

		public XblLeaderboardQuery NextQuery { get; }

		internal XblLeaderboardResult(XGamingRuntime.Interop.XblLeaderboardResult interopResult)
		{
			TotalRowCount = interopResult.totalRowCount;
			Columns = interopResult.GetColumns((XGamingRuntime.Interop.XblLeaderboardColumn c) => new XblLeaderboardColumn(c));
			Rows = interopResult.GetRows((XGamingRuntime.Interop.XblLeaderboardRow r) => new XblLeaderboardRow(r));
			HasNext = interopResult.hasNext.Value;
			NextQuery = new XblLeaderboardQuery(interopResult.nextQuery);
		}
	}
}
