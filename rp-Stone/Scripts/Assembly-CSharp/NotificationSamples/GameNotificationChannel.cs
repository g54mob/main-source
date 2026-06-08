using System.Linq;

namespace NotificationSamples
{
	public struct GameNotificationChannel
	{
		public enum NotificationStyle
		{
			None = 0,
			NoSound = 2,
			Default = 3,
			Popup = 4
		}

		public enum PrivacyMode
		{
			Secret = -1,
			Private = 0,
			Public = 1
		}

		public readonly string Id;

		public readonly string Name;

		public readonly string Description;

		public readonly bool ShowsBadge;

		public readonly bool ShowLights;

		public readonly bool Vibrates;

		public readonly bool HighPriority;

		public readonly NotificationStyle Style;

		public readonly PrivacyMode Privacy;

		public readonly int[] VibrationPattern;

		public GameNotificationChannel(string id, string name, string description)
		{
			this = default(GameNotificationChannel);
			Id = id;
			Name = name;
			Description = description;
			ShowsBadge = true;
			ShowLights = false;
			Vibrates = true;
			HighPriority = false;
			Style = NotificationStyle.Popup;
			Privacy = PrivacyMode.Public;
			VibrationPattern = null;
		}

		public GameNotificationChannel(string id, string name, string description, NotificationStyle style, bool showsBadge = true, bool showLights = false, bool vibrates = true, bool highPriority = false, PrivacyMode privacy = PrivacyMode.Public, long[] vibrationPattern = null)
		{
			Id = id;
			Name = name;
			Description = description;
			ShowsBadge = showsBadge;
			ShowLights = showLights;
			Vibrates = vibrates;
			HighPriority = highPriority;
			Style = style;
			Privacy = privacy;
			if (vibrationPattern != null)
			{
				VibrationPattern = vibrationPattern.Select((long v) => (int)v).ToArray();
			}
			else
			{
				VibrationPattern = null;
			}
		}
	}
}
