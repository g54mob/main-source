using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseBuryMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseBuryMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Hauling)
		{
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_bury");
			if (!(base.Owner.GetAsTarget() is HumanCarcassPileInstance humanCarcassPileInstance))
			{
				base.IsEnabled = false;
				return;
			}
			EnableIfWorkerIsSelected();
			DisableIfUnreachableFromSelectedWorker(humanCarcassPileInstance);
			if (!base.IsEnabled)
			{
				return;
			}
			foreach (GraveComponentInstance componentInstance in humanCarcassPileInstance.Map.GraveComponentManager.ComponentInstances)
			{
				if (!MonoSingleton<ReservationManager>.Instance.IsReserved(componentInstance) && componentInstance.CanStore((CarcassResourceInstance)humanCarcassPileInstance.GetStoredResource()) && IsReachableFromSelectedWorker(componentInstance))
				{
					base.IsEnabled = true;
					return;
				}
			}
			base.IsEnabled = false;
			base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("nowhere_to_bury");
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed)
			{
				HumanCarcassPileInstance humanCarcassPileInstance = (HumanCarcassPileInstance)base.Owner.GetAsTarget();
				if (humanCarcassPileInstance.IsForbidden)
				{
					humanCarcassPileInstance.IsForbidden = false;
				}
				ForceGoal("BuryBodyGoal", humanCarcassPileInstance);
			}
		}
	}
}
