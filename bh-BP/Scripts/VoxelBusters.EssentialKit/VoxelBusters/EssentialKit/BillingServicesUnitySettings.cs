using System;
using UnityEngine;
using UnityEngine.Serialization;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class BillingServicesUnitySettings : SettingsPropertyGroup
	{
		[Serializable]
		public class AndroidPlatformProperties
		{
			[SerializeField]
			[Tooltip("Public key provided by Google Play Services for in-app billing.")]
			private string m_publicKey;

			public string PublicKey => null;

			public AndroidPlatformProperties(string publicKey = null)
			{
			}
		}

		[SerializeField]
		[FormerlySerializedAs("m_billingProductMetaArray")]
		[Tooltip("Array contains information of the products used in the app.")]
		private BillingProductDefinition[] m_products;

		[SerializeField]
		[Tooltip("If enabled, completed transactions are removed from queue automatically. Else, you need to call FinishTransactions method manually. This is usually set to off if you have external verification system.")]
		private bool m_autoFinishTransactions;

		[SerializeField]
		[Header("Platform specific")]
		[Tooltip("Android specific properties.")]
		private AndroidPlatformProperties m_androidProperties;

		public BillingProductDefinition[] Products => null;

		public bool AutoFinishTransactions => false;

		public AndroidPlatformProperties AndroidProperties => null;

		public BillingServicesUnitySettings(bool isEnabled = true, BillingProductDefinition[] products = null, bool autoFinishTransactions = true, AndroidPlatformProperties androidProperties = null)
			: base(null, isEnabled: false)
		{
		}
	}
}
