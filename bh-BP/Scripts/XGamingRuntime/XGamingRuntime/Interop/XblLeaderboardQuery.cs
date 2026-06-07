using System;

namespace XGamingRuntime.Interop
{
	internal struct XblLeaderboardQuery
	{
		internal readonly ulong xboxUserId;

		private unsafe fixed byte scid[40];

		internal readonly UTF8StringPtr leaderboardName;

		internal readonly UTF8StringPtr statName;

		internal readonly XblSocialGroupType socialGroup;

		private readonly IntPtr additionalColumnleaderboardNames;

		private readonly SizeT additionalColumnleaderboardNamesCount;

		internal readonly XblLeaderboardSortOrder order;

		internal readonly uint maxItems;

		internal readonly ulong skipToXboxUserId;

		internal readonly uint skipResultToRank;

		internal readonly UTF8StringPtr continuationToken;

		internal readonly XblLeaderboardQueryType queryType;

		internal string[] GetAdditionalColumnleaderboardNames()
		{
			return null;
		}

		internal string GetScid()
		{
			return null;
		}

		internal XblLeaderboardQuery(XGamingRuntime.XblLeaderboardQuery query, DisposableCollection disposableCollection)
		{
			xboxUserId = 0uL;
			leaderboardName = default(UTF8StringPtr);
			statName = default(UTF8StringPtr);
			socialGroup = default(XblSocialGroupType);
			additionalColumnleaderboardNames = (IntPtr)0;
			additionalColumnleaderboardNamesCount = default(SizeT);
			order = default(XblLeaderboardSortOrder);
			maxItems = 0u;
			skipToXboxUserId = 0uL;
			skipResultToRank = 0u;
			continuationToken = default(UTF8StringPtr);
			queryType = default(XblLeaderboardQueryType);
		}

		internal static bool ValidateFields(string scid)
		{
			return false;
		}
	}
}
