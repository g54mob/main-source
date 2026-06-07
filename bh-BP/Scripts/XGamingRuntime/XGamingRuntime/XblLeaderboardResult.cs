using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblLeaderboardResult
	{
		public uint TotalRowCount { get; private set; }

		public XblLeaderboardColumn[] Columns { get; private set; }

		public XblLeaderboardRow[] Rows { get; private set; }

		public bool HasNext { get; private set; }

		public XblLeaderboardQuery NextQuery { get; private set; }

		internal XblLeaderboardResult(XGamingRuntime.Interop.XblLeaderboardResult interopResult)
		{
		}
	}
}
