using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class OpenDialogueRequirementNode : RequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllDialogIds")]
		public string dialogId;

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
