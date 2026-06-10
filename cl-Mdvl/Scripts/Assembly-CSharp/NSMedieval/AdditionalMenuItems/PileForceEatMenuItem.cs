using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Draft;
using NSMedieval.Enums;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;

namespace NSMedieval.AdditionalMenuItems
{
	public class PileForceEatMenuItem : AdditionalMenuItemBase
	{
		public PileForceEatMenuItem(IAdditionalMenuOwner owner)
			: base(owner)
		{
			if (!(base.Owner.GetAsTarget() is ResourcePileInstance resourcePileInstance))
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("general_consume");
				base.IsEnabled = false;
				return;
			}
			string text = MonoSingleton<LocalizationController>.Instance.GetText("general_consume");
			string localizedResourceName = ResourceUtils.GetLocalizedResourceName(resourcePileInstance.Blueprint);
			if (MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageEnum() == Language.Japanese || MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageEnum() == Language.Korean)
			{
				base.Text = localizedResourceName + text;
			}
			else if (MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageEnum() == Language.Chinese)
			{
				base.Text = text + localizedResourceName;
			}
			else
			{
				base.Text = text + " " + localizedResourceName;
			}
			EnableIfWorkerIsSelected();
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			ResourcePileInstance resourcePileInstance = (ResourcePileInstance)base.Owner.GetAsTarget();
			if (!resourcePileInstance.HasDisposed && resourcePileInstance.Blueprint.Category.HasFlag(ResourceCategory.CtgEdible))
			{
				HumanoidInstance selectedWorker = GetSelectedWorker();
				if (selectedWorker != null)
				{
					MonoSingleton<DraftController>.Instance.ExecuteDraftOrder(selectedWorker, new DraftOrderConsume(resourcePileInstance));
				}
			}
		}
	}
}
