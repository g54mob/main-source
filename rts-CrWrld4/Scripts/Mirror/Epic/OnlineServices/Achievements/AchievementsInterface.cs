using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Achievements
{
	public sealed class AchievementsInterface : Handle
	{
		public const int AchievementUnlocktimeUndefined = -1;

		public const int AddnotifyachievementsunlockedApiLatest = 1;

		public const int Addnotifyachievementsunlockedv2ApiLatest = 2;

		public const int Copyachievementdefinitionv2ByachievementidApiLatest = 2;

		public const int Copyachievementdefinitionv2ByindexApiLatest = 2;

		public const int CopydefinitionbyachievementidApiLatest = 1;

		public const int CopydefinitionbyindexApiLatest = 1;

		public const int Copydefinitionv2ByachievementidApiLatest = 2;

		public const int Copydefinitionv2ByindexApiLatest = 2;

		public const int CopyplayerachievementbyachievementidApiLatest = 2;

		public const int CopyplayerachievementbyindexApiLatest = 2;

		public const int CopyunlockedachievementbyachievementidApiLatest = 1;

		public const int CopyunlockedachievementbyindexApiLatest = 1;

		public const int DefinitionApiLatest = 1;

		public const int Definitionv2ApiLatest = 2;

		public const int GetachievementdefinitioncountApiLatest = 1;

		public const int GetplayerachievementcountApiLatest = 1;

		public const int GetunlockedachievementcountApiLatest = 1;

		public const int PlayerachievementApiLatest = 2;

		public const int PlayerstatinfoApiLatest = 1;

		public const int QuerydefinitionsApiLatest = 3;

		public const int QueryplayerachievementsApiLatest = 2;

		public const int StatthresholdApiLatest = 1;

		public const int StatthresholdsApiLatest = 1;

		public const int UnlockachievementsApiLatest = 1;

		public const int UnlockedachievementApiLatest = 1;

		public AchievementsInterface()
		{
		}

		public AchievementsInterface(IntPtr innerHandle)
		{
		}

		public ulong AddNotifyAchievementsUnlocked(AddNotifyAchievementsUnlockedOptions options, object clientData, OnAchievementsUnlockedCallback notificationFn)
		{
			return 0uL;
		}

		public ulong AddNotifyAchievementsUnlockedV2(AddNotifyAchievementsUnlockedV2Options options, object clientData, OnAchievementsUnlockedCallbackV2 notificationFn)
		{
			return 0uL;
		}

		public Result CopyAchievementDefinitionByAchievementId(CopyAchievementDefinitionByAchievementIdOptions options, out Definition outDefinition)
		{
			outDefinition = null;
			return default(Result);
		}

		public Result CopyAchievementDefinitionByIndex(CopyAchievementDefinitionByIndexOptions options, out Definition outDefinition)
		{
			outDefinition = null;
			return default(Result);
		}

		public Result CopyAchievementDefinitionV2ByAchievementId(CopyAchievementDefinitionV2ByAchievementIdOptions options, out DefinitionV2 outDefinition)
		{
			outDefinition = null;
			return default(Result);
		}

		public Result CopyAchievementDefinitionV2ByIndex(CopyAchievementDefinitionV2ByIndexOptions options, out DefinitionV2 outDefinition)
		{
			outDefinition = null;
			return default(Result);
		}

		public Result CopyPlayerAchievementByAchievementId(CopyPlayerAchievementByAchievementIdOptions options, out PlayerAchievement outAchievement)
		{
			outAchievement = null;
			return default(Result);
		}

		public Result CopyPlayerAchievementByIndex(CopyPlayerAchievementByIndexOptions options, out PlayerAchievement outAchievement)
		{
			outAchievement = null;
			return default(Result);
		}

		public Result CopyUnlockedAchievementByAchievementId(CopyUnlockedAchievementByAchievementIdOptions options, out UnlockedAchievement outAchievement)
		{
			outAchievement = null;
			return default(Result);
		}

		public Result CopyUnlockedAchievementByIndex(CopyUnlockedAchievementByIndexOptions options, out UnlockedAchievement outAchievement)
		{
			outAchievement = null;
			return default(Result);
		}

		public uint GetAchievementDefinitionCount(GetAchievementDefinitionCountOptions options)
		{
			return 0u;
		}

		public uint GetPlayerAchievementCount(GetPlayerAchievementCountOptions options)
		{
			return 0u;
		}

		public uint GetUnlockedAchievementCount(GetUnlockedAchievementCountOptions options)
		{
			return 0u;
		}

		public void QueryDefinitions(QueryDefinitionsOptions options, object clientData, OnQueryDefinitionsCompleteCallback completionDelegate)
		{
		}

		public void QueryPlayerAchievements(QueryPlayerAchievementsOptions options, object clientData, OnQueryPlayerAchievementsCompleteCallback completionDelegate)
		{
		}

		public void RemoveNotifyAchievementsUnlocked(ulong inId)
		{
		}

		public void UnlockAchievements(UnlockAchievementsOptions options, object clientData, OnUnlockAchievementsCompleteCallback completionDelegate)
		{
		}

		internal static void OnAchievementsUnlockedCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnAchievementsUnlockedCallbackV2InternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryDefinitionsCompleteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryPlayerAchievementsCompleteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnUnlockAchievementsCompleteCallbackInternalImplementation(IntPtr data)
		{
		}

		[PreserveSig]
		internal static extern ulong EOS_Achievements_AddNotifyAchievementsUnlocked(IntPtr handle, IntPtr options, IntPtr clientData, OnAchievementsUnlockedCallbackInternal notificationFn);

		[PreserveSig]
		internal static extern ulong EOS_Achievements_AddNotifyAchievementsUnlockedV2(IntPtr handle, IntPtr options, IntPtr clientData, OnAchievementsUnlockedCallbackV2Internal notificationFn);

		[PreserveSig]
		internal static extern Result EOS_Achievements_CopyAchievementDefinitionByAchievementId(IntPtr handle, IntPtr options, ref IntPtr outDefinition);

		[PreserveSig]
		internal static extern Result EOS_Achievements_CopyAchievementDefinitionByIndex(IntPtr handle, IntPtr options, ref IntPtr outDefinition);

		[PreserveSig]
		internal static extern Result EOS_Achievements_CopyAchievementDefinitionV2ByAchievementId(IntPtr handle, IntPtr options, ref IntPtr outDefinition);

		[PreserveSig]
		internal static extern Result EOS_Achievements_CopyAchievementDefinitionV2ByIndex(IntPtr handle, IntPtr options, ref IntPtr outDefinition);

		[PreserveSig]
		internal static extern Result EOS_Achievements_CopyPlayerAchievementByAchievementId(IntPtr handle, IntPtr options, ref IntPtr outAchievement);

		[PreserveSig]
		internal static extern Result EOS_Achievements_CopyPlayerAchievementByIndex(IntPtr handle, IntPtr options, ref IntPtr outAchievement);

		[PreserveSig]
		internal static extern Result EOS_Achievements_CopyUnlockedAchievementByAchievementId(IntPtr handle, IntPtr options, ref IntPtr outAchievement);

		[PreserveSig]
		internal static extern Result EOS_Achievements_CopyUnlockedAchievementByIndex(IntPtr handle, IntPtr options, ref IntPtr outAchievement);

		[PreserveSig]
		internal static extern uint EOS_Achievements_GetAchievementDefinitionCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern uint EOS_Achievements_GetPlayerAchievementCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern uint EOS_Achievements_GetUnlockedAchievementCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern void EOS_Achievements_QueryDefinitions(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryDefinitionsCompleteCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Achievements_QueryPlayerAchievements(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryPlayerAchievementsCompleteCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Achievements_DefinitionV2_Release(IntPtr achievementDefinition);

		[PreserveSig]
		internal static extern void EOS_Achievements_PlayerAchievement_Release(IntPtr achievement);

		[PreserveSig]
		internal static extern void EOS_Achievements_Definition_Release(IntPtr achievementDefinition);

		[PreserveSig]
		internal static extern void EOS_Achievements_UnlockedAchievement_Release(IntPtr achievement);

		[PreserveSig]
		internal static extern void EOS_Achievements_RemoveNotifyAchievementsUnlocked(IntPtr handle, ulong inId);

		[PreserveSig]
		internal static extern void EOS_Achievements_UnlockAchievements(IntPtr handle, IntPtr options, IntPtr clientData, OnUnlockAchievementsCompleteCallbackInternal completionDelegate);
	}
}
