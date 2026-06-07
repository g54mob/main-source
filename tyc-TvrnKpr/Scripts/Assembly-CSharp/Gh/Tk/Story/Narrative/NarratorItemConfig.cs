using System;

namespace Gh.Tk.Story.Narrative
{
	[Serializable]
	public struct NarratorItemConfig
	{
		public NarrationType type;

		public AdvisorState state;

		public string text;

		public bool isAutoSkipped;

		public float delayInSeconds;

		public bool useUnscaledTime;
	}
}
