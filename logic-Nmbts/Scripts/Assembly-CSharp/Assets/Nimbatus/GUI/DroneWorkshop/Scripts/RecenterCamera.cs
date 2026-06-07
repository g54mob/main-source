using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class RecenterCamera : MonoBehaviour
	{
		public void OnClick()
		{
			Vector3 position = RuntimeGlobals.MainCamera.transform.position;
			position.x = 0f;
			position.y = 0f;
			RuntimeGlobals.MainCamera.transform.position = position;
		}

		public void OnTooltip(bool show)
		{
			NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("DroneWorkshop/RecenterCamera"));
			if (!show)
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
