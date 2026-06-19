using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblLeaderboardColumn
	{
		public string StatName { get; }

		public XblLeaderboardStatType StatType { get; }

		internal XblLeaderboardColumn(XGamingRuntime.Interop.XblLeaderboardColumn interopColumn)
		{
			StatName = interopColumn.statName.GetString();
			StatType = interopColumn.statType;
		}
	}
}
