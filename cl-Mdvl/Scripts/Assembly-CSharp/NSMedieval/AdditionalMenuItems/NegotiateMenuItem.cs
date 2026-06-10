using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Roles;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;

namespace NSMedieval.AdditionalMenuItems
{
	public class NegotiateMenuItem : AdditionalMenuPrioritiseItem
	{
		private const string CannotNegotiateTextKey = "cannot_negotiate_with_leaving_npc";

		public NegotiateMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.None, canDoWhileDrafted: true)
		{
			if (!(base.Owner.GetAsTarget() is HumanoidInstance { ActiveBehaviour: INegotiator activeBehaviour }))
			{
				return;
			}
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker == null || selectedWorker.HasDisposed)
			{
				return;
			}
			base.IsEnabled = true;
			base.MenuTitle = string.Empty;
			if (!activeBehaviour.WantsToNegotiate)
			{
				base.IsEnabled = false;
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("cannot_negotiate_with_leaving_npc");
			}
			if (activeBehaviour is BeggarBehaviour { OnlyNegotiateWithRoleId: not null } beggarBehaviour)
			{
				RoleInstance roleInstance = selectedWorker.WorkerBehaviour.HumanoidRoleOwner.RoleInstance;
				if (roleInstance == null || roleInstance.Level < beggarBehaviour.OnlyNegotiateWithRoleLevel)
				{
					base.IsEnabled = false;
					string text = MonoSingleton<LocalizationController>.Instance.GetText(activeBehaviour.WontNegotiateWithWorkerBBTTextKey);
					base.Tooltip = text;
				}
			}
			if (activeBehaviour.WontNegotiateWithWorkerId.HasValue && activeBehaviour.WontNegotiateWithWorkerId == selectedWorker.UniqueId)
			{
				base.IsEnabled = false;
				string text2 = MonoSingleton<LocalizationController>.Instance.GetText(activeBehaviour.WontNegotiateWithWorkerBBTTextKey);
				text2 = TextFormatting.FormatText(text2, selectedWorker);
				base.Tooltip = text2;
			}
			base.Text = activeBehaviour.GetLocalizedMenuItemText();
			int skillLevel = selectedWorker.GetSkillLevel(SkillType.Speechcraft);
			base.MenuTitle = selectedWorker.Info.FirstName + " (" + AdditionalMenuItemUtil.GenerateSkillInfo(SkillType.Speechcraft.ToString().ToLower(), skillLevel) + ")";
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			if (!(base.Owner.GetAsTarget() is HumanoidInstance humanoidInstance))
			{
				Log.Warning("Negotiate target must be an NPC.", "C:\\GIT\\dev\\Assets\\Scripts\\Component\\AdditionalMenu\\Items\\NegotiateMenuItem.cs");
			}
			else
			{
				if (!(humanoidInstance.ActiveBehaviour is INegotiator negotiator))
				{
					return;
				}
				HumanoidInstance selectedWorker = GetSelectedWorker();
				if (selectedWorker != null && !selectedWorker.HasDisposed)
				{
					if (!negotiator.WantsToNegotiate)
					{
						MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("cannot_negotiate_with_leaving_npc"));
					}
					else if (negotiator.WontNegotiateWithWorkerId.HasValue && negotiator.WontNegotiateWithWorkerId == selectedWorker.UniqueId)
					{
						string text = MonoSingleton<LocalizationController>.Instance.GetText(negotiator.WontNegotiateWithWorkerBBTTextKey);
						text = TextFormatting.FormatText(text, selectedWorker);
						MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text);
					}
					else
					{
						selectedWorker.WorkerBehaviour.ShowPathDestinationLine(humanoidInstance.GetPosition());
						ForceGoal("NegotiateGoal", humanoidInstance);
					}
				}
			}
		}
	}
}
