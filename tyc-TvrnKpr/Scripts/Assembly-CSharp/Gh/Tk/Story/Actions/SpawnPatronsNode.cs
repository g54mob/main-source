using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Actions
{
	[NodeTint("#505961")]
	public class SpawnPatronsNode : ConnectedStoryNode
	{
		public int amount;

		[Range(1f, 5f)]
		public int minTier;

		[Range(1f, 5f)]
		public int maxTier;

		[DropDownChoice(typeof(StoryHelper), "GetRaces")]
		public string race;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
