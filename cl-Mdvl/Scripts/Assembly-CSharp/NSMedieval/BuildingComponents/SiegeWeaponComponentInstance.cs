using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Components;
using NSMedieval.Components.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Stockpiles;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	[FVSerializableKey("SiegeWeaponComponentInstance", "")]
	public class SiegeWeaponComponentInstance : BaseComponentInstance
	{
		[SerializeField]
		private string siegeWeaponName;

		[SerializeField]
		private ResourcesFilter resourcesFilter;

		[SerializeField]
		private Storage storage;

		[SerializeField]
		private float minRangeRadius;

		[SerializeField]
		private float maxRangeRadius;

		[NonSerialized]
		private float[] maxRangeMultipliersPerLayer;

		[NonSerialized]
		private float[] minRangeMultipliersPerLayer;

		[NonSerialized]
		private SiegeWeaponComponentBlueprint blueprint;

		[NonSerialized]
		private Vector3 target;

		[NonSerialized]
		private HashSet<Resource> defaultAllowed;

		[NonSerialized]
		private List<ResourceGroups> resourceGroups;

		[NonSerialized]
		private List<string> storableResourceGroups;

		[NonSerialized]
		private HashSet<Resource> defaultStorableResources;

		[NonSerialized]
		private ReservablePositionsComponentInstance reservablePositionsComponentInstance;

		[NonSerialized]
		private Vector3 projectileLaunchPosition;

		private bool weaponInAttackPosition;

		public List<ResourceGroups> ResourceGroups
		{
			get
			{
				if (resourceGroups == null || resourceGroups.Count == 0)
				{
					resourceGroups = new List<ResourceGroups>();
					InitializeStorableGroups(storableResourceGroups);
				}
				return resourceGroups;
			}
		}

		public SiegeWeaponProjectileBlueprint BulletBlueprint { get; private set; }

		public float ProjectileHp { get; private set; }

		public float ProjectileMaxHp { get; private set; }

		public bool AttackInProgress { get; set; }

		public string SiegeWeaponName => siegeWeaponName;

		public SiegeWeaponComponentBlueprint Blueprint => blueprint;

		public ResourcesFilter ResourcesFilter => resourcesFilter;

		public ReservablePositionsComponentInstance ReservablePositionsComponentInstance => reservablePositionsComponentInstance;

		public bool IsPlayerTargeting { get; set; }

		public bool ContinuousAttack { get; set; }

		public bool IsOperatorReady { get; set; }

		public Vector3 Target => target;

		public Storage Storage => storage;

		public Vector3 CrosshairPos { get; private set; }

		public float[] MaxRangeMultipliersPerLayer => maxRangeMultipliersPerLayer;

		public float[] MinRangeMultipliersPerLayer => minRangeMultipliersPerLayer;

		public Vector3 ProjectileLaunchPosition => projectileLaunchPosition;

		public bool WeaponInAttackPosition
		{
			get
			{
				return weaponInAttackPosition;
			}
			set
			{
				weaponInAttackPosition = value;
				if (ContinuousAttack && CanStartAttack())
				{
					LeftClickContinuousAttack();
				}
			}
		}

		public float ReloadAnimationSpeed
		{
			get
			{
				if (base.HasDisposed || blueprint == null || blueprint.ReloadAnimationSpeed <= 0f)
				{
					return 1f;
				}
				return Mathf.Clamp(blueprint.ReloadAnimationSpeed, 0.2f, 15f);
			}
		}

		public event Action TargetSetEvent;

		public event Action RotateTowardsTargetEvent;

		public event Action<SiegeWeaponProjectileBlueprint> StartAttackEvent;

		public event Action HideTrajectoryEvent;

		public event Action<Vector3> UpdateCrosshairEvent;

		public event Action RightClickResetTargetingEvent;

		public event Action<float> StartReloadingEvent;

		public event Action ReloadFailedEvent;

		public event Action ReloadSuccessEvent;

		public event Action<bool> ShowRangeEvent;

		public SiegeWeaponComponentInstance(BaseBuildingInstance ownerBuilding, SiegeWeaponComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			storage = new Storage(new StorageBase(1, ignoreWeigth: true));
			resourcesFilter = new ResourcesFilter();
			minRangeRadius = this.blueprint.MinRangeRadius;
			maxRangeRadius = this.blueprint.MaxRangeRadius;
			siegeWeaponName = BuildingUtils.GetLocalizedName(base.OwnerBuildingID);
			InitAllowedResourcesFromBlueprint();
			InitializeAllowedResources(this.blueprint);
			LoadDefaultAllowed(this.blueprint);
			PasteSettings();
			KeyValuePair<float[], float[]> minMaxRanges = SiegeWeaponUtil.GetMinMaxRanges(this.blueprint);
			minRangeMultipliersPerLayer = minMaxRanges.Key;
			maxRangeMultipliersPerLayer = minMaxRanges.Value;
			if (!base.OwnerBuilding.OwnedByPlayer())
			{
				MonoSingleton<GlobalWarningMessagesManager>.Instance.SetEnemySiegeWeaponsMessageVisible(visible: true);
			}
		}

		public void SaveProjectileLaunchPosition(Vector3 projectileLaunchPosition)
		{
			this.projectileLaunchPosition = projectileLaunchPosition;
		}

		public bool CanStartAttack()
		{
			if (IsOperatorReady && WeaponInAttackPosition && HasAmmunition())
			{
				return target != Vector3.zero;
			}
			return false;
		}

		public bool CanEnemyStartAttackPreCheck()
		{
			if (!base.HasDisposed)
			{
				BaseBuildingInstance baseBuildingInstance = base.OwnerBuilding;
				if (baseBuildingInstance != null && !baseBuildingInstance.HasDisposed && WeaponInAttackPosition)
				{
					return HasAmmunition();
				}
			}
			return false;
		}

		public bool CanEnemyStartAttack()
		{
			if (WeaponInAttackPosition && HasAmmunition())
			{
				return target != Vector3.zero;
			}
			return false;
		}

		public static bool SelectObjectsInRadius(IDamageTakingAgent agent, Vector3 searchAroundPoint, float radiusPow2)
		{
			float num = Mathf.Floor(Mathf.Abs(searchAroundPoint.x - agent.GetPosition().x));
			float num2 = Mathf.Floor(Mathf.Abs(searchAroundPoint.y - agent.GetPosition().y - (float)World.MapBlockHeight / 2f));
			float num3 = Mathf.Floor(Mathf.Abs(searchAroundPoint.z - agent.GetPosition().z));
			return num * num + num2 * num2 + num3 * num3 <= radiusPow2;
		}

		public override void Dispose()
		{
			base.Map.SiegeWeaponComponentManager.RemoveFromCache(this);
			reservablePositionsComponentInstance = null;
			storage = null;
			this.TargetSetEvent = null;
			this.StartAttackEvent = null;
			this.HideTrajectoryEvent = null;
			this.UpdateCrosshairEvent = null;
			this.RightClickResetTargetingEvent = null;
			this.StartReloadingEvent = null;
			this.ReloadFailedEvent = null;
			this.RotateTowardsTargetEvent = null;
			this.ReloadSuccessEvent = null;
			this.ShowRangeEvent = null;
			base.Dispose();
		}

		public override void SetupAfterLoading(BaseBuildingInstance ownerBuilding)
		{
			base.SetupAfterLoading(ownerBuilding);
			InitAllowedResourcesFromBlueprint(afterLoading: true);
			KeyValuePair<float[], float[]> minMaxRanges = SiegeWeaponUtil.GetMinMaxRanges(blueprint);
			minRangeMultipliersPerLayer = minMaxRanges.Key;
			maxRangeMultipliersPerLayer = minMaxRanges.Value;
		}

		public void StartReloading(float reloadSpeed)
		{
			this.StartReloadingEvent?.Invoke(reloadSpeed);
		}

		public void ReloadSuccessRefactored()
		{
			this.ReloadSuccessEvent?.Invoke();
			WeaponInAttackPosition = true;
			MonoSingleton<TrebuchetController>.Instance.OnTrebuchetAttackReady(this);
		}

		public void ReloadFailed()
		{
			WeaponInAttackPosition = false;
			this.ReloadFailedEvent?.Invoke();
		}

		protected override void ReservationChanged(bool isReserved)
		{
			base.ReservationChanged(isReserved);
			IsOperatorReady = false;
		}

		public void CacheReservablePositionsComponentInstance(ReservablePositionsComponentInstance reservablePositionsComponentInstance)
		{
			this.reservablePositionsComponentInstance = reservablePositionsComponentInstance;
		}

		public void SetName(string name)
		{
			siegeWeaponName = name;
		}

		public void AllowResource(Resource resource, bool allowed)
		{
			bool flag = false;
			foreach (ResourceGroups resourceGroup in blueprint.ResourceGroups)
			{
				if (resourceGroup.GetID() == resource.SortingGroup)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				if (allowed)
				{
					resourcesFilter.AddAllowedResource(resource);
				}
				else
				{
					resourcesFilter.RemoveAllowedResource(resource);
				}
			}
		}

		public void HideTrajectory()
		{
			this.HideTrajectoryEvent?.Invoke();
		}

		public Vector3 GetRandomizedPosition(Vector3 position)
		{
			if (blueprint.SiegeWeaponType == SiegeWeaponType.Onager)
			{
				return RandomizeTarget(position, 2f);
			}
			if (blueprint.SiegeWeaponType == SiegeWeaponType.Ballista)
			{
				return RandomizeTarget(position, 1f);
			}
			return RandomizePosition(position);
		}

		private Vector3 RandomizePosition(Vector3 position)
		{
			if (Blueprint == null || Blueprint.TargetRandomRadius < 1f)
			{
				return position;
			}
			System.Random random = new System.Random();
			float num = Blueprint.TargetRandomRadius * Mathf.Pow((float)random.NextDouble(), 1.3f);
			if (num < 1f)
			{
				return position;
			}
			float f = MathF.PI * 2f * (float)random.NextDouble();
			return position + (Vector3.right * Mathf.Sin(f) + Vector3.forward * Mathf.Cos(f)) * num;
		}

		private Vector3 RandomizeTarget(Vector3 position, float multiplier)
		{
			float from = 1f;
			float to = Blueprint.ProjectileHitRadius * multiplier;
			float from2 = minRangeRadius;
			float to2 = maxRangeRadius;
			float value = Vector3.Distance(base.OwnerBuilding.WorldPosition, position);
			float num = RemapRange(value, from2, to2, from, to);
			Vector3 normalized = (position - base.WorldPosition).normalized;
			return new Vector3((position + normalized * UnityEngine.Random.Range(0f, num * multiplier)).x, z: (position + normalized * UnityEngine.Random.Range(0f, num * multiplier)).z, y: position.y);
		}

		private float RemapRange(float value, float from1, float to1, float from2, float to2)
		{
			return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
		}

		public bool HasAmmoAvailableNearByFloodFill(float range = 5f)
		{
			foreach (MapNode item in FloodFillUtil.IterateFloodFillConnections(GetNode(), range))
			{
				ResourcePileInstance pileByGridPosition = MonoSingleton<ResourcePileManager>.Instance.GetPileByGridPosition(item.Position);
				if (pileByGridPosition != null && ResourcesFilter.IsValid(pileByGridPosition.GetStoredResource()))
				{
					return true;
				}
			}
			return false;
		}

		public bool HasAmmoAvailableOnMap()
		{
			foreach (Resource allowedResourceType in ResourcesFilter.AllowedResourceTypes)
			{
				if (!(allowedResourceType == null) && MonoSingleton<ResourcePileTracker>.Instance.GetCount(allowedResourceType).AllowedCount > 0)
				{
					return true;
				}
			}
			return false;
		}

		public void SetTarget(Vector3 target)
		{
			if (!IsTargetOutOfRange(target))
			{
				this.target = target;
				this.RotateTowardsTargetEvent?.Invoke();
				this.TargetSetEvent?.Invoke();
			}
		}

		public void UpdateCrosshair(Vector3 position)
		{
			CrosshairPos = position;
			UpdateMaxRange();
			this.UpdateCrosshairEvent?.Invoke(position);
		}

		public void SetTarget(IDamageTakingAgent target)
		{
			if (!IsTargetOutOfRange(target.GetPosition()))
			{
				this.target = target.GetPosition();
				this.RotateTowardsTargetEvent?.Invoke();
				this.TargetSetEvent?.Invoke();
			}
		}

		public void PasteSettings(SiegeWeaponCopySettingsData siegeWeaponCopySettingsData)
		{
			if (siegeWeaponCopySettingsData == null)
			{
				return;
			}
			resourcesFilter.SetAllowedResourceTypes(new HashSet<Resource>());
			foreach (Resource allowedResourceType in siegeWeaponCopySettingsData.ResourcesFilter.AllowedResourceTypes)
			{
				AllowResource(allowedResourceType, allowed: true);
			}
		}

		public SiegeWeaponCopySettingsData GetCopyData(BaseBuildingInstance newBuilding)
		{
			return new SiegeWeaponCopySettingsData(ResourcesFilter.DeepCopy(), newBuilding);
		}

		public bool IsTargetOutOfRange(Vector3 targetPosition, bool showMessage = true)
		{
			if (SiegeWeaponUtil.IsTargetTooClose(minRangeRadius, GetPosition(), targetPosition))
			{
				if (showMessage)
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("error_siege_weapon_target_too_close"));
				}
				return true;
			}
			if (SiegeWeaponUtil.IsTargetTooFar(maxRangeRadius, GetPosition(), targetPosition))
			{
				if (showMessage)
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("error_siege_weapon_target_too_far"));
				}
				return true;
			}
			return false;
		}

		public bool HasAmmunition()
		{
			return storage?.GetSingleResource() != null;
		}

		public SiegeWeaponProjectileBlueprint GetAmmoBlueprint()
		{
			Resource resource = storage.GetSingleResource()?.Blueprint;
			if (!(resource == null))
			{
				return Repository<SiegeWeaponProjectileRepository, SiegeWeaponProjectileBlueprint>.Instance.GetByID(resource.GetID());
			}
			return null;
		}

		public void ResetTarget()
		{
			target = Vector3.zero;
		}

		public void ShowRange(bool visible)
		{
			this.ShowRangeEvent?.Invoke(visible);
		}

		internal void MouseLeftClick(Vector3 position)
		{
			target = position;
			this.RotateTowardsTargetEvent?.Invoke();
			if (CanStartAttack())
			{
				IsPlayerTargeting = false;
				Attack();
				UpdatePanelInfo();
			}
		}

		private void UpdateMaxRange()
		{
			if (base.HasDisposed || base.OwnerBuilding == null || base.OwnerBuilding.HasDisposed)
			{
				return;
			}
			float num = GetPosition().y - CrosshairPos.y;
			float num2 = blueprint.MaxRangeRadius;
			float num3 = blueprint.MinRangeRadius;
			if (num > 0.01f)
			{
				int num4 = (int)((num + 0.5f) / (float)World.MapBlockHeight);
				for (int i = 1; i <= num4; i++)
				{
					if (blueprint.RangePerLayer.Dictionary.TryGetValue(i, out var value))
					{
						num2 *= value;
						num3 *= value;
					}
				}
			}
			maxRangeRadius = num2;
			minRangeRadius = num3;
		}

		private void TryStartPlayerAttack()
		{
			if (CanStartAttack())
			{
				IsPlayerTargeting = false;
				Attack();
				UpdatePanelInfo();
			}
		}

		internal void EnemyStartAttack()
		{
			if (CanStartAttack())
			{
				Attack();
				UpdatePanelInfo();
			}
		}

		internal void MouseLeftClick()
		{
			IsPlayerTargeting = false;
			Attack();
			UpdatePanelInfo();
		}

		internal void MouseRightClick()
		{
			IsPlayerTargeting = false;
			ResetTarget();
			UpdatePanelInfo();
			this.RightClickResetTargetingEvent?.Invoke();
		}

		private void OnAmmoDelivered(SimpleResourceCount simpleResourceCount)
		{
			TryStartPlayerAttack();
		}

		public void CheckIfCanStartAttack()
		{
			TryStartPlayerAttack();
		}

		private void LeftClickContinuousAttack()
		{
			Attack();
			UpdatePanelInfo();
		}

		private bool Attack()
		{
			if (!HasAmmunition())
			{
				return false;
			}
			if (!weaponInAttackPosition)
			{
				return false;
			}
			weaponInAttackPosition = false;
			ResourceInstance singleResource = storage.GetSingleResource();
			BulletBlueprint = Repository<SiegeWeaponProjectileRepository, SiegeWeaponProjectileBlueprint>.Instance.GetByID(singleResource.BlueprintId);
			ProjectileHp = singleResource.GetStatValue(StatType.Health);
			ProjectileMaxHp = singleResource.GetMaxStatValue(StatType.Health);
			this.StartAttackEvent?.Invoke(BulletBlueprint);
			storage.Consume(singleResource.Blueprint, 1);
			if (!HasAmmunition())
			{
				MonoSingleton<TrebuchetController>.Instance.OnTrebuchetAmmunitionDepleted(this);
			}
			MonoSingleton<CombatController>.Instance.CombatStarted();
			return true;
		}

		private void InitAllowedResourcesFromBlueprint(bool afterLoading = false)
		{
			if (storableResourceGroups == null)
			{
				storableResourceGroups = new List<string>();
			}
			if (defaultStorableResources == null)
			{
				defaultStorableResources = new HashSet<Resource>();
			}
			foreach (Resource allItem in Repository<ResourceRepository, Resource>.Instance.GetAllItems())
			{
				if (!(allItem == null) && Blueprint.ResourceGroups.Select((ResourceGroups item) => item.GetID()).Contains(allItem.SortingGroup))
				{
					if (!afterLoading)
					{
						resourcesFilter.AddAllowedResource(allItem);
					}
					resourcesFilter.CacheDefaultAllowedResources(allItem);
					defaultStorableResources.Add(allItem);
					if (!storableResourceGroups.Contains(allItem.SortingGroup))
					{
						storableResourceGroups.Add(allItem.SortingGroup);
					}
				}
			}
		}

		private void LoadDefaultAllowed(SiegeWeaponComponentBlueprint siegeWeaponComponentBlueprint)
		{
			using PooledHashSet<Resource> pooledHashSet = HashSetPool<Resource>.GetJanitor(resourcesFilter.AllowedResourceTypes);
			foreach (Resource item in pooledHashSet)
			{
				if (!siegeWeaponComponentBlueprint.AllowedByDefault.Contains(item.SortingGroup))
				{
					resourcesFilter.RemoveAllowedResource(item);
				}
			}
		}

		private void PasteSettings()
		{
			VillageSaveData currentVillageData = GlobalSaveController.CurrentVillageData;
			if (currentVillageData != null)
			{
				SiegeWeaponCopySettingsData siegeWeaponCopySettingsData = currentVillageData.SiegeWeaponCopySettingsData.FirstOrDefault((SiegeWeaponCopySettingsData x) => x.TargetBuilding == base.OwnerBuilding);
				if (siegeWeaponCopySettingsData != null)
				{
					currentVillageData.DeleteSiegeWeaponCopyData(siegeWeaponCopySettingsData);
					PasteSettings(siegeWeaponCopySettingsData);
				}
			}
		}

		private void InitializeAllowedResources(SiegeWeaponComponentBlueprint blueprint)
		{
			if (blueprint == null)
			{
				return;
			}
			if (defaultAllowed == null)
			{
				defaultAllowed = new HashSet<Resource>();
			}
			foreach (Resource allItem in Repository<ResourceRepository, Resource>.Instance.GetAllItems())
			{
				if (!(allItem == null) && blueprint.ResourceGroups.Select((ResourceGroups item) => item.GetID()).Contains(allItem.SortingGroup) && blueprint.AllowedByDefault.Contains(allItem.SortingGroup))
				{
					resourcesFilter.AddAllowedResource(allItem);
					defaultAllowed.Add(allItem);
					resourcesFilter.CacheDefaultAllowedResources(allItem);
				}
			}
		}

		private void InitializeStorableGroups(List<string> storableGroups)
		{
			foreach (string storableGroup in storableGroups)
			{
				ResourceGroups actualResourceGroup = GetActualResourceGroup(storableGroup);
				if (!(actualResourceGroup == null) && !resourceGroups.Contains(actualResourceGroup))
				{
					resourceGroups.Add(GetActualResourceGroup(storableGroup));
					AddParentsToList(storableGroup);
				}
			}
		}

		private void AddParentsToList(string childNode)
		{
			foreach (ResourceGroups resourceGroup in Repository<StockpileRepository, Stockpile>.Instance.GetByID("default_stockpile").ResourceGroups)
			{
				foreach (string subGroupID in resourceGroup.SubGroupIDs)
				{
					if (subGroupID == childNode && !resourceGroups.Contains(resourceGroup) && !storableResourceGroups.Contains(resourceGroup.GetID()))
					{
						resourceGroups.Add(resourceGroup);
						AddParentsToList(resourceGroup.GetID());
					}
				}
			}
		}

		private ResourceGroups GetActualResourceGroup(string id)
		{
			ResourceGroups resourceGroups = Repository<StockpileRepository, Stockpile>.Instance.GetByID("default_stockpile").ResourceGroups.FirstOrDefault((ResourceGroups x) => x.GetID() == id);
			if (resourceGroups != null)
			{
				if (resourceGroups.SubGroupIDs.Count <= 0)
				{
					return resourceGroups;
				}
				InitializeStorableGroups(resourceGroups.SubGroupIDs);
			}
			return null;
		}

		private void UpdatePanelInfo()
		{
			if (!base.HasDisposed && base.OwnerBuilding != null && !base.OwnerBuilding.HasDisposed)
			{
				SiegeWeaponComponent component = base.Map.SiegeWeaponComponentManager.GetComponent(this);
				if (component != null)
				{
					component.SetHasInfoChanged(hasInfoChanged: true);
				}
			}
		}

		public override string ToString()
		{
			if (Blueprint == null)
			{
				return string.Empty;
			}
			return string.Format("{0}: {1}, hasAmmo: {2} {3}: {4}, {5}: {6}", "Blueprint", Blueprint.GetID(), HasAmmunition(), "AttackInProgress", AttackInProgress, "IsOperatorReady", IsOperatorReady);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("siegeWeaponName", siegeWeaponName);
			serializer.Write("storage", storage);
			serializer.Write("resourcesFilter", resourcesFilter);
			serializer.Write("minRangeRadius", minRangeRadius);
			serializer.Write("maxRangeRadius", maxRangeRadius);
			serializer.Write("weaponInAttackPosition", weaponInAttackPosition);
		}

		public SiegeWeaponComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<SiegeWeaponComponentRepository, SiegeWeaponComponentBlueprint>.Instance.GetByID(base.ComponentBlueprintID);
			storage = deserializer.ReadObject<Storage>("storage");
			siegeWeaponName = deserializer.ReadString("siegeWeaponName");
			resourcesFilter = deserializer.ReadObject<ResourcesFilter>("resourcesFilter");
			minRangeRadius = deserializer.ReadFloat("minRangeRadius");
			maxRangeRadius = deserializer.ReadFloat("maxRangeRadius");
			weaponInAttackPosition = deserializer.ReadBool("weaponInAttackPosition");
			if (minRangeRadius == 0f)
			{
				minRangeRadius = blueprint.MinRangeRadius;
			}
			if (maxRangeRadius == 0f)
			{
				maxRangeRadius = blueprint.MaxRangeRadius;
			}
		}
	}
}
