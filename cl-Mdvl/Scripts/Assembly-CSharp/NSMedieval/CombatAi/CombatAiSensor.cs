using System;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;

namespace NSMedieval.CombatAi
{
	public abstract class CombatAiSensor : IGameDisposable, IDisposable
	{
		private CombatAiAgent agent;

		internal CombatAiAgent CombatAi => agent;

		internal IDamageDealAgent CombatAgent => agent?.AgentOwner as IDamageDealAgent;

		public bool HasDisposed { get; private set; }

		public event Action<IGameDisposable> OnDisposedEvent;

		internal CombatAiSensor(CombatAiAgent agent)
		{
			this.agent = agent;
		}

		public virtual void Dispose()
		{
			if (!HasDisposed)
			{
				OnDisable();
				HasDisposed = true;
				if (!LoadingController.IsLeavingMainScene)
				{
					this.OnDisposedEvent?.Invoke(this);
				}
				this.OnDisposedEvent = null;
				agent = null;
			}
		}

		internal abstract void InitStates();

		internal virtual void Refresh()
		{
		}

		public virtual void OnEnable()
		{
		}

		public virtual void OnDisable()
		{
		}

		public virtual void OnDamageAgentRemoved(IDamageCommonAgent agent)
		{
		}

		public virtual void PreferredTargetUpdated(IDamageDealAgent agent, IDamageTakingAgent newTarget, IDamageTakingAgent oldTarget)
		{
		}

		public virtual void OnDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
		}

		public virtual void OnHitMissed(IDamageDealAgent deal, IDamageTakingAgent take, CombatMissType missType)
		{
		}

		public virtual void OnHitBlocked(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
		}

		public virtual void OnFainted(StatsInstance stats)
		{
		}

		public virtual void OnWokeUp(StatsInstance stats)
		{
		}
	}
}
