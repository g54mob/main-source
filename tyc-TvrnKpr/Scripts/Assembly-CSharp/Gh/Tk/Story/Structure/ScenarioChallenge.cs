using System;

namespace Gh.Tk.Story.Structure
{
	[Serializable]
	public class ScenarioChallenge
	{
		public string achievementId;

		public TooltipData GetTooltipData()
		{
			return null;
		}

		public bool IsCompleted()
		{
			return false;
		}

		public string GetIconId()
		{
			return null;
		}
	}
}
