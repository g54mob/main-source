using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.Serialization;
using NSMedieval.Terrain;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("DigMarkerResourceInstance", "")]
	public class DigMarkerResourceInstance : MapResourceInstance
	{
		private DigMarkerResource blueprint;

		private List<Vec3Int> positions;

		private bool dontChangeTerrain;

		[NonSerialized]
		private bool initializedAfterLoad;

		public override bool BlueprintExists => Blueprint != null;

		public DigMarkerResource Blueprint => blueprint = ((blueprint == null) ? Repository<DigMarkerResourceRepository, DigMarkerResource>.Instance.GetByID(blueprintId) : blueprint);

		public override List<Vec3Int> Positions => positions;

		public event Action CancelDigMarkerFromInstanceEvent;

		public DigMarkerResourceInstance(DigMarkerResource blueprint, string prefabId, Vector3 worldPosition, FactionOwnership factionOwnership = FactionOwnership.Player)
			: base(blueprint.GetID(), prefabId, worldPosition, GridDataType.DigMarkerResourceToMine)
		{
			initializedAfterLoad = true;
			positions = new List<Vec3Int>();
			this.blueprint = blueprint;
			SetCurrentOrder(Blueprint.AutoStartOrder);
			SetStats(ResourceStatsProducer.ProduceMapResourceStats(this, blueprint.BaseHealth));
			SetFaction(factionOwnership);
		}

		public void Cancel()
		{
			this.CancelDigMarkerFromInstanceEvent?.Invoke();
		}

		public override void SetupWorldObject(Vector3 worldPosition)
		{
			base.SetupWorldObject(worldPosition);
			SetReachability(new ReachabilityInfo(new IntRange(-1, 0)));
			CalculateReachability(ReachabilityBuildingCheck);
		}

		public override void ReCalculateReachability()
		{
			CalculateReachability(ReachabilityBuildingCheck);
		}

		public void SetPositions(List<Vec3Int> positions)
		{
			this.positions = positions;
			CalculateReachability(ReachabilityBuildingCheck);
		}

		public override MapResource GetBlueprint()
		{
			return Blueprint;
		}

		public override OrderType GetPossibleOrders()
		{
			return Blueprint.OrderTypes;
		}

		public override HarvestParametars GetMiningParameters()
		{
			return Blueprint.GetMiningParameters();
		}

		public override List<ResourceInstance> GetAvailableResources(OrderType orders = OrderType.None)
		{
			if (orders == OrderType.None || Blueprint.OrderTypes.HasFlag(orders))
			{
				return Blueprint.StoredResources;
			}
			return null;
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				UnsubscribeFromEvents();
				base.Dispose();
			}
		}

		public void OnMapLoaded(bool fromSave)
		{
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			ReCalculateReachability();
			base.Map.BuildingsManagerMain.ConstructionJobManager.CreateDigJobs(this);
		}

		public void DontChangeTerrain()
		{
			dontChangeTerrain = true;
		}

		public bool OnDigCycleEnd()
		{
			if (dontChangeTerrain)
			{
				GetSlope()?.OnDigCanceled();
				dontChangeTerrain = false;
				MonoSingleton<ResourceCommonController>.Instance.DestroyResource(this);
				Dispose();
				return true;
			}
			if (blueprint.OrderTypes.HasFlag(OrderType.Digging) && !(((int)base.WorldPosition.y / World.MapBlockHeight == MonoSingleton<World>.Instance.SizeY) ? MonoSingleton<GroundManager>.Instance.OnDigActionCompleted(base.GridDataPosition) : MonoSingleton<GroundManager>.Instance.OnDigActionCompleted(base.GridDataPosition - Vec3Int.up)))
			{
				return false;
			}
			MonoSingleton<GroundController>.Instance.PlayDugHoleGroundParticles(this);
			MonoSingleton<ResourceCommonController>.Instance.DestroyResource(this);
			Dispose();
			return true;
		}

		public override void ReInstantiate()
		{
			if (!initializedAfterLoad)
			{
				if (positions == null)
				{
					positions = new List<Vec3Int>();
				}
				initializedAfterLoad = true;
				ResourceStatsProducer.ProduceMapResourceStats(this, Blueprint.BaseHealth, base.Stats);
				base.ReInstantiate();
			}
		}

		public MapNode GetGridSpaceBelow()
		{
			Vec3Int vec3Int = base.GridDataPosition + Vec3Int.down;
			return VillageManager.ActiveVillage.Map.GetNode(vec3Int.x, vec3Int.y, vec3Int.z);
		}

		public override bool OnOrderFail(OrderType order)
		{
			if (!blueprint.OrderTypes.HasFlag(order))
			{
				return false;
			}
			DamagePopup.Create(base.WorldPosition, MonoSingleton<LocalizationController>.Instance.GetText("dig_failed"));
			bool flag = false;
			SlopeInstance slope = GetSlope();
			if (slope != null)
			{
				if (slope.OnDigActionCompleted())
				{
					MonoSingleton<SlopeManager>.Instance.ForceRemoveSlope(slope);
					flag = true;
					base.Map.BuildingsManagerMain.ConstructionJobManager.RemoveDigJobs(this);
				}
			}
			else if (MonoSingleton<GroundManager>.Instance.OnDigActionCompleted(base.GridDataPosition - Vec3Int.up))
			{
				MonoSingleton<GroundManager>.Instance.DamageVoxel(base.GridDataPosition, 0);
				flag = true;
			}
			if (flag)
			{
				MonoSingleton<ResourceCommonController>.Instance.DestroyResource(this);
			}
			return true;
		}

		public override float GetBeautyInput()
		{
			return 0f;
		}

		public int GetNumberOfSameLevelReachablePositions(ISet<Vec3Int> reachablePositions, bool skipFireNodes = true)
		{
			int num = 0;
			foreach (Vec3Int reachablePosition in reachablePositions)
			{
				WaterDepthLevel waterLevelAsDepth = base.Map.WaterManager.GetWaterLevelAsDepth(reachablePosition);
				if (waterLevelAsDepth == WaterDepthLevel.Medium || waterLevelAsDepth == WaterDepthLevel.High)
				{
					continue;
				}
				if (skipFireNodes)
				{
					int num2 = GridDataIndexTools.FastTo1DIndex(reachablePosition);
					if (num2 != -1 && base.Map.FireSimLogic.GetFireData(num2) > 0f)
					{
						continue;
					}
				}
				if (reachablePosition.y == base.GridDataPosition.y)
				{
					num++;
				}
			}
			return num;
		}

		protected override List<Vec3Int> GatherReachabilityNodePositions()
		{
			if (positions == null || positions.Count == 0)
			{
				return base.GatherReachabilityNodePositions();
			}
			return positions.ConvertAll((Vec3Int item) => new Vec3Int(item.x, item.y, item.z));
		}

		protected override void CalculateReachability(Func<MapNode, bool> additionalCheck = null)
		{
			if (base.ReachabilityInfo == null)
			{
				SetReachabilityInfo(new ReachabilityInfo(new IntRange(0, 0)));
			}
			RemoveFromRegions();
			ReachablePositions.Clear();
			if ((base.GridDataPosition.x == 0 && base.GridDataPosition.y == 0) || (base.Size.x == 0 && base.Size.z == 0))
			{
				return;
			}
			List<Vec3Int> positions = GatherReachabilityNodePositions();
			if (positions == null)
			{
				return;
			}
			HashSet<Vec3Int> hashSet = new HashSet<Vec3Int>();
			ReachabilityUtil.GatherReachablePositions(base.GridDataPosition, base.ReachabilityInfo, hashSet, additionalCheck);
			SlopeInstance slope = GetSlope();
			if (slope != null)
			{
				foreach (Vec3Int position2 in slope.Positions)
				{
					ReachabilityUtil.GatherReachablePositions(position2, base.ReachabilityInfo, hashSet, additionalCheck);
				}
			}
			if (GetNumberOfSameLevelReachablePositions(hashSet) > 1)
			{
				hashSet.RemoveWhere((Vec3Int v) => Vec3Int.Distance(in v, base.GridDataPosition) < 0.2f);
			}
			hashSet.RemoveWhere((Vec3Int pos) => MonoSingleton<SlopeManager>.Instance.IsSlopeTopAtPosition(pos));
			hashSet.RemoveWhere((Vec3Int pos) => !base.Map.GetNode(pos).IsWalkable);
			ReachablePositions.UnionWith(hashSet);
			if (positions.Count <= 1 || ReachablePositions.Count < 2)
			{
				RegisterInRegions();
				return;
			}
			base.ReachabilityInfo.ForEachYAccess(delegate(int yPos, WorldDirection direction)
			{
				if ((direction & WorldDirection.C) != WorldDirection.None)
				{
					return;
				}
				foreach (Vec3Int item in positions)
				{
					Vec3Int position = item;
					ReachablePositions.RemoveWhere((Vec3Int item) => Vec3Int.Distance(in item, in position) <= 0.45f);
				}
			});
			RegisterInRegions();
		}

		private bool ReachabilityBuildingCheck(MapNode currentNode)
		{
			WaterDepthLevel waterLevelAsDepth = currentNode.Map.WaterManager.GetWaterLevelAsDepth(currentNode.Index);
			if (waterLevelAsDepth == WaterDepthLevel.Medium || waterLevelAsDepth == WaterDepthLevel.High)
			{
				return false;
			}
			if (currentNode.Map.FireSimLogic.GetFireData(currentNode.Index) > 0f)
			{
				return false;
			}
			bool flag = false;
			foreach (BaseBuildingInstance item in base.Map.BuildingsManagerMain.GetBuildings(base.GridDataPosition).OrEmptyIfNull())
			{
				if (item != null && !item.HasDisposed && item.BuildingType != BuildingType.Beam && item.BuildingType != BuildingType.Ladder && item.ConstructionPhase == ConstructionPhase.Finished && item.Blueprint.PlacementType != PlacementType.WallSocket && item.ConstructionPhase == ConstructionPhase.Finished)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				return true;
			}
			Vec3Int position = currentNode.Position;
			return base.GridDataPosition.y != position.y;
		}

		private void UnsubscribeFromEvents()
		{
			if (MonoSingleton<GroundController>.IsInstantiated())
			{
				MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent -= OnGroundDestroyedSingle;
			}
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent -= OnBuildingDestroyed;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			this.CancelDigMarkerFromInstanceEvent = null;
		}

		private void OnGroundDestroyedSingle(Vec3Int gridPosition)
		{
			if (!base.GridDataPosition.Equals(gridPosition) && !base.HasDisposed)
			{
				Vec3Int vec3Int = base.GridDataPosition - gridPosition;
				if (Math.Abs(vec3Int.x) <= 1 && Math.Abs(vec3Int.y) <= 1 && Math.Abs(vec3Int.z) <= 1)
				{
					CalculateReachability(ReachabilityBuildingCheck);
				}
			}
		}

		private void OnBuildingDestroyed(BaseBuildingInstance building)
		{
			Vec3Int b = building.GridDataPosition;
			if (!base.GridDataPosition.Equals(b) && !base.HasDisposed)
			{
				Vec3Int vec3Int = base.GridDataPosition - b;
				if (Math.Abs(vec3Int.x) <= 1 && Math.Abs(vec3Int.y) <= 1 && Math.Abs(vec3Int.z) <= 1)
				{
					CalculateReachability(ReachabilityBuildingCheck);
				}
			}
		}

		private SlopeInstance GetSlope()
		{
			return MonoSingleton<SlopeManager>.Instance.GetSlopeAtPosition(base.GridDataPosition + Vec3Int.down);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public DigMarkerResourceInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
