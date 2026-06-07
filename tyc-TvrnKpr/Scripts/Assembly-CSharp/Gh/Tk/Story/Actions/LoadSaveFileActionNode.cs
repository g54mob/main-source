using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Actions
{
	public class LoadSaveFileActionNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection input;

		public TextAsset saveFile;

		[Header("Optional")]
		public string narration;

		[Header("Start Story")]
		public StoryGraph storyGraph;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
