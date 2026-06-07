using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Logic
{
	[NodeTint("#1B90AD")]
	public class ChanceNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection input;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection pass;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection fail;

		[Range(0f, 100f)]
		public int passChance;

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void Complete(ActiveStory story)
		{
		}
	}
}
