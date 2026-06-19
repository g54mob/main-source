using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblLeaderboardQuery
	{
		public ulong XboxUserId { get; }

		public string ServiceConfigurationId { get; }

		public string LeaderboardName { get; }

		public string StatName { get; }

		public XblSocialGroupType SocialGroup { get; }

		public string[] AdditionalColumnleaderboardNames { get; }

		public XblLeaderboardSortOrder Order { get; }

		public uint MaxItems { get; }

		public ulong SkipToXboxUserId { get; }

		public uint SkipResultToRank { get; }

		public string ContinuationToken { get; }

		private XblLeaderboardQuery(ulong xboxUserId, string serviceConfigurationId, string leaderboardName, string statName, XblSocialGroupType socialGroup, string[] additionalColumnleaderboardNames, XblLeaderboardSortOrder order, uint maxItems, ulong skipToXboxUserId, uint skipResultToRank, string continuationToken)
		{
			XboxUserId = xboxUserId;
			ServiceConfigurationId = serviceConfigurationId;
			LeaderboardName = leaderboardName;
			StatName = statName;
			SocialGroup = socialGroup;
			AdditionalColumnleaderboardNames = additionalColumnleaderboardNames;
			Order = order;
			MaxItems = maxItems;
			SkipToXboxUserId = skipToXboxUserId;
			SkipResultToRank = skipResultToRank;
			ContinuationToken = continuationToken;
		}

		internal XblLeaderboardQuery(XGamingRuntime.Interop.XblLeaderboardQuery interopLeaderboardQuery)
		{
			XboxUserId = interopLeaderboardQuery.xboxUserId;
			ServiceConfigurationId = interopLeaderboardQuery.GetScid();
			LeaderboardName = interopLeaderboardQuery.leaderboardName.GetString();
			StatName = interopLeaderboardQuery.statName.GetString();
			SocialGroup = interopLeaderboardQuery.socialGroup;
			AdditionalColumnleaderboardNames = interopLeaderboardQuery.GetAdditionalColumnleaderboardNames();
			Order = interopLeaderboardQuery.order;
			MaxItems = interopLeaderboardQuery.maxItems;
			SkipToXboxUserId = interopLeaderboardQuery.skipToXboxUserId;
			SkipResultToRank = interopLeaderboardQuery.skipResultToRank;
			ContinuationToken = interopLeaderboardQuery.continuationToken.GetString();
		}

		public static int Create(ulong xboxUserId, string serviceConfigurationId, string leaderboardName, string statName, XblSocialGroupType socialGroup, string[] additionalColumnleaderboardNames, XblLeaderboardSortOrder order, uint maxItems, ulong skipToXboxUserId, uint skipResultToRank, string continuationToken, out XblLeaderboardQuery leaderboardQuery)
		{
			if (!XGamingRuntime.Interop.XblLeaderboardQuery.ValidateFields(serviceConfigurationId))
			{
				leaderboardQuery = null;
				return -2147024809;
			}
			leaderboardQuery = new XblLeaderboardQuery(xboxUserId, serviceConfigurationId, leaderboardName, statName, socialGroup, additionalColumnleaderboardNames, order, maxItems, skipToXboxUserId, skipResultToRank, continuationToken);
			return 0;
		}
	}
}
