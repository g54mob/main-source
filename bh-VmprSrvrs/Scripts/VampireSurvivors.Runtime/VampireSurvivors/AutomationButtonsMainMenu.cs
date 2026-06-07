using UnityEngine;

namespace VampireSurvivors
{
	public class AutomationButtonsMainMenu : MonoBehaviour
	{
		public enum MainMenuButtons
		{
			Start = 0,
			Bestiary = 1,
			CharacterConfirm = 2,
			CharacterStart = 3,
			StageConfirm = 4,
			StageStart = 5
		}

		[SerializeField]
		private MainMenuButtonsDictionary _buttons;

		private static AutomationButtonsMainMenu _instance;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public static GameObject GetButtonGameObject(MainMenuButtons button)
		{
			return null;
		}
	}
}
