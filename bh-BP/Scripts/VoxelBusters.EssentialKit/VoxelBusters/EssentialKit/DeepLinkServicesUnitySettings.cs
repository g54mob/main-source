using System;
using System.Collections.Generic;
using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class DeepLinkServicesUnitySettings : SettingsPropertyGroup
	{
		[Serializable]
		public class AndroidPlatformProperties
		{
			[SerializeField]
			private List<DeepLinkDefinition> m_customSchemeUrls;

			[SerializeField]
			[Tooltip("Universal links are termed as App Links on Android")]
			private List<DeepLinkDefinition> m_universalLinks;

			public DeepLinkDefinition[] CustomSchemeUrls => null;

			public DeepLinkDefinition[] UniversalLinks => null;

			public AndroidPlatformProperties(DeepLinkDefinition[] customSchemeUrls = null, DeepLinkDefinition[] universalLinks = null)
			{
			}

			public void AddCustomSchemeUrl(DeepLinkDefinition definition)
			{
			}

			public void AddUniversalLink(DeepLinkDefinition definition)
			{
			}
		}

		[Serializable]
		public class IosPlatformProperties
		{
			[SerializeField]
			private List<DeepLinkDefinition> m_customSchemeUrls;

			[SerializeField]
			private List<DeepLinkDefinition> m_universalLinks;

			public DeepLinkDefinition[] CustomSchemeUrls => null;

			public DeepLinkDefinition[] UniversalLinks => null;

			public IosPlatformProperties(DeepLinkDefinition[] customSchemeUrls = null, DeepLinkDefinition[] universalLinks = null)
			{
			}

			public void AddCustomSchemeUrl(DeepLinkDefinition definition)
			{
			}

			public void AddUniversalLink(DeepLinkDefinition definition)
			{
			}
		}

		[SerializeField]
		private IosPlatformProperties m_iosProperties;

		[SerializeField]
		private AndroidPlatformProperties m_androidProperties;

		public IosPlatformProperties IosProperties => null;

		public AndroidPlatformProperties AndroidProperties => null;

		public DeepLinkServicesUnitySettings(bool isEnabled = true, IosPlatformProperties iosProperties = null, AndroidPlatformProperties androidProperties = null)
			: base(null, isEnabled: false)
		{
		}

		private static int FindDeepLinkIndexWithIdentifier(List<DeepLinkDefinition> list, string identifier)
		{
			return 0;
		}

		private static void AddDeepLinkDefinition(List<DeepLinkDefinition> list, DeepLinkDefinition deepLinkSettings)
		{
		}

		public DeepLinkDefinition[] GetCustomSchemeUrlsForPlatform(NativePlatform platform)
		{
			return null;
		}

		public DeepLinkDefinition[] GetUniversalLinksForPlatform(NativePlatform platform)
		{
			return null;
		}

		public void AddCustomSchemeUrl(DeepLinkDefinition definition, NativePlatform platform)
		{
		}

		public void AddUniversalLink(DeepLinkDefinition definition, NativePlatform platform)
		{
		}
	}
}
