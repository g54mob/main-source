using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	public abstract class AgentVisualUpdater : VFXUpdater
	{
		[SerializeField]
		private Agent _agent;

		public void SetAgent(Agent agent)
		{
			_agent = agent;
		}

		public sealed override void Execute()
		{
			if ((bool)_agent)
			{
				Execute(_agent.Material);
			}
		}

		protected abstract void Execute(AgentVisual agent);
	}
}
