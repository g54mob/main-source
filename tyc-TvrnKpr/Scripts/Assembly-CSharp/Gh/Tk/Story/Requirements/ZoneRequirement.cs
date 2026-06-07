using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class ZoneRequirement : RequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllZones")]
		public string zone;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void OnResearchChanged(ActiveStory data)
		{
		}

		public override string GetLabelKey(ActiveStory data)
		{
			return null;
		}

		protected override bool IsMetInternal(ActiveStory data)
		{
			return false;
		}
	}
}
