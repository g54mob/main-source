using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class SkipTutorial : MonoBehaviour
	{
		public void OnClick()
		{
			RuntimeGlobals.Settings.SkipTutorial = true;
			MainMenuNavigator.Instance.NavigateTowards(EMainMenuPage.CreateGame);
		}
	}
}
