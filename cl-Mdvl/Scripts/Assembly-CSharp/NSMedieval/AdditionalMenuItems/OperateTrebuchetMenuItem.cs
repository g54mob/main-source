using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Draft;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.AdditionalMenuItems
{
	public class OperateTrebuchetMenuItem : AdditionalMenuItemBase
	{
		private SiegeWeaponComponentInstance componentInstance;

		public OperateTrebuchetMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.None, canDoWhileDrafted: true)
		{
			if (!(base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance))
			{
				base.IsEnabled = false;
				return;
			}
			if (!baseBuildingInstance.OwnedByPlayer())
			{
				base.IsEnabled = false;
				return;
			}
			if (baseBuildingInstance.HasDisposed)
			{
				base.IsEnabled = false;
				return;
			}
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("general_operate");
			componentInstance = baseBuildingInstance.GetComponentInstance<SiegeWeaponComponentInstance>();
			if (componentInstance == null || componentInstance.HasDisposed)
			{
				base.IsEnabled = false;
			}
			else if (!componentInstance.HasAmmunition() && !componentInstance.HasAmmoAvailableOnMap())
			{
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("no_piles_allowed");
				base.IsEnabled = false;
			}
			else if (componentInstance.IsOperatorReady)
			{
				base.IsEnabled = false;
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("already_has_operator");
			}
			else
			{
				EnableIfWorkerIsSelected();
			}
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker != null)
			{
				MonoSingleton<DraftController>.Instance.ExecuteDraftOrder(selectedWorker, new DraftOrderOperateTrebuchet(componentInstance));
			}
		}
	}
}
