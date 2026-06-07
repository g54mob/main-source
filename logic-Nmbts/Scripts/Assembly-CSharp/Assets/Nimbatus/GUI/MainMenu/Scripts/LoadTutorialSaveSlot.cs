using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class LoadTutorialSaveSlot : SerializedMonoBehaviour
	{
		public FillupTutorial TutorialPanel;

		public void OnClick()
		{
			MainMenuNavigator.Instance.NavigateTowards(EMainMenuPage.LoadTutorial);
			Invoke("LoadTutorial", 0.5f);
		}

		public void LoadTutorial()
		{
			SaveManager.StartEmptyGame(EGameMode.Tutorial);
			TutorialPanel.Fill();
			MainMenuNavigator.Instance.NavigateTowards(EMainMenuPage.TutorialSelection);
		}
	}
}
