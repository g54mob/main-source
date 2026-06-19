using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public interface IOnlineManager
	{
		OnlineManager.Config Config { get; set; }

		DataFileCache DataFiles { get; }

		Action<bool> OnServerConnectionChanged { get; set; }

		bool IsInitialized();

		bool IsLoggedOn();

		bool IsConnected();

		bool MustBeLoggedOn();

		void StartLogOn();

		void Initialise();

		void Update();

		void Destroy();

		Sprite GetAvatar(OnlinePlayerID playerID);

		void ShowUserProfile(OnlinePlayerID targetPlayerID);

		void SetAssetIDs(BiDictionary<int, object> AssetIDs);

		void InitDataFileCache();

		IEnumerator RequestPlayerInfo(List<OnlinePlayerID> playerID);

		OnlinePlayerID GetLocalPlayerID();

		uint GetServerTime();

		void UpdateRichPresenceLevelData(in RichPresenceLevelData data);

		void ClearRichPresenceLevelData();

		void SetGameMode(GameMode gameMode);

		void UpdateRichPresenceDisplayValue();

		void OnApplicationFocus(bool focus);
	}
}
