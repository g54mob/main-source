using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class OpenColorChooser : MonoBehaviour
	{
		public bool Grid;

		public WorkshopColorManager Manager;

		public void OnClick()
		{
			if (Grid)
			{
				Manager.OpenGridColorChooser();
			}
			else
			{
				Manager.OpenBackgroundColorChooser();
			}
		}
	}
}
