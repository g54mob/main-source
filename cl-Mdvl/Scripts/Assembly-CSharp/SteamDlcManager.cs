using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval;
using Steamworks;
using UnityEngine;

[DisallowMultipleComponent]
public class SteamDlcManager : MonoSingleton<SteamDlcManager>
{
	private const uint SupporterPackDlcId = 4400170u;

	private readonly Dictionary<uint, Action<uint>> dlcDictionary = new Dictionary<uint, Action<uint>>();

	private void Start()
	{
		dlcDictionary.Add(4400170u, UnlockChessPieces);
		if (SteamSdkManager.IsSteamInitialised)
		{
			CheckDLCs();
			CheckEarlyAccess();
		}
	}

	private void CheckEarlyAccess()
	{
		if (MonoSingleton<GlobalSaveController>.Instance.UserDataInfo.IsEarlyBird || !SteamSdkManager.IsSteamInitialised)
		{
			return;
		}
		uint earliestPurchaseUnixTime = SteamApps.GetEarliestPurchaseUnixTime(SteamUtils.GetAppID());
		if (earliestPurchaseUnixTime != 0)
		{
			DateTime dateTime = new DateTime(2026, 3, 17);
			if (DateTimeOffset.FromUnixTimeSeconds(earliestPurchaseUnixTime).LocalDateTime < dateTime)
			{
				MonoSingleton<GlobalSaveController>.Instance.SetIsEarlyBird(isEarlyBird: true);
				MonoSingleton<GlobalSaveController>.Instance.SerializeUserData();
			}
		}
	}

	private void CheckDLCs()
	{
		foreach (KeyValuePair<uint, Action<uint>> item in dlcDictionary)
		{
			item.Value(item.Key);
		}
	}

	private void UnlockChessPieces(uint dlcId)
	{
		if (SteamApps.BIsDlcInstalled(new AppId_t(dlcId)))
		{
			string[] chessPieces = LockedBuildingsManager.ChessPieces;
			foreach (string id in chessPieces)
			{
				MonoSingleton<GlobalSaveController>.Instance.RemoveFromLockedBuildings(id);
			}
			MonoSingleton<GlobalSaveController>.Instance.SerializeUserData();
		}
	}
}
