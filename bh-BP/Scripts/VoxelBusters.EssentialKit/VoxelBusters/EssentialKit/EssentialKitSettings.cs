using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit
{
	public class EssentialKitSettings : SettingsObject
	{
		[ClearOnReload]
		private static EssentialKitSettings s_sharedInstance;

		[ClearOnReload]
		private static UnityPackageDefinition s_package;

		[SerializeField]
		private ApplicationSettings m_applicationSettings;

		[SerializeField]
		private AddressBookUnitySettings m_addressBookSettings;

		[SerializeField]
		private AppUpdaterUnitySettings m_appUpdaterSettings;

		[SerializeField]
		private AppShortcutsUnitySettings m_appShortcutsSettings;

		[SerializeField]
		private NativeUIUnitySettings m_nativeUISettings;

		[SerializeField]
		private SharingServicesUnitySettings m_sharingServicesSettings;

		[SerializeField]
		private CloudServicesUnitySettings m_cloudServicesSettings;

		[SerializeField]
		private GameServicesUnitySettings m_gameServicesSettings;

		[SerializeField]
		private BillingServicesUnitySettings m_billingServicesSettings;

		[SerializeField]
		private NetworkServicesUnitySettings m_networkServicesSettings;

		[SerializeField]
		private NotificationServicesUnitySettings m_notificationServicesSettings;

		[SerializeField]
		private MediaServicesUnitySettings m_mediaServicesSettings;

		[SerializeField]
		private DeepLinkServicesUnitySettings m_deepLinkServicesSettings;

		[SerializeField]
		private RateMyAppUnitySettings m_rateMyAppSettings;

		[SerializeField]
		private TaskServicesUnitySettings m_taskServicesSettings;

		[SerializeField]
		private UtilityUnitySettings m_utilitySettings;

		[SerializeField]
		private WebViewUnitySettings m_webViewSettings;

		internal static UnityPackageDefinition Package => null;

		public static string PackageName => null;

		public static string DisplayName => null;

		public static string Version => null;

		public static string DefaultSettingsAssetName => null;

		public static string DefaultSettingsAssetPath => null;

		public static string PersistentDataPath => null;

		public static EssentialKitSettings Instance => null;

		public ApplicationSettings ApplicationSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AddressBookUnitySettings AddressBookSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AppShortcutsUnitySettings AppShortcutsSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AppUpdaterUnitySettings AppUpdaterSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public TaskServicesUnitySettings TaskServicesSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public NativeUIUnitySettings NativeUISettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SharingServicesUnitySettings SharingServicesSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CloudServicesUnitySettings CloudServicesSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public GameServicesUnitySettings GameServicesSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BillingServicesUnitySettings BillingServicesSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public NetworkServicesUnitySettings NetworkServicesSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public WebViewUnitySettings WebViewSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public NotificationServicesUnitySettings NotificationServicesSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public MediaServicesUnitySettings MediaServicesSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DeepLinkServicesUnitySettings DeepLinkServicesSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public UtilityUnitySettings UtilitySettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public RateMyAppUnitySettings RateMyAppSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static void SetSettings(EssentialKitSettings settings)
		{
		}

		private static EssentialKitSettings GetSharedInstanceInternal(bool throwError = true)
		{
			return null;
		}

		protected override void UpdateLoggerSettings()
		{
		}

		protected override void OnValidate()
		{
		}

		private string[] GetAvailableFeatureNames()
		{
			return null;
		}

		private string[] GetUsedFeatureNames()
		{
			return null;
		}

		private bool IsPlatformTarget(NativePlatform nativePlatform)
		{
			return false;
		}

		private void InitialiseFeatureIfRequired(string feature, Action initialiseAction)
		{
		}

		private void SyncSettings()
		{
		}

		public void InitialiseFeatures()
		{
		}

		public bool IsFeatureUsed(string name)
		{
			return false;
		}
	}
}
