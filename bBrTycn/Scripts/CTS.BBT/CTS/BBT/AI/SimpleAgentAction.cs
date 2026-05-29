using System;
using System.Collections;

namespace CTS.BBT.AI
{
	[Serializable]
	public abstract class SimpleAgentAction : AgentAction<Agent>
	{
		public SimpleAgentAction()
		{
			base.Name = GetType().Name;
		}

		public override void OnStart()
		{
		}

		protected abstract void Execute();

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public override IEnumerator ActionRoutine()
		{
			Execute();
			yield break;
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}

		public override void OnComplete()
		{
			base.OnComplete();
		}
	}
}
