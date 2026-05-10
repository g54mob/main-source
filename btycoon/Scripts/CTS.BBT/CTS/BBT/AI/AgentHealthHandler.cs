using CTS.Core;

namespace CTS.BBT.AI
{
	internal sealed class AgentHealthHandler : CTSBehaviour
	{
		[Inject(false)]
		private Agent _agent;

		[Inject(false)]
		private UnitHealth _health;

		protected override void OnEnabled()
		{
			_health.Died += OnDeath;
		}

		protected override void OnDisabled()
		{
			_health.Died -= OnDeath;
		}

		private void OnDeath()
		{
			_agent.ContextualFSM.SetStateDead();
		}
	}
}
