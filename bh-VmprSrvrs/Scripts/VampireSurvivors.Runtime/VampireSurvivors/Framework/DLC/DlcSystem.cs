using System;
using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.DLC
{
	public static class DlcSystem
	{
		private static DlcCatalog _dlcCatalog;

		public static bool _initialised;

		private static LicenseManager _licenseManager;

		private static LoadingManager _loadingManager;

		private static UpdateManager _updateManager;

		private static DlcUtils _utils;

		private const string DlcDownloadPopupId = "download-dlc";

		private const string DlcErrorPopupId = "error-dlc";

		private const string SelectedDlcKey = "selecteddlc";

		private static DLCSelection _dlcSelection;

		public static List<DlcType> OnlineAvaliableDlcTypes;

		public const string PreviouslyExitedUnsafelyKey = "PREVIOUSLYEXITEDUNSAFELY";

		public const string PERSISTENT_TAG = "persistent";

		public const string DYNAMIC_TAG = "dynamic";

		public const string LOCAL_GROUP = "vs_local";

		public static DlcCatalog DlcCatalog => null;

		public static DlcUtils Utils => null;

		public static List<DlcType> OwnedDlc => null;

		public static List<DlcType> IncludedDlc => null;

		public static SelectedDLCDictionary SelectedDlc => null;

		public static Dictionary<DlcType, BundleManifestData> LoadedDlc => null;

		public static Dictionary<DlcType, string> MountedPaths => null;

		public static void Init(DlcCatalog catalog)
		{
		}

		public static void SaveDlcSelection()
		{
		}

		public static void LicenseCheckDlc(Action callback)
		{
		}

		public static void UpdateDlc(Action callback)
		{
		}

		public static void LoadDlc(Action callback)
		{
		}

		public static void MountDlc(DlcType dlcType, Action callback)
		{
		}

		public static bool IsFreeDlcActivated(DlcType dlcType)
		{
			return false;
		}

		public static void SetFreeDlcActivated(DlcType dlcType, bool activated = true)
		{
		}

		public static List<DlcType> GetMissingDlc()
		{
			return null;
		}

		public static List<DlcType> GetDlcTypesToLoad()
		{
			return null;
		}

		public static void ReleaseGameplayDlc()
		{
		}

		public static void Reset(Action callback)
		{
		}

		public static void ShowDlcDownload(DlcType dlcType)
		{
		}

		public static void UpdateDlcDownloadProgressText(DlcType dlcType, string progressPercentage)
		{
		}

		public static void HideDlcDownload()
		{
		}

		public static void ShowDlcDownloadError(DlcType dlcType, Action onRetry, Action onContinue, string info = "")
		{
		}

		public static void PrepareBgmLoad(BgmType bgmType)
		{
		}

		public static void OpenDLCLink()
		{
		}

		public static void Log(string message)
		{
		}
	}
}
