using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class DebtFreeRequirement : RequirementNode
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void OnLoansChanged(ActiveStory story)
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
