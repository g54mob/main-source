using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using Steamworks;

namespace NSMedieval.Modding
{
	public class WorkshopItemVersion
	{
		[Flags]
		private enum EBetaBranch
		{
			None = 0,
			Default = 1,
			Available = 2,
			Private = 4,
			Selected = 8,
			Installed = 0x10
		}

		private readonly Dictionary<PublishedFileId_t, (string, string)> minMaxVersionById = new Dictionary<PublishedFileId_t, (string, string)>();

		private readonly Dictionary<PublishedFileId_t, bool> modsByValidVersion = new Dictionary<PublishedFileId_t, bool>();

		private readonly Dictionary<PublishedFileId_t, string> subscribedModsById = new Dictionary<PublishedFileId_t, string>();

		private readonly Dictionary<string, uint> versionsByName = new Dictionary<string, uint>();

		private uint currentVersion;

		private UGCQueryHandle_t modsHandle;

		private UGCQueryHandle_t versionHandle;

		private CallResult<SteamUGCQueryCompleted_t> modsQueryCallResult;

		private CallResult<SteamUGCQueryCompleted_t> versionQueryCallResult;

		public WorkshopItemVersion()
		{
			MonoSingleton<SteamWorkshopManager>.Instance.OnWorkshopItemsUpdatedEvent += Refresh;
		}

		public (string, string) GetMinMaxVersion(ulong publishedFileId)
		{
			if (minMaxVersionById.TryGetValue((PublishedFileId_t)publishedFileId, out var value))
			{
				return value;
			}
			return (null, null);
		}

		public bool AnyModVersionInvalid()
		{
			foreach (KeyValuePair<PublishedFileId_t, bool> item in modsByValidVersion)
			{
				if (!item.Value && MonoSingleton<ModManager>.Instance.IsWorkshopModEnabled((ulong)item.Key))
				{
					return true;
				}
			}
			return false;
		}

