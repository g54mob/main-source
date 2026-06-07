using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Actions
{
	[NodeTint("#1B90AD")]
	public class UnlockFeatureNode : ConnectedStoryNode
	{
		[DropDownChoice(typeof(FeatureUnlockKey), "GetAllKeys")]
		public string keyToUnlock;

		[Tooltip("Speed Locking/Blocking: When locking speed controls the game will force set to a paused state because the user cant control the speed")]
		public UnlockState setState;

		[Tooltip("If true, the state will be set regardless of whether this feature was unlocked before (allows reverting to a locked state).")]
		public bool forceSetState;

		public bool saveToPlayerProfile;

		public override void OnTrigger(ActiveStory story)
		{
		}

		private void SetUnlockState()
		{
		}
	}
}
