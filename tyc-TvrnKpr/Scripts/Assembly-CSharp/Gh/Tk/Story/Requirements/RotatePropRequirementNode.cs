using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class RotatePropRequirementNode : RequirementNode
	{
		public int numberOfRotations;

		private string StoryKey => null;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void IncreaseRotationCount(ActiveStory story)
		{
		}

		public override int GetMaxPips(ActiveStory story)
		{
			return 0;
		}

		public override float GetFilledPips(ActiveStory story)
		{
			return 0f;
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
