using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class WebViewUnitySettings : SettingsPropertyGroup
	{
		[Serializable]
		public class AndroidPlatformProperties
		{
			[SerializeField]
			[Tooltip("Enabling this will allow your app to access camera from webview")]
			private bool m_usesCamera;

			[SerializeField]
			[Tooltip("Enabling this will allow your app to access microphone from webview")]
			private bool m_usesMicrophone;

			[SerializeField]
			[Tooltip("Enabling this will allow you to dismiss webview when back navigation button on the device is pressed")]
			private bool m_allowBackNavigationKey;

			public bool UsesCamera => false;

			public bool UsesMicrophone => false;

			public bool AllowBackNavigationKey => false;

			public AndroidPlatformProperties(bool usesCamera = false, bool usesMicrophone = false, bool allowBackNavigationKey = true)
			{
			}
		}

		[SerializeField]
		[Tooltip("Android specific settings.")]
		private AndroidPlatformProperties m_androidProperties;

		public AndroidPlatformProperties AndroidProperties => null;

		public WebViewUnitySettings(bool isEnabled = true, AndroidPlatformProperties androidProperties = null)
			: base(null, isEnabled: false)
		{
		}
	}
}
