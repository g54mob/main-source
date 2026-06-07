using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class PolishTavernFloorsActionNode : ConnectedStoryNode
	{
		[Range(1f, 100f)]
		public int percentageOfRoomsAffected;

		[Range(0f, 100f)]
		public int polishPercentage;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
