using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseTendWoundsMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseTendWoundsMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.TendWounds, canDoWhileDrafted: true)
		{
			if (base.Owner.GetAsTarget() is HumanoidInstance humanoidInstance && !SelectedWorkerIsOwner() && humanoidInstance.HasUntendendWounds())
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_tending_wounds");
				EnableIfWorkerIsSelected();
				DisableIfUnreachableFromSelectedWorker(humanoidInstance);
			}
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			HumanoidInstance selectedWorker = GetSelectedWorker();
			HumanoidInstance humanoidInstance = base.Owner.GetAsTarget() as HumanoidInstance;
			if (selectedWorker?.GetGoapAgent() != null && humanoidInstance != null)
			{
				if (humanoidInstance.GoapAgent.CurrentGoalName != "FaintGoal")
				{
					humanoidInstance.CanReceiveWoundTreatment = true;
					ForceGoal("PatientGoal", selectedWorker, humanoidInstance);
				}
				ForceGoal("TendWoundsGoal", humanoidInstance);
			}
		}
	}
}
