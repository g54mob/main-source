using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Village;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseEscortPrisonerMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseEscortPrisonerMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Gaoler)
		{
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_escort");
			EnableIfWorkerIsSelected();
			if (!base.IsEnabled || !EnableIfOwnerIsVillageCaptive())
			{
				return;
			}
			PrisonerBehaviour prisonerBehaviour = ((HumanoidInstance)base.Owner.GetAsTarget()).PrisonerBehaviour;
			if (prisonerBehaviour == null)
			{
				Log.Error("Owner of menu item is not a prisoner!", "C:\\GIT\\dev\\Assets\\Scripts\\Component\\AdditionalMenu\\Items\\Prisoners\\PrioritiseEscortPrisonerMenuItem.cs");
				base.IsEnabled = false;
				return;
			}
			if (prisonerBehaviour.IsInPrisonCell)
			{
				base.IsEnabled = false;
				return;
			}
			DisableIfUnreachableFromSelectedWorker(base.Owner.GetAsTarget());
			if (base.IsEnabled)
			{
				Vec3Int position;
				if (!VillageManager.ActiveVillage.Map.RoomDetection.IterateRoomsSafe().Any((Room room) => room.RoomType.Prison))
				{
					base.IsEnabled = false;
					base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_escort_error_no_jail_cell");
				}
				else if (!PrisonerUtil.FindJailCellPositionForEscort(GetSelectedWorker(), out position))
				{
					base.IsEnabled = false;
					base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_escort_error_no_reachable_jail_cell");
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
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed)
			{
				HumanoidInstance setPreferredReservable = base.Owner.GetAsTarget() as HumanoidInstance;
				ForceGoal("RopeEnemyGoal", setPreferredReservable);
			}
		}
	}
}
