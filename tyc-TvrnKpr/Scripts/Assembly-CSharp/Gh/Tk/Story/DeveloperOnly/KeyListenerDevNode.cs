using UnityEngine;

namespace Gh.Tk.Story.DeveloperOnly
{
	public class KeyListenerDevNode : ConnectedStoryNode
	{
		public KeyCode key;

		public bool requireCtrl;

		public bool requireShift;

		public bool requireAlt;

		public override void OnUpdate(ActiveStory story)
		{
		}
	}
}
