using I2.Loc;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.UI;

namespace NSMedieval.DevConsole
{
	public class DeveloperActionButton : SoundButton
	{
		public void SetupButton(string name, string tooltip = "")
		{
			GetComponentInChildren<Localize>().SetTerm(name);
			GetComponent<TooltipViewNew>().SetSingleLineTooltip(MonoSingleton<LocalizationController>.Instance.GetText(tooltip));
		}

		public void SetActive(bool active)
		{
			base.gameObject.SetActive(active);
		}

		public void ResetButton()
		{
			SetActive(active: false);
			base.interactable = true;
			base.onClick.RemoveAllListeners();
			GetComponentInChildren<Localize>().SetTerm(string.Empty);
			GetComponent<TooltipViewNew>().ClearLines();
		}
	}
}
