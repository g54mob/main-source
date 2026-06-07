using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class DynamicGoldRequirementNode : GoldRequirement
	{
		public string UniqueTargetValueStoryFlagId;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void OnLoansChanged(ActiveStory story)
		{
		}

		protected override int GetEffectiveTargetValue(ActiveStory story)
		{
			return 0;
		}

		private int CalculateIdealTargetMoney(ActiveStory story)
		{
			return 0;
		}

		private int RoundOff(int number, int interval)
		{
			return 0;
		}
	}
}
