using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	public class StatementNode : DTNode
	{
		[SerializeField]
		public Statement statement;

		public override bool requireActorSelection => false;

		protected override Status OnExecute(Component agent, IBlackboard bb)
		{
			return default(Status);
		}

		private void OnStatementFinish()
		{
		}
	}
}
