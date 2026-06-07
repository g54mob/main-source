using UnityEngine;

namespace Gh.Tk.Story.DeveloperOnly
{
	public class ResetPlayerProfileDevNode : ConnectedStoryNode
	{
		[Header("Options")]
		public string profilePrefixName;

		public bool autoContinueAfterLoad;

		public bool runGameInBackground;

		public string profileEmail;

		public override void OnTrigger(ActiveStory story)
		{
		}

		private void ResetProfile()
		{
		}
	}
}
