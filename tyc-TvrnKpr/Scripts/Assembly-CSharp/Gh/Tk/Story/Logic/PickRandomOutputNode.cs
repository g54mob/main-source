using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Logic
{
	public class PickRandomOutputNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection input;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection pickRandom;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection noMoreChoices;

		[Header("Smart choices")]
		public bool preferNewOutputsForRepeatExecutions;

		public bool discourageSameOutputsTwiceInARow;

		[Tooltip("If true, previously chosen outputs will not be picked again. if no outputs are left, the node will silently complete.")]
		public bool onlyPlayChoicesOnce;

		[Tooltip("Configure the scope at which previous choices are remembered")]
		public StoryFlagScope choiceScope;

		private string PreviousPicksKey => null;

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void Complete(ActiveStory story)
		{
		}

		private string[] GetPreviousPicks(ActiveStory story)
		{
			return null;
		}

		private void SavePicks(ActiveStory story, string[] picks)
		{
		}

		private DataStore GetTargetDataStore(ActiveStory story)
		{
			return null;
		}
	}
}
