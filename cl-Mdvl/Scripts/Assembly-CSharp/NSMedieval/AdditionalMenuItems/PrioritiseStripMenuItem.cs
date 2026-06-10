using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseStripMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseStripMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Hauling)
		{
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_stripping");
			if (!(base.Owner.GetAsTarget() is HumanCarcassPileInstance humanCarcassPileInstance))
			{
				base.IsEnabled = false;
				return;
			}
			EnableIfWorkerIsSelected();
			DisableIfUnreachableFromSelectedWorker(humanCarcassPileInstance);
			if (!base.IsEnabled || !MonoSingleton<ReservationManager>.Instance.IsReserved(humanCarcassPileInstance))
			{
				return;
			}
			bool isOnlyReserved = true;
			HumanoidInstance goapAgentOwner = GetSelectedWorker();
			MonoSingleton<ReservationManager>.Instance.ForEachReserver(humanCarcassPileInstance, delegate(IGoapAgentOwner agent)
			{
				if (agent != goapAgentOwner)
				{
					isOnlyReserved = false;
				}
			});
			if (isOnlyReserved && humanCarcassPileInstance.IsReserveAll)
			{
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("already_working_on_target");
			}
			else
			{
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("already_reserved_by_other_worker_will_cancel");
			}
		}

		public override bool Setup(AdditionalMenuFloatingElement overlayElement, AdditionalMenuItemData data)
		{
			if (!(base.Owner.GetAsTarget() is HumanCarcassPileInstance { Stripped: false }))
			{
				return false;
			}
			return base.Setup(overlayElement, data);
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
				humanCarcassPileInstance.MarkForStripping(markedForStripping: true);
				ForceGoal("StripCarcassGoal", humanCarcassPileInstance);
			}
		}
	}
}
