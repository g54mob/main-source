using System.Collections.Generic;

namespace TH20
{
	public static class GameEventsRegistry
	{
		private static List<IGameEventsBase> _globalEvents = new List<IGameEventsBase>();

		private static List<IGameEventsBase> _levelEvents = new List<IGameEventsBase>();

		public static void RegisterGlobalEvent(IGameEventsBase gameEvent)
		{
			_globalEvents.Add(gameEvent);
		}

		public static void RegisterLevelEvent(IGameEventsBase gameEvent)
		{
			_levelEvents.Add(gameEvent);
		}

		public static void VerifyAndClearGlobalEvents()
		{
			VerifyAndClearEvents(ref _globalEvents);
		}

		public static void VerifyAndClearLevelEvents()
		{
			VerifyAndClearEvents(ref _levelEvents);
		}

		private static void VerifyAndClearEvents(ref List<IGameEventsBase> events)
		{
			ActionExtension.VerifyCallValid = true;
			foreach (IGameEventsBase @event in events)
			{
				@event.VerifyEvents();
			}
			events.Clear();
			ActionExtension.VerifyCallValid = false;
		}
	}
}
