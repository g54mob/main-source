using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public abstract class SelectedObjectRequirementBase : RequirementNode
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		protected abstract void OnSelectedObjectChanged(ISelectable selectable, ActiveStory story);
	}
}
