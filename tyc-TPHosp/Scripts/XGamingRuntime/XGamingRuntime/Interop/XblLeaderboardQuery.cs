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

		internal string[] GetAdditionalColumnleaderboardNames()
		{
			return Converters.PtrToClassArray(additionalColumnleaderboardNames, additionalColumnleaderboardNamesCount, (UTF8StringPtr s) => s.GetString());
		}

		internal unsafe string GetScid()
		{
			fixed (byte* bytePointer = scid)
			{
				return Converters.BytePointerToString(bytePointer, 40);
			}
		}

		internal unsafe XblLeaderboardQuery(XGamingRuntime.XblLeaderboardQuery query, DisposableCollection disposableCollection)
		{
			xboxUserId = query.XboxUserId;
			fixed (byte* bytePointer = scid)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(query.ServiceConfigurationId, bytePointer, 40);
			}
			leaderboardName = new UTF8StringPtr(query.LeaderboardName, disposableCollection);
			statName = new UTF8StringPtr(query.StatName, disposableCollection);
			socialGroup = query.SocialGroup;
			additionalColumnleaderboardNames = Converters.StringArrayToUTF8StringArray(query.AdditionalColumnleaderboardNames, disposableCollection, out additionalColumnleaderboardNamesCount);
			order = query.Order;
			maxItems = query.MaxItems;
			skipToXboxUserId = query.SkipToXboxUserId;
			skipResultToRank = query.SkipResultToRank;
			continuationToken = new UTF8StringPtr(query.ContinuationToken, disposableCollection);
		}

		internal static bool ValidateFields(string scid)
		{
			if (scid != null)
			{
				return Converters.StringToNullTerminatedUTF8ByteArray(scid).Length <= 40;
			}
			return false;
		}
	}
}
