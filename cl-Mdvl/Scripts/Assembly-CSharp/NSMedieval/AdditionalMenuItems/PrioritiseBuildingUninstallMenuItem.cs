using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.UI.Utils;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseBuildingUninstallMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseBuildingUninstallMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Construction, canDoWhileDrafted: false, showWorkerSkillInTitle: false)
		{
			if (base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance && baseBuildingInstance.OwnedByPlayer() && baseBuildingInstance.Blueprint.CanBeMoved)
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_building_uninstall");
				base.Text = base.Text + " " + BuildingUtils.GetLocalizedName(baseBuildingInstance.Blueprint.GetID());
				EnableIfWorkerIsSelected();
				DisableIfUnreachableFromSelectedWorker(baseBuildingInstance);
				DisableIfReserved();
			}
		}

		public override bool Setup(AdditionalMenuFloatingElement overlayElement, AdditionalMenuItemData data)
		{
			if (!(base.Owner.GetAsTarget() is BaseBuildingInstance { HasDisposed: false, ConstructionPhase: ConstructionPhase.Finished }))
			{
				return false;
			}
			return base.Setup(overlayElement, data);
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed && base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance && (!MonoSingleton<ReservationManager>.Instance.IsReserved(baseBuildingInstance) || MonoSingleton<ReservationManager>.Instance.IsReservedBy(baseBuildingInstance, selectedWorker)))
			{
				baseBuildingInstance.SetIsMarkedForUninstall(!baseBuildingInstance.MarkedForMoving);
				MonoSingleton<ConstructablesGoapUninstallManager>.Instance.AddToUninstallList(baseBuildingInstance);
				ForceGoal("UninstallBuildingGoal", baseBuildingInstance);
			}
		}
	}
}
