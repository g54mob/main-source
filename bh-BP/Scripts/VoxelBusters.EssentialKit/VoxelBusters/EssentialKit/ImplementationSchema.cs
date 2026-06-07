using System.Collections.Generic;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit
{
	internal static class ImplementationSchema
	{
		private static Dictionary<string, NativeFeatureRuntimeConfiguration> s_configurationMap;

		public static NativeFeatureRuntimeConfiguration AddressBook => null;

		public static NativeFeatureRuntimeConfiguration AppShortcuts => null;

		public static NativeFeatureRuntimeConfiguration AppUpdater => null;

		public static NativeFeatureRuntimeConfiguration BillingServices => null;

		public static NativeFeatureRuntimeConfiguration CloudServices => null;

		public static NativeFeatureRuntimeConfiguration GameServices => null;

		public static NativeFeatureRuntimeConfiguration MediaServices => null;

		public static NativeFeatureRuntimeConfiguration NativeUI => null;

		public static NativeFeatureRuntimeConfiguration NetworkServices => null;

		public static NativeFeatureRuntimeConfiguration NotificationServices => null;

		public static NativeFeatureRuntimeConfiguration SharingServices => null;

		public static NativeFeatureRuntimeConfiguration WebView => null;

		public static NativeFeatureRuntimeConfiguration Extras => null;

		public static NativeFeatureRuntimeConfiguration DeepLinkServices => null;

		public static NativeFeatureRuntimeConfiguration RateMyApp => null;

		public static NativeFeatureRuntimeConfiguration TaskServices => null;

		static ImplementationSchema()
		{
		}

		public static KeyValuePair<string, NativeFeatureRuntimeConfiguration>[] GetAllRuntimeConfigurations(bool includeInactive = true, EssentialKitSettings settings = null)
		{
			return null;
		}

		public static NativeFeatureRuntimeConfiguration GetRuntimeConfiguration(string featureName)
		{
			return null;
		}
	}
}
