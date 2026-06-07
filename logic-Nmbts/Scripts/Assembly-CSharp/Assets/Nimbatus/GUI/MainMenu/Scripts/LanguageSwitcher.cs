using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class LanguageSwitcher : MonoBehaviour
	{
		public LanguageChooser Languages;

		public bool Right;

		public void OnClick()
		{
			Languages.ToggleNextOption(Right);
		}
	}
}
