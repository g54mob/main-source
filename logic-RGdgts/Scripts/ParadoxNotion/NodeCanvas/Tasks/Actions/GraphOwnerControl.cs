using System.Collections;
using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Actions
{
	public class GraphOwnerControl : ActionTask<GraphOwner>
	{
		public enum Control
		{
			StartBehaviour = 0,
			StopBehaviour = 1,
			PauseBehaviour = 2
		}

		public Control control;

		public bool waitActionFinish;

		protected override string info => null;

		protected override void OnExecute()
		{
		}

		private IEnumerator YieldDo()
		{
			return null;
		}

		private void Do()
		{
		}

		protected override void OnStop()
		{
		}
	}
}
