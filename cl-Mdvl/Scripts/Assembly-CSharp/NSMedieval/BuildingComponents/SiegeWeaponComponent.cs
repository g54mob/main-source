using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.CombatAi;
using NSMedieval.Components;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.MovableBuildings;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent), typeof(BuildingUsePositionsToParentComponent))]
	public class SiegeWeaponComponent : BaseComponent
	{
		[NonSerialized]
		private BuildingUsePositionsComponent buildingUsePositionsComponent;

		[SerializeField]
		private Transform guiOverlayHookTransform;

		[NonSerialized]
		private SiegeWeaponComponentInstance componentInstance;

		private bool hasInfoChanged;

		private ReservablePositionsComponentInstance reservablePositionsComponentInstance;

		public SiegeWeaponComponentInstance ComponentInstance => componentInstance;

		public BuildingUsePositionsComponent BuildingUsePositionsComponent => buildingUsePositionsComponent;

		public event Action AttackOrderButtonClickEvent;

		public event Action CancelOrderButtonClickEvent;

		public event Action ContinuousAttackOrderButtonClickEvent;

		public event Action CancelContinuousAttackOrderButtonClickEvent;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			buildingUsePositionsComponent = null;
			componentInstance = null;
			reservablePositionsComponentInstance = null;
			this.CancelContinuousAttackOrderButtonClickEvent = null;
			this.ContinuousAttackOrderButtonClickEvent = null;
			this.CancelOrderButtonClickEvent = null;
			this.AttackOrderButtonClickEvent = null;
		}

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			buildingUsePositionsComponent = GetComponent<BuildingUsePositionsComponent>();
			reservablePositionsComponentInstance = new ReservablePositionsComponentInstance();
		}

		public void SetHasInfoChanged(bool hasInfoChanged)
		{
			this.hasInfoChanged = hasInfoChanged;
		}

		protected override void OnEnterPoolOnMainSceneLeaving()
		{
			base.OnEnterPoolOnMainSceneLeaving();
			this.AttackOrderButtonClickEvent = null;
			this.CancelOrderButtonClickEvent = null;
			this.ContinuousAttackOrderButtonClickEvent = null;
			this.CancelContinuousAttackOrderButtonClickEvent = null;
			if (buildingUsePositionsComponent != null)
			{
				buildingUsePositionsComponent.Dispose();
			}
			if (componentInstance != null)
			{
				componentInstance.RightClickResetTargetingEvent -= OnRightClickResetTargeting;
				componentInstance.RotateTowardsTargetEvent -= OnRotateTowardsTarget;
				componentInstance = null;
			}
		}

		protected override void OnReturnToPoolDuringGameplay()
		{
			base.OnReturnToPoolDuringGameplay();
			this.AttackOrderButtonClickEvent = null;
			this.CancelOrderButtonClickEvent = null;
			this.ContinuousAttackOrderButtonClickEvent = null;
			this.CancelContinuousAttackOrderButtonClickEvent = null;
			if (buildingUsePositionsComponent != null)
			{
				buildingUsePositionsComponent.Dispose();
			}
			if (componentInstance != null)
			{
				componentInstance.RightClickResetTargetingEvent -= OnRightClickResetTargeting;
				componentInstance.RotateTowardsTargetEvent -= OnRotateTowardsTarget;
				componentInstance = null;
			}
		}

		protected override void OnBaseBuildingEnterFinishedState(bool afterLoading = false)
		{
			SetReservablePositions();
			if (!afterLoading)
			{
				SiegeWeaponComponentBlueprint byID = Repository<SiegeWeaponComponentRepository, SiegeWeaponComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.SiegeWeaponComponentID);
				SiegeWeaponCopySettingsData siegeWeaponCopySettingsData = null;
				using PooledList<ResourceInstance> pooledList = base.OwnerBuilding.Storage.Resources.ToPooledListJanitor();
				foreach (ResourceInstance item in pooledList)
				{
					if (item is MoveBuildingResourceInstance moveBuildingResourceInstance)
					{
						siegeWeaponCopySettingsData = moveBuildingResourceInstance.SiegeWeaponCopySettingsData;
						(base.OwnerBuilding.Storage.Take(moveBuildingResourceInstance) as MoveBuildingResourceInstance)?.Dispose();
					}
				}
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID);
				if (siegeWeaponCopySettingsData != null)
				{
					componentInstance.PasteSettings(siegeWeaponCopySettingsData);
				}
			}
			else
			{
				componentInstance = base.OwnerBuilding.Village.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as SiegeWeaponComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(69, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\SiegeWeapons\\SiegeWeaponComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find SiegeWeaponComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
					}
					Log.Error(messageBuilder);
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			base.BaseBuildingViewComponent.SetAdditionalMenuItemId("trebuchet");
			base.BaseComponentInstance = componentInstance;
			componentInstance.CacheReservablePositionsComponentInstance(reservablePositionsComponentInstance);
			componentInstance.Map.SiegeWeaponComponentManager.AddToCache(this, componentInstance);
			componentInstance.RightClickResetTargetingEvent += OnRightClickResetTargeting;
			componentInstance.RotateTowardsTargetEvent += OnRotateTowardsTarget;
			base.OnBaseBuildingEnterFinishedState(afterLoading);
		}

		private void OnRotateTowardsTarget()
		{
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(SetReservablePositions);
		}

		private void SetReservablePositions()
		{
			reservablePositionsComponentInstance.SetupReservablePositions(buildingUsePositionsComponent.UseTransforms);
		}

		protected override Transform OnRequestGuiOverlayHookTransform()
		{
			return guiOverlayHookTransform;
		}

		protected override void OnInfoPanelDataRequested()
		{
			string buildingName = base.OwnerBuilding.GetBuildingName();
			InfoPanelHeader header = new InfoPanelHeader("Trebuchet", buildingName, string.Empty);
			InfoPanelBody body = new InfoPanelBody("Trebuchet", buildingName, string.Empty, base.BaseBuildingViewComponent.GetInfoStats(), null, GetResourcesInfo(), base.BaseBuildingViewComponent.GetDescriptions(), GetInfos(), BuildingSubCategoryUI.None);
			InfoPanelData infoPanelData = new TrebuchetInfoPanelData(ComponentInstance, header, body, new InfoPanelFooter(GetActions()), new InfoPanelSiegeWeapon(ComponentInstance));
			hasInfoChanged = false;
			base.BaseBuildingViewComponent.SetInfoPanelData(infoPanelData);
		}

		private List<InfoPanelResource> GetResourcesInfo()
		{
			List<InfoPanelResource> list = new List<InfoPanelResource>();
			if (ComponentInstance == null || ComponentInstance.HasDisposed || ComponentInstance.OwnerBuilding == null || ComponentInstance.OwnerBuilding.HasDisposed)
			{
				return list;
			}
			foreach (ResourceInstance resource in ComponentInstance.Storage.Resources)
			{
				list.Add(new InfoPanelResource(resource.Blueprint.GetID(), "resource", $" ~{Mathf.RoundToInt(resource.Amount)}"));
			}
			return list;
		}

		private List<string> GetInfos()
		{
			List<string> infos = base.BaseBuildingViewComponent.GetInfos();
			if (MonoSingleton<ReservationManager>.Instance.IsReserved(ComponentInstance))
			{
				infos.Add(MonoSingleton<LocalizationController>.Instance.GetText("trebuchet_has_agent"));
			}
			else
			{
				infos.Add(MonoSingleton<LocalizationController>.Instance.GetText("trebuchet_no_agent"));
				infos.Add(MonoSingleton<LocalizationController>.Instance.GetText("info_need_operate"));
			}
			bool flag = false;
			foreach (Resource allowedResourceType in componentInstance.ResourcesFilter.AllowedResourceTypes)
			{
				if (MonoSingleton<ResourcePileTracker>.Instance.GetCount(allowedResourceType).AllowedCount > 0)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				infos.Add("<style=DefaultRed>" + MonoSingleton<LocalizationController>.Instance.GetText("no_piles_allowed") + "</style>");
			}
			return infos;
		}

		private List<InfoPanelAction> GetActions()
		{
			List<InfoPanelAction> list = new List<InfoPanelAction>();
			list.AddRange(base.BaseBuildingViewComponent.GetInfoPanelActions());
			if (!MonoSingleton<ReservationManager>.Instance.IsReserved(ComponentInstance))
			{
				return list;
			}
			HumanoidInstance humanoidInstance = MonoSingleton<ReservationManager>.Instance.GetSingleReserver(ComponentInstance) as HumanoidInstance;
			if (humanoidInstance == null)
			{
				return list;
			}
			KeyValuePair<SelectionInputActionData, Action>[] objectActions = new KeyValuePair<SelectionInputActionData, Action>[1]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("ExitTrebuchet"), delegate
				{
					OnExitTrebuchetClick(humanoidInstance);
				})
			};
			list.Add(new InfoPanelAction(objectActions));
			if (MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count > 1)
			{
				return list;
			}
			int currentIndex = ((componentInstance.IsPlayerTargeting && !componentInstance.ContinuousAttack) ? 1 : 0);
			KeyValuePair<SelectionInputActionData, Action>[] objectActions2 = new KeyValuePair<SelectionInputActionData, Action>[2]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("SiegeWeaponAttack"), OnAttackOrderButtonClick),
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), OnCancelAttackButtonOrderClick)
			};
			list.Add(new InfoPanelAction(objectActions2, currentIndex));
			int currentIndex2 = (componentInstance.ContinuousAttack ? 1 : 0);
			KeyValuePair<SelectionInputActionData, Action>[] objectActions3 = new KeyValuePair<SelectionInputActionData, Action>[2]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("SiegeWeaponAttackContinuously"), OnContinuousAttackOrderButtonClick),
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), OnCancelContinuousAttackOrderButtonClick)
			};
			list.Add(new InfoPanelAction(objectActions3, currentIndex2));
			return list;
		}

		private void OnExitTrebuchetClick(HumanoidInstance humanoidInstance)
		{
			ComponentInstance.ContinuousAttack = false;
			MonoSingleton<ReservationManager>.Instance.ReleaseObject(componentInstance, humanoidInstance);
			humanoidInstance.CombatAi?.SetState(CombatAiState.OperatingTrebuchet, null);
			humanoidInstance.GetGoapAgent().Abort();
			MonoSingleton<InputManager>.Instance.GetListener(InputListenerType.Trebuchet).Disable();
			MonoSingleton<SelectableObjectManager>.Instance.DeselectAll();
		}

		private void OnRightClickResetTargeting()
		{
			if (ComponentInstance.ContinuousAttack)
			{
				OnCancelContinuousAttackOrderButtonClick();
			}
			else
			{
				OnCancelAttackButtonOrderClick();
			}
		}

		private void OnAttackOrderButtonClick()
		{
			if (componentInstance.ContinuousAttack)
			{
				OnCancelContinuousAttackOrderButtonClick();
			}
			hasInfoChanged = true;
			ComponentInstance.IsPlayerTargeting = true;
			if (ComponentInstance.IsPlayerTargeting)
			{
				MonoSingleton<InputManager>.Instance.GetListener(InputListenerType.Trebuchet).Enable();
			}
			else
			{
				MonoSingleton<InputManager>.Instance.GetListener(InputListenerType.Trebuchet).Disable();
			}
			this.AttackOrderButtonClickEvent?.Invoke();
		}

		private void OnCancelAttackButtonOrderClick()
		{
			hasInfoChanged = true;
			ComponentInstance.IsPlayerTargeting = false;
			ComponentInstance.ResetTarget();
			if (ComponentInstance.IsPlayerTargeting)
			{
				MonoSingleton<InputManager>.Instance.GetListener(InputListenerType.Trebuchet).Enable();
			}
			else
			{
				MonoSingleton<InputManager>.Instance.GetListener(InputListenerType.Trebuchet).Disable();
			}
			this.CancelOrderButtonClickEvent?.Invoke();
		}

		private void OnContinuousAttackOrderButtonClick()
		{
			if (componentInstance.IsPlayerTargeting)
			{
				OnCancelAttackButtonOrderClick();
			}
			hasInfoChanged = true;
			ComponentInstance.IsPlayerTargeting = true;
			ComponentInstance.ContinuousAttack = true;
			if (ComponentInstance.IsPlayerTargeting)
			{
				MonoSingleton<InputManager>.Instance.GetListener(InputListenerType.Trebuchet).Enable();
			}
			else
			{
				MonoSingleton<InputManager>.Instance.GetListener(InputListenerType.Trebuchet).Disable();
			}
			this.ContinuousAttackOrderButtonClickEvent?.Invoke();
		}

		private void OnCancelContinuousAttackOrderButtonClick()
		{
			hasInfoChanged = true;
			ComponentInstance.IsPlayerTargeting = false;
			ComponentInstance.ContinuousAttack = false;
			ComponentInstance.ResetTarget();
			if (ComponentInstance.IsPlayerTargeting && ComponentInstance.IsOperatorReady && ComponentInstance.ContinuousAttack)
			{
				MonoSingleton<InputManager>.Instance.GetListener(InputListenerType.Trebuchet).Enable();
			}
			else
			{
				MonoSingleton<InputManager>.Instance.GetListener(InputListenerType.Trebuchet).Disable();
			}
			this.CancelContinuousAttackOrderButtonClickEvent?.Invoke();
		}
	}
}
