using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseSelfTendWoundsMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseSelfTendWoundsMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.TendWounds, canDoWhileDrafted: true)
		{
			if (base.Owner.GetAsTarget() is HumanoidInstance humanoidInstance && SelectedWorkerIsOwner() && humanoidInstance.IsWounded)
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_tending_wounds");
				if (!humanoidInstance.WorkerBehaviour.IsAllowedSelfTending)
				{
					base.IsEnabled = false;
					base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("self_tend_must_be_enabled");
				}
				else
				{
					EnableIfWorkerIsSelected(canTargetOwner: true);
				}
			}
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			if (GetSelectedWorker()?.GetGoapAgent() != null)
			{
				ForceGoal("SelfTendWoundsGoal", (HumanoidInstance)base.Owner.GetAsTarget());
			}
		}
	}
}
