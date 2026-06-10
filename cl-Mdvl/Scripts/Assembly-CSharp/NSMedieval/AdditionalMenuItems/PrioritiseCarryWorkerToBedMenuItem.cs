using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Types;
using NSMedieval.Village;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseCarryWorkerToBedMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseCarryWorkerToBedMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.None, canDoWhileDrafted: true)
		{
			PrioritiseCarryWorkerToBedMenuItem prioritiseCarryWorkerToBedMenuItem = this;
			HumanoidInstance humanoid = base.Owner.GetAsTarget() as HumanoidInstance;
			if (humanoid == null || !humanoid.HasFainted || humanoid.IsBeingCarried || humanoid.IsReceivingWoundTreatman)
			{
				return;
			}
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (MonoSingleton<ReservationManager>.Instance.GetReservedBed(humanoid) != null || selectedWorker == humanoid)
			{
				return;
			}
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_carry_to_bed");
			base.IsEnabled = true;
			DisableIfReserved();
			if (base.IsEnabled)
			{
				if (!VillageManager.ActiveVillage.Map.BedComponentManager.GetBeds(BedType.Basic).Any((BedComponentInstance item) => MonoSingleton<ReservationManager>.Instance.CanReserve(item, humanoid) && prioritiseCarryWorkerToBedMenuItem.IsReachableFromSelectedWorker(item)))
				{
					base.IsEnabled = false;
					base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("not_enough_free_beds");
				}
				else
				{
					EnableIfWorkerIsSelected();
				}
			}
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			if (GetSelectedWorker()?.GetGoapAgent() != null)
			{
				ForceGoal("CarryToBedGoal", (HumanoidInstance)base.Owner.GetAsTarget());
			}
		}
	}
}
