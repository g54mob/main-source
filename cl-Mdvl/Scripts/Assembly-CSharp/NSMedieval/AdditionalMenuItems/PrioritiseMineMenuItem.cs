using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Types;
using NSMedieval.UI.Utils;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseMineMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseMineMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Mining)
		{
			if (!(base.Owner.GetAsTarget() is DigMarkerResourceInstance digMarkerResourceInstance))
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_mine_resource");
				base.IsEnabled = false;
				return;
			}
			OrderType possibleOrders = digMarkerResourceInstance.GetPossibleOrders();
			if (possibleOrders.HasFlag(OrderType.Digging))
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_mine_resource");
				base.Text = base.Text + " " + MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(digMarkerResourceInstance.GetBlueprint().LocKeys));
				EnableIfWorkerIsSelected();
				DisableIfUnreachableFromSelectedWorker(digMarkerResourceInstance);
			}
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			GetReserver()?.GetGoapAgent()?.Abort();
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed && base.Owner.GetAsTarget() is DigMarkerResourceInstance digMarkerResourceInstance && (digMarkerResourceInstance.CurrentOrder & OrderType.Digging) != OrderType.None)
			{
				ForceGoal("DigGoal", digMarkerResourceInstance);
			}
		}
	}
}
