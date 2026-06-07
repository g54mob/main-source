using UnityEngine;

namespace Gh.Tk.Story.Requirements
{
	public class OwnPercentageOfTavernRequirementNode : RoomUnlockRequirementBaseNode
	{
		[Range(0f, 100f)]
		public int targetPercentage;

		public override string GetLabelKey(ActiveStory story)
		{
			return null;
		}

		public override int GetMaxPips(ActiveStory story)
		{
			return 0;
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}

		public override float GetFilledPips(ActiveStory story)
		{
			return 0f;
		}
	}
}
