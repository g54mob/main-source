using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblLeaderboardQuery
	{
		public ulong XboxUserId { get; private set; }

		public string ServiceConfigurationId { get; private set; }

		public string LeaderboardName { get; private set; }

		public string StatName { get; private set; }

		public XblSocialGroupType SocialGroup { get; private set; }

		public string[] AdditionalColumnleaderboardNames { get; private set; }

		public XblLeaderboardSortOrder Order { get; private set; }

		public uint MaxItems { get; private set; }

		public ulong SkipToXboxUserId { get; private set; }

		public uint SkipResultToRank { get; private set; }

		public string ContinuationToken { get; private set; }

		public XblLeaderboardQueryType QueryType { get; private set; }

		private XblLeaderboardQuery(ulong xboxUserId, string serviceConfigurationId, string leaderboardName, string statName, XblSocialGroupType socialGroup, string[] additionalColumnleaderboardNames, XblLeaderboardSortOrder order, uint maxItems, ulong skipToXboxUserId, uint skipResultToRank, string continuationToken, XblLeaderboardQueryType queryType)
		{
		}

		internal XblLeaderboardQuery(XGamingRuntime.Interop.XblLeaderboardQuery interopLeaderboardQuery)
		{
		}

		public static int Create(ulong xboxUserId, string serviceConfigurationId, string leaderboardName, string statName, XblSocialGroupType socialGroup, string[] additionalColumnleaderboardNames, XblLeaderboardSortOrder order, uint maxItems, ulong skipToXboxUserId, uint skipResultToRank, string continuationToken, XblLeaderboardQueryType queryType, out XblLeaderboardQuery leaderboardQuery)
		{
			leaderboardQuery = null;
			return 0;
		}
	}
}
