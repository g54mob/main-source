using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Village;
using NSMedieval_Pooling;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent), typeof(BuildingUsePositionsComponent))]
	public class EntertainmentComponent : BaseComponent
	{
		[SerializeField]
		private EntertainmentComponentInstance componentInstance;

		[NonSerialized]
		private BuildingUsePositionsComponent buildingUsePositionsComponent;

		public Dictionary<Transform, Transform> ChairSitPositions = new Dictionary<Transform, Transform>();

		public EntertainmentComponentInstance ComponentInstance => componentInstance;

		public BuildingUsePositionsComponent BuildingUsePositionsComponent => buildingUsePositionsComponent;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			componentInstance = null;
			buildingUsePositionsComponent = null;
		}

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			buildingUsePositionsComponent = GetComponent<BuildingUsePositionsComponent>();
		}

		protected override void OnEnterPoolOnMainSceneLeaving()
		{
			base.OnEnterPoolOnMainSceneLeaving();
			ChairSitPositions.Clear();
			componentInstance = null;
			if (buildingUsePositionsComponent != null)
			{
				buildingUsePositionsComponent.Dispose();
			}
		}

		protected override void OnReturnToPoolDuringGameplay()
		{
			base.OnReturnToPoolDuringGameplay();
			ChairSitPositions.Clear();
			componentInstance = null;
			if (buildingUsePositionsComponent != null)
			{
				buildingUsePositionsComponent.Dispose();
			}
		}

		protected override void OnBaseBuildingEnterFinishedState(bool afterLoading = false)
		{
			ReservablePositionsComponentInstance reservablePositionsComponentInstance = new ReservablePositionsComponentInstance();
			reservablePositionsComponentInstance.SetupReservablePositions(buildingUsePositionsComponent.UseTransforms);
			if (!afterLoading)
			{
				EntertainmentComponentBlueprint byID = Repository<EntertainmentComponentRepository, EntertainmentComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.EntertainmentComponentID);
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID, reservablePositionsComponentInstance);
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as EntertainmentComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(71, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Entertainment\\EntertainmentComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find EntertainmentComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
					}
					Log.Error(messageBuilder);
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			componentInstance.CacheReservablePositionsComponentInstance(reservablePositionsComponentInstance);
			base.BaseComponentInstance = componentInstance;
			componentInstance.Map.EntertainmentComponentManager.AddToCache(this, componentInstance);
			foreach (Transform useTransform in buildingUsePositionsComponent.UseTransforms)
			{
				ChairSitPositions.Add(useTransform, GameObjectPool.GetDefaultEmpty(returnActive: true, "SitPosition").transform);
				ChairSitPositions[useTransform].SetParent(useTransform, worldPositionStays: false);
				componentInstance.Blueprint.SittingPosition.ApplyToTransform(ChairSitPositions[useTransform]);
			}
			base.OnBaseBuildingEnterFinishedState(afterLoading);
		}

		protected override void OnInfoPanelDataRequested()
		{
		}
	}
}
