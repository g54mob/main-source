using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Leaderboards
{
	public sealed class LeaderboardsInterface : Handle
	{
		public const int CopyleaderboarddefinitionbyindexApiLatest = 1;

		public const int CopyleaderboarddefinitionbyleaderboardidApiLatest = 1;

		public const int CopyleaderboardrecordbyindexApiLatest = 2;

		public const int CopyleaderboardrecordbyuseridApiLatest = 2;

		public const int CopyleaderboarduserscorebyindexApiLatest = 1;

		public const int CopyleaderboarduserscorebyuseridApiLatest = 1;

		public const int DefinitionApiLatest = 1;

		public const int GetleaderboarddefinitioncountApiLatest = 1;

		public const int GetleaderboardrecordcountApiLatest = 1;

		public const int GetleaderboarduserscorecountApiLatest = 1;

		public const int LeaderboardrecordApiLatest = 2;

		public const int LeaderboarduserscoreApiLatest = 1;

		public const int QueryleaderboarddefinitionsApiLatest = 2;

		public const int QueryleaderboardranksApiLatest = 2;

		public const int QueryleaderboarduserscoresApiLatest = 2;

		public const int TimeUndefined = -1;

		public const int UserscoresquerystatinfoApiLatest = 1;

		public LeaderboardsInterface()
		{
		}

		public LeaderboardsInterface(IntPtr innerHandle)
		{
		}

		public Result CopyLeaderboardDefinitionByIndex(CopyLeaderboardDefinitionByIndexOptions options, out Definition outLeaderboardDefinition)
		{
			outLeaderboardDefinition = null;
			return default(Result);
		}

		public Result CopyLeaderboardDefinitionByLeaderboardId(CopyLeaderboardDefinitionByLeaderboardIdOptions options, out Definition outLeaderboardDefinition)
		{
			outLeaderboardDefinition = null;
			return default(Result);
		}

		public Result CopyLeaderboardRecordByIndex(CopyLeaderboardRecordByIndexOptions options, out LeaderboardRecord outLeaderboardRecord)
		{
			outLeaderboardRecord = null;
			return default(Result);
		}

		public Result CopyLeaderboardRecordByUserId(CopyLeaderboardRecordByUserIdOptions options, out LeaderboardRecord outLeaderboardRecord)
		{
			outLeaderboardRecord = null;
			return default(Result);
		}

		public Result CopyLeaderboardUserScoreByIndex(CopyLeaderboardUserScoreByIndexOptions options, out LeaderboardUserScore outLeaderboardUserScore)
		{
			outLeaderboardUserScore = null;
			return default(Result);
		}

		public Result CopyLeaderboardUserScoreByUserId(CopyLeaderboardUserScoreByUserIdOptions options, out LeaderboardUserScore outLeaderboardUserScore)
		{
			outLeaderboardUserScore = null;
			return default(Result);
		}

		public uint GetLeaderboardDefinitionCount(GetLeaderboardDefinitionCountOptions options)
		{
			return 0u;
		}

		public uint GetLeaderboardRecordCount(GetLeaderboardRecordCountOptions options)
		{
			return 0u;
		}

		public uint GetLeaderboardUserScoreCount(GetLeaderboardUserScoreCountOptions options)
		{
			return 0u;
		}

		public void QueryLeaderboardDefinitions(QueryLeaderboardDefinitionsOptions options, object clientData, OnQueryLeaderboardDefinitionsCompleteCallback completionDelegate)
		{
		}

		public void QueryLeaderboardRanks(QueryLeaderboardRanksOptions options, object clientData, OnQueryLeaderboardRanksCompleteCallback completionDelegate)
		{
		}

		public void QueryLeaderboardUserScores(QueryLeaderboardUserScoresOptions options, object clientData, OnQueryLeaderboardUserScoresCompleteCallback completionDelegate)
		{
		}

		internal static void OnQueryLeaderboardDefinitionsCompleteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryLeaderboardRanksCompleteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryLeaderboardUserScoresCompleteCallbackInternalImplementation(IntPtr data)
		{
		}

		[PreserveSig]
		internal static extern Result EOS_Leaderboards_CopyLeaderboardDefinitionByIndex(IntPtr handle, IntPtr options, ref IntPtr outLeaderboardDefinition);

		[PreserveSig]
		internal static extern Result EOS_Leaderboards_CopyLeaderboardDefinitionByLeaderboardId(IntPtr handle, IntPtr options, ref IntPtr outLeaderboardDefinition);

		[PreserveSig]
		internal static extern Result EOS_Leaderboards_CopyLeaderboardRecordByIndex(IntPtr handle, IntPtr options, ref IntPtr outLeaderboardRecord);

		[PreserveSig]
		internal static extern Result EOS_Leaderboards_CopyLeaderboardRecordByUserId(IntPtr handle, IntPtr options, ref IntPtr outLeaderboardRecord);

		[PreserveSig]
		internal static extern Result EOS_Leaderboards_CopyLeaderboardUserScoreByIndex(IntPtr handle, IntPtr options, ref IntPtr outLeaderboardUserScore);

		[PreserveSig]
		internal static extern Result EOS_Leaderboards_CopyLeaderboardUserScoreByUserId(IntPtr handle, IntPtr options, ref IntPtr outLeaderboardUserScore);

		[PreserveSig]
		internal static extern uint EOS_Leaderboards_GetLeaderboardDefinitionCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern uint EOS_Leaderboards_GetLeaderboardRecordCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern uint EOS_Leaderboards_GetLeaderboardUserScoreCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern void EOS_Leaderboards_QueryLeaderboardDefinitions(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryLeaderboardDefinitionsCompleteCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Leaderboards_QueryLeaderboardRanks(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryLeaderboardRanksCompleteCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Leaderboards_QueryLeaderboardUserScores(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryLeaderboardUserScoresCompleteCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Leaderboards_Definition_Release(IntPtr leaderboardDefinition);

		[PreserveSig]
		internal static extern void EOS_Leaderboards_LeaderboardUserScore_Release(IntPtr leaderboardUserScore);

		[PreserveSig]
		internal static extern void EOS_Leaderboards_LeaderboardRecord_Release(IntPtr leaderboardRecord);

		[PreserveSig]
		internal static extern void EOS_Leaderboards_LeaderboardDefinition_Release(IntPtr leaderboardDefinition);
	}
}
