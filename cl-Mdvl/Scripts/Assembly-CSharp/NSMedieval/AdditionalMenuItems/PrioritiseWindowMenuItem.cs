using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseWindowMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseWindowMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Basic)
		{
			if (!(base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance))
			{
				base.IsEnabled = false;
				return;
			}
			WindowComponentInstance componentInstance = baseBuildingInstance.Map.WindowComponentManager.GetComponentInstance(baseBuildingInstance);
			if (componentInstance == null)
			{
				base.IsEnabled = false;
				return;
			}
			switch (componentInstance.WindowOrder)
			{
			case WindowOrder.None:
				base.IsEnabled = false;
				return;
			case WindowOrder.Close:
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_close_window");
				break;
			case WindowOrder.Open:
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_open_window");
				break;
			}
			EnableIfWorkerIsSelected();
			DisableIfUnreachableFromSelectedWorker(baseBuildingInstance);
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed)
			{
				WindowComponentInstance windowComponentInstance = ((base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance) ? baseBuildingInstance.Map.WindowComponentManager.GetComponentInstance(baseBuildingInstance) : null);
				if (windowComponentInstance != null)
				{
					ForceGoal("ChangeLockStateGoal", windowComponentInstance);
				}
			}
		}
	}
}
