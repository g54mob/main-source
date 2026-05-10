using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	[Name("FINISH", 0)]
	[Category("Control")]
	[Description("End the dialogue in Success or Failure.\nNote: A Dialogue will anyway End in Succcess if it has reached a node without child connections. Thus this node is mostly useful if you want to end a Dialogue in Failure.")]
	[Icon("Halt", false, null)]
	[Color("6ebbff")]
	public class FinishNode : DTNode
	{
		public CompactStatus finishState;

		public override int maxOutConnections => 0;

		public override bool requireActorSelection => false;

		protected override Status OnExecute(Component agent, IBlackboard bb)
		{
			return default(Status);
		}
	}
}
