using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class IncreaseGameStatActionNode : ConnectedStoryNode
	{
		[Tooltip("use consistent format of word_word (example: mouse_clicks) to define key")]
		public string key;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
