using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class ApplySettings : MonoBehaviour
	{
		public ResolutionChooser Chooser;

		public void OnClick()
		{
			RuntimeGlobals.Settings.ScreenWidth = Chooser.SelectedOption.width;
			RuntimeGlobals.Settings.ScreenHeight = Chooser.SelectedOption.height;
			RuntimeGlobals.Settings.Apply();
			RuntimeGlobals.Settings.ApplyResolution();
		}
	}
}
