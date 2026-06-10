using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.MovableBuildings;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseBuildingMaterialsDeliveryMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseBuildingMaterialsDeliveryMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Construction)
		{
			if (!(base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance))
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_building_construction");
				base.IsEnabled = false;
			}
			else
			{
				if (!baseBuildingInstance.OwnedByPlayer())
				{
					return;
				}
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_building_construction");
				base.Text = base.Text + " " + BuildingUtils.GetLocalizedName(baseBuildingInstance.Blueprint.GetID());
				if (!baseBuildingInstance.IsMoveBlueprint)
				{
					int minBuildSkillRequired = baseBuildingInstance.Blueprint.MinBuildSkillRequired;
					HumanoidInstance selectedWorker = GetSelectedWorker();
					if (selectedWorker != null && selectedWorker.Skills.GetSkill(SkillType.Construction).Level < minBuildSkillRequired)
					{
						base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("construction_skill_level_low");
						base.IsEnabled = false;
						return;
					}
				}
				if (!baseBuildingInstance.IsBlueprintOnClearNode())
				{
					base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("build_sight_must_be_clear");
					string localizedBlockerPile = baseBuildingInstance.GetLocalizedBlockerPile();
					if (!string.IsNullOrEmpty(localizedBlockerPile))
					{
						base.Tooltip = base.Tooltip + " (" + localizedBlockerPile + ")";
					}
					base.IsEnabled = false;
					return;
				}
				if (!baseBuildingInstance.HasStabilityToBuild)
				{
					base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("building_unstable");
					base.IsEnabled = false;
					return;
				}
				EnableIfWorkerIsSelected();
				DisableIfUnreachableFromSelectedWorker(baseBuildingInstance);
				DisableIfReserved();
				if (base.IsEnabled && !baseBuildingInstance.ResourcesAvailable)
				{
					base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("not_enough_construction_materials");
					base.IsEnabled = false;
				}
			}
		}

		public override bool Setup(AdditionalMenuFloatingElement overlayElement, AdditionalMenuItemData data)
		{
			if (!(base.Owner.GetAsTarget() is BaseBuildingInstance { ConstructionPhase: ConstructionPhase.Blueprint }))
			{
				return false;
			}
			return base.Setup(overlayElement, data);
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() == null || selectedWorker.HasFainted || selectedWorker.HasDisposed || !(base.Owner.GetAsTarget() is IReservable reservable) || !(reservable is BaseBuildingInstance baseBuildingInstance) || (MonoSingleton<ReservationManager>.Instance.IsReserved(baseBuildingInstance) && !MonoSingleton<ReservationManager>.Instance.IsReservedBy(baseBuildingInstance, selectedWorker)))
			{
				return;
			}
			if (baseBuildingInstance.IsMoveBlueprint)
			{
				BaseBuildingInstance sourceBuilding = MonoSingleton<MoveBuildingsManager>.Instance.GetSourceBuilding(baseBuildingInstance);
				if (sourceBuilding != null && !sourceBuilding.HasDisposed)
				{
					ForceGoal("UninstallBuildingGoal", sourceBuilding);
				}
				else
				{
					ForceGoal("DeliverMoveBuildingResource", baseBuildingInstance);
				}
			}
			else
			{
				ForceGoal("DeliverBuildingMaterialsGoal", reservable);
			}
		}
	}
}
