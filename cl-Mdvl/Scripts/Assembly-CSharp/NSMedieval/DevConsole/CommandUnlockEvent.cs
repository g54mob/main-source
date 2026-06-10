using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.EventBase;
using NSMedieval.GameEventSystem;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Repository;

namespace NSMedieval.DevConsole
{
	public class CommandUnlockEvent : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandUnlockEvent()
		{
			Command = "unlockEvent";
			Description = "Unlocks the given game event type or player triggered event type.";
			Help = "Usage: unlockEvent <eventId:string>.";
		}

		private static string GetAvailableEventsString()
		{
			string text = string.Join(", ", (from ge in Repository<GameEventSettingsRepository, GameEvent>.Instance.GetAllItems()
				where ge.Lockable
				select ge).ToList().ConvertAll((GameEvent e) => (!e.IsLocked()) ? (e.GetID() + " [unlocked]") : e.GetID()));
			string text2 = string.Join(", ", (from ge in Repository<PlayerTriggeredEventRepository, PlayerTriggeredEvent>.Instance.GetAllItems()
				where ge.Lockable
				select ge).ToList().ConvertAll((PlayerTriggeredEvent e) => (!e.IsLocked()) ? (e.GetID() + " [unlocked]") : e.GetID()));
			return "Game events: " + text + "\nPlayer triggered events: " + text2;
		}

		private void CommandMethod()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(Help + "\nAvailable lockable game events:\n" + GetAvailableEventsString());
		}

		private void CommandMethod(string eventId)
		{
			EventBaseModel byID = Repository<GameEventSettingsRepository, GameEvent>.Instance.GetByID(eventId);
			if (byID == null)
			{
				byID = Repository<PlayerTriggeredEventRepository, PlayerTriggeredEvent>.Instance.GetByID(eventId);
			}
			if (byID == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Event with id " + eventId + " not found in GameEventSettingsRepository.json nor in PlayerTriggeredEvent.json\nAvailable lockable events:\n" + GetAvailableEventsString());
				return;
			}
			string result = (byID.Unlock() ? ("Unlocked event " + eventId) : ("Didn't unlock event " + eventId + " - " + (byID.Lockable ? "already unlocked" : "GameEvent is not lockable") + "."));
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}
	}
}
