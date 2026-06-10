using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StorageUniversal;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseHaulingMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseHaulingMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Hauling)
		{
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_hauling");
			if (!(base.Owner.GetAsTarget() is ResourcePileInstance resourcePileInstance))
			{
				base.IsEnabled = false;
				return;
			}
			EnableIfWorkerIsSelected();
			DisableIfUnreachableFromSelectedWorker(resourcePileInstance);
			if (base.IsEnabled)
			{
				ResourceInstance storedResource = resourcePileInstance.GetStoredResource();
				IStorage storage = PathfinderUtil.FindNearestStorage(GetSelectedWorker(), storedResource);
				base.IsEnabled = storedResource != null && storage != null;
				if (!base.IsEnabled)
				{
					base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("nowhere_to_store");
				}
				else
				{
					HandleIfReservedMessage();
				}
			}
		}

		public override bool Setup(AdditionalMenuFloatingElement overlayElement, AdditionalMenuItemData data)
		{
			if (!(base.Owner.GetAsTarget() is ResourcePileInstance resourcePileInstance) || resourcePileInstance.IsStoredOnStockpile())
			{
				return false;
			}
			return base.Setup(overlayElement, data);
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed)
			{
				ResourcePileInstance resourcePileInstance = (ResourcePileInstance)base.Owner.GetAsTarget();
				if (resourcePileInstance.IsForbidden)
				{
					resourcePileInstance.IsForbidden = false;
				}
				if (MonoSingleton<StorageCommonManager>.Instance.CanStoreAnywhere(resourcePileInstance.GetStoredResource()))
				{
					MonoSingleton<ReservationManager>.Instance.ReleaseAll(resourcePileInstance);
					ForceGoal("StockpileHaulingGoal", resourcePileInstance);
				}
				else
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText(base.Tooltip));
				}
			}
		}

		private void HandleIfReservedMessage()
		{
			if (!(base.Owner.GetAsTarget() is ResourcePileInstance resourcePileInstance) || !MonoSingleton<ReservationManager>.Instance.IsReserved(resourcePileInstance))
			{
				return;
			}
			bool isOnlyReserved = true;
			HumanoidInstance goapAgentOwner = GetSelectedWorker();
			MonoSingleton<ReservationManager>.Instance.ForEachReserver(resourcePileInstance, delegate(IGoapAgentOwner agent)
			{
				if (agent != goapAgentOwner)
				{
					isOnlyReserved = false;
				}
			});
			if (isOnlyReserved && resourcePileInstance.IsReserveAll)
			{
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("already_working_on_target");
			}
			else
			{
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("already_reserved_by_other_worker_will_cancel");
			}
		}
	}
}
