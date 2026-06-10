using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.MovableBuildings
{
	public class MoveBuildingsManager : MonoSingleton<MoveBuildingsManager>
	{
		private Dictionary<BaseBuildingInstance, MoveBuildingInfo> newBuildingInstanceDict = new Dictionary<BaseBuildingInstance, MoveBuildingInfo>();

		private Dictionary<BaseBuildingInstance, MoveBuildingInfo> oldBuildingInstanceDict = new Dictionary<BaseBuildingInstance, MoveBuildingInfo>();

		[NonSerialized]
		private BaseBuildingInstance buildingToMove;

		[NonSerialized]
		private MovableBuildingPileInstance pileToInstall;

		public int Count => newBuildingInstanceDict.Count;

		public BaseBuildingInstance BuildingToMove => buildingToMove;

		public MovableBuildingPileInstance PileToInstall => pileToInstall;

		public BaseBuildingInstance GetSourceBuilding(BaseBuildingInstance moveBlueprint)
		{
			if (!newBuildingInstanceDict.TryGetValue(moveBlueprint, out var value))
			{
				return null;
			}
			return value.OldBuilding;
		}

		public BaseBuildingInstance GetMovedBaseBuildingInstance()
		{
			if (buildingToMove != null)
			{
				return buildingToMove;
			}
			if (pileToInstall != null)
			{
				return pileToInstall.TargetBuilding ?? pileToInstall.MoveBuildingResourceInstance.TargetBuilding;
			}
			return null;
		}

		public BaseBuildingBlueprint GetMovedObjectBlueprint()
		{
			if (buildingToMove != null)
			{
				return buildingToMove.Blueprint;
			}
			if (pileToInstall != null)
			{
				if (pileToInstall.TargetBuilding != null && pileToInstall.TargetBuilding.VariationsApplied != null && pileToInstall.TargetBuilding.VariationsApplied.Count > 0)
				{
					return pileToInstall.TargetBuilding.Blueprint;
				}
				return pileToInstall.MoveBuildingResourceInstance.TargetBaseBlueprint;
			}
			return null;
		}

		public BaseBuildingInstance GetMoveBlueprintSourceBuilding(BaseBuildingInstance moveBlueprint)
		{
			newBuildingInstanceDict.TryGetValue(moveBlueprint, out var value);
			return value?.OldBuilding;
		}

		public IReadOnlyList<string> GetMovedObjectMeshVariations()
		{
			if (buildingToMove != null)
			{
				return buildingToMove.VariationsApplied;
			}
			if (pileToInstall == null)
			{
				return null;
			}
			BaseBuildingInstance targetBuilding = pileToInstall.TargetBuilding;
			if (targetBuilding != null)
			{
				IReadOnlyList<string> variationsApplied = targetBuilding.VariationsApplied;
				if (variationsApplied != null && variationsApplied.Count > 0)
				{
					return pileToInstall.TargetBuilding.VariationsApplied;
				}
			}
			return pileToInstall?.MoveBuildingResourceInstance?.MeshVariations;
		}

		public void SetBuildingToMove(BaseBuildingInstance buildingToMove)
		{
			this.buildingToMove = buildingToMove;
		}

		public void SetPileToInstall(MovableBuildingPileInstance pileToInstall)
		{
			this.pileToInstall = pileToInstall;
			this.pileToInstall.OnDisposedEvent += OnPileToInstallDisposed;
		}

		private void OnPileToInstallDisposed(IDisposable obj)
		{
			if (MonoSingleton<BuildingPlacementManager>.IsInstantiated())
			{
				MonoSingleton<BuildingPlacementManager>.Instance.CancelSelection(resetCancelPlacement: true);
			}
			pileToInstall = null;
		}

		public void LoadingSetup()
		{
			CacheAfterLoading(GlobalSaveController.CurrentVillageData.MoveBuildingInfos);
		}

		public void BuildingDeconstructed(BaseBuildingInstance deconstructedBuilding)
		{
			if (deconstructedBuilding != null)
			{
				oldBuildingInstanceDict.Remove(deconstructedBuilding);
				newBuildingInstanceDict.Remove(deconstructedBuilding);
			}
		}

		public void MoveCanceledFromSource(BaseBuildingInstance sourceBuilding)
		{
			oldBuildingInstanceDict.TryGetValue(sourceBuilding, out var value);
			if (value != null)
			{
				VillageManager.ActiveVillage.Map.BuildingsManagerMain.DestroyBuilding(value.NewBuilding);
				oldBuildingInstanceDict.Remove(sourceBuilding);
				newBuildingInstanceDict.Remove(value.NewBuilding);
				GlobalSaveController.CurrentVillageData.MoveBuildingInfos.Remove(value);
			}
		}

		public void BlueprintCanceled(BaseBuildingInstance canceledBuilding)
		{
			if (!canceledBuilding.IsMoveBlueprint)
			{
				return;
			}
			MonoSingleton<ResourcePileController>.Instance.InstallBuildingCancelled(canceledBuilding);
			oldBuildingInstanceDict.TryGetValue(canceledBuilding, out var value);
			if (value?.OldBuilding != null)
			{
				oldBuildingInstanceDict.Remove(canceledBuilding);
				if (value.NewBuilding != null)
				{
					newBuildingInstanceDict.Remove(value.NewBuilding);
				}
				MonoSingleton<ConstructablesGoapUninstallManager>.Instance.RemoveFromUninstallList(value.OldBuilding);
				GlobalSaveController.CurrentVillageData.MoveBuildingInfos.Remove(value);
				return;
			}
			newBuildingInstanceDict.TryGetValue(canceledBuilding, out var value2);
			if (value2?.NewBuilding != null)
			{
				if (value2.OldBuilding != null)
				{
					oldBuildingInstanceDict.Remove(value2.OldBuilding);
					value2.OldBuilding.SetIsMarkedForMoving(markedForMoving: false);
				}
				newBuildingInstanceDict.Remove(canceledBuilding);
				MonoSingleton<ConstructablesGoapUninstallManager>.Instance.RemoveFromUninstallList(value2.OldBuilding);
				GlobalSaveController.CurrentVillageData.MoveBuildingInfos.Remove(value2);
			}
		}

		public void SourceBuildingDestroyed(BaseBuildingInstance sourceBuilding)
		{
			if (sourceBuilding != null && !sourceBuilding.MarkedForMoving)
			{
				MoveCanceledFromSource(sourceBuilding);
			}
		}

		private void CacheAfterLoading(List<MoveBuildingInfo> moveBuildingInfos)
		{
			if (moveBuildingInfos == null)
			{
				return;
			}
			foreach (MoveBuildingInfo moveBuildingInfo in moveBuildingInfos)
			{
				BaseBuildingInstance newBuilding = moveBuildingInfo.NewBuilding;
				BaseBuildingInstance oldBuilding = moveBuildingInfo.OldBuilding;
				if (newBuilding == null || newBuilding.HasDisposed)
				{
					continue;
				}
				if (newBuildingInstanceDict.ContainsKey(newBuilding))
				{
					Log.Warning("New instance already added to dictionary.", "C:\\GIT\\dev\\Assets\\Scripts\\MovableBuildings\\MoveBuildingsManager.cs");
					continue;
				}
				if (oldBuilding != null && oldBuildingInstanceDict.ContainsKey(oldBuilding))
				{
					Log.Error("Old instance already added to dictionary.", "C:\\GIT\\dev\\Assets\\Scripts\\MovableBuildings\\MoveBuildingsManager.cs");
					continue;
				}
				newBuildingInstanceDict.Add(newBuilding, moveBuildingInfo);
				if (oldBuilding != null)
				{
					oldBuildingInstanceDict.Add(oldBuilding, moveBuildingInfo);
					MonoSingleton<ConstructablesGoapUninstallManager>.Instance.AddToUninstallList(oldBuilding);
				}
			}
		}

		private void Start()
		{
			MonoSingleton<BuildingPlacementManager>.Instance.SelectionCanceledEvent += OnCancelPlacement;
			MonoSingleton<ConstructionController>.Instance.BuildingUninstalledEvent += OnBaseBuildingUninstalled;
			MonoSingleton<ConstructionController>.Instance.BuildingMovePlacedEvent += OnBuildingMovePlaced;
			MonoSingleton<ConstructionController>.Instance.InstallBuildingPlacedEvent += OnInstallBuildingPlaced;
			MonoSingleton<ConstructionController>.Instance.CancelPileInstallationEvent += OnCancelInstallFromPile;
			MonoSingleton<CaravanController>.Instance.PileAddedToCaravanEvent += OnPileAddedToCaravan;
			MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent += OnConstructionCompleted;
			MonoSingleton<UIController>.Instance.BuildButtonClickEvent += OnBuildButtonClick;
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.BuildingUninstalledEvent -= OnBaseBuildingUninstalled;
				MonoSingleton<ConstructionController>.Instance.BuildingMovePlacedEvent -= OnBuildingMovePlaced;
				MonoSingleton<ConstructionController>.Instance.InstallBuildingPlacedEvent -= OnInstallBuildingPlaced;
				MonoSingleton<ConstructionController>.Instance.CancelPileInstallationEvent -= OnCancelInstallFromPile;
				MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent -= OnConstructionCompleted;
			}
			if (MonoSingleton<BuildingPlacementManager>.IsInstantiated())
			{
				MonoSingleton<BuildingPlacementManager>.Instance.SelectionCanceledEvent -= OnCancelPlacement;
			}
			if (MonoSingleton<CaravanController>.IsInstantiated())
			{
				MonoSingleton<CaravanController>.Instance.PileAddedToCaravanEvent -= OnPileAddedToCaravan;
			}
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.BuildButtonClickEvent -= OnBuildButtonClick;
			}
			buildingToMove = null;
			if (pileToInstall != null)
			{
				pileToInstall.OnDisposedEvent -= OnPileToInstallDisposed;
			}
			pileToInstall = null;
			base.OnDestroy();
		}

		private void OnBuildButtonClick()
		{
			buildingToMove = null;
			pileToInstall = null;
		}

		private void OnCancelPlacement()
		{
			if (BuildingToMove != null)
			{
				oldBuildingInstanceDict.TryGetValue(BuildingToMove, out var value);
				if (value == null)
				{
					BuildingToMove.SetIsMarkedForMoving(markedForMoving: false);
				}
				buildingToMove = null;
				pileToInstall = null;
			}
		}

		private void OnBaseBuildingUninstalled(BaseBuildingInstance uninstalledBuilding, Vector3 resourceSpawnPosition, HumanoidInstance humanoidInstance)
		{
			if (uninstalledBuilding == null)
			{
				return;
			}
			string blueprintId = uninstalledBuilding.BlueprintId;
			Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(blueprintId);
			if (byID == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\MovableBuildings\\MoveBuildingsManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Building resource with id ");
					messageBuilder.AppendFormatted(blueprintId);
					messageBuilder.AppendLiteral(" not found.");
				}
				Log.Error(messageBuilder);
				return;
			}
			MonoSingleton<ConstructablesGoapUninstallManager>.Instance.RemoveFromUninstallList(uninstalledBuilding);
			if (uninstalledBuilding.MarkedForUninstall)
			{
				MovableBuildingPileInstance movableBuildingPileInstance = MonoSingleton<ResourcePileManager>.Instance.SpawnPile(byID, resourceSpawnPosition, blueprintId).MovableBuildingPileInstance;
				movableBuildingPileInstance.MoveBuildingResourceInstance.SetTargetBuilding(null);
				movableBuildingPileInstance.Stats.GetStat(StatType.Health).SetCurrent(uninstalledBuilding.Stats.GetStat(StatType.Health).Current);
				movableBuildingPileInstance.MoveBuildingResourceInstance.SetBuildingId(uninstalledBuilding.BlueprintId);
				movableBuildingPileInstance.MoveBuildingResourceInstance.SaveComponentData(uninstalledBuilding);
				movableBuildingPileInstance.MoveBuildingResourceInstance.CloneMeshVariations(uninstalledBuilding?.MovableBuildingPileInstance?.MoveBuildingResourceInstance?.MeshVariations);
				movableBuildingPileInstance.MoveBuildingResourceInstance.SetProducerUniqueId(uninstalledBuilding.ProducerUniqueId);
				return;
			}
			oldBuildingInstanceDict.TryGetValue(uninstalledBuilding, out var value);
			if (value != null)
			{
				BaseBuildingInstance newBuilding = value.NewBuilding;
				MovableBuildingPileInstance movableBuildingPileInstance = MonoSingleton<ResourcePileManager>.Instance.SpawnPile(byID, resourceSpawnPosition, newBuilding).MovableBuildingPileInstance;
				movableBuildingPileInstance.MoveBuildingResourceInstance.SetTargetBuilding(newBuilding);
				movableBuildingPileInstance.Stats.GetStat(StatType.Health).SetCurrent(uninstalledBuilding.Stats.GetStat(StatType.Health).Current);
				movableBuildingPileInstance.MoveBuildingResourceInstance.SetBuildingId(uninstalledBuilding.BlueprintId);
				movableBuildingPileInstance.MoveBuildingResourceInstance.SaveComponentData(uninstalledBuilding);
				movableBuildingPileInstance.MoveBuildingResourceInstance.SetProducerUniqueId(uninstalledBuilding.ProducerUniqueId);
				newBuilding.SetMovableBuildingResourceInstance(movableBuildingPileInstance);
				newBuilding.OverrideDefaultConstructionConst(byID, 1);
				value.EraseOldBuilding();
				oldBuildingInstanceDict.Remove(uninstalledBuilding);
				ForceGoal("DeliverMoveBuildingResource", newBuilding, humanoidInstance);
			}
		}

		private void ForceGoal(string goalId, IReservable setPreferedReservable, HumanoidInstance humanoidInstance)
		{
			if (!(humanoidInstance.GetGoapAgent() is WorkerGoapAgent workerGoapAgent))
			{
				return;
			}
			if (setPreferedReservable != null)
			{
				MonoSingleton<ReservationManager>.Instance.SetPreferedReservable(humanoidInstance, setPreferedReservable);
				if (!MonoSingleton<ReservationManager>.Instance.TryToExclusiveReservation(setPreferedReservable, humanoidInstance, 1f))
				{
					bool isEnabled;
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(46, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\MovableBuildings\\MoveBuildingsManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Could not exclusive reserve item for humanoid:");
						messageBuilder.AppendFormatted(humanoidInstance);
					}
					Log.Warning(messageBuilder);
				}
			}
			workerGoapAgent.Abort();
			workerGoapAgent.ForceNextGoalExclusive(goalId);
		}

		private void OnConstructionCompleted(BaseBuildingInstance newBuilding)
		{
			newBuildingInstanceDict.TryGetValue(newBuilding, out var value);
			if (value == null)
			{
				return;
			}
			newBuildingInstanceDict.Remove(newBuilding);
			if (newBuilding.Storage.GetById(newBuilding.BlueprintId) is MoveBuildingResourceInstance moveBuildingResourceInstance)
			{
				if (moveBuildingResourceInstance.ProducerUniqueId != 0)
				{
					newBuilding.SetProducerUniqueId(moveBuildingResourceInstance.ProducerUniqueId);
				}
				float health = moveBuildingResourceInstance.Stats.GetStat(StatType.Health).Current;
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					newBuilding?.Stats?.GetStat(StatType.Health)?.SetCurrent(health);
				});
			}
			GlobalSaveController.CurrentVillageData.MoveBuildingInfos.Remove(value);
		}

		private void OnBuildingMovePlaced(BaseBuildingInstance newBuilding)
		{
			if (newBuildingInstanceDict.ContainsKey(newBuilding))
			{
				Log.Warning("New instance already added to dictionary.", "C:\\GIT\\dev\\Assets\\Scripts\\MovableBuildings\\MoveBuildingsManager.cs");
				return;
			}
			if (BuildingToMove == null)
			{
				Log.Warning("Building to Move is null", "C:\\GIT\\dev\\Assets\\Scripts\\MovableBuildings\\MoveBuildingsManager.cs");
				return;
			}
			if (oldBuildingInstanceDict.ContainsKey(BuildingToMove) && !RemoveOldBlueprint())
			{
				Log.Error("Couldn't swap old building with new!", "C:\\GIT\\dev\\Assets\\Scripts\\MovableBuildings\\MoveBuildingsManager.cs");
				return;
			}
			MoveBuildingInfo moveBuildingInfo = new MoveBuildingInfo(newBuilding, BuildingToMove);
			newBuildingInstanceDict.Add(newBuilding, moveBuildingInfo);
			oldBuildingInstanceDict.Add(BuildingToMove, moveBuildingInfo);
			MonoSingleton<ConstructablesGoapUninstallManager>.Instance.AddToUninstallList(BuildingToMove);
			newBuilding.SetIsMoved(isMoved: true);
			BuildingToMove.SetIsMarkedForMoving(markedForMoving: true);
			GlobalSaveController.CurrentVillageData.MoveBuildingInfos.Add(moveBuildingInfo);
			buildingToMove = null;
		}

		private bool RemoveOldBlueprint()
		{
			oldBuildingInstanceDict.TryGetValue(BuildingToMove, out var value);
			if (value == null)
			{
				return false;
			}
			VillageManager.ActiveVillage.Map.BuildingsManagerMain.DestroyBuilding(value.NewBuilding);
			newBuildingInstanceDict.Remove(value.NewBuilding);
			oldBuildingInstanceDict.Remove(BuildingToMove);
			GlobalSaveController.CurrentVillageData.MoveBuildingInfos.Remove(value);
			return true;
		}

		private void OnInstallBuildingPlaced(BaseBuildingInstance newBuilding)
		{
			if (PileToInstall == null)
			{
				return;
			}
			BaseBuildingInstance[] array = newBuildingInstanceDict.Keys.ToArray();
			foreach (BaseBuildingInstance baseBuildingInstance in array)
			{
				if (baseBuildingInstance.MovableBuildingPileInstance == PileToInstall)
				{
					MoveBuildingInfo moveBuildingInfo = newBuildingInstanceDict[baseBuildingInstance];
					VillageManager.ActiveVillage.Map.BuildingsManagerMain.DestroyBuilding(moveBuildingInfo.NewBuilding);
					newBuildingInstanceDict.Remove(baseBuildingInstance);
					GlobalSaveController.CurrentVillageData.MoveBuildingInfos.Remove(moveBuildingInfo);
				}
			}
			if (newBuildingInstanceDict.ContainsKey(newBuilding))
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(62, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\MovableBuildings\\MoveBuildingsManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Move building instance already added to dictionary. Position ");
					messageBuilder.AppendFormatted(newBuilding.GridDataPosition);
					messageBuilder.AppendLiteral(".");
				}
				Log.Warning(messageBuilder);
				return;
			}
			if (PileToInstall == null)
			{
				Log.Warning("The pile you're trying to install is null. This should never happen.", "C:\\GIT\\dev\\Assets\\Scripts\\MovableBuildings\\MoveBuildingsManager.cs");
				return;
			}
			MoveBuildingInfo moveBuildingInfo2 = new MoveBuildingInfo(newBuilding, null);
			newBuildingInstanceDict.Add(newBuilding, moveBuildingInfo2);
			newBuilding.SetIsMoved(isMoved: true);
			newBuilding.SetMovableBuildingResourceInstance(PileToInstall);
			newBuilding.OverrideDefaultConstructionConst(PileToInstall.Blueprint, 1);
			PileToInstall.MoveBuildingResourceInstance.SetTargetBuilding(newBuilding);
			PileToInstall.MoveBuildingResourceInstance.SetBuildingId(newBuilding.BlueprintId);
			GlobalSaveController.CurrentVillageData.MoveBuildingInfos.Add(moveBuildingInfo2);
			if (pileToInstall != null)
			{
				pileToInstall.OnDisposedEvent -= OnPileToInstallDisposed;
			}
			pileToInstall = null;
		}

		private void Cancel(ResourcePileInstance resourcePileInstance)
		{
			if (resourcePileInstance is MovableBuildingPileInstance movableBuildingPileInstance)
			{
				movableBuildingPileInstance.PlacementModeActive = false;
				BaseBuildingInstance targetBuilding = movableBuildingPileInstance.TargetBuilding;
				if (targetBuilding != null)
				{
					BlueprintCanceled(targetBuilding);
					VillageManager.ActiveVillage.Map.BuildingsManagerMain.DestroyBuilding(targetBuilding);
					movableBuildingPileInstance.MoveBuildingResourceInstance.SetTargetBuilding(null);
					buildingToMove = null;
				}
			}
		}

		private void OnPileAddedToCaravan(ResourcePileInstance resourcePileInstance)
		{
			Cancel(resourcePileInstance);
		}

		private void OnCancelInstallFromPile(ResourcePileInstance resourcePileInstance)
		{
			Cancel(resourcePileInstance);
		}
	}
}
