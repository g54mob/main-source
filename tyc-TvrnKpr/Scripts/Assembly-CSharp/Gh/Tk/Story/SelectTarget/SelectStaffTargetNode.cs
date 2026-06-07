using UnityEngine;
using XNode;

namespace Gh.Tk.Story.SelectTarget
{
	[NodeTint("#0094FF")]
	public class SelectStaffTargetNode : ConnectedStoryNode
	{
		[Header("Story staff")]
		[Tooltip("If provided, will select the specific staff")]
		public StaffDataConfig storyStaff;

		[Header("Filter")]
		public StoryStaffConfig filter;

		[Range(10f, 100f)]
		[Tooltip("If set and there are multiple matches, it will reduce the affected number by the desired percentage (as far as practical).")]
		public int maxPercentageAffected;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
