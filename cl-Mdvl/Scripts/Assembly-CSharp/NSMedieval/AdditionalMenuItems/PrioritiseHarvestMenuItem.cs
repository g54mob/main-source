using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Views.Resources;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseHarvestMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseHarvestMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Harvesting)
		{
			if (!(base.Owner.GetAsTarget() is PlantMapResourceInstance plantMapResourceInstance))
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_harvest_plant");
				base.IsEnabled = false;
				return;
			}
			OrderType possibleOrders = plantMapResourceInstance.GetPossibleOrders();
			if (possibleOrders.HasFlag(OrderType.Harvesting))
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_harvest_plant");
				base.Text = base.Text + " " + MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(plantMapResourceInstance.GetBlueprint().LocKeys));
				EnableIfWorkerIsSelected();
				DisableIfUnreachableFromSelectedWorker(plantMapResourceInstance);
				DisableIfReserved();
			}
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed && base.Owner.GetAsTarget() is PlantMapResourceInstance setPreferredReservable && base.Owner is PlantMapResourceView plantMapResourceView)
			{
				plantMapResourceView.GiveOrder(OrderType.Harvesting);
				ForceGoal("HarvestGoal", setPreferredReservable);
			}
		}
	}
}
