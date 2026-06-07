using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class NavigateToPage : MonoBehaviour
	{
		public EMainMenuPage Page;

		public void OnClick()
		{
			MainMenuNavigator.Instance.NavigateTowards(Page);
		}
	}
}
