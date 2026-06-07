using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class EnsureMinimumRandomEventCooldownActionNode : ConnectedStoryNode
	{
		[Tooltip("Makes sure random events are on cooldown for at least the specified days")]
		public float cooldownInDays;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
