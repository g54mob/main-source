using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.CombatAi;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Village.Map;

namespace NSMedieval.Goap.Goals
{
	public class EnemyWithdrawalGoal : Goal
	{
		private HumanoidInstance humanoidInstance;

		private HumanoidInstance HumanoidInstance => humanoidInstance ?? (humanoidInstance = base.AgentOwner as HumanoidInstance);

		public EnemyWithdrawalGoal(Agent selfAgent)
			: base("EnemyWithdrawalGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (HumanoidInstance.HasFainted || !HumanoidInstance.IsLeaving)
			{
				return false;
			}
			if (HumanoidInstance.IsTrader())
			{
				foreach (AnimalInstance pet in HumanoidInstance.Pets)
				{
					if (pet != null && !pet.HasDied && !pet.HasDisposed && pet.CombatAi != null && pet.CombatAi.IsStateSet(CombatAiState.AnimalRetreatingNoPathToTrader))
					{
						return false;
					}
				}
			}
			return true;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition);
			yield return new GoapAction("LeftMap")
			{
				OnInit = delegate
				{
					CreatureBase unit = (CreatureBase)base.AgentOwner;
					unit.DestroyStorage();
					unit.DestroyEquipment();
					MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
					{
						if (unit is HumanoidInstance humanoidInstance)
						{
							if (humanoidInstance.Pets != null)
							{
								AnimalInstance[] array = humanoidInstance.Pets.ToArray();
								foreach (AnimalInstance animal in array)
								{
									MonoSingleton<AnimalManager>.Instance.RemoveAnimal(animal, dropResources: false);
								}
							}
							MonoSingleton<NPCController>.Instance.RemoveNPC(humanoidInstance);
						}
					});
				}
			};
		}

		private bool PrepareData()
		{
			if (!MonoSingleton<NPCStartPositionManager>.IsInstantiated())
			{
				return false;
			}
			IPathfindingAgent pathfindingAgent;
			if (HumanoidInstance.IsCaptive())
			{
				HumanoidInstance owner = HumanoidInstance.CaptiveNpcBehaviour.Owner;
				if (owner != null && owner.IsNegotiator())
				{
					pathfindingAgent = owner;
					goto IL_0042;
				}
			}
			pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
			goto IL_0042;
			IL_0042:
			MapNode closestReachableEdgeNode = NPCStartPositionManager.GetClosestReachableEdgeNode(pathfindingAgent);
			HumanoidInstance?.CombatAi.SetState(CombatAiState.StuckWhileRetreating, closestReachableEdgeNode == null);
			if (closestReachableEdgeNode != null)
			{
				SetTarget(TargetIndex.A, new TargetObject(closestReachableEdgeNode.Position));
				return true;
			}
			return false;
		}
	}
}
