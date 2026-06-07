using Assets.Nimbatus.GUI.Common.Scripts;
using I2.Loc;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class WarningDisplay : SerializedMonoBehaviour
	{
		public TranslationTerm Tooltip;

		public void OnTooltip(bool show)
		{
			NimbatusToolTip.Show(string.Concat(LabelHelper.Red + LocalizationManager.GetTermTranslation("DroneWorkshop/Warning") + LabelHelper.White + LabelHelper.NewLine, LabelHelper.White, Tooltip.GetTranslation()));
			if (!show)
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
