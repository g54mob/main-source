using UnityEngine;

namespace VampireSurvivors
{
	public class AutomationButtonsGameplay : MonoBehaviour
	{
		public enum GameplayButtons
		{
			Options = 0,
			Quit = 1,
			Resume = 2,
			RecapDone = 3
		}

		[SerializeField]
		private GameplayButtonsDictionary _buttons;

		private static AutomationButtonsGameplay _instance;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public static GameObject GetButtonGameObject(GameplayButtons button)
		{
			return null;
		}
	}
}