		public bool HasValidVersion(ulong publishedFileId)
		{
			if (modsByValidVersion.TryGetValue((PublishedFileId_t)publishedFileId, out var value))
			{
				return value;
			}
			Log.Error("Invalid published file ID: " + publishedFileId, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\WorkshopItemVersion.cs");
			return false;
		}

		public void Refresh()
		{
			subscribedModsById.Clear();
			versionsByName.Clear();
			GetBetasInfo();
		}

		private void GetBetasInfo()
		{
			SteamApps.GetCurrentBetaName(out var pchName, 100);
			if (string.IsNullOrEmpty(pchName))
			{
				pchName = "public";
			}
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(14, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\WorkshopItemVersion.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral(" Current beta:");
				messageBuilder.AppendFormatted(pchName);
			}
			Log.Debug(messageBuilder);
			int pnAvailable;
			int pnPrivate;
			int numBetas = SteamApps.GetNumBetas(out pnAvailable, out pnPrivate);
			for (int i = 0; i < numBetas; i++)
			{
				SteamApps.GetBetaInfo(i, out var punFlags, out var punBuildID, out var pchBetaName, 128, out var _, 1024);
				if (pchBetaName == pchName)
				{
					currentVersion = punBuildID;
					FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(19, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\WorkshopItemVersion.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral(" Current ");
						messageBuilder2.AppendFormatted(pchName);
						messageBuilder2.AppendLiteral(" build ID:");
						messageBuilder2.AppendFormatted(currentVersion);
					}
					Log.Trace(messageBuilder2);
				}
				EBetaBranch eBetaBranch = (EBetaBranch)punFlags;
				if (!eBetaBranch.HasFlag(EBetaBranch.Private))
				{
					versionsByName[pchBetaName] = punBuildID;
					messageBuilder = new FVLogDebugInterpolationHandler(13, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\WorkshopItemVersion.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral(" ");
						messageBuilder.AppendFormatted(i);
						messageBuilder.AppendLiteral(": ");
						messageBuilder.AppendFormatted(pchBetaName);
						messageBuilder.AppendLiteral(" buildId: ");
						messageBuilder.AppendFormatted(punBuildID);
					}
					Log.Debug(messageBuilder);
				}
			}
			GetSubscribedMods();
		}

		private void GetSubscribedMods()
		{
			modsHandle = SteamUGC.CreateQueryUserUGCRequest(SteamUser.GetSteamID().GetAccountID(), EUserUGCList.k_EUserUGCList_Subscribed, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items, EUserUGCListSortOrder.k_EUserUGCListSortOrder_LastUpdatedDesc, SteamUtils.GetAppID(), SteamUtils.GetAppID(), 1u);
			SteamAPICall_t hAPICall = SteamUGC.SendQueryUGCRequest(modsHandle);
			modsQueryCallResult = CallResult<SteamUGCQueryCompleted_t>.Create(OnUserUGCQueryCompleted);
			modsQueryCallResult.Set(hAPICall);
		}

		private void OnUserUGCQueryCompleted(SteamUGCQueryCompleted_t result, bool ioFailure)
		{
			if (ioFailure || result.m_eResult != EResult.k_EResultOK)
			{
				Log.Error("OnUserUGCQueryCompleted failed", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\WorkshopItemVersion.cs");
				return;
			}
			for (uint num = 0u; num < result.m_unNumResultsReturned; num++)
			{
				if (SteamUGC.GetQueryUGCResult(result.m_handle, num, out var pDetails))
				{
					PublishedFileId_t nPublishedFileId = pDetails.m_nPublishedFileId;
					string rgchTitle = pDetails.m_rgchTitle;
					subscribedModsById[nPublishedFileId] = rgchTitle;
				}
			}
			SteamUGC.ReleaseQueryUGCRequest(result.m_handle);
			UpdateModVersions();
		}

		private void UpdateModVersions()
		{
			versionHandle = SteamUGC.CreateQueryUGCDetailsRequest(subscribedModsById.Keys.ToArray(), (uint)subscribedModsById.Count);
			SteamAPICall_t hAPICall = SteamUGC.SendQueryUGCRequest(versionHandle);
			versionQueryCallResult = CallResult<SteamUGCQueryCompleted_t>.Create(OnVersionUGCQueryCompleted);
			versionQueryCallResult.Set(hAPICall);
		}

		private void OnVersionUGCQueryCompleted(SteamUGCQueryCompleted_t result, bool ioFailure)
		{
			Log.Trace("OnVersionUGCQueryCompleted", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\WorkshopItemVersion.cs");
			if (ioFailure || result.m_eResult != EResult.k_EResultOK)
			{
				Log.Error("OnVersionUGCQueryCompleted failed", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\WorkshopItemVersion.cs");
				return;
			}
			modsByValidVersion.Clear();
			minMaxVersionById.Clear();
			uint unNumResultsReturned = result.m_unNumResultsReturned;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(18, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\WorkshopItemVersion.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral(" ");
				messageBuilder.AppendFormatted(unNumResultsReturned);
				messageBuilder.AppendLiteral(" results returned");
			}
			Log.Debug(messageBuilder);
			for (uint num = 0u; num < unNumResultsReturned; num++)
			{
				if (!SteamUGC.GetQueryUGCResult(result.m_handle, num, out var pDetails))
				{
					continue;
				}
				PublishedFileId_t nPublishedFileId = pDetails.m_nPublishedFileId;
				if (!subscribedModsById.TryGetValue(nPublishedFileId, out var value))
				{
					FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\WorkshopItemVersion.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Could not find mod name for ");
						messageBuilder2.AppendFormatted(nPublishedFileId);
					}
					Log.Error(messageBuilder2);
					continue;
				}
				if (!SteamUGC.GetSupportedGameVersionData(result.m_handle, (ushort)num, 0u, out var pchGameBranchMin, out var pchGameBranchMax, 128u))
				{
					messageBuilder = new FVLogDebugInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\WorkshopItemVersion.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Mod: ");
						messageBuilder.AppendFormatted(value);
						messageBuilder.AppendLiteral(" has no Version set");
					}
					Log.Debug(messageBuilder);
					modsByValidVersion[nPublishedFileId] = false;
					minMaxVersionById[nPublishedFileId] = (string.Empty, string.Empty);
					continue;
				}
				messageBuilder = new FVLogDebugInterpolationHandler(26, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\WorkshopItemVersion.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Mod: ");
					messageBuilder.AppendFormatted(value);
					messageBuilder.AppendLiteral(" Version min: ");
					messageBuilder.AppendFormatted(pchGameBranchMin);
					messageBuilder.AppendLiteral(", max: ");
					messageBuilder.AppendFormatted(pchGameBranchMax);
				}
				Log.Debug(messageBuilder);
				modsByValidVersion[nPublishedFileId] = ValidVersionCheck(pchGameBranchMin, pchGameBranchMax);
				minMaxVersionById[nPublishedFileId] = (pchGameBranchMin, pchGameBranchMax);
			}
			SteamUGC.ReleaseQueryUGCRequest(result.m_handle);
			MonoSingleton<SteamWorkshopManager>.Instance.NotifyVersionUpdate();
		}

		private bool ValidVersionCheck(string branchMin, string branchMax)
		{
			uint num = 0u;
			if (!string.IsNullOrEmpty(branchMin))
			{
				num = versionsByName[branchMin];
			}
			uint num2 = uint.MaxValue;
			if (!string.IsNullOrEmpty(branchMax))
			{
				num2 = versionsByName[branchMax];
			}
			bool flag = currentVersion > num && currentVersion <= num2;
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(27, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\WorkshopItemVersion.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(" - ");
				messageBuilder.AppendFormatted(num2);
				messageBuilder.AppendLiteral(" (current: ");
				messageBuilder.AppendFormatted(currentVersion);
				messageBuilder.AppendLiteral(") is valid: ");
				messageBuilder.AppendFormatted(flag);
				messageBuilder.AppendLiteral(" ");
			}
			Log.Trace(messageBuilder);
			return flag;
		}
	}
}
