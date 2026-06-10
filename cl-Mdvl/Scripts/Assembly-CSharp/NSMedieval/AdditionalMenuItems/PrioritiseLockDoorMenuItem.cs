using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseLockDoorMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseLockDoorMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Basic)
		{
			if (!(base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance))
			{
				base.IsEnabled = false;
				return;
			}
			DoorComponentInstance componentInstance = baseBuildingInstance.Map.DoorComponentManager.GetComponentInstance(baseBuildingInstance);
			if (componentInstance == null || componentInstance.LockState == LockState.ForcedOpen)
			{
				base.IsEnabled = false;
				return;
			}
			switch (componentInstance.DoorOrder)
			{
			case DoorOrder.Unlock:
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_unlocking_door");
				break;
			case DoorOrder.Open:
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_always_open_door");
				break;
			case DoorOrder.Lock:
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_locking_door");
				break;
			default:
				base.Text = "";
				return;
			}
			EnableIfWorkerIsSelected();
			DisableIfUnreachableFromSelectedWorker(baseBuildingInstance);
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed)
			{
				DoorComponentInstance doorComponentInstance = ((base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance) ? baseBuildingInstance.Map.DoorComponentManager.GetComponentInstance(baseBuildingInstance) : null);
				if (doorComponentInstance != null)
				{
					ForceGoal("ChangeDoorLockStateGoal", doorComponentInstance);
				}
			}
		}

		protected override void DisableIfUnreachableFromSelectedWorker(params IGoapTargetable[] targets)
		{
			foreach (IGoapTargetable goapTargetable in targets)
			{
				if (!(goapTargetable is BaseBuildingInstance { ConstructionPhase: ConstructionPhase.Finished, BuildingType: BuildingType.FenceGate } baseBuildingInstance))
				{
					continue;
				}
				DoorComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<DoorComponentInstance>();
				if (componentInstance != null && componentInstance.Blueprint.DoorType == DoorType.Drawbridge)
				{
					HumanoidInstance selectedWorker = GetSelectedWorker();
					if (selectedWorker == null)
					{
						base.IsEnabled = false;
						return;
					}
					if (!PathfinderUtil.IsPathPossible(selectedWorker, componentInstance.UsePosition))
					{
						base.IsEnabled = false;
						base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("error_no_possible_path").Replace("<object>", goapTargetable.GetLocalizedName());
						return;
					}
				}
			}
			base.DisableIfUnreachableFromSelectedWorker(targets);
		}
	}
}
