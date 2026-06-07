using System.Collections;
using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	public class ActionNode : DTNode, ITaskAssignable<ActionTask>, ITaskAssignable, IGraphElement
	{
		[SerializeField]
		private ActionTask _action;

		public ActionTask action
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Task task
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override bool requireActorSelection => false;

		protected override Status OnExecute(Component agent, IBlackboard bb)
		{
			return default(Status);
		}

		private IEnumerator UpdateAction(Component actionAgent)
		{
			return null;
		}

		private void OnActionEnd(bool success)
		{
		}

		protected override void OnReset()
		{
		}

		public override void OnGraphPaused()
		{
		}
	}
}
