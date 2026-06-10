using System;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Types;

namespace NSMedieval.CombatAi
{
	public class CombatAiTargetSwitcherDefault : IGameDisposable, IDisposable
	{
		private CombatAiAgent agent;

		public bool HasDisposed { get; private set; }

		protected CombatAiAgent Agent => agent;

		public event Action<IGameDisposable> OnDisposedEvent;

		public CombatAiTargetSwitcherDefault()
		{
			agent = null;
		}

		public virtual void Dispose()
		{
			HasDisposed = true;
			if (!LoadingController.IsLeavingMainScene)
			{
				this.OnDisposedEvent?.Invoke(this);
			}
			this.OnDisposedEvent = null;
			agent = null;
		}

		public virtual void SetAgent(CombatAiAgent agent)
		{
			this.agent = agent;
		}

		protected void CleanupOnCompletion()
		{
			agent.SetState(CombatAiState.NextTarget, null);
			agent.SetState(CombatAiState.NextTargetValidated, null);
		}

		public virtual bool DoProcessing()
		{
			IDamageTakingAgent state = agent.GetState<IDamageTakingAgent>(CombatAiState.NextTarget);
			if (state == null)
			{
				state = agent.GetState<IDamageTakingAgent>(CombatAiState.NextTargetValidated);
				if (state == null)
				{
					return false;
				}
				if (!CombatUtils.CanBeTargeted(state))
				{
					CleanupOnCompletion();
					return false;
				}
				CleanupOnCompletion();
				MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget((IDamageDealAgent)agent.AgentOwner, state);
				return true;
			}
			CreatureBase damageDealAgent = agent.AgentOwner as CreatureBase;
			if (CombatUtils.GetAttackType(damageDealAgent) == AttackType.RangeChargeAfter || CombatUtils.GetAttackType(damageDealAgent) == AttackType.RangeChargeBefore || MonoSingleton<CombatAttackerPositioningManager>.Instance.CanCreatePath(agent.AgentOwner as IDamageDealAgent, state))
			{
				MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget((IDamageDealAgent)agent.AgentOwner, state);
				CleanupOnCompletion();
				return true;
			}
			CleanupOnCompletion();
			return false;
		}
	}
}
