using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts
{
	public class CustomChooserArrow : MonoBehaviour
	{
		public CustomChooser Chooser;

		public bool Right;

		public void OnClick()
		{
			Chooser.ToggleNextOption(Right);
		}
	}
}
