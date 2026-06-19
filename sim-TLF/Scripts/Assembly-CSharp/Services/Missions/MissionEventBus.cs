using System;

namespace Services.Missions
{
	public class MissionEventBus
	{
		public event Action<string, string, int> OnGameEvent;

		public void Emit(string eventType, string targetId, int amount = 1)
		{
			this.OnGameEvent?.Invoke(eventType, targetId, amount);
		}
	}
}
