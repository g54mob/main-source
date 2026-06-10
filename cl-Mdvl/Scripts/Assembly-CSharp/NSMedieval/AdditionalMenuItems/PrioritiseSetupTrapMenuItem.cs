using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseSetupTrapMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseSetupTrapMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Basic)
		{
			if (!(base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance))
			{
				base.IsEnabled = false;
				return;
			}
			if (baseBuildingInstance.Map.TrapComponentsManager.GetComponentInstance(baseBuildingInstance).Operational)
			{
				base.IsEnabled = false;
				return;
			}
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_reset_trap");
			EnableIfWorkerIsSelected();
			DisableIfUnreachableFromSelectedWorker(baseBuildingInstance);
			DisableIfReserved();
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			TrapComponentInstance trapComponentInstance = ((base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance) ? baseBuildingInstance.Map.TrapComponentsManager.GetComponentInstance(baseBuildingInstance) : null);
			if (trapComponentInstance != null && !trapComponentInstance.HasDisposed)
			{
				HumanoidInstance selectedWorker = GetSelectedWorker();
				if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed)
				{
					ForceGoal("SetupTrapGoal", trapComponentInstance);
				}
			}
		}
	}
}
