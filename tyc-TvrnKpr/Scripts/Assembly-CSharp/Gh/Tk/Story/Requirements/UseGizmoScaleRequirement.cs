using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class UseGizmoScaleRequirement : TimedRequirementNodeBase
	{
		private bool _gizmoChanged;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		protected override bool IsRequirementMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
