using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.MovableBuildings
{
	[Serializable]
	[FVSerializableKey("MoveBuildingResourceInstance", "")]
	public class MoveBuildingResourceInstance : ResourceInstance
	{
		[SerializeField]
		private BaseBuildingInstance targetBuilding;

		[SerializeField]
		private string targetBuildingId;

		[SerializeField]
		private ShelfCopySettingsData shelfCopySettingsData;

		[SerializeField]
		private FuelConsumerCopySettingsData fuelConsumerCopySettingsData;

		[SerializeField]
		private SiegeWeaponCopySettingsData siegeWeaponCopySettingsData;

		[SerializeField]
		private List<string> meshVariations;

		[SerializeField]
		private BaseBuildingBlueprint targetBaseBlueprint;

		public BaseBuildingInstance TargetBuilding => targetBuilding;

		public string TargetBuildingId => targetBuildingId;

		public BaseBuildingBlueprint TargetBaseBlueprint => targetBaseBlueprint;

		public List<string> MeshVariations => meshVariations;

		public ShelfCopySettingsData ShelfCopySettingsData => shelfCopySettingsData;

		public FuelConsumerCopySettingsData FuelConsumerCopySettingsData => fuelConsumerCopySettingsData;

		public SiegeWeaponCopySettingsData SiegeWeaponCopySettingsData => siegeWeaponCopySettingsData;

		public MoveBuildingResourceInstance(Resource blueprint, int amount, string targetBuildingId)
			: base(blueprint, amount)
		{
			SetBuildingId(targetBuildingId);
			BaseBuildingBlueprint byID = Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID(this.targetBuildingId);
			InitMeshVariations(byID);
		}

		public MoveBuildingResourceInstance(Resource blueprint, int amount, BaseBuildingInstance targetBuilding)
			: base(blueprint, amount)
		{
			this.targetBuilding = targetBuilding;
			if (this.targetBuilding != null)
			{
				SetBuildingId(this.targetBuilding.BlueprintId);
			}
		}

		public override ResourceInstance Clone(int overrideAmount = -1)
		{
			MoveBuildingResourceInstance moveBuildingResourceInstance = new MoveBuildingResourceInstance(base.Blueprint, (overrideAmount >= 0) ? overrideAmount : base.Amount, targetBuilding);
			moveBuildingResourceInstance.CloneStatsCurrent(base.Stats);
			moveBuildingResourceInstance.SetTargetBuilding(targetBuilding);
			moveBuildingResourceInstance.SetBuildingId(targetBuildingId);
			moveBuildingResourceInstance.CloneComponentData(this);
			moveBuildingResourceInstance.CloneMeshVariations(MeshVariations);
			moveBuildingResourceInstance.SetProducerUniqueId(base.ProducerUniqueId);
			moveBuildingResourceInstance.SetFaction(factionOwnership);
			return moveBuildingResourceInstance;
		}

		public override void Dispose()
		{
			base.Dispose();
			fuelConsumerCopySettingsData = null;
			shelfCopySettingsData = null;
			targetBuilding = null;
			shelfCopySettingsData = null;
			fuelConsumerCopySettingsData = null;
			siegeWeaponCopySettingsData = null;
		}

		public void SetTargetBuilding(BaseBuildingInstance baseBuildableObject)
		{
			targetBuilding = baseBuildableObject;
			meshVariations = new List<string>();
			if (targetBuilding != null)
			{
				MeshVariations.AddRange(targetBuilding.VariationsApplied);
			}
		}

		public void SetBuildingId(string targetBuildingId)
		{
			this.targetBuildingId = targetBuildingId;
			if (!string.IsNullOrEmpty(this.targetBuildingId) && Repository<ResourceRepository, Resource>.Instance.GetByID(TargetBuildingId) == null)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(86, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\MovableBuildings\\MoveBuildingResourceInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("SetBuildingId failed; ");
					messageBuilder.AppendFormatted(TargetBuildingId);
					messageBuilder.AppendLiteral(" does not exist in ResourceRepository. This should never happen.");
				}
				Log.Warning(messageBuilder);
				this.targetBuildingId = string.Empty;
			}
		}

		public void SetupAfterLoading()
		{
			if (targetBuilding != null && !targetBuilding.GetNode().ContainsBuilding(targetBuilding))
			{
				SetTargetBuilding(null);
			}
		}

		public void SaveComponentData(BaseBuildingInstance baseBuildingInstance)
		{
			fuelConsumerCopySettingsData = baseBuildingInstance.Map.FuelConsumerComponentManager.GetComponentInstance(baseBuildingInstance)?.GetCopyData(baseBuildingInstance);
			shelfCopySettingsData = baseBuildingInstance.Map.ShelfComponentManager.GetComponentInstance(baseBuildingInstance)?.GetCopyData(baseBuildingInstance);
			siegeWeaponCopySettingsData = baseBuildingInstance.Map.SiegeWeaponComponentManager.GetComponentInstance(baseBuildingInstance)?.GetCopyData(baseBuildingInstance);
		}

		public void CloneComponentData(MoveBuildingResourceInstance sourceMoveBuildingResourceInstance)
		{
			if (sourceMoveBuildingResourceInstance.FuelConsumerCopySettingsData != null)
			{
				fuelConsumerCopySettingsData = sourceMoveBuildingResourceInstance.FuelConsumerCopySettingsData.DeepCopy();
			}
			if (sourceMoveBuildingResourceInstance.ShelfCopySettingsData != null)
			{
				shelfCopySettingsData = sourceMoveBuildingResourceInstance.ShelfCopySettingsData.DeepCopy();
			}
			if (sourceMoveBuildingResourceInstance.SiegeWeaponCopySettingsData != null)
			{
				siegeWeaponCopySettingsData = sourceMoveBuildingResourceInstance.SiegeWeaponCopySettingsData.DeepCopy();
			}
		}

		public void CloneMeshVariations(List<string> variations)
		{
			if (variations != null && variations != null && variations.Count > 0)
			{
				MeshVariations.AddRangeUnique(variations);
			}
		}

		private void InitMeshVariations(BaseBuildingBlueprint blueprint)
		{
			targetBaseBlueprint = blueprint;
			meshVariations = new List<string>();
			if (blueprint.DefaultVariations != null && blueprint.DefaultVariations.Count > 0)
			{
				CloneMeshVariations(blueprint.DefaultVariations);
				return;
			}
			foreach (MeshVariationList variationList in blueprint.VariationLists)
			{
				if (variationList?.Variations != null && variationList.Variations.Count > 0 && variationList.Variations[0] != null)
				{
					MeshVariation meshVariation = variationList.Variations[0];
					if (variationList.IsRandom)
					{
						meshVariation = variationList.Variations.PickRandom();
					}
					MeshVariations.Add(meshVariation.Name);
				}
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("targetBuilding", targetBuilding);
			serializer.Write("targetBuildingId", targetBuildingId);
			serializer.Write("meshVariations", meshVariations);
			serializer.Write("targetBaseBlueprintID", (targetBaseBlueprint != null) ? targetBaseBlueprint.ID : string.Empty);
			serializer.Write("fuelConsumerCopySettingsData", fuelConsumerCopySettingsData);
			serializer.Write("shelfCopySettingsData", shelfCopySettingsData);
			serializer.Write("siegeWeaponCopySettingsData", siegeWeaponCopySettingsData);
		}

		public MoveBuildingResourceInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			targetBuilding = deserializer.ReadObject<BaseBuildingInstance>("targetBuilding");
			targetBuildingId = deserializer.ReadString("targetBuildingId");
			meshVariations = deserializer.ReadStringList("meshVariations");
			FuelConsumerComponentInstance fuelConsumerComponentInstance = deserializer.ReadObject<FuelConsumerComponentInstance>("fuelConsumerComponentInstance");
			if (fuelConsumerComponentInstance != null)
			{
				fuelConsumerCopySettingsData = new FuelConsumerCopySettingsData(fuelConsumerComponentInstance.ResourcesFilter, fuelConsumerComponentInstance.RefuelPriority, fuelConsumerComponentInstance.TorchState, fuelConsumerComponentInstance.TurnedOff, fuelConsumerComponentInstance.ThermalModelIntensity, targetBuilding);
			}
			else
			{
				fuelConsumerCopySettingsData = deserializer.ReadObject<FuelConsumerCopySettingsData>("fuelConsumerCopySettingsData");
			}
			shelfCopySettingsData = deserializer.ReadObject<ShelfCopySettingsData>("shelfCopySettingsData");
			siegeWeaponCopySettingsData = deserializer.ReadObject<SiegeWeaponCopySettingsData>("siegeWeaponCopySettingsData");
			string id = deserializer.ReadString("targetBaseBlueprintID");
			targetBaseBlueprint = Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID(id);
		}
	}
}
