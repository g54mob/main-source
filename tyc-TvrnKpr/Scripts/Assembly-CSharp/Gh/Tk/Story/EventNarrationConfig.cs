using System;

namespace Gh.Tk.Story
{
	[Serializable]
	public class EventNarrationConfig
	{
		public TavernEventType eventType;

		public bool isChaosEvent;

		public ItemNarrationConfig narration;
	}
}
