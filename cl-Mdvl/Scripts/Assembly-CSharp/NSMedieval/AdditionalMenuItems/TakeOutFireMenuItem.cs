using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.Tools;

namespace NSMedieval.AdditionalMenuItems
{
	public class TakeOutFireMenuItem : AdditionalMenuItemBase
	{
		private Vec3Int targetPosition;

		public TakeOutFireMenuItem(IAdditionalMenuOwner owner)
			: base(owner)
		{
			targetPosition = GridUtils.GetGridPosition(owner.GetGuiOverlayHookTransform().position);
			HumanoidInstance selectedWorker = GetSelectedWorker();
			int num = GridDataIndexTools.FastTo1DIndex(targetPosition);
			base.IsEnabled = num != -1 && selectedWorker != null && !selectedWorker.IsOnFire && !Vec3Int.zero.Equals(targetPosition) && selectedWorker.Map.FireSimLogic.IsFireAt(num);
			if (base.IsEnabled)
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("put_out_fire");
				string key;
				if (selectedWorker.IsOnFire)
				{
					key = "worker_on_fire";
				}
				else if (selectedWorker.Map.FireSimLogic.GetFlameType(num) == 1)
				{
					key = "cannot_extingush_greek_fire";
					base.IsEnabled = false;
				}
				else
				{
					key = "put_out_fire_tooltip";
				}
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText(key);
			}
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed)
			{
				Agent goapAgent = selectedWorker.GetGoapAgent();
				if (goapAgent != null)
				{
					goapAgent.Abort();
					goapAgent.ForceNextGoal("TakeOutFireGoal")?.ForceTarget(TargetIndex.A, new TargetObject(targetPosition));
				}
			}
		}
	}
}
