using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	[Serializable]
	public class StoryGiverConfig : IPersistable
	{
		public List<string> StoryActivatesWhenPatronUsesProps { get; set; }

		public bool ShowOnSleepingActors { get; set; }

		public string EventLabelKey { get; set; }

		public string EventCameraTextKey { get; set; }

		public string StatusIcon { get; set; }

		public int SourceActiveStoryId { get; set; }

		public bool PauseBeforeTimeout { get; set; }

		public float TimeoutTimeOverride { get; set; }
	}
}
