using NodeCanvas.Framework;
using ParadoxNotion;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
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
