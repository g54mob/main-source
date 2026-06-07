using System;
using System.IO;
using Steamworks;
using UnityEngine;

namespace Heathen.SteamworksIntegration
{
	[HelpURL("https://kb.heathen.group/assets/steamworks/downloadable-content-object")]
	[CreateAssetMenu(menuName = "Steamworks/Downloadable Content Object")]
	public class DownloadableContentObject : ScriptableObject
	{
		[SerializeField]
		public DlcData data;

		public string Name => data.Name;

		public bool Available => data.Available;

		public bool IsSubscribed => data.IsSubscribed;

		public bool IsInstalled => data.IsInstalled;

		public DirectoryInfo GetInstallDirectory()
		{
			return data.InstallDirectory;
		}

		public float GetDownloadProgress()
		{
			return data.DownloadProgress;
		}

		public DateTime GetEarliestPurchaseTime()
		{
			return data.EarliestPurchaseTime;
		}

		public void Install()
		{
			data.Install();
		}

		public void Uninstall()
		{
			data.Uninstall();
		}

		public void OpenStore(EOverlayToStoreFlag flag = EOverlayToStoreFlag.k_EOverlayToStoreFlag_None)
		{
			data.OpenStore(flag);
		}

		public override string ToString()
		{
			return Name + ":" + data.ToString();
		}
	}
}
