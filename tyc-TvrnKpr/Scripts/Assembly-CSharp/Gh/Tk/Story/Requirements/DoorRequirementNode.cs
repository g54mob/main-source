using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class DoorRequirementNode : RequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllZones")]
		public string zone;

		public bool alsoCountDoorsToTheOutside;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
