using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class NotificationServicesUnitySettings : SettingsPropertyGroup
	{
		[Serializable]
		public class AndroidPlatformProperties
		{
			[Serializable]
			public class Keys
			{
				[SerializeField]
				[DefaultValue("content_title")]
				[Tooltip("The key used to capture content title property from the payload.")]
				private string m_contentTitle;

				[SerializeField]
				[DefaultValue("content_text")]
				[Tooltip("The key used to capture content text property from the payload.")]
				private string m_contentText;

				[SerializeField]
				[DefaultValue("ticker_text")]
				[Tooltip("The key used to capture ticker text property from the payload.")]
				private string m_tickerText;

				[SerializeField]
				[DefaultValue("user_info")]
				[Tooltip("The key used to capture user info dictionary from the payload.")]
				private string m_userInfo;

				[SerializeField]
				[DefaultValue("tag")]
				[Tooltip("The key used to capture tag property from the payload.")]
				private string m_tag;

				[SerializeField]
				[DefaultValue("badge")]
				[Tooltip("The key used to capture badge property from the payload.")]
				private string m_badge;

				[SerializeField]
				[DefaultValue("priority")]
				[Tooltip("The key used to capture priority property from the payload.")]
				private string m_priority;

				[SerializeField]
				[DefaultValue("sound")]
				[Tooltip("The key used to capture sound property from the payload.")]
				private string m_sound;

				[SerializeField]
				[DefaultValue("big_picture")]
				[Tooltip("The key used to capture big picture property from the payload.")]
				private string m_bigPicture;

				[SerializeField]
				[DefaultValue("large_icon")]
				[Tooltip("The key used to capture large icon property from the payload.")]
				private string m_largeIcon;

				public string TickerTextKey => null;

				public string ContentTitleKey => null;

				public string ContentTextKey => null;

				public string UserInfoKey => null;

				public string TagKey => null;

				public string BadgeKey => null;

				public string PriorityKey => null;

				public string SoundFileNameKey => null;

				public string BigPictureKey => null;

				public string LargeIconKey => null;

				public Keys(string tickerText = null, string contentTitle = null, string contentText = null, string userInfo = null, string tag = null, string badge = null, string priority = null, string sound = null, string bigPicture = null, string largeIcon = null)
				{
				}
			}

			[HideInInspector]
			[SerializeField]
			[Tooltip("If enabled, app will use big style notification.")]
			private bool m_needsBigStyle;

			[SerializeField]
			[Tooltip("If enabled, device vibrates on receiving a notification.")]
			private bool m_allowVibration;

			[SerializeField]
			[Tooltip("The texture used as small icon in post Android L Devices.")]
			private Texture2D m_whiteSmallIcon;

			[SerializeField]
			[Tooltip("The texture used as small icon in pre Android L Devices.")]
			private Texture2D m_colouredSmallIcon;

			[SerializeField]
			[Tooltip("If enabled, notifications are displayed even when app is foreground.")]
			private bool m_allowNotificationDisplayWhenForeground;

			[SerializeField]
			[DefaultValue("#FFFFFF")]
			[Tooltip("If set, the value will be used as accent color for notification.")]
			private string m_accentColor;

			[SerializeField]
			[Tooltip("Array of payload keys.")]
			private Keys m_payloadKeys;

			[Space]
			[Header("Advanced Settings")]
			[Space]
			[Header("Exact timing settings - Can affect battery optimisation and focus mode")]
			[SerializeField]
			[Tooltip("Enable if you need notifications at exact time (Make sure your app is eligible for using this feature.). Enabling this will NOT have energy saving capabilities.")]
			private bool m_allowExactTimeScheduling;

			[SerializeField]
			[Tooltip("Enable this if you want exact timing notifications to even ignore doze mode. This may consume user's device battery and not recommended for most apps.")]
			private bool m_canIgnoreDozeMode;

			public bool NeedsBigStyle => false;

			public bool AllowVibration => false;

			public Texture2D WhiteSmallIcon => null;

			public Texture2D ColouredSmallIcon => null;

			public Keys PayloadKeys => null;

			public bool AllowNotificationDisplayWhenForeground => false;

			public string AccentColor => null;

			public bool AllowExactTimeScheduling => false;

			public bool AllowExactTimeSchedulingIgnoringDozeMode => false;

			public AndroidPlatformProperties(bool needsBigStyle = false, bool allowVibration = true, Texture2D whiteSmallIcon = null, Texture2D colouredSmallIcon = null, bool allowNotificationDisplayWhenForeground = false, string accentColor = null, Keys payloadKeys = null, bool allowExactTimeScheduling = false, bool canIgnoreDozeMode = false)
			{
			}
		}

		[SerializeField]
		[EnumMaskField(typeof(NotificationPresentationOptions))]
		[Tooltip("Notification display options.")]
		private NotificationPresentationOptions m_presentationOptions;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, permission required to use location based notification will be added.")]
		private bool m_usesLocationBasedNotification;

		[SerializeField]
		[Tooltip("External notification service used within the app.")]
		private PushNotificationServiceType m_pushNotificationServiceType;

		[SerializeField]
		[Tooltip("Android specific properties.")]
		private AndroidPlatformProperties m_androidProperties;

		public NotificationPresentationOptions PresentationOptions => default(NotificationPresentationOptions);

		public bool UsesLocationBasedNotification => false;

		public PushNotificationServiceType PushNotificationServiceType => default(PushNotificationServiceType);

		public AndroidPlatformProperties AndroidProperties => null;

		public NotificationServicesUnitySettings(bool isEnabled = true, NotificationPresentationOptions presentationOptions = NotificationPresentationOptions.Alert | NotificationPresentationOptions.Badge | NotificationPresentationOptions.Sound, bool usesLocationBasedNotification = false, PushNotificationServiceType pushNotificationServiceType = PushNotificationServiceType.Custom, AndroidPlatformProperties androidProperties = null)
			: base(null, isEnabled: false)
		{
		}
	}
}
