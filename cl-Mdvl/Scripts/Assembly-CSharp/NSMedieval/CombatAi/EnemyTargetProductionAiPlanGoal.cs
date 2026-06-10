using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Water;

namespace NSMedieval.CombatAi
{
	public class EnemyTargetProductionAiPlanGoal : CombatAiPlanningGoal
	{
		private PathfinderAgentDriver pathfinderAgentDriver;

		private List<WorldObject> productionBuildings;

		private List<TargetObject> buildingsFound;

		public EnemyTargetProductionAiPlanGoal(Agent selfAgent)
			: base("EnemyTargetProductionAiPlanGoal", selfAgent)
		{
			AddInitStep(new ThreadSequenceStep(FindProductionBuildings, TargetProductionBuilding));
		}

		public override bool CanStart(bool isForced = false)
		{
			if (base.CombatAgent is HumanoidInstance { ActiveBehaviour: EnemyBehaviour { CurrentOrder: not null } })
			{
				return false;
			}
			if (pathfinderAgentDriver == null)
			{
				pathfinderAgentDriver = ((IPathfindingAgent)base.AgentOwner).PathDriver;
			}
			if (!base.CombatAi.IsStateSet(CombatAiState.Fainted) && pathfinderAgentDriver != null && !base.CombatAi.IsStateSet(CombatAiState.PreferedTarget))
			{
				return CombatUtils.GetAttackType(base.CombatAgent) == AttackType.Melee;
			}
			return false;
		}

		private bool FindProductionBuildings()
		{
			buildingsFound = null;
			if (base.CombatAi.IsStateSet(CombatAiState.PreferedTarget))
			{
				return false;
			}
			IEnumerable<WorldObject> worldObjects = VillageManager.ActiveVillage.Map.GetWorldObjects(GridDataType.ProductionBuilding);
			worldObjects = worldObjects.Where(delegate(WorldObject item)
			{
				if (!(item is BaseBuildingInstance baseBuildingInstance))
				{
					return false;
				}
				WaterDepthLevel waterLevelAsDepth = baseBuildingInstance.Map.WaterManager.GetWaterLevelAsDepth(baseBuildingInstance.GridDataPosition);
				return CombatUtils.IsAttackPossible(base.CombatAgent, (IDamageTakingAgent)item) && (waterLevelAsDepth == WaterDepthLevel.None || waterLevelAsDepth == WaterDepthLevel.Low);
			});
			if (!worldObjects.Any())
			{
				return false;
			}
			productionBuildings = worldObjects.ToList();
			return true;
		}

		private bool TargetProductionBuilding()
		{
			if (base.CombatAgent == null || base.CombatAgent.HasDisposed)
			{
				return false;
			}
			buildingsFound = PathfinderMedieval.FindMedievalObjects((IPathfindingAgent)base.CombatAgent, productionBuildings, (BaseBuildingInstance item) => item.ConstructionPhase == ConstructionPhase.Finished && !item.IsOnFire);
			if (buildingsFound == null || buildingsFound.Count <= 0)
			{
				buildingsFound = null;
				return false;
			}
			foreach (TargetObject item in buildingsFound)
			{
				IDamageTakingAgent building = item.GetObjectAs<IDamageTakingAgent>();
				Path path = MonoSingleton<CombatAttackerPositioningManager>.Instance.CreatePath(base.CombatAgent, building);
				if (path == null)
				{
					continue;
				}
				WaterDepthLevel waterLevelAsDepth = building.Map.WaterManager.GetWaterLevelAsDepth(building.GetGridPosition());
				if (waterLevelAsDepth != WaterDepthLevel.Medium && waterLevelAsDepth != WaterDepthLevel.High)
				{
					Path.ReleasePath(path);
					MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThreadBlocking(delegate
					{
						MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(base.CombatAgent, building);
					});
					return true;
				}
			}
			return false;
		}
	}
}
