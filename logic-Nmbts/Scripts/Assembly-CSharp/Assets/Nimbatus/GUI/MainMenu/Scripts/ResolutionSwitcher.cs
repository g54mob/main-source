using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class ResolutionSwitcher : MonoBehaviour
	{
		public ResolutionChooser Resolutions;

		public bool Right;

		public void OnClick()
		{
			Resolutions.ToggleNextOption(Right);
		}
	}
}
