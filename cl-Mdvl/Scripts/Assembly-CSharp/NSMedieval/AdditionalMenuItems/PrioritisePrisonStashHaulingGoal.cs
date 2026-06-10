using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StorageUniversal;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritisePrisonStashHaulingGoal : AdditionalMenuPrioritiseItem
	{
		private bool resourcesExist;

		private ShelfComponentInstance shelfComponentInstance;

		public PrioritisePrisonStashHaulingGoal(IAdditionalMenuOwner owner)
			: base(owner, JobType.Gaoler)
		{
			if (!(base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance))
			{
				base.IsEnabled = false;
				return;
			}
			shelfComponentInstance = baseBuildingInstance.Map.ShelfComponentManager.GetComponentInstance(baseBuildingInstance);
			if (shelfComponentInstance == null || shelfComponentInstance.HasDisposed || !shelfComponentInstance.PrisonFeeder)
			{
				base.IsEnabled = false;
				return;
			}
			bool flag = false;
			foreach (UniversalStorage item in shelfComponentInstance.AllStorage)
			{
				if (item.GetFreeSpace() > 0)
				{
					flag = true;
					break;
				}
			}
			if (shelfComponentInstance.Underwater)
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_prison_stash_refill");
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("structure_in_water");
				base.IsEnabled = false;
				return;
			}
			if (!flag)
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_prison_stash_refill");
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("storage_full");
				base.IsEnabled = false;
				return;
			}
			resourcesExist = false;
			foreach (Resource allowedResourceType in shelfComponentInstance.ResourcesFilter.AllowedResourceTypes)
			{
				if (MonoSingleton<ResourcePileTracker>.Instance.GetCount(allowedResourceType).AllowedCount > 0)
				{
					resourcesExist = true;
					break;
				}
			}
			if (!resourcesExist)
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_prison_stash_refill");
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("building_error_no_resources");
				base.IsEnabled = false;
			}
			else
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_prison_stash_refill");
				EnableIfWorkerIsSelected();
				DisableIfUnreachableFromSelectedWorker(baseBuildingInstance);
				DisableIfReserved();
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			shelfComponentInstance = null;
		}

		protected override void OnClickCallback()
		{
			if (shelfComponentInstance.Underwater)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("structure_in_water"));
				base.OnClickCallback();
				return;
			}
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() == null || selectedWorker.HasFainted || selectedWorker.HasDisposed)
			{
				base.OnClickCallback();
				return;
			}
			if (!resourcesExist)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("building_error_no_resources"));
				base.OnClickCallback();
				return;
			}
			if (shelfComponentInstance.IsForbidden())
			{
				shelfComponentInstance.SetForbidden(isForbidden: false);
			}
			ForceGoal("PrisonStashHaulingGoal", shelfComponentInstance);
			base.OnClickCallback();
		}
	}
}
