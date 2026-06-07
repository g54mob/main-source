using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class UnlockMapRegionActionNode : ConnectedStoryNode
	{
		[SerializeField]
		private string[] _regionNamesToUnlock;

		public bool announceToPlayer;

		public override void OnTrigger(ActiveStory story)
		{
		}

		private void UnlockRegions()
		{
		}
	}
}
