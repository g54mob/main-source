using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.Types;

namespace NSMedieval.CombatAi
{
	public abstract class CombatAiReaction
	{
		private readonly CombatAiAgent agent;

		internal CombatAiAgent CombatAi => agent;

		internal IDamageDealAgent CombatAgent => agent.AgentOwner as IDamageDealAgent;

		public bool HasDisposed { get; private set; }

		public virtual bool ShouldWorkWhileEnemyAssignedToCommander => false;

		internal CombatAiReaction(CombatAiAgent agent)
		{
			this.agent = agent;
		}

		public virtual void Dispose()
		{
			if (!HasDisposed)
			{
				OnDisable();
				HasDisposed = true;
			}
		}

		public virtual void OnHitMissed(IDamageDealAgent deal, IDamageTakingAgent take, CombatMissType missType)
		{
		}

		public virtual void OnHitBlocked(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
		}

		public virtual void OnDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
		}

		internal virtual void Refresh()
		{
		}

		internal virtual void CombatTick()
		{
		}

		internal virtual void OnAgentStateChanges(CombatAiState state, object oldObject, object newObject)
		{
		}

		public virtual void OnEnable()
		{
		}

		public virtual void SceneControllerTick()
		{
		}

		public virtual void OnDisable()
		{
		}
	}
}
