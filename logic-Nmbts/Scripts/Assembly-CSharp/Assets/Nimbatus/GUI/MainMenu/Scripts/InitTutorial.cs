using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Tutorial;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class InitTutorial : MonoBehaviour
	{
		public ETutorialType TutorialType;

		public UILabel Label;

		public GameObject Complete;

		public GameObject Incomplete;

		private Tutorial _tutorial;

		public void Start()
		{
			Init();
		}

		public void Init()
		{
			_tutorial = GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.GetTutorial(TutorialType);
			if (_tutorial != null)
			{
				Label.text = _tutorial.Name.GetTranslation();
				bool flag = GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.IsTutorialCompleted(TutorialType);
				Complete.gameObject.SetActive(flag);
				Incomplete.gameObject.SetActive(!flag);
			}
		}

		public void OnClick()
		{
			if (RuntimeGlobals.RunningMode == ERunningMode.Menu)
			{
				MainMenuNavigator mainMenuNavigator = Object.FindObjectOfType<MainMenuNavigator>();
				if (mainMenuNavigator != null)
				{
					mainMenuNavigator.NavigateTowards(EMainMenuPage.None);
					Invoke("OnTweenFinished", 0.5f);
				}
				else
				{
					OnTweenFinished();
				}
			}
			else
			{
				OnTweenFinished();
			}
		}

		public void OnTweenFinished()
		{
			GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.SetTutorial(TutorialType);
			SceneManager.LoadScene("DroneWorkshopScene");
		}
	}
}
