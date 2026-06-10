using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.UI.Utils;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseBuildingDeConstructionMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseBuildingDeConstructionMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Construction, canDoWhileDrafted: false, showWorkerSkillInTitle: false)
		{
			if (!(base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance))
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_building_deconstruction");
				base.IsEnabled = false;
				return;
			}
			if (!baseBuildingInstance.OwnedByPlayer())
			{
				base.IsEnabled = false;
				return;
			}
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_building_deconstruction");
			base.Text = base.Text + " " + BuildingUtils.GetLocalizedName(baseBuildingInstance.Blueprint.GetID());
			EnableIfWorkerIsSelected();
			DisableIfUnreachableFromSelectedWorker(baseBuildingInstance);
		}

		public override bool Setup(AdditionalMenuFloatingElement overlayElement, AdditionalMenuItemData data)
		{
			if (!(base.Owner.GetAsTarget() is BaseBuildingInstance { ConstructionPhase: ConstructionPhase.Finished }))
			{
				return false;
			}
			return base.Setup(overlayElement, data);
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			GetReserver()?.GetGoapAgent()?.Abort();
			HumanoidInstance humanoidInstance = GetSelectedWorker();
			if (humanoidInstance?.GetGoapAgent() == null || humanoidInstance.HasFainted || humanoidInstance.HasDisposed)
			{
				return;
			}
			BaseBuildingInstance baseObject = base.Owner.GetAsTarget() as BaseBuildingInstance;
			if (baseObject == null || (MonoSingleton<ReservationManager>.Instance.IsReserved(baseObject) && !MonoSingleton<ReservationManager>.Instance.IsReservedBy(baseObject, humanoidInstance)))
			{
				return;
			}
			if (baseObject.MarkedForDestruction)
			{
				ForceGoal("DeconstructGoal", baseObject);
				return;
			}
			baseObject.SetMarkedForDestruction(value: true);
			DestroyVoxelJobManager jobManager = humanoidInstance.Map.BuildingsManagerMain.ConstructionJobManager.DestroyVoxelManager;
			uint startingJobManagerVersion = jobManager.Version;
			MonoSingleton<TaskController>.Instance.WaitUntil((float time) => time > 5f || jobManager.Version != startingJobManagerVersion).Then(delegate
			{
				if (!humanoidInstance.HasFainted && !humanoidInstance.HasDisposed)
				{
					ForceGoal("DeconstructGoal", baseObject, humanoidInstance);
				}
			});
		}
	}
}
