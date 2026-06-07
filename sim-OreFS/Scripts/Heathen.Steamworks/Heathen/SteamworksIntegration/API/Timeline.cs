using Steamworks;

namespace Heathen.SteamworksIntegration.API
{
	public static class Timeline
	{
		public enum EventClipPriority
		{
			Invalid = 0,
			None = 1,
			Standard = 2,
			Featured = 3
		}

		public enum GameMode
		{
			Invalid = 0,
			Playing = 1,
			Staging = 2,
			Menus = 3,
			LoadingScreen = 4,
			Max = 5
		}

		public static class Client
		{
			public static void SetStateDescription(string description, float deltaTime)
			{
				SteamTimeline.SetTimelineStateDescription(description, deltaTime);
			}

			public static void ClearStateDescription(float deltaTime)
			{
				SteamTimeline.ClearTimelineStateDescription(deltaTime);
			}

			public static void AddEvent(string iconName, string eventTitle, string eventDescription, uint priority, float deltaTime, float duration, EventClipPriority possibleClip)
			{
				SteamTimeline.AddTimelineEvent(iconName, eventTitle, eventDescription, priority, deltaTime, duration, (ETimelineEventClipPriority)possibleClip);
			}

			public static void SetGameMode(GameMode mode)
			{
				SteamTimeline.SetTimelineGameMode((ETimelineGameMode)mode);
			}
		}
	}
}
