using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class RemoveDirtFromTavernActionNode : ConnectedStoryNode
	{
		[Range(1f, 100f)]
		public int percentageToRemove;

		public override void OnTrigger(ActiveStory story)
		{
		}

		private void CleanTavern(ActiveStory story)
		{
		}
	}
}
