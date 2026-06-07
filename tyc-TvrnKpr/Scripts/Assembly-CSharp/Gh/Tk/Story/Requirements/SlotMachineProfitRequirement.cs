using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class SlotMachineProfitRequirement : PipProgressBaseRequirementNode
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		private string GetCurrentProfitDataKey()
		{
			return null;
		}

		protected override int GetCurrentValue(ActiveStory story)
		{
			return 0;
		}

		public override string GetLabelKey(ActiveStory data)
		{
			return null;
		}
	}
}
