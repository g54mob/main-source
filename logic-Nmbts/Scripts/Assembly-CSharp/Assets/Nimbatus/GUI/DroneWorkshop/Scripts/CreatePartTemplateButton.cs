using Assets.Nimbatus.GUI.Common.Scripts;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class CreatePartTemplateButton : MonoBehaviour
	{
		public CreateDronePartTemplateWindow Window;

		public void OnClick()
		{
			Window.Init();
		}

		public void OnTooltip(bool show)
		{
			NimbatusToolTip.Show(show ? LocalizationManager.GetTermTranslation("DroneWorkshop/CreateTemplate") : null);
		}
	}
}
