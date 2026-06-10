using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Views.Resources;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseChopMenuItem : AdditionalMenuPrioritiseItem
	{
		private readonly OrderType orderTypeToGive;

		public PrioritiseChopMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.PlantCutting)
		{
			if (!(base.Owner.GetAsTarget() is PlantMapResourceInstance plantMapResourceInstance))
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_chop_plant");
				base.IsEnabled = false;
				return;
			}
			OrderType possibleOrders = plantMapResourceInstance.GetPossibleOrders();
			if (possibleOrders.HasFlag(OrderType.Chopping))
			{
				orderTypeToGive = OrderType.Chopping;
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_chop_plant");
			}
			else
			{
				if (!possibleOrders.HasFlag(OrderType.CutAllVegetation))
				{
					return;
				}
				orderTypeToGive = OrderType.CutAllVegetation;
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_cut_all_vegetation_plant");
			}
			base.Text = base.Text + " " + MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(plantMapResourceInstance.GetBlueprint().LocKeys));
			EnableIfWorkerIsSelected();
			DisableIfUnreachableFromSelectedWorker(plantMapResourceInstance);
			DisableIfReserved(ignoreNonHumanReservations: true);
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed && base.Owner.GetAsTarget() is PlantMapResourceInstance plantMapResourceInstance && base.Owner is PlantMapResourceView plantMapResourceView)
			{
				if (MonoSingleton<ReservationManager>.Instance.GetSingleReserver(plantMapResourceInstance) is CreatureBase creatureBase && creatureBase != selectedWorker)
				{
					MonoSingleton<ReservationManager>.Instance.ReleaseObject(plantMapResourceInstance, creatureBase);
				}
				plantMapResourceView.GiveOrder(orderTypeToGive);
				ForceGoal("ChopTreeGoal", plantMapResourceInstance);
			}
		}
	}
}
