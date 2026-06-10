using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	public class OperateSiegeWeaponInstance
	{
		private enum Phase
		{
			None = 0,
			Constructing = 1,
			Reloading = 2,
			PrimingWeapon = 3,
			Firing = 4,
			Error = 5
		}

		private CommanderAgentProxy agent;

		private List<IDamageTakingAgent> artilleryTargets;

		private VillageMap map;

		private CommanderAIUnit unit;

		private List<Vec3Int> plannedConstructionPoints;

		private string toConstructBlueprintId;

		private BaseBuildingInstance toFinishConstructingBuilding;

		private List<BaseBuildingInstance> availableSiegeWeapons;

		private IList<MapNode> constructionPoints;

		private OrderBase orderToAssign;

		private Phase phase;

		private BaseBuildingInstance assignedSiegeWeaponBuilding;

		private SiegeWeaponComponentInstance assignedSiegeWeapon;

		private ResourcePileInstance ammoResourcePile;

		private IDamageTakingAgent currentTarget;

		public bool ShouldEndAction { get; private set; }

		public CommanderAIUnit Unit => unit;

		public OperateSiegeWeaponInstance(List<BaseBuildingInstance> availableSiegeWeapons, CommanderAgentProxy agent, List<IDamageTakingAgent> artilleryTargets, VillageMap map, CommanderAIUnit unit, List<Vec3Int> plannedConstructionPoints)
		{
			this.availableSiegeWeapons = availableSiegeWeapons;
			this.agent = agent;
			this.artilleryTargets = artilleryTargets;
			this.map = map;
			this.unit = unit;
			this.plannedConstructionPoints = plannedConstructionPoints;
		}

		public OperateSiegeWeaponInstance(List<BaseBuildingInstance> availableSiegeWeapons, CommanderAgentProxy agent, List<IDamageTakingAgent> artilleryTargets, VillageMap map, CommanderAIUnit unit, List<Vec3Int> plannedConstructionPoints, string toConstructBlueprintId, IList<MapNode> constructionPoints)
			: this(availableSiegeWeapons, agent, artilleryTargets, map, unit, plannedConstructionPoints)
		{
			this.toConstructBlueprintId = toConstructBlueprintId;
			this.constructionPoints = constructionPoints;
		}

		public OperateSiegeWeaponInstance(List<BaseBuildingInstance> availableSiegeWeapons, CommanderAgentProxy agent, List<IDamageTakingAgent> artilleryTargets, VillageMap map, CommanderAIUnit unit, List<Vec3Int> plannedConstructionPoints, BaseBuildingInstance toFinishConstructingBuilding)
			: this(availableSiegeWeapons, agent, artilleryTargets, map, unit, plannedConstructionPoints)
		{
			this.toFinishConstructingBuilding = toFinishConstructingBuilding;
		}

		public bool InitThread()
		{
			if (CombatUtils.IsNullOrDisposed(unit.Humanoid))
			{
				return false;
			}
			BaseBuildingInstance baseBuildingInstance = toFinishConstructingBuilding;
			bool isEnabled;
			if (baseBuildingInstance != null)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(74, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Siege weapon is already under construction, finish it. Building: ");
					messageBuilder.AppendFormatted(baseBuildingInstance);
					messageBuilder.AppendLiteral(", agent: ");
					messageBuilder.AppendFormatted(unit.Humanoid);
				}
				Log.Trace(messageBuilder);
				phase = Phase.Constructing;
				ConstructBuildingOrder constructBuildingOrder = new ConstructBuildingOrder(baseBuildingInstance.BlueprintId, baseBuildingInstance.GridDataPosition, (int)baseBuildingInstance.Angle, isSiegeWeapon: true);
				plannedConstructionPoints.Add(constructBuildingOrder.Position);
				orderToAssign = constructBuildingOrder;
			}
			else if (toConstructBlueprintId != null)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(73, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Siege weapon needs to be constructed from scratch. BlueprintId: ");
					messageBuilder.AppendFormatted(toConstructBlueprintId);
					messageBuilder.AppendLiteral(", agent: ");
					messageBuilder.AppendFormatted(unit.Humanoid);
				}
				Log.Trace(messageBuilder);
				phase = Phase.Constructing;
				ConstructBuildingOrder constructBuildingOrder2 = GenerateConstructNewOrder(toConstructBlueprintId, 0);
				if (constructBuildingOrder2 == null)
				{
					FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(63, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Failed to generate construct siege weapon order for '");
						messageBuilder2.AppendFormatted(toConstructBlueprintId);
						messageBuilder2.AppendLiteral("', agent: ");
						messageBuilder2.AppendFormatted(unit.Humanoid);
					}
					Log.Error(messageBuilder2);
					return false;
				}
				plannedConstructionPoints.Add(constructBuildingOrder2.Position);
				orderToAssign = constructBuildingOrder2;
			}
			else
			{
				phase = Phase.Reloading;
				BaseBuildingInstance baseBuildingInstance2 = availableSiegeWeapons.MinItem((BaseBuildingInstance building) => building.WorldPosition.DistanceSquared(unit.Humanoid.GetPosition()));
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(50, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Siege weapon is ready, man it. Building: ");
					messageBuilder.AppendFormatted(baseBuildingInstance2);
					messageBuilder.AppendLiteral(", agent: ");
					messageBuilder.AppendFormatted(unit.Humanoid);
				}
				Log.Trace(messageBuilder);
				if (baseBuildingInstance2 == null)
				{
					FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(90, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("No siege weapons left to construct, but can't find an available weapon for artillery unit ");
						messageBuilder2.AppendFormatted(unit.Humanoid);
					}
					Log.Error(messageBuilder2);
					return false;
				}
				availableSiegeWeapons.Remove(baseBuildingInstance2);
				assignedSiegeWeaponBuilding = baseBuildingInstance2;
				assignedSiegeWeapon = baseBuildingInstance2.GetComponentInstance<SiegeWeaponComponentInstance>();
			}
			return true;
		}

		private ConstructBuildingOrder GenerateConstructNewOrder(string blueprintId, int angle)
		{
			BaseBuildingBlueprint byID = Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID(blueprintId);
			SiegeWeaponComponentBlueprint byID2 = Repository<SiegeWeaponComponentRepository, SiegeWeaponComponentBlueprint>.Instance.GetByID(blueprintId);
			float weaponMinRange = byID2.MinRangeRadius;
			float weaponMaxRange = byID2.MaxRangeRadius;
			MapNode unitNode = unit.Humanoid.GetNode();
			using PooledList<MapNode> pooledList = constructionPoints.ScoreItems(delegate(MapNode mapNode)
			{
				if (mapNode.IsWater || !PathfinderUtil.IsPathPossible(unit.Humanoid, mapNode) || GridDataIndexTools.IsForbiddenEdge(mapNode.Position))
				{
					return float.MinValue;
				}
				float num = 0f;
				num -= Vector3.Distance(unitNode.WorldPosition, mapNode.WorldPosition);
				foreach (IDamageTakingAgent artilleryTarget in artilleryTargets)
				{
					if (SiegeWeaponUtil.IsTargetInRange(weaponMinRange, weaponMaxRange, mapNode.WorldPosition, artilleryTarget.GetPosition()))
					{
						float num2 = weaponMaxRange - weaponMinRange;
						float num3 = (weaponMaxRange + weaponMinRange) / 2f;
						float num4 = Vector3.Distance(mapNode.WorldPosition, artilleryTarget.GetPosition());
						float num5 = 1f - Mathf.Min(1f, Mathf.Abs(num3 - num4) / (num2 / 2f));
						float num6 = 10000f * num5;
						float num7 = mapNode.Position.y - artilleryTarget.GetGridPosition().y;
						num7 = ((!(num7 < 0f)) ? (num7 * 500f) : (num7 * 1000f));
						num += num6 + num7;
					}
				}
				return num;
			});
			foreach (MapNode node in pooledList)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder;
				if (!map.BuildingsManagerMain.CanPlaceEnemyBuilding(byID, node.Position, angle))
				{
					messageBuilder = new FVLogTraceInterpolationHandler(18, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Can't place '");
						messageBuilder.AppendFormatted(blueprintId);
						messageBuilder.AppendLiteral("' at ");
						messageBuilder.AppendFormatted(node.Position);
					}
					Log.Trace(messageBuilder);
					continue;
				}
				if (plannedConstructionPoints.AnyNonAlloc((Vec3Int position) => position.Distance(node.Position) < 10f))
				{
					messageBuilder = new FVLogTraceInterpolationHandler(58, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Can place '");
						messageBuilder.AppendFormatted(blueprintId);
						messageBuilder.AppendLiteral("' at ");
						messageBuilder.AppendFormatted(node.Position);
						messageBuilder.AppendLiteral(", but is too close to other planned weapon");
					}
					Log.Trace(messageBuilder);
					continue;
				}
				messageBuilder = new FVLogTraceInterpolationHandler(16, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Construct '");
					messageBuilder.AppendFormatted(blueprintId);
					messageBuilder.AppendLiteral("' at ");
					messageBuilder.AppendFormatted(node.Position);
				}
				Log.Trace(messageBuilder);
				return new ConstructBuildingOrder(blueprintId, node.Position, angle, isSiegeWeapon: true);
			}
			return null;
		}

		public void OnDoneCallback()
		{
			if (orderToAssign != null)
			{
				unit.CurrentOrder = orderToAssign;
			}
		}

		public void OnBlueprintPlaced(BaseBuildingInstance building)
		{
			if (phase != Phase.Constructing)
			{
				return;
			}
			ConstructBuildingOrder constructBuildingOrder = (ConstructBuildingOrder)unit.CurrentOrder;
			if (building.BlueprintId == constructBuildingOrder.BlueprintId && building.GridDataPosition == constructBuildingOrder.Position && (int)building.Angle == constructBuildingOrder.YAngle)
			{
				if (!building.Map.CommanderAIManager.HasDeployedSiegeWeapons())
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("enemy_siege_weapon_bbt"));
				}
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(65, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint placed, adding siege weapon to unit group from order '");
					messageBuilder.AppendFormatted(constructBuildingOrder);
					messageBuilder.AppendLiteral("'");
				}
				Log.Trace(messageBuilder);
				SpawnAmmoAroundWeapon(building);
				agent.Agent.UnitGroup.AddSiegeWeapon(building);
				assignedSiegeWeaponBuilding = building;
			}
		}

		public void OnBuildingFinished(BaseBuildingInstance building)
		{
			if (phase != Phase.Constructing)
			{
				return;
			}
			bool isEnabled;
			if (!(unit.CurrentOrder is ConstructBuildingOrder constructBuildingOrder))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(124, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Phase was ");
					messageBuilder.AppendFormatted(Phase.Constructing);
					messageBuilder.AppendLiteral(", and a building was finished, but the unit didn't have a construct order - entering error state for this instance");
				}
				Log.Error(messageBuilder);
				phase = Phase.Error;
			}
			else if (building.BlueprintId == constructBuildingOrder.BlueprintId && building.GridDataPosition == constructBuildingOrder.Position && (int)building.Angle == constructBuildingOrder.YAngle)
			{
				FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(42, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Siege weapon building finished by order '");
					messageBuilder2.AppendFormatted(constructBuildingOrder);
					messageBuilder2.AppendLiteral("'");
				}
				Log.Trace(messageBuilder2);
				assignedSiegeWeaponBuilding = building;
				assignedSiegeWeapon = building.GetComponentInstance<SiegeWeaponComponentInstance>();
				phase = Phase.Reloading;
			}
		}

		private void SpawnAmmoAroundWeapon(BaseBuildingInstance building)
		{
			(string resourceId, int count) ammoInfo = Repository<SiegeWeaponSettingsData, SiegeWeaponSettings>.Instance.GetData<SiegeWeaponSettings>().GetAmmoInfo(building.BlueprintId);
			string item = ammoInfo.resourceId;
			int item2 = ammoInfo.count;
			ResourceInstance resource = new ResourceInstance(Repository<ResourceRepository, Resource>.Instance.GetByID(item), item2);
			MonoSingleton<ResourcePileManager>.Instance.SpawnEnemyPile(resource, building.GetFirstReachablePosition(unit.Humanoid).ToVector3World());
		}

		public bool Tick()
		{
			bool isEnabled;
			if (phase == Phase.Error)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Error phase, ending instance, agent: ");
					messageBuilder.AppendFormatted(unit.Humanoid);
				}
				Log.Trace(messageBuilder);
				return false;
			}
			if (unit.Humanoid.HasDiedOrFainted || unit.Humanoid.HasDisposed)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Unit died, ending action, agent: ");
					messageBuilder.AppendFormatted(unit.Humanoid);
				}
				Log.Trace(messageBuilder);
				ShouldEndAction = true;
				return false;
			}
			if (assignedSiegeWeaponBuilding != null && assignedSiegeWeaponBuilding.HasDisposed)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(47, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Siege weapon destroyed, ending action, weapon: ");
					messageBuilder.AppendFormatted(assignedSiegeWeaponBuilding);
				}
				Log.Trace(messageBuilder);
				return false;
			}
			if (assignedSiegeWeapon != null)
			{
				if (currentTarget == null || CombatAiUtils.IsAgentDefeated(currentTarget))
				{
					RepickTarget();
				}
				if (currentTarget == null)
				{
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(48, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Failed to find a target for siege weapon ");
						messageBuilder.AppendFormatted(assignedSiegeWeaponBuilding?.Blueprint.GetID());
						messageBuilder.AppendLiteral(" at ");
						messageBuilder.AppendFormatted(assignedSiegeWeaponBuilding?.GridDataPosition);
						messageBuilder.AppendLiteral(" (");
						messageBuilder.AppendFormatted(assignedSiegeWeaponBuilding?.Storage);
						messageBuilder.AppendLiteral(")");
					}
					Log.Trace(messageBuilder);
					return false;
				}
			}
			switch (phase)
			{
			case Phase.Reloading:
				isEnabled = TickReloading();
				return isEnabled;
			case Phase.PrimingWeapon:
				isEnabled = TickPrimingWeapon();
				return isEnabled;
			case Phase.Firing:
				isEnabled = TickFiring();
				return isEnabled;
			default:
				isEnabled = true;
				return isEnabled;
			}
		}

		private void RepickTarget()
		{
			currentTarget = null;
			if (artilleryTargets.Count == 0)
			{
				Log.Trace("No more artillery targets available", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
				return;
			}
			IDamageTakingAgent target = artilleryTargets.PickRandom();
			for (int i = 0; i < artilleryTargets.Count; i++)
			{
				if (!CanAttackTarget(target))
				{
					target = artilleryTargets.PickRandom();
					continue;
				}
				currentTarget = target;
				break;
			}
		}

		private bool TickReloading()
		{
			if (assignedSiegeWeapon == null)
			{
				return false;
			}
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder;
			if (assignedSiegeWeapon.HasAmmunition())
			{
				messageBuilder = new FVLogTraceInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Switching to priming weapon ");
					messageBuilder.AppendFormatted(unit.Humanoid);
				}
				Log.Trace(messageBuilder);
				phase = Phase.PrimingWeapon;
				ammoResourcePile = null;
				return true;
			}
			if (ammoResourcePile != null)
			{
				return true;
			}
			if (!HasAmmoNearBy())
			{
				messageBuilder = new FVLogTraceInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("No ammo left, failing action ");
					messageBuilder.AppendFormatted(unit.Humanoid);
				}
				Log.Trace(messageBuilder);
				return false;
			}
			messageBuilder = new FVLogTraceInterpolationHandler(39, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(assignedSiegeWeapon.Blueprint.GetID());
				messageBuilder.AppendLiteral(" has no ammo at ");
				messageBuilder.AppendFormatted(assignedSiegeWeapon.GridPosition);
				messageBuilder.AppendLiteral(" (");
				messageBuilder.AppendFormatted(assignedSiegeWeapon.Storage);
				messageBuilder.AppendLiteral("), searching for pile");
			}
			Log.Trace(messageBuilder);
			float num = 10f;
			foreach (MapNode item in FloodFillUtil.IterateFloodFillConnections(assignedSiegeWeapon.OwnerBuilding.GetNode(), num))
			{
				if (item.IsWalkable && PathfinderUtil.IsPathPossible(unit.Humanoid, item) && item.GetWorldObject(WorldObjectType.ResourcePile) is ResourcePileInstance resourcePileInstance)
				{
					messageBuilder = new FVLogTraceInterpolationHandler(0, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(resourcePileInstance);
					}
					Log.Trace(messageBuilder);
					if (assignedSiegeWeapon.ResourcesFilter.IsValid(resourcePileInstance.GetStoredResource()))
					{
						ammoResourcePile = resourcePileInstance;
						break;
					}
					messageBuilder = new FVLogTraceInterpolationHandler(51, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Pile doesn't pass resource filter, pile: ");
						messageBuilder.AppendFormatted(resourcePileInstance);
						messageBuilder.AppendLiteral(", filter: ");
						messageBuilder.AppendFormatted(assignedSiegeWeapon.ResourcesFilter);
					}
					Log.Trace(messageBuilder);
				}
			}
			if (ammoResourcePile == null)
			{
				messageBuilder = new FVLogTraceInterpolationHandler(61, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Ammo not found within search radius ");
					messageBuilder.AppendFormatted(num);
					messageBuilder.AppendLiteral(" for siege weapon ");
					messageBuilder.AppendFormatted(assignedSiegeWeaponBuilding.Blueprint.GetID());
					messageBuilder.AppendLiteral(" at ");
					messageBuilder.AppendFormatted(assignedSiegeWeapon.GridPosition);
					messageBuilder.AppendLiteral(" (");
					messageBuilder.AppendFormatted(assignedSiegeWeaponBuilding.Storage);
					messageBuilder.AppendLiteral(")");
				}
				Log.Trace(messageBuilder);
				return false;
			}
			messageBuilder = new FVLogTraceInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Giving deliver ammo order to ");
				messageBuilder.AppendFormatted(unit.Humanoid);
			}
			Log.Trace(messageBuilder);
			unit.CurrentOrder = new DeliverSiegeWeaponAmmoOrder(assignedSiegeWeapon, ammoResourcePile);
			return true;
		}

		private bool HasAmmoNearBy()
		{
			foreach (MapNode item in FloodFillUtil.IterateFloodFillConnections(assignedSiegeWeaponBuilding.GetNode(), 10f))
			{
				ResourcePileInstance pileByGridPosition = MonoSingleton<ResourcePileManager>.Instance.GetPileByGridPosition(item.Position);
				if (pileByGridPosition != null && assignedSiegeWeapon.ResourcesFilter.IsValid(pileByGridPosition.GetStoredResource()))
				{
					return true;
				}
			}
			return false;
		}

		private bool TickPrimingWeapon()
		{
			if (assignedSiegeWeapon == null)
			{
				return false;
			}
			SiegeWeaponComponentInstance siegeWeaponComponentInstance = assignedSiegeWeapon;
			bool isEnabled;
			if (!siegeWeaponComponentInstance.HasAmmunition())
			{
				phase = Phase.Reloading;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(76, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Weapon is somehow without ammo while in priming phase, going back to reload ");
					messageBuilder.AppendFormatted(unit.Humanoid);
				}
				Log.Trace(messageBuilder);
				return true;
			}
			if (siegeWeaponComponentInstance.IsOperatorReady)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Weapon is primed, giving attack order to ");
					messageBuilder.AppendFormatted(unit.Humanoid);
				}
				Log.Trace(messageBuilder);
				phase = Phase.Firing;
				unit.CurrentOrder = new AttackOrder(currentTarget, siegeWeaponComponentInstance);
				return true;
			}
			if (!(unit.CurrentOrder is OperateSiegeWeaponOrder operateSiegeWeaponOrder) || operateSiegeWeaponOrder.SiegeWeaponComponentInstance != siegeWeaponComponentInstance)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Giving operate siege weapon order to ");
					messageBuilder.AppendFormatted(unit.Humanoid);
				}
				Log.Trace(messageBuilder);
				unit.CurrentOrder = new OperateSiegeWeaponOrder(siegeWeaponComponentInstance);
				return true;
			}
			return true;
		}

		private bool TickFiring()
		{
			if (assignedSiegeWeapon == null)
			{
				return false;
			}
			if (!assignedSiegeWeapon.HasAmmunition())
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\OperateSiegeWeaponInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Done firing, going to reloading ");
					messageBuilder.AppendFormatted(unit.Humanoid);
				}
				Log.Trace(messageBuilder);
				phase = Phase.Reloading;
				return true;
			}
			return true;
		}

		private bool CanAttackTarget(IDamageTakingAgent target)
		{
			if (assignedSiegeWeapon == null || assignedSiegeWeaponBuilding == null || assignedSiegeWeaponBuilding.HasDisposed)
			{
				return false;
			}
			if (!assignedSiegeWeapon.IsTargetOutOfRange(target.GetPosition(), showMessage: false))
			{
				return !CombatAiUtils.IsAgentDefeated(target);
			}
			return false;
		}
	}
}
