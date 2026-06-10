using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.UI.Utils;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseRefuelingMenuItem : AdditionalMenuPrioritiseItem
	{
		private FuelConsumerComponentInstance fuelConsumerComponentInstance;

		public PrioritiseRefuelingMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Basic)
		{
			if (!(base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance))
			{
				base.IsEnabled = false;
				return;
			}
			FuelConsumerComponentInstance componentInstance = baseBuildingInstance.Map.FuelConsumerComponentManager.GetComponentInstance(baseBuildingInstance);
			if (componentInstance == null || componentInstance.HasDisposed)
			{
				base.IsEnabled = false;
				return;
			}
			if (componentInstance.GetMaxCaloriesToStore() == 0)
			{
				base.IsEnabled = false;
				return;
			}
			fuelConsumerComponentInstance = componentInstance;
			if (componentInstance.Underwater)
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_refuel");
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("structure_in_water");
				base.IsEnabled = false;
			}
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_refuel");
			base.Text = base.Text + " " + BuildingUtils.GetLocalizedName(componentInstance.BaseBuildingBlueprint.GetID());
			EnableIfWorkerIsSelected();
			DisableIfUnreachableFromSelectedWorker(baseBuildingInstance);
			DisableIfReserved();
		}

		public override void Dispose()
		{
			fuelConsumerComponentInstance = null;
			base.Dispose();
		}

		protected override void OnClickCallback()
		{
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed && fuelConsumerComponentInstance != null && (!MonoSingleton<ReservationManager>.Instance.IsReserved(fuelConsumerComponentInstance) || MonoSingleton<ReservationManager>.Instance.IsReservedBy(fuelConsumerComponentInstance, selectedWorker)))
			{
				if (fuelConsumerComponentInstance.Underwater)
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("building_error_no_resources"));
					return;
				}
				fuelConsumerComponentInstance.TurnOn();
				ForceGoal("DeliverFuelGoal", fuelConsumerComponentInstance);
				base.OnClickCallback();
			}
		}
	}
}
