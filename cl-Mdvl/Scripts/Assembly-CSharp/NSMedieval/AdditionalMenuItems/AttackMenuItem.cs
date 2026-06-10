using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.AdditionalMenuItems
{
	public class AttackMenuItem : AdditionalMenuItemBase
	{
		public AttackMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.None, canDoWhileDrafted: true)
		{
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("general_attack");
			EnableIfWorkerIsSelected(canTargetOwner: false, draftedOnly: true);
			if (!base.IsEnabled)
			{
				base.Text = null;
				base.Tooltip = null;
			}
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			if (!(base.Owner.GetAsTarget() is IDamageTakingAgent target))
			{
				Log.Warning("Trying to attack target which is not IDamageTakingAgent", "C:\\GIT\\dev\\Assets\\Scripts\\Component\\AdditionalMenu\\Items\\AttackMenuItem.cs");
			}
			else
			{
				MonoSingleton<DraftManager>.Instance.HandleRightClickAttack(target, draftedOnly: true);
			}
		}
	}
}
