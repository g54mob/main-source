using System;
using System.Text;
using Heathen.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

namespace Heathen.SteamworksIntegration
{
	public class LeaderboardEntry
	{
		public LeaderboardEntry_t entry;

		public int[] details;

		public string cashedUgcFileName = string.Empty;

		public UnityEvent<string> evtUgcDownloaded = new UnityEvent<string>();

		public UserData User => entry.m_steamIDUser;

		public int Rank => entry.m_nGlobalRank;

		public int Score => entry.m_nScore;

		public UGCHandle_t UgcHandle => entry.m_hUGC;

		public int this[int index] => details[index];

		public bool HasCashedUgcFileName => !string.IsNullOrEmpty(cashedUgcFileName);

		public void GetAttachedUgc<T>(Action<T, bool> callback = null)
		{
			if (UgcHandle == UGCHandle_t.Invalid)
			{
				callback?.Invoke(default(T), arg2: true);
				return;
			}
			RemoteStorage.Client.UGCDownload(UgcHandle, 0u, delegate(RemoteStorageDownloadUGCResult_t dr, bool de)
			{
				if (!de && dr.m_eResult == EResult.k_EResultOK)
				{
					cashedUgcFileName = dr.m_pchFileName;
					evtUgcDownloaded.Invoke(dr.m_pchFileName);
					if (callback != null)
					{
						byte[] bytes = RemoteStorage.Client.UGCRead(dr.m_hFile);
						T arg = JsonUtility.FromJson<T>(Encoding.UTF8.GetString(bytes));
						callback(arg, arg2: false);
					}
				}
				else
				{
					cashedUgcFileName = string.Empty;
					evtUgcDownloaded.Invoke(null);
					callback?.Invoke(default(T), arg2: true);
				}
			});
		}

		public bool StartUgcDownload(uint priority = 0u)
		{
			if (UgcHandle != UGCHandle_t.Invalid)
			{
				RemoteStorage.Client.UGCDownload(UgcHandle, priority, HandleUgcDownloadResult);
				return true;
			}
			return false;
		}

		public bool StartUgcDownload(uint priority, Action<RemoteStorageDownloadUGCResult_t, bool> callback)
		{
			if (UgcHandle != UGCHandle_t.Invalid)
			{
				RemoteStorage.Client.UGCDownload(UgcHandle, priority, delegate(RemoteStorageDownloadUGCResult_t p, bool e)
				{
					HandleUgcDownloadResult(p, e);
					if (callback != null)
					{
						callback(p, e);
					}
				});
				return true;
			}
			return false;
		}

		public float UgcDownloadProgress()
		{
			SteamRemoteStorage.GetUGCDownloadProgress(UgcHandle, out var pnBytesDownloaded, out var pnBytesExpected);
			return (float)pnBytesDownloaded / (float)pnBytesExpected;
		}

		private void HandleUgcDownloadResult(RemoteStorageDownloadUGCResult_t param, bool bIOFailure)
		{
			if (!bIOFailure && param.m_eResult == EResult.k_EResultOK)
			{
				cashedUgcFileName = param.m_pchFileName;
				evtUgcDownloaded.Invoke(param.m_pchFileName);
			}
			else
			{
				cashedUgcFileName = string.Empty;
				evtUgcDownloaded.Invoke(null);
			}
		}
	}
}
