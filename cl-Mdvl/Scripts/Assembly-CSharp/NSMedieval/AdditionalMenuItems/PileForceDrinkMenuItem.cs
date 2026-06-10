using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Draft;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;

namespace NSMedieval.AdditionalMenuItems
{
	public class PileForceDrinkMenuItem : AdditionalMenuItemBase
	{
		public PileForceDrinkMenuItem(IAdditionalMenuOwner owner)
			: base(owner)
		{
			if (!(base.Owner.GetAsTarget() is ResourcePileInstance resourcePileInstance))
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("general_drink");
				base.IsEnabled = false;
			}
			else
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("general_drink") + " " + ResourceUtils.GetLocalizedResourceName(resourcePileInstance.Blueprint);
				EnableIfWorkerIsSelected();
			}
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			ResourcePileInstance resourcePileInstance = (ResourcePileInstance)base.Owner.GetAsTarget();
			if (!resourcePileInstance.HasDisposed && resourcePileInstance.Blueprint.Category.HasFlag(ResourceCategory.CtgAlcohol))
			{
				HumanoidInstance selectedWorker = GetSelectedWorker();
				if (selectedWorker != null)
				{
					MonoSingleton<DraftController>.Instance.ExecuteDraftOrder(selectedWorker, new DraftOrderConsume(resourcePileInstance, isDrink: true));
				}
			}
		}
	}
}
