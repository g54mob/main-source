using System;
using ModIO;

namespace ModIOBrowser
{
	internal static class Mods
	{
		private static ModId lastRatedMod;

		private static ModRating lastRatingType;

		public static ProgressHandle CurrentModManagementOperationHandle;

		public static ModManagementEventDelegate OnModManagementEvent;

		internal static void SubscribeToEvent(ModProfile profile, Action callback = null)
		{
		}

		public static void UnsubscribeFromEvent(ModProfile profile, Action callback = null)
		{
		}

		public static void RateEvent(ModId modId, ModRating rating, Action callback = null)
		{
		}

		public static void ModManagementEvent(ModManagementEventType type, ModId id, Result eventResult)
		{
		}

		internal static void UpdateProgressState()
		{
		}

		private static void UpdateProgressStateInternal(ProgressHandle handle)
		{
		}
	}
}
