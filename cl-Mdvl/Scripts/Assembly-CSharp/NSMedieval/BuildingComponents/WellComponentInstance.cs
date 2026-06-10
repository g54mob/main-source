using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Map;
using NSMedieval.Serialization;
using NSMedieval.Terrain;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("WellComponentInstance", "")]
	public class WellComponentInstance : BaseComponentInstance
	{
		[NonSerialized]
		private WellComponentBlueprint blueprint;

		[SerializeField]
		private bool hasWaterSource;

		[SerializeField]
		private Vec3Int start;

		[SerializeField]
		private Vec3Int end;

		[SerializeField]
		private Vec3Int center;

		[NonSerialized]
		private float wellHeight;

		[NonSerialized]
		private MapNode waterSourceNode;

		[NonSerialized]
		private ReservablePositionsComponentInstance reservablePositionsComponentInstance;

		public WellComponentBlueprint Blueprint => blueprint;

		public bool HasWaterSource => hasWaterSource;

		public bool CanBeUsed
		{
			get
			{
				if (hasWaterSource)
				{
					return !base.Underwater;
				}
				return false;
			}
		}

		public Vec3Int Center => center;

		public MapNode WaterSourceNode => waterSourceNode;

		public float WellHeight => wellHeight;

		public ReservablePositionsComponentInstance ReservablePositionsComponentInstance => reservablePositionsComponentInstance;

		public event Action<bool> RefreshCanBeUsedEvent;

		public event Action RefreshBucketLineEvent;

		public event Action<float> StartObtainingWaterEvent;

		public event Action BucketHardResetEvent;

		public event Action WaterObtainedEvent;

		public WellComponentInstance(BaseBuildingInstance ownerBuilding, WellComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			start = ownerBuilding.Positions[0];
			center = ownerBuilding.Positions[1];
			end = ownerBuilding.Positions[2];
			base.Map.BuildingsManagerMain.BuildingDestroyedEvent += OnBuildingDestroyed;
			base.Map.WaterManager.WaterLevelChangedEvent += OnWaterLevelChanged;
			MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent += OnBuildingConstructed;
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent += OnGroundDestroyed;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
			base.OwnerBuilding.RequestHasStabilityToBuildEvent += OnRequestHasStabilityToBuild;
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				if (base.Map?.BuildingsManagerMain != null)
				{
					base.Map.BuildingsManagerMain.BuildingDestroyedEvent -= OnBuildingDestroyed;
				}
				if (base.Map?.WaterManager != null)
				{
					base.Map.WaterManager.WaterLevelChangedEvent -= OnWaterLevelChanged;
				}
				if (MonoSingleton<ConstructionController>.IsInstantiated())
				{
					MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent -= OnBuildingConstructed;
				}
				if (MonoSingleton<GroundController>.IsInstantiated())
				{
					MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent -= OnGroundDestroyed;
				}
				if (MonoSingleton<World>.IsInstantiated())
				{
					MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
				}
				base.Map?.WellComponentManager?.RemoveFromCache(this);
				this.RefreshCanBeUsedEvent = null;
				this.RefreshBucketLineEvent = null;
				this.StartObtainingWaterEvent = null;
				this.BucketHardResetEvent = null;
				this.WaterObtainedEvent = null;
				waterSourceNode = null;
				reservablePositionsComponentInstance = null;
				base.Dispose();
			}
		}

		public override void SetupAfterLoading(BaseBuildingInstance ownerBuilding)
		{
			base.SetupAfterLoading(ownerBuilding);
			start = ownerBuilding.Positions[0];
			center = ownerBuilding.Positions[1];
			end = ownerBuilding.Positions[2];
			base.OwnerBuilding.AddNewComponent(blueprint.ComponentType);
			base.OwnerBuilding.RequestHasStabilityToBuildEvent += OnRequestHasStabilityToBuild;
			base.Map.BuildingsManagerMain.BuildingDestroyedEvent += OnBuildingDestroyed;
			base.Map.WaterManager.WaterLevelChangedEvent += OnWaterLevelChanged;
			MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent += OnBuildingConstructed;
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent += OnGroundDestroyed;
			CheckForWaterSourceRefresh();
		}

		public void CacheReservablePositionsComponentInstance(ReservablePositionsComponentInstance reservablePositionsComponentInstance)
		{
			this.reservablePositionsComponentInstance = reservablePositionsComponentInstance;
		}

		public void StartObtainingWater(float time)
		{
			this.StartObtainingWaterEvent?.Invoke(time);
		}

		public void BucketHardReset()
		{
			this.BucketHardResetEvent?.Invoke();
		}

		public void WaterObtained()
		{
			this.WaterObtainedEvent?.Invoke();
		}

		protected override void OnStabilityCarrierDestroyed(BaseBuildingInstance buildingInstance, bool replaced)
		{
			if ((buildingInstance.Positions.Contains(start) || buildingInstance.Positions.Contains(end)) && !HasStabilityToBuild())
			{
				base.Map.BuildingsManagerMain.DestroyBuilding(base.OwnerBuilding);
			}
		}

		private bool HasStabilityToBuild()
		{
			BuildingsManagerMain buildingsManagerMain = base.OwnerBuilding.Map.BuildingsManagerMain;
			bool flag = MonoSingleton<GroundManager>.Instance.GroundExists(start + Vec3Int.down);
			bool flag2 = MonoSingleton<GroundManager>.Instance.GroundExists(end + Vec3Int.down);
			bool flag3 = buildingsManagerMain.BuildingExists(start, BuildingType.Floor, onlyConstructed: true);
			bool flag4 = buildingsManagerMain.BuildingExists(end, BuildingType.Floor, onlyConstructed: true);
			if (flag || flag3)
			{
				return flag2 || flag4;
			}
			return false;
		}

		private void OnWaterLevelChanged(HashSet<int> nodeIndexes, HashSet<int> nodeNeighborsIndices)
		{
			foreach (int nodeIndex in nodeIndexes)
			{
				OnWaterLevelChanged(nodeIndex);
			}
		}

		private void OnWaterLevelChanged(int nodeIndex)
		{
			if (base.HasDisposed || base.OwnerBuilding == null || base.OwnerBuilding.HasDisposed || nodeIndex < 0 || nodeIndex >= base.Map.GridSpaceData.Length)
			{
				return;
			}
			MapNode mapNode = base.Map.GridSpaceData[nodeIndex];
			if (mapNode != null)
			{
				Vec3Int position = mapNode.Position;
				if (position.x == center.x && position.z == center.z)
				{
					CheckForWaterSourceRefresh();
				}
				MonoSingleton<ConstructionController>.Instance.RefreshUsableWells(base.Map.WellComponentManager.GetOperationalCount() > 0);
			}
		}

		protected override void OnWaterLevelChanged(WaterDepthLevel waterDepthLevel)
		{
			bool underWater = waterDepthLevel == WaterDepthLevel.Medium || waterDepthLevel == WaterDepthLevel.High;
			base.OwnerBuilding.SetUnderWater(underWater);
			CheckForWaterSourceRefresh();
			MonoSingleton<ConstructionController>.Instance.RefreshUsableWells(base.Map.WellComponentManager.GetOperationalCount() > 0);
		}

		private void OnRequestHasStabilityToBuild()
		{
			base.OwnerBuilding.SetHasStabilityToBuild(HasStabilityToBuild());
		}

		private void OnMapLoaded(bool fromSave)
		{
			CheckForWaterSource();
		}

		private bool CheckForWaterSource()
		{
			if (base.HasDisposed || base.OwnerBuilding == null || base.OwnerBuilding.HasDisposed)
			{
				waterSourceNode = null;
				return false;
			}
			if (base.Map.BuildingsManagerMain.BuildingExists(BuildingType.Floor, center))
			{
				waterSourceNode = null;
				return false;
			}
			MapNode node = base.Map.GetNode(center);
			bool isEnabled;
			if (node == null)
			{
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(55, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Wells\\WellComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Can't find well center node ");
					messageBuilder.AppendFormatted(center);
					messageBuilder.AppendLiteral(". This should never happen.");
				}
				Log.Warning(messageBuilder);
				return false;
			}
			if (node.IsWater)
			{
				waterSourceNode = node;
				wellHeight = base.GridPosition.y - waterSourceNode.Position.y;
				return true;
			}
			int num = center.y;
			while (num > 0)
			{
				num--;
				Vec3Int vec3Int = new Vec3Int(center.x, num, center.z);
				node = base.Map.GetNode(vec3Int);
				if (node == null)
				{
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(52, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Wells\\WellComponentInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Can't find well map node ");
						messageBuilder.AppendFormatted(vec3Int);
						messageBuilder.AppendLiteral(". This should never happen.");
					}
					Log.Warning(messageBuilder);
					continue;
				}
				if (base.Map.BuildingsManagerMain.BuildingExists(vec3Int, (BaseBuildingInstance x) => x.BuildingType != BuildingType.Ladder && x.BuildingType != BuildingType.Floor))
				{
					waterSourceNode = null;
					return false;
				}
				if (MonoSingleton<GroundManager>.Instance.GroundExists(vec3Int))
				{
					waterSourceNode = null;
					return false;
				}
				if (!node.IsWater)
				{
					continue;
				}
				waterSourceNode = node;
				wellHeight = base.GridPosition.y - waterSourceNode.Position.y;
				return true;
			}
			return false;
		}

		private void OnBuildingConstructed(BaseBuildingInstance baseBuildingInstance)
		{
			BuildingConstructedOrDestroyed(baseBuildingInstance);
		}

		private void OnBuildingDestroyed(BaseBuildingInstance baseBuildingInstance)
		{
			BuildingConstructedOrDestroyed(baseBuildingInstance);
		}

		private void BuildingConstructedOrDestroyed(BaseBuildingInstance baseBuildingInstance)
		{
			if (base.HasDisposed || base.OwnerBuilding == null || base.OwnerBuilding.HasDisposed)
			{
				return;
			}
			foreach (Vec3Int position in baseBuildingInstance.Positions)
			{
				if (position.x == center.x && position.z == center.z && position.y <= center.y)
				{
					CheckForWaterSourceRefresh();
					break;
				}
			}
		}

		private void OnGroundDestroyed(Vec3Int gridPos)
		{
			if (!base.HasDisposed && base.OwnerBuilding != null && !base.OwnerBuilding.HasDisposed)
			{
				Vec3Int rhs = gridPos + Vec3Int.up;
				if ((start == rhs || end == rhs) && !HasStabilityToBuild())
				{
					base.Map.BuildingsManagerMain.DestroyBuilding(base.OwnerBuilding);
				}
				else if (gridPos.x == center.x && gridPos.z == center.z && gridPos.y <= center.y)
				{
					CheckForWaterSourceRefresh();
				}
			}
		}

		private void CheckForWaterSourceRefresh()
		{
			hasWaterSource = CheckForWaterSource();
			this.RefreshCanBeUsedEvent?.Invoke(!CanBeUsed);
			this.RefreshBucketLineEvent?.Invoke();
		}

		public override void Serialize(FVSerializer serializer)
		{
			serializer.Write("hasWaterSource", hasWaterSource);
			base.Serialize(serializer);
		}

		public WellComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<WellComponentRepository, WellComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(61, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Wells\\WellComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in WellComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				hasWaterSource = deserializer.ReadBool("hasWaterSource");
			}
		}
	}
}
