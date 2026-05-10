using System.Collections.Generic;
using ParadoxNotion.Design;

namespace NodeCanvas.Framework
{
	[DoNotList]
	public class ActionList : ActionTask
	{
		public enum ActionsExecutionMode
		{
			ActionsRunInSequence = 0,
			ActionsRunInParallel = 1
		}

		public ActionsExecutionMode executionMode;

		public List<ActionTask> actions;

		private int currentActionIndex;

		private bool[] finishedIndeces;

		protected override string info => null;

		public override Task Duplicate(ITaskSystem newOwnerSystem)
		{
			return null;
		}

		protected override string OnInit()
		{
			return null;
		}

		protected override void OnExecute()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void OnStop()
		{
		}

		protected override void OnPause()
		{
		}

		public override void OnDrawGizmosSelected()
		{
		}

		public void AddAction(ActionTask action)
		{
		}

		internal override string GetWarningOrError()
		{
			return null;
		}
	}
}
