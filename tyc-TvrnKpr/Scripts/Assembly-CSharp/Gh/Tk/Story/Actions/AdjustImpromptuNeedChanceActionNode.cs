using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class AdjustImpromptuNeedChanceActionNode : ConnectedStoryNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllPatronNeedTypes")]
		public string needType;

		[Range(0f, 100f)]
		public int percentage;

		[Tooltip("If true, percentage will be used as chance, if false (default) as modifier")]
		public bool forcePercentage;

		public int durationInHours;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
