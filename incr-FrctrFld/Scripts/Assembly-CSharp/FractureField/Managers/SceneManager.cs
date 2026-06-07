using Reactivity;
using UnityEngine.SceneManagement;

namespace FractureField.Managers
{
	public class SceneManager : InitableMonoBehaviour
	{
		public static CBool IsSplashScreenScene;

		public static CBool IsMainMenuScene;

		public static CBool IsGameScene;

		public static bool IsRestartingGame;

		public bool IsSwapping { get; private set; }

		public static string PreviousScene { get; private set; }

		public static RString CurrentScene { get; }

		public static RTrigger SceneUnloaded { get; private set; }

		public static RTrigger SceneLoaded { get; private set; }

		protected override void InitHandler()
		{
		}

		private void OnDestroy()
		{
		}

		private void HandleSceneUnloaded(UnityEngine.SceneManagement.Scene scene)
		{
		}

		private void HandleSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
		{
		}

		public void GoToScene(Scene scene, bool force = false)
		{
		}

		public void GoToGame()
		{
		}

		public void GoToMainMenu()
		{
		}

		public void GoToSplashScreen()
		{
		}

		public void RestartGame()
		{
		}
	}
}
