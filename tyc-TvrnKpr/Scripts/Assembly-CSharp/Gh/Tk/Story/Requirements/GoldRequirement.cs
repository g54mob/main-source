using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class GoldRequirement : PipProgressBaseRequirementNode
	{
		public bool onlyHaveToMeetRequirementOnce;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void OnMoneyChanged(ActiveStory data)
		{
		}

		protected override bool IsMetInternal(ActiveStory data)
		{
			return false;
		}

		public override string GetLabelKey(ActiveStory data)
		{
			return null;
		}

		public override string GetLabelPostfixKey(ActiveStory story)
		{
			return null;
		}

		protected override int GetCurrentValue(ActiveStory story)
		{
			return 0;
		}
	}
}
