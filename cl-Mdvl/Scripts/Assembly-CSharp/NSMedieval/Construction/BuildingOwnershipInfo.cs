using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.Construction
{
	[FVSerializableKey("BuildingOwnershipInfo", "")]
	public class BuildingOwnershipInfo : IFVSerializable, IDisposable
	{
		[SerializeField]
		private HumanoidInstance owner;

		[NonSerialized]
		private BaseBuildingInstance buildingOwned;

		[NonSerialized]
		private HumanoidInstance tempOwner;

		[NonSerialized]
		private VillageMap map;

		private VillageMap Map
		{
			get
			{
				if (map == null)
				{
					map = VillageManager.ActiveVillage.Map;
				}
				return map;
			}
		}

		public bool Occupied
		{
			get
			{
				if (owner == null)
				{
					return tempOwner != null;
				}
				return true;
			}
		}

		public HumanoidInstance Owner => owner;

		public HumanoidInstance TempOwner => tempOwner;

		public BuildingOwnershipInfo(VillageMap map)
		{
			this.map = map;
		}

		public bool HasTempOwner()
		{
			return tempOwner != null;
		}

		public void ClearTempOwner()
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(49, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\States\\BuildingOwnershipInfo.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Clear temporary reservation for bed at position ");
				messageBuilder.AppendFormatted(buildingOwned.GridDataPosition);
				messageBuilder.AppendLiteral(".");
			}
			Log.Info(messageBuilder);
			tempOwner = null;
		}

		public void SetOwner(HumanoidInstance owner, BaseBuildingInstance buildingOwned)
		{
			if (buildingOwned == null || buildingOwned.IsForbiddenPrisonCell)
			{
				return;
			}
			if (Map.BedComponentManager.OwnsABed(this.owner) && this.owner == null)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\States\\BuildingOwnershipInfo.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Temporary reservation for bed at position ");
					messageBuilder.AppendFormatted(buildingOwned.GridDataPosition);
					messageBuilder.AppendLiteral(".");
				}
				Log.Info(messageBuilder);
				tempOwner = owner;
				this.buildingOwned = buildingOwned;
			}
			else
			{
				this.owner = owner;
				this.buildingOwned = buildingOwned;
				tempOwner = null;
				Map.BuildingsManagerMain.RegisterOwnedBuilding(this.owner, this.buildingOwned);
			}
		}

		public void SetOwnerFromUI(HumanoidInstance owner, BaseBuildingInstance buildingOwned)
		{
			if (buildingOwned != null && !buildingOwned.IsForbiddenPrisonCell)
			{
				this.owner = owner;
				this.buildingOwned = buildingOwned;
				tempOwner = null;
				Map.BuildingsManagerMain.RegisterOwnedBuilding(this.owner, this.buildingOwned);
			}
		}

		public void ClearOwner()
		{
			Map.BuildingsManagerMain.UnregisterOwnedBuilding(owner, buildingOwned);
			owner = null;
		}

		public void CheckIfObjectIsInPrisonCell()
		{
			if (buildingOwned != null && !buildingOwned.HasDisposed && buildingOwned.IsForbiddenPrisonCell)
			{
				ClearOwner();
			}
		}

		public bool IsOwner(HumanoidInstance humanoidInstance)
		{
			if (humanoidInstance == null)
			{
				return false;
			}
			if (owner == null)
			{
				return false;
			}
			return owner.UniqueId == humanoidInstance.UniqueId;
		}

		public void SetupAfterLoading(BaseBuildingInstance buildingOwned)
		{
			this.buildingOwned = buildingOwned;
			TryResetHumanOwner();
			Map.BuildingsManagerMain.RegisterOwnedBuilding(owner, this.buildingOwned);
		}

		private void TryResetHumanOwner()
		{
			if (owner == null)
			{
				return;
			}
			bool isEnabled;
			foreach (HumanoidInstance caravanHuman in MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.CaravanHumans)
			{
				if (caravanHuman.GetUniqueId() == owner.GetUniqueId() && owner != caravanHuman)
				{
					owner = caravanHuman;
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(24, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\States\\BuildingOwnershipInfo.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Re-setting owner of ");
						messageBuilder.AppendFormatted(buildingOwned.BlueprintId);
						messageBuilder.AppendLiteral(" to ");
						messageBuilder.AppendFormatted(owner);
					}
					Log.Debug(messageBuilder);
				}
			}
			foreach (HumanoidInstance worker in GlobalSaveController.CurrentVillageData.Workers)
			{
				if (worker.GetUniqueId() == owner.GetUniqueId() && owner != worker)
				{
					owner = worker;
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(24, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\States\\BuildingOwnershipInfo.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Re-setting owner of ");
						messageBuilder.AppendFormatted(buildingOwned.BlueprintId);
						messageBuilder.AppendLiteral(" to ");
						messageBuilder.AppendFormatted(owner);
					}
					Log.Debug(messageBuilder);
				}
			}
		}

		public string GetLocalizedOwner()
		{
			return owner?.Info.GetFullName() ?? string.Empty;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("owner", owner);
		}

		public BuildingOwnershipInfo(FVDeserializer deserializer)
		{
			owner = deserializer.ReadObject<HumanoidInstance>("owner");
		}

		public void Dispose()
		{
			if (!LoadingController.IsLeavingMainScene)
			{
				Map.BuildingsManagerMain.UnregisterOwnedBuilding(owner, buildingOwned);
			}
			owner = null;
			map = null;
			buildingOwned = null;
			tempOwner = null;
		}
	}
}
