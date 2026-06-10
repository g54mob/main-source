using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Controllers;
using NSMedieval.Draft;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Sound;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Tools;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class DraftManager : MonoSingleton<DraftManager>
	{
		private int raycastMask = -1;

		private GameObject clickIndicatorPrefab;

		public int RaycastMask => raycastMask;

		public bool HandleMovementOnClick()
		{
			if (MonoSingleton<AdditionalMenuManager>.Instance.IsBlockingInput())
			{
				return true;
			}
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			InitRayCastMask();
			if (!RaycastUtils.RaycastToSurface(out var hit, ray, raycastMask, RaycastBuildingFilter))
			{
				return false;
			}
			return MoveToLocation(hit.point);
		}

		public bool MoveToLocation(Vector3 worldPosition)
		{
			using PooledList<WorkerView> selectedWorkers = MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.OfTypePooled<WorkerView>();
			return MoveToLocation(worldPosition, selectedWorkers);
		}

		public bool MoveToLocation(Vector3 worldPosition, PooledList<WorkerView> selectedWorkers, bool excludeOriginPoint = false, bool sameYLevel = false, UnitCombatModeType stance = UnitCombatModeType.None, bool minimizeNodePenalties = false)
		{
			MapNode mapNode = VillageManager.ActiveVillage.Map.GetNode(GridUtils.GetGridPosition(worldPosition, 0.01f));
			if (mapNode == null || !mapNode.IsWalkable)
			{
				return false;
			}
			MapNode nodeAbove = mapNode.GetNodeAbove();
			if (mapNode.IsWater && mapNode.WaterDepthLevel.HasFlag(WaterDepthLevel.High) && nodeAbove != null && nodeAbove.IsWater && nodeAbove.WaterDepthLevel.HasFlag(WaterDepthLevel.Low))
			{
				mapNode = nodeAbove;
			}
			foreach (WorkerView item in selectedWorkers)
			{
				if (item.ManualAttackTargeting)
				{
					item.CancelManualAttack();
				}
			}
			using PooledList<HumanoidInstance> pooledList = selectedWorkers.SelectPooled((WorkerView view) => view.HumanoidInstance, (HumanoidInstance workerInstance) => workerInstance != null && !workerInstance.HasDied && !workerInstance.HasDisposed && !workerInstance.HasFainted && workerInstance.WorkerBehaviour.IsDrafting);
			if (pooledList.Count == 0)
			{
				return false;
			}
			if (pooledList.Count == 1)
			{
				HumanoidInstance humanoidInstance = pooledList.First();
				GenerateRtsMouseClickIndicator(worldPosition, PathfinderUtil.IsPathPossible(humanoidInstance, mapNode));
				MonoSingleton<DraftController>.Instance.ExecuteDraftOrder(humanoidInstance, new DraftOrderGoToLocation(mapNode.WorldPosition));
				humanoidInstance.WorkerBehaviour.ShowPathDestinationLine(worldPosition);
				return true;
			}
			using PooledHashSet<Vec3Int> pooledHashSet = HashSetPool<Vec3Int>.GetJanitor();
			GetFormationPoints(pooledList[0], mapNode.WorldPosition, pooledList.Count, pooledHashSet, excludeOriginPoint, sameYLevel, minimizeNodePenalties);
			if ((sameYLevel || excludeOriginPoint) && pooledHashSet.Count == 0)
			{
				GetFormationPoints(pooledList[0], mapNode.WorldPosition, pooledList.Count, pooledHashSet);
			}
			bool isReachable = true;
			foreach (HumanoidInstance item2 in pooledList)
			{
				if (pooledHashSet.Count == 0)
				{
					Log.Warning("No movement points left", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\DraftManager.cs");
					continue;
				}
				Vec3Int vec3Int = pooledHashSet.First();
				pooledHashSet.Remove(vec3Int);
				MonoSingleton<DraftController>.Instance.ExecuteDraftOrder(item2, new DraftOrderGoToLocation(GridUtils.GetWorldPosition(vec3Int), stance));
				item2.WorkerBehaviour.ShowPathDestinationLine((Vector3)vec3Int);
				if (!PathfinderUtil.IsPathPossible(item2, vec3Int))
				{
					isReachable = false;
				}
			}
			GenerateRtsMouseClickIndicator(worldPosition, isReachable);
			return true;
		}

		public void ExecuteOrder(HumanoidInstance humanoid, DraftOrder order)
		{
			if (DateTime.UtcNow.Ticks - humanoid.WorkerBehaviour.LastDraftOrderTime <= 100000)
			{
				return;
			}
			if (order.RequiredHourType != HourType.None && ((WorkerGoapAgent)humanoid.GetGoapAgent()).CurrentHourType != order.RequiredHourType)
			{
				Log.Warning("Hour type condition for draft order " + order?.ToString() + " not satisfied", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\DraftManager.cs");
			}
			else
			{
				if (!order.CheckRequirements(humanoid, humanoid.WorkerBehaviour.LastDraftOrder))
				{
					return;
				}
				if (humanoid.WorkerBehaviour.LastDraftOrder != null)
				{
					humanoid.WorkerBehaviour.LastDraftOrder.OnNewOrder(humanoid, order);
				}
				humanoid.WorkerBehaviour.LastDraftOrder = order;
				humanoid.SetTarget(null);
				MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(humanoid, null);
				humanoid.CombatAi.SetState(CombatAiState.LastAttackOrderTarget, null);
				humanoid.CombatAi.SetState(CombatAiState.IsDraftAutoTargetSet, false);
				humanoid.GetGoapAgent().Abort();
				if (humanoid.PathDriver == null)
				{
					Log.Error("Should NEVER happen!", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\DraftManager.cs");
					return;
				}
				if (!(order is DraftOrderGoToLocation))
				{
					humanoid.PathDriver?.Abort();
				}
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
				{
					order.Execute(humanoid);
				});
				humanoid.WorkerBehaviour.LastDraftOrderTime = DateTime.UtcNow.Ticks;
			}
		}

		public bool HandleRightClickAttack(IDamageTakingAgent target, bool draftedOnly)
		{
			if (CombatUtils.IsNullOrDisposed(target))
			{
				return false;
			}
			List<HumanoidInstance> currenlySelected = GetCurrenlySelected(draftedOnly);
			string key = "can_not_deal_damage_to_target";
			bool flag = false;
			foreach (HumanoidInstance item in currenlySelected)
			{
				if (CombatUtils.IsNullOrDisposed(item) || item.HasFainted)
				{
					continue;
				}
				if (item.GetGoapAgent().AgentOwner == target || (draftedOnly && !item.WorkerBehaviour.IsDrafting) || !item.GetGoapAgent().GoalScheduler.IsEnabled("AttackGoal"))
				{
					key = "worker_can_not_attack";
					continue;
				}
				if (item.GetTarget() == target)
				{
					flag = true;
					continue;
				}
				if (CombatCalculator.CalculateDamage(item, target, isCritical: false) <= 0f)
				{
					key = "can_not_deal_damage_to_target";
					continue;
				}
				bool flag2 = CombatAttackerPositioningManager.IsInAttackPosition(item, target);
				if (!flag2)
				{
					Path path = MonoSingleton<CombatAttackerPositioningManager>.Instance.CreatePath(item, target);
					if (path == null)
					{
						key = "worker_can_not_find_path_to_target";
						continue;
					}
					Path.ReleasePath(path);
				}
				item.CombatAi.SetState(CombatAiState.IsDraftAutoTargetSet, false);
				MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(item, target);
				item.CombatAi.SetState(CombatAiState.LastAttackOrderTarget, target);
				item.GetGoapAgent().Abort();
				item.GetGoapAgent().ForceNextGoal("AttackGoal");
				item.WorkerBehaviour.ShowPathDestinationLine(target.GetPosition());
				if (!flag2 && item.WorkerBehaviour.CombatMode == UnitCombatModeType.DraftedHoldGround)
				{
					item.WorkerBehaviour.SetCombatMode(UnitCombatModeType.DraftedDefault);
				}
				flag = true;
			}
			if (!flag && currenlySelected.Count > 0)
			{
				DamagePopup.Create(target.GetPosition(), MonoSingleton<LocalizationController>.Instance.GetText(key), Color.yellow);
			}
			return flag;
		}

		private List<HumanoidInstance> GetCurrenlySelected(bool draftedOnly)
		{
			List<HumanoidInstance> list = new List<HumanoidInstance>();
			foreach (SelectableObject selectedObject in MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects)
			{
				WorkerView workerView = selectedObject as WorkerView;
				if (!(workerView == null) && workerView.HumanoidInstance != null && !workerView.HumanoidInstance.HasDisposed && (!draftedOnly || workerView.HumanoidInstance.WorkerBehaviour.IsDrafting))
				{
					list.Add(workerView.HumanoidInstance);
				}
			}
			return list;
		}

		private void GenerateRtsMouseClickIndicator(Vector3 pos, bool isReachable)
		{
			MapNode nodeByWorldPos = VillageManager.ActiveVillage.Map.GetNodeByWorldPos(pos);
			if (nodeByWorldPos != null && Mathf.Abs(nodeByWorldPos.WorldPosition.y - pos.y) >= 0.5f)
			{
				pos.y -= 0.05f;
			}
			if (clickIndicatorPrefab == null)
			{
				clickIndicatorPrefab = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByID("RtsMouseClick").Value;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(clickIndicatorPrefab, pos, Quaternion.identity);
			if (isReachable)
			{
				MonoSingleton<AudioManager>.Instance.PlaySound("UI_Worker_DraftSend");
				return;
			}
			MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				if (!(meshRenderer == null) && !(meshRenderer.material == null))
				{
					meshRenderer.material.SetColor("_Color0", Color.red);
				}
			}
			MonoSingleton<AudioManager>.Instance.PlaySound("UI_Worker_DraftSendFail");
		}

		private void InitRayCastMask()
		{
			if (raycastMask == -1)
			{
				raycastMask = (1 << LayerMask.NameToLayer("VoxelMap")) | (1 << LayerMask.NameToLayer("Water")) | (1 << LayerMask.NameToLayer("BuildingWalkable")) | (1 << LayerMask.NameToLayer("RaycastPlaneHelper")) | (1 << LayerMask.NameToLayer("VoxelMapPathfinding"));
			}
		}

		private static void GetFormationPoints(HumanoidInstance firstHumanoid, Vector3 position, int pointsCount, PooledHashSet<Vec3Int> outPoints, bool excludeOriginPoint = false, bool sameYLevel = false, bool minimizeNodePenalties = false)
		{
			outPoints.Clear();
			VillageMap map = firstHumanoid.Map;
			MapNode originNode = map.GetNodeByWorldPos(position);
			if (originNode == null)
			{
				return;
			}
			using PooledList<MapNode> pooledList = ListPool<MapNode>.GetJanitor();
			foreach (MapNode item in FloodFillUtil.IterateFloodFillConnections(originNode, 100f))
			{
				if ((excludeOriginPoint && item == originNode) || !firstHumanoid.PathTraversalProvider.CanStandOnNode(item))
				{
					continue;
				}
				if (minimizeNodePenalties)
				{
					pooledList.Add(item);
					if (pooledList.Count >= 100)
					{
						break;
					}
				}
				else
				{
					outPoints.Add(item.Position);
					if (outPoints.Count >= pointsCount)
					{
						return;
					}
				}
			}
			if (!minimizeNodePenalties)
			{
				return;
			}
			if (pooledList.Count == 0)
			{
				Log.Warning("Not enough formation points found", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\DraftManager.cs");
				return;
			}
			PathfindingPenalty pathfindingPenalty = firstHumanoid.WalkableModel.PathfindingPenalty;
			pooledList.Sort(delegate(MapNode node1, MapNode node2)
			{
				float num2 = (float)(100 * node1.GetPenalty(pathfindingPenalty)) + 100f * node1.DistanceSquared(originNode);
				if (node1.IsSlopeOrStairs() || node1.IsLadder() || node1.IsVoxelDoor() || (node1.GetNodeBelow() != null && node1.GetNodeBelow().IsSlopeOrStairs()))
				{
					num2 += 100f;
				}
				if (sameYLevel && node1.Position.y != originNode.Position.y)
				{
					num2 += 500f;
				}
				float num3 = (float)(100 * node2.GetPenalty(pathfindingPenalty)) + 100f * node2.DistanceSquared(originNode);
				if (node2.IsSlopeOrStairs() || node2.IsLadder() || node2.IsVoxelDoor() || (node2.GetNodeBelow() != null && node2.GetNodeBelow().IsSlopeOrStairs()))
				{
					num3 += 100f;
				}
				if (sameYLevel && node2.Position.y != originNode.Position.y)
				{
					num3 += 500f;
				}
				return num2.CompareTo(num3);
			});
			for (int num = 0; num < pooledList.Count; num++)
			{
				MapNode mapNode = pooledList[num];
				outPoints.Add(mapNode.Position);
				if (outPoints.Count >= pointsCount)
				{
					break;
				}
			}
		}

		private static bool RaycastBuildingFilter(RaycastHit hit)
		{
			BaseBuildingViewComponent baseBuildingViewComponent = hit.transform.gameObject.GetComponent<BaseBuildingViewComponent>();
			if (baseBuildingViewComponent == null)
			{
				baseBuildingViewComponent = hit.transform.gameObject.GetComponentInParent<BaseBuildingViewComponent>();
			}
			if (baseBuildingViewComponent != null)
			{
				if (baseBuildingViewComponent.HasDisposed || baseBuildingViewComponent.BaseBuildingInstance == null || baseBuildingViewComponent.BaseBuildingInstance.HasDisposed)
				{
					return false;
				}
				if (!baseBuildingViewComponent.LayerObjectHide.Visible)
				{
					return false;
				}
				int num = (int)baseBuildingViewComponent.LayerObjectHide.ObjectLevel;
				if ((baseBuildingViewComponent.BaseBuildingInstance.Blueprint.BuildingType & BuildingType.Floor) != 0)
				{
					num++;
				}
				if ((float)num > MonoSingleton<World>.Instance.LayerLevel)
				{
					return false;
				}
			}
			else if (hit.transform.gameObject.GetComponent<RoofViewComponent>() != null)
			{
				return false;
			}
			return true;
		}
	}
}
