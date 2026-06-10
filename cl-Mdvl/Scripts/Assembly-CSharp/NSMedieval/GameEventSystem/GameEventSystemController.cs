using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.EventBase;
using NSMedieval.Manager;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	public class GameEventSystemController : MonoSingleton<GameEventSystemController>
	{
		public delegate void RaidStartedDelegate(bool isSiege, List<IEnemyPurchaseUnit> enemies, string settingsCategory, int raidId);

		public delegate void OptionChosenDelegate(GameEventInstance eventInstance, int dialogShowingIndex);

		public event Action<GameEventInstance> GameEventStarted;

		public event Action<GameEventInstance> GameEventEnded;

		public event OptionChosenDelegate GameEventOptionChosen;

		public event Action<ActiveRaidInfo> RaidEventEnded;

		public event RaidStartedDelegate RaidEventStarted;

		public event Action<EventBaseModel> GameEventUnlockedEvent;

		public event Action<string> NpcArrivedToEventEvent;

		public void RaidStarted(bool isSiege, List<IEnemyPurchaseUnit> enemies, string settingsCategory, int raidId)
		{
			this.RaidEventStarted?.Invoke(isSiege, enemies, settingsCategory, raidId);
		}

		public void RaidEnded(ActiveRaidInfo info)
		{
			this.RaidEventEnded?.Invoke(info);
		}

		public void EventStarted(GameEventInstance eventInstance)
		{
			this.GameEventStarted?.Invoke(eventInstance);
		}

		public void EventEnded(GameEventInstance eventInstance)
		{
			this.GameEventEnded?.Invoke(eventInstance);
		}

		public void EventOptionChosen(GameEventInstance eventInstance, int dialogShowingIndex)
		{
			this.GameEventOptionChosen?.Invoke(eventInstance, dialogShowingIndex);
		}

		public void GameEventUnlocked(EventBaseModel gameEventUnlocked)
		{
			this.GameEventUnlockedEvent?.Invoke(gameEventUnlocked);
		}

		public void NpcArrivedToEvent(string fromEvent)
		{
			this.NpcArrivedToEventEvent?.Invoke(fromEvent);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.GameEventStarted = null;
			this.GameEventEnded = null;
			this.RaidEventEnded = null;
			this.GameEventUnlockedEvent = null;
			this.GameEventOptionChosen = null;
			this.RaidEventStarted = null;
			this.NpcArrivedToEventEvent = null;
		}
	}
}
