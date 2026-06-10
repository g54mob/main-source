using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.CombatAi;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class HuntingGoal : AttackBaseGoal
	{
		private const float UnreachablePreyCooldown = 60f;

		private const float UnreachablePreyCooldownStaggerStep = 1f;

		private readonly List<AnimalInstance> potentialPreyAnimals;

		private float goalInitStartTime;

		private IDamageTakingAgent bestTarget;

		public HuntingGoal(Agent selfAgent)
			: base("HuntingGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
			potentialPreyAnimals = new List<AnimalInstance>();
		}

		protected override void AddInitSteps()
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<AnimalInstance>());
			AddInitStep(new ThreadSequenceStep(PrepareWeaponAndGatherTargets, PathToBestTargetThread));
		}

		public override bool CanStart(bool isForced = false)
		{
			if (!MonoSingleton<CombatTargetManager>.IsInstantiated() || !MonoSingleton<AnimalManager>.IsInstantiated())
			{
				return false;
			}
			IDamageDealAgent damageDealAgent = (IDamageDealAgent)base.AgentOwner;
			if (damageDealAgent.HasDisposed || damageDealAgent.IsOnFire)
			{
				return false;
			}
			if ((damageDealAgent.CanAttackTypes() & DamageTakingAgentType.Animal) == 0)
			{
				return false;
			}
			if (!CombatUtils.HasRangedWeapon(damageDealAgent))
			{
				return false;
			}
			CombatAiAgent combatAi = ownerAgent.CombatAi;
			if (combatAi.IsStateSet(CombatAiState.NextTarget))
			{
				return false;
			}
			if (!combatAi.IsStateSet(CombatAiState.Fainted))
			{
				return MonoSingleton<AnimalManager>.Instance.HasAnimalWithOrder(AnimalOrderType.Hunt);
			}
			return false;
		}

		public override void Start()
		{
			base.Start();
			ownerAgent.CombatAi.SetState(CombatAiState.IsFleeingDisabled, true);
		}

		public override void Dispose()
		{
			if (MonoSingleton<AnimalController>.IsInstantiated())
			{
				MonoSingleton<AnimalController>.Instance.AnimalKilledByHunterEvent -= OnAnimalKilledByHunter;
			}
			ownerAgent?.CombatAi?.SetState(CombatAiState.IsFleeingDisabled, false);
			bestTarget = null;
			base.Dispose();
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			ownerAgent.SetWeaponVisibility(isVisible: false);
			base.EndGoalWith(condition);
			if (MonoSingleton<AnimalController>.IsInstantiated())
			{
				MonoSingleton<AnimalController>.Instance.AnimalKilledByHunterEvent -= OnAnimalKilledByHunter;
			}
			bestTarget = null;
		}

		private void OnAnimalKilledByHunter(AnimalInstance animal, ResourcePileInstance corpsePile)
		{
			if (animal != null && corpsePile != null && !corpsePile.HasDisposed && ownerAgent?.CombatAi != null && animal.CombatAi != null)
			{
				IDamageTakingAgent damageTakingAgent = ownerAgent.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.LastAttackedTarget);
				IDamageDealAgent damageDealAgent = animal.CombatAi?.GetState<IDamageDealAgent>(CombatAiState.LastDamageTakenFrom);
				if (damageTakingAgent == animal && damageDealAgent == ownerAgent)
				{
					MonoSingleton<ReservationManager>.Instance.SetPreferedReservable(base.AgentOwner, corpsePile);
					base.Agent.ForceNextGoal("StockpileHaulingGoal");
					MonoSingleton<AnimalController>.Instance.AnimalKilledByHunterEvent -= OnAnimalKilledByHunter;
				}
			}
		}

		private bool PrepareWeaponAndGatherTargets()
		{
			if (CombatUtils.IsNullOrDisposed(base.AgentOwner))
			{
				return false;
			}
			MonoSingleton<AnimalController>.Instance.AnimalKilledByHunterEvent += OnAnimalKilledByHunter;
			IDamageDealAgent damageDealAgent = (IDamageDealAgent)base.AgentOwner;
			if (CombatUtils.GetAttackType(damageDealAgent) == AttackType.Melee)
			{
				damageDealAgent.ToggleWeaponMode();
			}
			if (base.PreferredReservableHandler.HasTarget())
			{
				IGoapTargetable objectInstance = base.PreferredReservableHandler.GetTarget().ObjectInstance;
				AnimalInstance targetAnimal = objectInstance as AnimalInstance;
				if (targetAnimal != null && targetAnimal.OrderType == AnimalOrderType.Hunt)
				{
					base.PreferredReservableHandler.ClearTarget();
					MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThreadBlocking(delegate
					{
						MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(ownerAgent, targetAnimal);
						ownerAgent.SetTarget(targetAnimal);
					});
					return true;
				}
			}
			IDamageTakingAgent preferredTarget = MonoSingleton<CombatTargetManager>.Instance.GetPreferredTarget(ownerAgent);
			if (preferredTarget != null && preferredTarget is AnimalInstance { OrderType: AnimalOrderType.Hunt })
			{
				return true;
			}
			initialPath = null;
			goalInitStartTime = Time.unscaledTime;
			potentialPreyAnimals.Clear();
			MonoSingleton<CombatAttackTracker>.Instance.RemoveExpiredCooldownTargets(goalInitStartTime);
			MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(ownerAgent);
			foreach (AnimalInstance key in MonoSingleton<AnimalManager>.Instance.Animals.Keys)
			{
				if (!MonoSingleton<CombatAttackTracker>.Instance.IsTargetOnCooldown(key, goalInitStartTime) && key.OrderType == AnimalOrderType.Hunt && CombatUtils.IsAlive(key) && CombatUtils.IsAttackPossible(ownerAgent, key) && MonoSingleton<CombatTargetManager>.Instance.GetFirstPreferedAttacker(key) == null)
				{
					potentialPreyAnimals.Add(key);
					if (CombatAttackerPositioningManager.IsInAttackPosition(ownerAgent, key))
					{
						MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(ownerAgent, key);
						ownerAgent.SetTarget(key);
						break;
					}
				}
			}
			if (potentialPreyAnimals.Count == 0)
			{
				return false;
			}
			Vector3 huntersPosition = ownerAgent.GetPosition();
			potentialPreyAnimals.Sort(delegate(AnimalInstance animal1, AnimalInstance animal2)
			{
				float num = ((MonoSingleton<CombatTargetManager>.Instance.GetFirstPreferedAttacker(animal1) != null) ? 1000000f : 0f);
				float num2 = ((MonoSingleton<CombatTargetManager>.Instance.GetFirstPreferedAttacker(animal2) != null) ? 1000000f : 0f);
				float num3 = (animal1.GetPosition() - huntersPosition).sqrMagnitude + num;
				float value = (animal2.GetPosition() - huntersPosition).sqrMagnitude + num2;
				return num3.CompareTo(value);
			});
			return true;
		}

		private bool PathToBestTargetThread()
		{
			if (MonoSingleton<CombatTargetManager>.Instance.HasPreferredTarget(ownerAgent))
			{
				return true;
			}
			CreatureBase agent = (CreatureBase)base.AgentOwner;
			if (CombatUtils.IsNullOrDisposed(agent))
			{
				return false;
			}
			bestTarget = null;
			int num = 0;
			foreach (AnimalInstance potentialPreyAnimal in potentialPreyAnimals)
			{
				if (CombatUtils.IsNullOrDisposed(potentialPreyAnimal) || MonoSingleton<CombatAttackTracker>.Instance.IsTargetOnCooldown(potentialPreyAnimal, goalInitStartTime))
				{
					continue;
				}
				IDamageTakingAgent damageTakingAgent = potentialPreyAnimal;
				if (PathfinderUtil.IsPathPossible(agent, damageTakingAgent))
				{
					bestTarget = damageTakingAgent;
					initialPath = P2PPath.Construct(agent, damageTakingAgent.GetGridPosition());
					break;
				}
				initialPath = MonoSingleton<CombatAttackTracker>.Instance.StartAttackPath(agent, damageTakingAgent);
				if (initialPath != null)
				{
					bestTarget = damageTakingAgent;
					break;
				}
				MapNode node = agent.GetNode();
				if ((node.Tag & MapNodeTags.Ladder) != MapNodeTags.None && node == damageTakingAgent.GetNode())
				{
					float ladderAttackOffset = CombatActions.GetLadderAttackOffset(damageTakingAgent);
					((IPathfindingAgent)ownerAgent).PathDriver.Teleport(node.WorldPosition + new Vector3(0f, ladderAttackOffset, 0f));
					bestTarget = damageTakingAgent;
					break;
				}
				foreach (AnimalInstance potentialPreyAnimal2 in potentialPreyAnimals)
				{
					if (!CombatUtils.IsNullOrDisposed(potentialPreyAnimal2) && potentialPreyAnimal2.GetNode().Region == potentialPreyAnimal.GetNode().Region)
					{
						MonoSingleton<CombatAttackTracker>.Instance.SetTargetCooldown(potentialPreyAnimal2, goalInitStartTime, 60f + (float)num * 1f);
						num++;
					}
				}
			}
			if (failedTarget != bestTarget || failedTarget == null)
			{
				failedTarget = null;
				failedCount = 0;
			}
			MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThreadBlocking(delegate
			{
				MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(agent, bestTarget);
				ownerAgent.SetTarget(bestTarget);
			});
			if (bestTarget == null)
			{
				if (initialPath != null)
				{
					Path.ReleasePath(initialPath);
				}
				return false;
			}
			if (initialPath == null)
			{
				return false;
			}
			MonoSingleton<PathProcessorManager>.Instance.InstantProcessPath(initialPath);
			if (initialPath == null)
			{
				return false;
			}
			if (initialPath.State == PathState.Calculated)
			{
				return true;
			}
			MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThread(delegate
			{
				MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget((IDamageDealAgent)base.AgentOwner, null);
			});
			Path.ReleasePath(initialPath);
			return false;
		}
	}
}
