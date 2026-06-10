using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Tutorial;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Views.Resources;

namespace NSMedieval.MovableBuildings
{
	public class BuildingPileView : ResourcePileView
	{
		[field: NonSerialized]
		public MovableBuildingPileInstance MovableBuildingPileInstance { get; private set; }

		public string BuildingId => MovableBuildingPileInstance.TargetBuildingId;

		public override void Dispose()
		{
			MovableBuildingPileInstance = null;
			base.Dispose();
		}

		public override void OnLeavingMainScene()
		{
			MovableBuildingPileInstance = null;
			base.OnLeavingMainScene();
		}

		public override void Setup(ResourcePileInstance pile)
		{
			MovableBuildingPileInstance movableBuildingPileInstance = (MovableBuildingPileInstance)pile;
			MovableBuildingPileInstance = movableBuildingPileInstance;
			base.Setup(pile);
		}

		protected override List<InfoPanelAction> GetInfoPanelActions()
		{
			if (TutorialManager.IsTutorialActive)
			{
				return new List<InfoPanelAction>();
			}
			if (base.ResourcePileInstance == null || base.ResourcePileInstance.HasDisposed || !base.ResourcePileInstance.OwnedByPlayer())
			{
				return new List<InfoPanelAction>();
			}
			int currentIndex = ((MovableBuildingPileInstance.TargetBuilding != null && !MovableBuildingPileInstance.TargetBuilding.HasDisposed) ? 1 : 0);
			KeyValuePair<SelectionInputActionData, Action>[] objectActions = new KeyValuePair<SelectionInputActionData, Action>[2]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("InstallBuilding"), InstallBuilding),
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), CancelUninstall)
			};
			return base.GetInfoPanelActions().Append(new InfoPanelAction(objectActions, currentIndex)).ToList();
		}

		public override string GetSimpleName()
		{
			return BuildingUtils.GetLocalizedName(MovableBuildingPileInstance.TargetBuildingId);
		}

		protected override string GetMaterial()
		{
			List<string> meshVariations = MovableBuildingPileInstance.MoveBuildingResourceInstance.MeshVariations;
			if (meshVariations != null && meshVariations.Count > 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (string item in meshVariations)
				{
					string variationIconName = BuildingUtils.GetVariationIconName(MovableBuildingPileInstance.TargetBuildingId, item);
					if (!string.IsNullOrEmpty(variationIconName))
					{
						stringBuilder.Append(AssetUtils.GetSpriteAsset(variationIconName) ?? "");
						return $"<style=\"TooltipSpriteAsset\">{stringBuilder}</style>";
					}
				}
			}
			return string.Empty;
		}

		private void InstallBuilding()
		{
			if (MovableBuildingPileInstance != null && !MovableBuildingPileInstance.HasDisposed)
			{
				MonoSingleton<MoveBuildingsManager>.Instance.SetPileToInstall(MovableBuildingPileInstance);
				MonoSingleton<BuildingPlacementManager>.Instance.CachePileToInstall(MovableBuildingPileInstance);
				MonoSingleton<BuildingPlacementManager>.Instance.InitializeBuilding(BuildingId, RelocateBuilding.Install);
			}
		}

		private void CancelUninstall()
		{
			if (MovableBuildingPileInstance != null && !MovableBuildingPileInstance.HasDisposed)
			{
				MonoSingleton<ConstructionController>.Instance.CancelPileInstallation(MovableBuildingPileInstance);
			}
		}
	}
}
