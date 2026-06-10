using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseShackleMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseShackleMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.None, canDoWhileDrafted: true)
		{
			base.MenuTitle = string.Empty;
			base.Text = string.Empty;
			if (!EnableIfOwnerIsVillageCaptive())
			{
				return;
			}
			PrisonerBehaviour prisonerBehaviour = GetPrisonerBehaviour(owner);
			if (prisonerBehaviour == null)
			{
				base.IsEnabled = false;
				return;
			}
			if (prisonerBehaviour.Humanoid.IsAtEvent())
			{
				base.IsEnabled = false;
				return;
			}
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker == null)
			{
				base.IsEnabled = false;
				return;
			}
			base.MenuTitle = selectedWorker.Info.FirstName;
			base.IsEnabled = true;
			bool flag = prisonerBehaviour.MarkedForShackling || (!prisonerBehaviour.MarkedForUnShackling && !prisonerBehaviour.Shackled);
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText(flag ? "prioritise_shackle" : "hud_lb_order_off_shackless");
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			PrisonerBehaviour prisonerBehaviour = GetPrisonerBehaviour(base.Owner);
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (prisonerBehaviour != null && selectedWorker != null)
			{
				if (!prisonerBehaviour.Shackled && !MonoSingleton<ResourcePileManager>.Instance.ResourcePileWithProtoIdExists("shackles"))
				{
					string newValue = MonoSingleton<LocalizationController>.Instance.GetText("equipment_name_shackles");
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("no_item_available").Replace("<item_name>", newValue));
					return;
				}
				selectedWorker.WorkerBehaviour.ShowPathDestinationLine(prisonerBehaviour.Humanoid.GetPosition());
				prisonerBehaviour.MarkForUnShackling(prisonerBehaviour.Shackled);
				prisonerBehaviour.MarkForShackling(!prisonerBehaviour.Shackled);
				ForceGoal("ShacklePrisonerGoal", prisonerBehaviour.Humanoid);
			}
		}

		private PrisonerBehaviour GetPrisonerBehaviour(IAdditionalMenuOwner _)
		{
			if (base.Owner.GetAsTarget() is HumanoidInstance { ActiveBehaviour: PrisonerBehaviour activeBehaviour })
			{
				return activeBehaviour;
			}
			return null;
		}
	}
}
