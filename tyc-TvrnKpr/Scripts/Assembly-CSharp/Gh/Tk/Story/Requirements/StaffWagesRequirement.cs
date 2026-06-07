using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class StaffWagesRequirement : PipProgressBaseRequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetRaces")]
		public string race;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		public override string GetLabelKey(ActiveStory data)
		{
			return null;
		}

		protected override int GetCurrentValue(ActiveStory story)
		{
			return 0;
		}
	}
}
