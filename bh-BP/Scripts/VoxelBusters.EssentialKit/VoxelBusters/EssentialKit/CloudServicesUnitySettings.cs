using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class CloudServicesUnitySettings : SettingsPropertyGroup
	{
		[Serializable]
		public class AndroidPlatformProperties
		{
			[SerializeField]
			[ReadOnly("On Android, both Cloud Services and Game Services internally use Google Play Services. So, setting play services application id in Game Services settings will get reflected here.")]
			[Tooltip("Your application id in Google Play services. Set this value in Game Services settings -> Android Properties -> Play Services Application Id.")]
			private string m_playServicesApplicationId;

			public string PlayServicesApplicationId
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public AndroidPlatformProperties(string playServicesApplicationId = null)
			{
			}
		}

		[Serializable]
		public class IosPlatformProperties
		{
			[SerializeField]
			[Tooltip("Enable this if you want to replace the entitlement identifiers with absolute values.")]
			private bool m_substituteEntitlementIdentifiers;

			public bool SubstituteEntitlementIdentifiers
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public IosPlatformProperties(bool substituteEntitlementIdentifiers = false)
			{
			}
		}

		[SerializeField]
		[Tooltip("iOS specific settings.")]
		private IosPlatformProperties m_iosProperties;

		[SerializeField]
		[Tooltip("Android specific settings.")]
		private AndroidPlatformProperties m_androidProperties;

		public IosPlatformProperties IosProperties => null;

		public AndroidPlatformProperties AndroidProperties => null;

		public CloudServicesUnitySettings(bool isEnabled = true, IosPlatformProperties iosProperties = null, AndroidPlatformProperties androidProperties = null)
			: base(null, isEnabled: false)
		{
		}
	}
}
