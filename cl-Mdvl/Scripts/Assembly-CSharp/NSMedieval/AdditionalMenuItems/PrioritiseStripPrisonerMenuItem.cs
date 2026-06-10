using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Types;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseStripPrisonerMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseStripPrisonerMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Gaoler)
		{
			EnableIfWorkerIsSelected();
			if (!base.IsEnabled || !EnableIfOwnerIsVillageCaptive())
			{
				return;
			}
			CaptiveNpcBehaviour captiveNpcBehaviour = ((HumanoidInstance)base.Owner.GetAsTarget()).CaptiveNpcBehaviour;
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("action_StripPrisoner");
			DisableIfUnreachableFromSelectedWorker(base.Owner.GetAsTarget());
			if (base.IsEnabled)
			{
				if (captiveNpcBehaviour.Humanoid.Inventory.OccupiedSlots == EquipmentSlotType.None)
				{
					base.IsEnabled = false;
				}
				else
				{
					base.IsEnabled = true;
				}
			}
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed && base.Owner.GetAsTarget() is HumanoidInstance humanoidInstance)
			{
				humanoidInstance.CaptiveNpcBehaviour.MarkForStripping(mark: true);
				ForceGoal("StripCaptiveGoal", humanoidInstance);
			}
		}
	}
}
