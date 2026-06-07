using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class EnumChooserArrow : MonoBehaviour
	{
		public EnumChooser Chooser;

		public bool Right;

		public void OnClick()
		{
			Chooser.ToggleNextOption(Right);
		}
	}
}
