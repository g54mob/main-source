using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class ObjectChooserArrow : MonoBehaviour
	{
		public ObjectChooser Chooser;

		public bool Right;

		public void OnClick()
		{
			Chooser.ToggleNextOption(Right);
		}
	}
}
