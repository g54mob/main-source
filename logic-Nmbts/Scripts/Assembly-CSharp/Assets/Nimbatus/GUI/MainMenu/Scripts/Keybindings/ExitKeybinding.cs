using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts.Keybindings
{
	public class ExitKeybinding : MonoBehaviour
	{
		public KeybindList List;

		public void OnClick()
		{
			MainMenuNavigator.Instance.NavigateTowards(EMainMenuPage.Main);
		}

		public void Update()
		{
			if (MainMenuNavigator.CurrentPage == EMainMenuPage.KeyBinding && !List.IsPopupShown() && Input.GetKeyDown(KeyCode.Escape))
			{
				OnClick();
			}
		}
	}
}
