using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class PatronInTavernCountRequirementNode : RequirementNode
	{
		public int targetValue;

		public bool ignoreSleepingPatrons;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void ActivePatronsChanged(object sender, EventArgs<Actor> e)
		{
		}

		private static void InvalidateAll()
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
