namespace VoxelBusters.EssentialKit
{
	public class NotificationSettingsInternal
	{
		public NotificationPermissionStatus PermissionStatus { get; private set; }

		public NotificationSettingStatus AlertSetting { get; private set; }

		public NotificationSettingStatus BadgeSetting { get; private set; }

		public NotificationSettingStatus CarPlaySetting { get; private set; }

		public NotificationSettingStatus LockScreenSetting { get; private set; }

		public NotificationSettingStatus NotificationCenterSetting { get; private set; }

		public NotificationSettingStatus SoundSetting { get; private set; }

		public NotificationSettingStatus CriticalAlertSetting { get; private set; }

		public NotificationSettingStatus AnnouncementSetting { get; private set; }

		public NotificationAlertStyle AlertStyle { get; private set; }

		public NotificationPreviewStyle PreviewStyle { get; private set; }

		public NotificationSettingStatus ExactTimingSetting { get; private set; }

		internal NotificationSettingsInternal(NotificationPermissionStatus permissionStatus, NotificationSettingStatus alertSetting, NotificationSettingStatus badgeSetting, NotificationSettingStatus carPlaySetting, NotificationSettingStatus lockScreenSetting, NotificationSettingStatus notificationCenterSetting, NotificationSettingStatus soundSetting, NotificationSettingStatus criticalAlertSetting, NotificationSettingStatus announcementSetting, NotificationAlertStyle alertStyle, NotificationPreviewStyle previewStyle, NotificationSettingStatus exactTimingSetting)
		{
		}
	}
}
