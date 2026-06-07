using Sirenix.OdinInspector;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class HoverTooltip : SerializedMonoBehaviour
	{
		public TranslationTerm Tooltip;

		public void OnTooltip(bool show)
		{
			NimbatusToolTip.Show(show ? Tooltip.GetTranslation() : null);
		}
	}
}
