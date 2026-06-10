using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseBarrelFill : AdditionalMenuPrioritiseItem
	{
		private readonly ShelfComponentInstance shelfComponentInstance;

		public PrioritiseBarrelFill(IAdditionalMenuOwner owner)
			: base(owner, JobType.Hauling)
		{
			if (!(base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance))
			{
				base.IsEnabled = false;
				return;
			}
			if (baseBuildingInstance.HasDisposed)
			{
				base.IsEnabled = false;
				return;
			}
			shelfComponentInstance = baseBuildingInstance.GetComponentInstance<ShelfComponentInstance>();
			if (shelfComponentInstance == null || shelfComponentInstance.HasDisposed || !shelfComponentInstance.Blueprint.Barrel)
			{
				base.IsEnabled = false;
			}
			else if (shelfComponentInstance.Underwater)
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_barrel_refill");
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("structure_in_water");
				base.IsEnabled = false;
			}
			else
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_barrel_refill");
				EnableIfWorkerIsSelected();
				DisableIfUnreachableFromSelectedWorker(baseBuildingInstance);
				DisableIfReserved();
			}
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			if (shelfComponentInstance == null || shelfComponentInstance.HasDisposed || shelfComponentInstance.Blueprint.LockStates.Count <= 0)
			{
				return;
			}
			if (shelfComponentInstance.Underwater)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("structure_in_water"));
				return;
			}
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed)
			{
				ForceGoal("BarrelFillGoal", shelfComponentInstance);
			}
		}
	}
}
