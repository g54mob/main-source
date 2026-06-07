using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class PlacePropRequirementNode : RequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllPropOptions")]
		public string prop;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void OnPropBuilt(Prop value, ActiveStory story)
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
