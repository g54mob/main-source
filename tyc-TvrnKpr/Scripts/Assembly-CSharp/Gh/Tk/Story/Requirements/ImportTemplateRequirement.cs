using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class ImportTemplateRequirement : RequirementNode
	{
		public string ExpectedShareCode;

		private static string Key;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void ImportTemplateHappened(object source, EventArgs<string> eventArgs)
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
