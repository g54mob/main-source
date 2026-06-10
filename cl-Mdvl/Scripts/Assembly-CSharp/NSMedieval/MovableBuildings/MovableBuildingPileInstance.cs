using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.Serialization;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.MovableBuildings
{
	[Serializable]
	[FVSerializableKey("MovableBuildingPileInstance", "")]
	public class MovableBuildingPileInstance : ResourcePileInstance
	{
		[SerializeField]
		private MoveBuildingResourceInstance buildingResourceInstance;

		public BaseBuildingInstance TargetBuilding => buildingResourceInstance?.TargetBuilding;

		public string TargetBuildingId => buildingResourceInstance.TargetBuildingId;

		public MoveBuildingResourceInstance MoveBuildingResourceInstance => buildingResourceInstance;

		public bool PlacementModeActive { get; set; }

		public MovableBuildingPileInstance(MoveBuildingResourceInstance instance, Vector3 worldPosition)
			: base(instance, worldPosition)
		{
			buildingResourceInstance = instance;
			OverrideConstructionCost();
			MonoSingleton<ResourcePileController>.Instance.InstallBuildingCanceledEvent += OnInstallBuildingCanceled;
		}

		public override void ReInstantiate()
		{
			base.ReInstantiate();
			OverrideConstructionCost();
			buildingResourceInstance.SetupAfterLoading();
		}

		public override void Dispose()
		{
			base.Dispose();
			if (MonoSingleton<ResourcePileController>.IsInstantiated())
			{
				MonoSingleton<ResourcePileController>.Instance.InstallBuildingCanceledEvent -= OnInstallBuildingCanceled;
			}
			buildingResourceInstance = null;
		}

		public void PileAddedToCaravan()
		{
			if (TargetBuilding != null)
			{
				base.Map.BuildingsManagerMain.DestroyBuilding(TargetBuilding);
			}
		}

		protected override void ForbidStatusChanged()
		{
			TargetBuilding?.PileForbidChangedColorBlueprint(base.IsForbidden);
		}

		protected override void OnHealthDepleted(object stat)
		{
			if (TargetBuilding != null)
			{
				base.Map.BuildingsManagerMain.DestroyBuilding(TargetBuilding);
			}
			base.OnHealthDepleted(stat);
		}

		private void OverrideConstructionCost()
		{
			if (TargetBuilding == null)
			{
				return;
			}
			Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(TargetBuildingId);
			if (byID == null)
			{
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(72, 2, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\MovableBuildings\\MovableBuildingPileInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Failed to find resource with id ");
					messageBuilder.AppendFormatted(TargetBuildingId);
					messageBuilder.AppendLiteral(". Movable building pile grid position: ");
					messageBuilder.AppendFormatted(base.GridDataPosition);
					messageBuilder.AppendLiteral(".");
				}
				Log.Warning(messageBuilder);
				if (TargetBuilding?.Blueprint != null && !TargetBuilding.Blueprint.CanBeMoved)
				{
					messageBuilder = new FVLogWarningInterpolationHandler(117, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\MovableBuildings\\MovableBuildingPileInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Trying to override construction cost for a building that can't be moved. This should never happen. TargetBuildingId: ");
						messageBuilder.AppendFormatted(TargetBuildingId);
					}
					Log.Warning(messageBuilder);
				}
			}
			else
			{
				TargetBuilding.SetMovableBuildingResourceInstance(this);
				TargetBuilding.OverrideDefaultConstructionConst(byID, 1);
			}
		}

		private void OnInstallBuildingCanceled(BaseBuildingInstance cancelledBuilding)
		{
			if (cancelledBuilding == TargetBuilding)
			{
				PlacementModeActive = false;
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("buildingResourceInstance", buildingResourceInstance);
		}

		public MovableBuildingPileInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			buildingResourceInstance = deserializer.ReadObject<MoveBuildingResourceInstance>("buildingResourceInstance");
		}
	}
}
