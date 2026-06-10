using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Types;
using NSMedieval.View.Resources;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseFishingMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseFishingMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Animal)
		{
			if (!(base.Owner.GetAsTarget() is FishMapResourceInstance fishMapResourceInstance))
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_fishing");
				base.IsEnabled = false;
				return;
			}
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_fishing");
			EnableIfWorkerIsSelected();
			DisableIfUnreachableFromSelectedWorker(fishMapResourceInstance);
			DisableIfReserved();
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed && base.Owner.GetAsTarget() is FishMapResourceInstance setPreferredReservable && base.Owner is FishMapResourceView fishMapResourceView)
			{
				fishMapResourceView.GiveOrder(OrderType.Fishing);
				ForceGoal("FishingGoal", setPreferredReservable);
			}
		}
	}
}
