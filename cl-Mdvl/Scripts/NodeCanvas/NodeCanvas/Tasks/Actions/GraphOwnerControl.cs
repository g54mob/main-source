using System.Collections;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Name("Control Graph Owner", 0)]
	[Category("✫ Utility")]
	[Description("Start, Resume, Pause, Stop a GraphOwner's behaviour")]
	public class GraphOwnerControl : ActionTask<GraphOwner>
	{
		public enum Control
		{
			StartBehaviour = 0,
			StopBehaviour = 1,
			PauseBehaviour = 2
		}

		public Control control;

		public bool waitActionFinish = true;

		protected override string info => base.agentInfo + "." + control;

		protected override void OnExecute()
		{
			if (control == Control.StartBehaviour)
			{
				if (waitActionFinish)
				{
					base.agent.StartBehaviour(delegate(bool s)
					{
						EndAction(s);
					});
				}
				else
				{
					base.agent.StartBehaviour();
					EndAction();
				}
			}
			else if (base.agent == base.ownerSystemAgent)
			{
				StartCoroutine(YieldDo());
			}
			else
			{
				Do();
			}
		}

		private IEnumerator YieldDo()
		{
			yield return null;
			Do();
		}

		private void Do()
		{
			if (control == Control.StopBehaviour)
			{
				EndAction(null);
				base.agent.StopBehaviour();
			}
			if (control == Control.PauseBehaviour)
			{
				EndAction(null);
				base.agent.PauseBehaviour();
			}
		}

		protected override void OnStop()
		{
			if (waitActionFinish && control == Control.StartBehaviour)
			{
				base.agent.StopBehaviour();
			}
		}
	}
}
