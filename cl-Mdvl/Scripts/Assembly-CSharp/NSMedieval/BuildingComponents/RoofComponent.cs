using System;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Construction;
using NSMedieval.Map;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent))]
	public class RoofComponent : BaseComponent
	{
		[NonSerialized]
		private RoofViewComponent viewComponent;

		[SerializeField]
		private RoofComponentInstance componentInstance;

		public RoofComponentInstance ComponentInstance => componentInstance;

		public event Action OnAfterComponentInstantiatedEvent;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			viewComponent = null;
			componentInstance = null;
			this.OnAfterComponentInstantiatedEvent = null;
		}

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			viewComponent = GetComponent<RoofViewComponent>();
		}

		public void CacheInstance(RoofComponentInstance componentInstance)
		{
			this.componentInstance = componentInstance;
			base.BaseComponentInstance = componentInstance;
			this.componentInstance.SetStartEndPositions(viewComponent.Positions.First(), viewComponent.Positions.Last());
			this.componentInstance.Positions.AddRangeUnique(viewComponent.Positions);
			this.componentInstance.CalculateEdgeLowPoints();
			this.componentInstance.Map.RoofComponentManager.AddToCache(this, this.componentInstance);
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.RoofConstructed(this.componentInstance);
			}
		}

		public void ShowRoof(bool fromSave = false)
		{
			if (!fromSave)
			{
				base.BaseBuildingViewComponent.SetForceHide(hidden: false);
			}
			base.BaseBuildingViewComponent.LayerObjectHide.SetBlockActivatingColliders(blockActivatingColliders: false);
			base.BaseBuildingViewComponent.LayerObjectHide.ForceActivateColliders();
			base.BaseBuildingViewComponent.LayerObjectHide.RefreshVisibility(MonoSingleton<World>.Instance.LayerLevel);
			base.BaseBuildingViewComponent.IgnoreSelectionHighlight = false;
		}

		public void HideRoof()
		{
			base.BaseBuildingViewComponent.SetForceHide(hidden: true);
			base.BaseBuildingViewComponent.LayerObjectHide.ForceDeactivateColliders();
			base.BaseBuildingViewComponent.LayerObjectHide.SetBlockActivatingColliders(blockActivatingColliders: true);
			base.BaseBuildingViewComponent.IgnoreSelectionHighlight = true;
		}

		protected override void OnEnterPoolOnMainSceneLeaving()
		{
			base.OnEnterPoolOnMainSceneLeaving();
			componentInstance = null;
		}

		protected override void OnReturnToPoolDuringGameplay()
		{
			base.OnReturnToPoolDuringGameplay();
			componentInstance = null;
		}

		protected override void OnAfterBaseBuildingPlaced(bool afterLoading = false)
		{
			if (afterLoading)
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as RoofComponentInstance;
				base.BaseComponentInstance = componentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(62, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Roofs\\RoofComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find RoofComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
					}
					Log.Error(messageBuilder);
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
				componentInstance.Map.RoofComponentManager.AddToCache(this, componentInstance);
			}
			base.OnAfterBaseBuildingPlaced(afterLoading);
			CheckRoofVisuals();
			this.OnAfterComponentInstantiatedEvent?.Invoke();
			this.OnAfterComponentInstantiatedEvent = null;
		}

		protected override void OnBaseBuildingEnterFinishedState(bool afterLoading = false)
		{
			base.OnBaseBuildingEnterFinishedState(afterLoading);
			CheckRoofVisuals();
		}

		private void CheckRoofVisuals()
		{
			if (!GlobalSaveController.CurrentVillageData.RoofsVisible)
			{
				HideRoof();
			}
		}
	}
}
