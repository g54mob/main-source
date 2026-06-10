using System;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Types;

namespace NSMedieval.Controllers
{
	public class CombatController : MonoSingleton<CombatController>
	{
		public delegate void DamageCommonAgentHandler(IDamageCommonAgent agent);

		public delegate void DamageDealAgentHandler(IDamageDealAgent agent);

		public delegate void DealTakeDamageAgentHandler(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo);

		public delegate void DealTakeDmgAgentHandler(IDamageDealAgent deal, IDamageTakingAgent take);

		public delegate void DealTakeTakeDmgAgentHandler(IDamageDealAgent deal, IDamageTakingAgent newTarget, IDamageTakingAgent oldTarget);

		public delegate void DealTrapDamageAgentHandler(TrapComponentInstance trapComponentInstance, IDamageTakingAgent take, CombatHitInfo hitInfo);

		public delegate void HitMissAgentHandler(IDamageDealAgent deal, IDamageTakingAgent take, CombatMissType missType);

		public event DamageCommonAgentHandler DamageAgentRegisteredEvent;

		public event DamageCommonAgentHandler DamageAgentRemovedEvent;

		public event DealTakeDmgAgentHandler TargetChangedEvent;

		public event DealTakeTakeDmgAgentHandler PreferedTargetUpdateEvent;

		public event DamageCommonAgentHandler AgentDiedEvent;

		public event DealTakeDamageAgentHandler DamageTakenEvent;

		public event DealTrapDamageAgentHandler TrapDamageTakenEvent;

		public event Action<IDamageTakingAgent, CombatHitInfo> GateDamageTakenEvent;

		public event DealTakeDmgAgentHandler OnAgentKilledEvent;

		public event DamageDealAgentHandler AgentAttackStreamStart;

		public event DamageDealAgentHandler AgentAttackStreamEnd;

		public event HitMissAgentHandler HitMissedEvent;

		public event DealTakeDamageAgentHandler HitBlockedEvent;

		public event DamageCommonAgentHandler FleeStartEvent;

		public event DamageCommonAgentHandler FleeStopEvent;

		public event Action<IDamageTakingAgent, float> DealDamageEvent;

		public event Action CombatStartedEvent;

		public event Action<DoorComponentInstance> DealGateDamageEvent;

		public event Action<DrawbridgeComponent> DealDrawbridgeDamageEvent;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.DamageAgentRegisteredEvent = null;
			this.DamageAgentRemovedEvent = null;
			this.TargetChangedEvent = null;
			this.PreferedTargetUpdateEvent = null;
			this.AgentDiedEvent = null;
			this.DamageTakenEvent = null;
			this.TrapDamageTakenEvent = null;
			this.OnAgentKilledEvent = null;
			this.AgentAttackStreamStart = null;
			this.AgentAttackStreamEnd = null;
			this.HitMissedEvent = null;
			this.HitBlockedEvent = null;
			this.FleeStartEvent = null;
			this.FleeStopEvent = null;
			this.DealDamageEvent = null;
			this.CombatStartedEvent = null;
		}

		public void OnDamageAgentRegister(IDamageCommonAgent agent)
		{
			this.DamageAgentRegisteredEvent?.Invoke(agent);
		}

		public void OnDamageAgentRemove(IDamageCommonAgent agent)
		{
			this.DamageAgentRemovedEvent?.Invoke(agent);
		}

		public void OnAgentKilled(IDamageDealAgent killer, IDamageTakingAgent target)
		{
			this.OnAgentKilledEvent?.Invoke(killer, target);
		}

		public void OnAgentDied(IDamageCommonAgent agent)
		{
			this.AgentDiedEvent?.Invoke(agent);
		}

		public void OnDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			this.DamageTakenEvent?.Invoke(deal, take, hitInfo);
		}

		public void OnTrapDamageTaken(TrapComponentInstance trapComponentInstance, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			this.TrapDamageTakenEvent?.Invoke(trapComponentInstance, take, hitInfo);
		}

		public void GateDamageTaken(IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			this.GateDamageTakenEvent?.Invoke(take, hitInfo);
		}

		public void OnHitMissed(IDamageDealAgent deal, IDamageTakingAgent take, CombatMissType missType)
		{
			this.HitMissedEvent?.Invoke(deal, take, missType);
		}

		public void OnHitBlocked(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo info)
		{
			this.HitBlockedEvent?.Invoke(deal, take, info);
		}

		public void OnTargetChanged(IDamageDealAgent agent, IDamageTakingAgent oldTarget)
		{
			this.TargetChangedEvent?.Invoke(agent, oldTarget);
		}

		public void OnPreferedTargetUpdated(IDamageDealAgent agent, IDamageTakingAgent newTarget, IDamageTakingAgent oldTarget)
		{
			if (CombatUtils.IsAlive(agent))
			{
				this.PreferedTargetUpdateEvent?.Invoke(agent, newTarget, oldTarget);
			}
		}

		public void OnFleeStart(IDamageCommonAgent agent)
		{
			this.FleeStartEvent?.Invoke(agent);
		}

		public void OnFleeStop(IDamageCommonAgent agent)
		{
			this.FleeStopEvent?.Invoke(agent);
		}

		public void OnAttackStreamStart(IDamageDealAgent agent)
		{
			this.AgentAttackStreamStart?.Invoke(agent);
		}

		public void OnAttackStreamEnd(IDamageDealAgent agent)
		{
			this.AgentAttackStreamEnd?.Invoke(agent);
		}

		public void OnDealDamage(IDamageTakingAgent target, float damage)
		{
			this.DealDamageEvent?.Invoke(target, damage);
		}

		public void CombatStarted()
		{
			this.CombatStartedEvent?.Invoke();
		}

		public void DealGateDamage(DoorComponentInstance doorComponentInstance)
		{
			this.DealGateDamageEvent?.Invoke(doorComponentInstance);
		}

		public void DealDrawbridgeDamage(DrawbridgeComponent drawbridgeComponent)
		{
			this.DealDrawbridgeDamageEvent?.Invoke(drawbridgeComponent);
		}
	}
}
