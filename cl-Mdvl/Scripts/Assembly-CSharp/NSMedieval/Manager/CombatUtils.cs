using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Manager
{
	public static class CombatUtils
	{
		private static int raycastMask;

		private static WalkableModel workerNoDoorsModel;

		private static readonly RaycastHit[] RaycastHitBuffer = new RaycastHit[15];

		private static int RaycastMask
		{
			get
			{
				if (raycastMask == 0)
				{
					raycastMask = (1 << LayerMask.NameToLayer("VoxelMap")) | (1 << LayerMask.NameToLayer("Obstacle")) | (1 << LayerMask.NameToLayer("CombatCover")) | (1 << LayerMask.NameToLayer("VoxelMapPathfinding"));
				}
				return raycastMask;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			workerNoDoorsModel = null;
			raycastMask = 0;
			int i = 0;
			for (int num = RaycastHitBuffer.Length; i < num; i++)
			{
				RaycastHitBuffer[i] = default(RaycastHit);
			}
		}

		public static bool CheckIsInCombat(IDamageDealAgent agent)
		{
			if (agent?.CombatAi?.IsStateSet(CombatAiState.Fainted) ?? true)
			{
				return false;
			}
			long state = agent.CombatAi.GetState<long>(CombatAiState.LastDamageTakenTime);
			if (state <= 0)
			{
				return false;
			}
			float state2 = agent.CombatAi.GetState<float>(CombatAiState.LastAttackTime);
			float timeSinceStartup = TimerController.TimeSinceStartup;
			if (state2 > 0.15f && timeSinceStartup - state2 < 3f)
			{
				return true;
			}
			IDamageDealAgent state3 = agent.CombatAi.GetState<IDamageDealAgent>(CombatAiState.LastDamageTakenFrom);
			if (state3 == null)
			{
				return false;
			}
			if (Vector3.Distance(state3.GetPosition(), agent.GetPosition()) <= 5f)
			{
				return true;
			}
			if (timeSinceStartup - (float)state < 8f)
			{
				return true;
			}
			return false;
		}

		public static bool CanBeTargeted(IDamageTakingAgent agent)
		{
			if (agent == null || agent.HasDisposed || agent.HasDied)
			{
				return false;
			}
			return true;
		}

		public static bool IsAgentOnLadder(IDamageCommonAgent agent)
		{
			return (agent?.PathDriver)?.IsClimbing ?? false;
		}

		public static bool IsAlive(IDamageCommonAgent agent)
		{
			if (agent != null && !agent.HasDisposed && !agent.HasDied)
			{
				return agent.Stats != null;
			}
			return false;
		}

		public static bool IsNullOrDisposed(IDamageCommonAgent agent)
		{
			return agent?.HasDisposed ?? true;
		}

		public static bool IsNullOrDisposed(IGoapAgentOwner agent)
		{
			return agent?.HasDisposed ?? true;
		}

		public static bool IsNullOrDisposed(CreatureBase agent)
		{
			return agent?.HasDisposed ?? true;
		}

		public static bool IsNullOrDisposed(IPathfindingAgent agent)
		{
			return agent?.HasDisposed ?? true;
		}

		public static bool IsNullOrDisposed(IDamageCommonAgent agent1, IDamageCommonAgent agent2)
		{
			if (agent1 != null && !agent1.HasDisposed && agent2 != null)
			{
				return agent2.HasDisposed;
			}
			return true;
		}

		public static bool IsNullOrDisposed(IPathfindingAgent agent1, IGoapTargetable agent2)
		{
			if (agent1 != null && !agent1.HasDisposed && agent2 != null)
			{
				return agent2.HasDisposed;
			}
			return true;
		}

		public static bool IsNullOrDisposed(CreatureBase agent1, CreatureBase agent2)
		{
			if (agent1 != null && !agent1.HasDisposed && agent2 != null)
			{
				return agent2.HasDisposed;
			}
			return true;
		}

		public static bool IsNullOrDisposed(IPathfindingAgent agent1, IPathfindingAgent agent2)
		{
			if (agent1 != null && !agent1.HasDisposed && agent2 != null)
			{
				return agent2.HasDisposed;
			}
			return true;
		}

		public static bool IsNullOrDisposed(IGoapAgentOwner agent1, CreatureBase agent2)
		{
			if (agent1 != null && !agent1.HasDisposed && agent2 != null)
			{
				return agent2.HasDisposed;
			}
			return true;
		}

		public static void SetWeaponVisibility(IDamageDealAgent agent, bool isVisible)
		{
			agent.SetWeaponVisibility(isVisible & agent.ForbidWeapon);
		}

		public static EquipmentInstance GetWeapon(IDamageCommonAgent agent, bool ignoreForbidden = false)
		{
			if (agent == null)
			{
				return null;
			}
			List<EquipmentInstance> equipment = agent.GetEquipment();
			if (equipment == null || (!ignoreForbidden && agent is IDamageDealAgent { ForbidWeapon: not false }))
			{
				return null;
			}
			EquipmentInstance equipmentInstance = equipment.FirstOrDefault((EquipmentInstance item) => item.Blueprint.ItemType == ItemType.Weapon);
			if (equipmentInstance == null)
			{
				return null;
			}
			if (!ignoreForbidden && IsAgentOnLadder(agent) && equipmentInstance.WeaponTypeSettings.AttackType != AttackType.Melee)
			{
				return null;
			}
			return equipmentInstance;
		}

		public static bool IsAgentSwimming(IDamageCommonAgent agent)
		{
			MapNode mapNode = agent?.GetNode();
			if (mapNode != null && mapNode.IsWater)
			{
				return !VillageManager.ActiveVillage.Map.WaterManager.CanWalkInside(mapNode);
			}
			return false;
		}

		public static AttackType GetAttackType(IDamageDealAgent damageDealAgent, WeaponMode weaponModeOverride = null)
		{
			return (weaponModeOverride ?? GetWeapon(damageDealAgent)?.ActiveWeaponMode)?.WeaponTypeSettings.AttackType ?? AttackType.Melee;
		}

		public static bool HasRangedWeapon(IDamageDealAgent damageDealAgent)
		{
			EquipmentInstance weapon = GetWeapon(damageDealAgent, ignoreForbidden: true);
			if (weapon?.Blueprint.PrimaryWeaponMode == null)
			{
				return false;
			}
			if (weapon.Blueprint.SecondaryWeaponMode == null)
			{
				return weapon.Blueprint.PrimaryWeaponMode.WeaponTypeSettings.AttackType != AttackType.Melee;
			}
			if (weapon.Blueprint.PrimaryWeaponMode.WeaponTypeSettings.AttackType == AttackType.Melee)
			{
				return weapon.Blueprint.SecondaryWeaponMode.WeaponTypeSettings.AttackType != AttackType.Melee;
			}
			return true;
		}

		public static float GetRange(IDamageDealAgent agent, IDamageTakingAgent target, WeaponMode weaponModeOverride = null)
		{
			float num = CombatCalculator.CalculateAttackRange(agent, weaponModeOverride);
			if (target == null)
			{
				return num;
			}
			if (agent.GetPosition().y - target.GetPosition().y >= 1f && GetAttackType(agent, weaponModeOverride) != AttackType.Melee)
			{
				num *= 1.2f;
			}
			Vector3 position = agent.GetPosition();
			Vector3 position2 = target.GetPosition();
			if (Mathf.Approximately(position.x, position2.x) && Mathf.Approximately(position.z, position2.z) && IsAgentOnLadder(agent))
			{
				num += 1f;
			}
			return num;
		}

		public static bool IsInAttackRange(IDamageDealAgent agent, IDamageTakingAgent target, float maxHeight = -1f, WeaponMode weaponModeOverride = null, MapNode agentNodeOverride = null)
		{
			using (ProfilerSampleJanitor.Begin("IsInAttackRange"))
			{
				if (IsNullOrDisposed(agent, target))
				{
					return false;
				}
				MapNode mapNode = agentNodeOverride ?? agent.GetNode();
				Vector3 a = agentNodeOverride?.WorldPosition ?? agent.GetPosition();
				float y = mapNode.WorldPosition.y;
				Vector3 position = target.GetPosition();
				bool isEnabled;
				if (maxHeight > 0f && Mathf.Abs(y - position.y) > maxHeight)
				{
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(49, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatUtils.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("IsInRange false because of max height diff, ");
						messageBuilder.AppendFormatted(Mathf.Abs(y - position.y));
						messageBuilder.AppendLiteral(" > ");
						messageBuilder.AppendFormatted(maxHeight);
						messageBuilder.AppendLiteral(", ");
						messageBuilder.AppendFormatted(agent);
					}
					Log.Trace(messageBuilder);
					return false;
				}
				if (target is BaseBuildingInstance building)
				{
					return IsInAttackRangeBuilding(agent, building, maxHeight, weaponModeOverride);
				}
				float range = GetRange(agent, target, weaponModeOverride);
				float num = (((GetAttackType(agent, weaponModeOverride) == AttackType.Melee || !(y - position.y > 0f)) && !target.GetNode().IsLayerRamp() && !mapNode.IsLayerRamp()) ? Vector3.Distance(a, position) : a.DistanceXZ(position));
				bool num2 = num - range < 0.3f;
				if (!num2)
				{
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(31, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatUtils.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Not in range, distance ");
						messageBuilder.AppendFormatted(num);
						messageBuilder.AppendLiteral(", range ");
						messageBuilder.AppendFormatted(range);
					}
					Log.Trace(messageBuilder);
				}
				return num2;
			}
		}

		public static bool IsAttackPossible(IDamageDealAgent agent, IDamageTakingAgent target)
		{
			if (agent == null || !IsAlive(target))
			{
				return false;
			}
			if ((agent.CanAttackTypes() & target.DamageAgentType) == 0)
			{
				return false;
			}
			if (CombatCalculator.CalculateDamage(agent, target, isCritical: false) <= 0f)
			{
				return false;
			}
			return true;
		}

		public static bool IsValidToFocus(IDamageDealAgent deal, IDamageTakingAgent target)
		{
			if (IsNullOrDisposed(deal, target))
			{
				return false;
			}
			if (IsAgentOnLadder(target) && MonoSingleton<CombatTargetManager>.Instance.CountPreferedAttackers(target) >= 2)
			{
				return false;
			}
			return true;
		}

		public static List<IDamageTakingAgent> GetTargetsInRange(Vector3 position, float range, Func<IDamageTakingAgent, bool> filter = null, DamageTakingAgentType type = DamageTakingAgentType.All)
		{
			return MonoSingleton<CombatAgentManager>.Instance.DamageTakingAgentsSafeForEach(type, (IDamageTakingAgent agent) => Vector3.Distance(position, agent.GetPosition()) <= range && (filter == null || filter(agent)));
		}

		public static List<IDamageTakingAgent> GetTargetsInRangeForSiegeWeapon(Vector3 position, float range, Func<IDamageTakingAgent, bool> filter = null, DamageTakingAgentType type = DamageTakingAgentType.All)
		{
			return MonoSingleton<CombatAgentManager>.Instance.DamageTakingAgentsSafeForEach(type, delegate(IDamageTakingAgent agent)
			{
				if (agent is BaseBuildingInstance { HasDisposed: false } baseBuildingInstance)
				{
					if (!string.IsNullOrEmpty(baseBuildingInstance.Blueprint.SiegeWeaponComponentID))
					{
						if (baseBuildingInstance.IsInBounds(position.ToGridVec3Int()))
						{
							if (filter != null)
							{
								return filter(agent);
							}
							return true;
						}
						return false;
					}
					if (Mathf.Approximately(baseBuildingInstance.Blueprint.BoxColliderSettings.SizeOffset.y, World.MapBlockHeight) && Mathf.Abs(Vector3.Distance(position, agent.GetPosition()) - range) <= 0.2f)
					{
						if (filter != null)
						{
							return filter(agent);
						}
						return true;
					}
				}
				return Vector3.Distance(position, agent.GetPosition()) <= range && (filter == null || filter(agent));
			});
		}

		public static List<IDamageDealAgent> GetDealAgentsInRange(Vector3 position, float range, Func<IDamageDealAgent, bool> filter)
		{
			return MonoSingleton<CombatAgentManager>.Instance.GetDamageDealAgentsSafe((IDamageDealAgent agent) => Vector3.Distance(position, agent.GetPosition()) <= range && (filter == null || filter(agent)));
		}

		public static bool HasCombatLos(Vector3 attacker, Vector3 target)
		{
			using (ProfilerSampleJanitor.Begin("HasCombatLos"))
			{
				float losObjectsCover = 0f;
				return HasCombatLos(attacker, target, out losObjectsCover);
			}
		}

		public static bool HasCombatLosMainThreadBlocking(Vec3Int attacker, Vec3Int target)
		{
			bool result = false;
			MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThreadBlocking(delegate
			{
				result = HasCombatLos(attacker.ToVector3World(), target.ToVector3World());
			});
			return result;
		}

		private static int RaycastNonAlloc(Vector3 start, Vector3 direction, float rayLength)
		{
			return Physics.RaycastNonAlloc(start, direction, RaycastHitBuffer, rayLength, RaycastMask, QueryTriggerInteraction.Ignore);
		}

		public static float RaycastLosRaw(Vector3 start, Vector3 direction, float rayLength, out MapNode firstNodeHit, out Vector3 firstNodeHitPoint, int ignoreHitsRadiusGridSpace = -1, bool stopAtFirstHit = false)
		{
			direction = direction.normalized;
			firstNodeHit = null;
			firstNodeHitPoint = default(Vector3);
			float num = 0f;
			int num2 = RaycastNonAlloc(start, direction, rayLength);
			Vector3 vector = start + direction * rayLength;
			if (PathfinderUtil.LineOfSightFilters.IgnoreEndNode(vector, RaycastHitBuffer, num2))
			{
				return 0f;
			}
			VillageMap map = VillageManager.ActiveVillage.Map;
			for (int i = 0; i < num2; i++)
			{
				RaycastHit raycastHit = RaycastHitBuffer[i];
				if (i > 0)
				{
					bool flag = false;
					Transform transform = raycastHit.transform;
					for (int num3 = i - 1; num3 >= 0; num3--)
					{
						if (RaycastHitBuffer[num3].transform == transform)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						continue;
					}
				}
				Vector3 extents = raycastHit.collider.bounds.extents;
				float num4 = Mathf.Min(extents.x, extents.y, extents.z, 0.08f);
				Vector3 vector2 = raycastHit.point - raycastHit.normal * num4;
				Vec3Int gridPosition = GridUtils.GetGridPosition(vector2);
				MapNode node = map.GetNode(gridPosition);
				if (node == null)
				{
					num = 2f;
					break;
				}
				if (ignoreHitsRadiusGridSpace > 0 && Vec3Int.Distance(node.Position, start.ToGridVec3Int()) < (float)ignoreHitsRadiusGridSpace)
				{
					continue;
				}
				if (node.GetWorldObject(GridDataType.BuildingFinished | GridDataType.Stairs | GridDataType.Roof | GridDataType.FurnitureGate) is BaseBuildingInstance { ConstructionPhase: ConstructionPhase.Finished } baseBuildingInstance)
				{
					if (baseBuildingInstance.Blueprint.CoverIgnore > 0f && (baseBuildingInstance.GetPosition().DistanceXZ(start) <= baseBuildingInstance.Blueprint.CoverIgnore || baseBuildingInstance.GetPosition().DistanceXZ(vector) <= baseBuildingInstance.Blueprint.CoverIgnore))
					{
						continue;
					}
					if (baseBuildingInstance.GetCover() <= 0f || baseBuildingInstance.GetCover() >= 1f)
					{
						num = 2f;
						if (firstNodeHit == null)
						{
							firstNodeHit = node;
							firstNodeHitPoint = vector2;
						}
						break;
					}
					if (Vector3.Distance(baseBuildingInstance.GetPosition(), start) <= 3f)
					{
						continue;
					}
					num += baseBuildingInstance.GetCover();
					if (num >= 1f)
					{
						if (firstNodeHit == null)
						{
							firstNodeHit = node;
							firstNodeHitPoint = vector2;
						}
						break;
					}
				}
				else
				{
					if (node.IsVoxelAir())
					{
						continue;
					}
					num += 1f;
					if (firstNodeHit == null)
					{
						firstNodeHit = node;
						firstNodeHitPoint = vector2;
						if (stopAtFirstHit)
						{
							break;
						}
					}
				}
			}
			return Mathf.Max(num, 0f);
		}

		public static bool HasCombatLos(Vector3 attacker, Vector3 target, out float losObjectsCover)
		{
			attacker = PushUpToHeadHeight(attacker);
			target = PushUpToHeadHeight(target);
			losObjectsCover = RaycastLosRaw(attacker, target - attacker, Vector3.Distance(attacker, target), out var _, out var _);
			if (losObjectsCover >= 1f)
			{
				losObjectsCover = 0f;
				return false;
			}
			return true;
		}

		public static Vector3 PushUpToHeadHeight(Vector3 pos)
		{
			return pos + CombatConstants.HeadHeightOffset;
		}

		public static float GetMaxHeightDiff(IDamageDealAgent agent, IDamageTakingAgent target)
		{
			if (IsNullOrDisposed(agent, target))
			{
				return 0f;
			}
			if (GetAttackType(agent) == AttackType.Melee)
			{
				MapNode node = agent.GetNode();
				MapNode node2 = target.GetNode();
				if (node.IsSlopeOrStairs() || node2.IsSlopeOrStairs())
				{
					return 3f;
				}
				if (node.IsLadder() && !node2.GetNodeAbove().IsLadder())
				{
					return 3.1f;
				}
				if (node.IsLadder() || node2.IsLadder())
				{
					return 1.4f;
				}
				return 1.2f;
			}
			return -1f;
		}

		public static float GetMaxHeightDiff(IDamageDealAgent agent, IDamageTakingAgent target, MapNode agentAttackNode, bool forceMelee = false)
		{
			if (IsNullOrDisposed(agent, target))
			{
				return 0f;
			}
			if (forceMelee || GetAttackType(agent) == AttackType.Melee)
			{
				MapNode node = target.GetNode();
				if (agentAttackNode.IsSlopeOrStairs() || node.IsSlopeOrStairs())
				{
					return 3f;
				}
				if (agentAttackNode.IsLadder() && node.GetNodeAbove() != null && !node.GetNodeAbove().IsLadder())
				{
					return 3.1f;
				}
				if (agentAttackNode.IsLadder() || node.IsLadder())
				{
					return 1.4f;
				}
				return 1.2f;
			}
			return -1f;
		}

		public static bool IsAttackingDoor(IDamageDealAgent agent)
		{
			IDamageTakingAgent target = agent.GetTarget();
			if (target == null)
			{
				return false;
			}
			if (!(target is BaseBuildingInstance { BuildingType: BuildingType.Door }))
			{
				return false;
			}
			return IsInAttackRange(agent, target);
		}

		public static CombatLadderDirection GetLadderAttackDirection(IDamageDealAgent agent, IDamageTakingAgent target = null)
		{
			if (IsNullOrDisposed(agent))
			{
				return CombatLadderDirection.None;
			}
			if (!agent.PathDriver.IsClimbing)
			{
				return CombatLadderDirection.None;
			}
			if (target == null)
			{
				target = agent.GetTarget();
			}
			if (IsNullOrDisposed(target))
			{
				return CombatLadderDirection.None;
			}
			Vec3Int gridPosition = target.GetGridPosition();
			Vec3Int gridPosition2 = agent.GetGridPosition();
			float y = target.GetPosition().y;
			float y2 = agent.GetPosition().y;
			if (!Mathf.Approximately(y, y2))
			{
				if (y > y2)
				{
					return CombatLadderDirection.Up;
				}
				return CombatLadderDirection.Down;
			}
			if (gridPosition2.z == gridPosition.z)
			{
				if (gridPosition2.x > gridPosition.x)
				{
					return CombatLadderDirection.Left;
				}
				if (gridPosition2.x < gridPosition.x)
				{
					return CombatLadderDirection.Right;
				}
			}
			if (gridPosition2.x == gridPosition.x)
			{
				if (gridPosition2.z > gridPosition.z)
				{
					return CombatLadderDirection.Left;
				}
				if (gridPosition2.z < gridPosition.z)
				{
					return CombatLadderDirection.Right;
				}
			}
			return CombatLadderDirection.None;
		}

		public static bool CanLoadFlammableRound(IDamageDealAgent agent)
		{
			if (IsNullOrDisposed(agent))
			{
				return false;
			}
			MapNode node = agent.GetNode();
			if (node == null)
			{
				return false;
			}
			foreach (MapNode item in node.IterateNeighboursXZAndSelf())
			{
				if (item.Position.y != node.Position.y)
				{
					continue;
				}
				foreach (WorldObject worldObject in item.WorldObjects)
				{
					if (worldObject is BaseBuildingInstance baseBuildingInstance && !(baseBuildingInstance.ThermalModel == null) && baseBuildingInstance.ThermalModel.Emission >= 5)
					{
						return true;
					}
				}
			}
			return false;
		}

		private static bool IsInAttackRangeBuilding(IDamageDealAgent agent, BaseBuildingInstance building, float maxHeight, WeaponMode weaponModeOverride = null)
		{
			Vector3 a = agent.GetPosition().SnapToGrid();
			float range = GetRange(agent, building, weaponModeOverride);
			bool flag = GetAttackType(agent, weaponModeOverride) != AttackType.Melee;
			if ((float)building.Size.x <= 1f && (float)building.Size.z <= 1f)
			{
				Vector3 position = building.GetPosition();
				if (flag && a.y > position.y)
				{
					return a.DistanceXZ(position) <= range;
				}
				return Vector3.Distance(a, position) <= range;
			}
			foreach (Vec3Int position2 in building.Positions)
			{
				Vector3 b = position2.ToVector3World();
				if ((!(maxHeight > 0f) || !(Mathf.Abs(b.y - a.y) > maxHeight)) && (!flag || !(a.y > b.y) || !(a.DistanceXZ(position2.ToVector3World()) > range)) && !(Vector3.Distance(a, b) > range))
				{
					return true;
				}
			}
			return false;
		}

		public static EquipmentInstance GetShield(IDamageCommonAgent agent)
		{
			if (agent == null)
			{
				return null;
			}
			if (agent.GetEquipment() == null)
			{
				return null;
			}
			return agent.GetEquipment().Find(GetShieldFilter);
			static bool GetShieldFilter(EquipmentInstance item)
			{
				if (item.Blueprint.ItemType == ItemType.Armor)
				{
					return (item.Blueprint.EquipmentSlots & (EquipmentSlotType.RightHand | EquipmentSlotType.LeftHand)) != 0;
				}
				return false;
			}
		}

		public static bool PathGoesThroughUnbreachedDoors(MapNode workerNode, MapNode targetNode)
		{
			if ((object)workerNoDoorsModel == null)
			{
				workerNoDoorsModel = Repository<WalkableModelRepository, WalkableModel>.Instance.GetByID("worker_no_doors");
			}
			return !PathfinderUtil.IsPathPossible(workerNoDoorsModel, workerNode, targetNode);
		}

		public static bool IsRanged(IDamageDealAgent damageDealAgent)
		{
			return GetAttackType(damageDealAgent) != AttackType.Melee;
		}
	}
}
