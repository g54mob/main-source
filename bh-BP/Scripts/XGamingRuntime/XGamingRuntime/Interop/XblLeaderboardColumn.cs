namespace XGamingRuntime.Interop
{
	internal struct XblLeaderboardColumn
	{
		internal readonly UTF8StringPtr statName;

		internal readonly XblLeaderboardStatType statType;

		internal XblLeaderboardColumn(XGamingRuntime.XblLeaderboardColumn column, DisposableCollection disposableCollection)
		{
			statName = default(UTF8StringPtr);
			statType = default(XblLeaderboardStatType);
		}
	}
}
