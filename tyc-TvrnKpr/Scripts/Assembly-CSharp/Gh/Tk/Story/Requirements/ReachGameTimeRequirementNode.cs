using UnityEngine;

namespace Gh.Tk.Story.Requirements
{
	public class ReachGameTimeRequirementNode : RequirementNode
	{
		[Tooltip("If true, then the daysInFuture will be counted from the start of the next day, instead of from now.")]
		public bool countFromNextMidnight;

		public float daysInTheFuture;

		private string TargetTimeKey => null;

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}

		private float GetTargetTime(ActiveStory story)
		{
			return 0f;
		}

		private float SetTargetTime(ActiveStory story)
		{
			return 0f;
		}

		public override string GetLabelPostfixKey(ActiveStory story)
		{
			return null;
		}
	}
}
