using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

namespace IngameDebugConsole.Commands
{
	public class SceneCommands
	{
		[ConsoleMethod("scene.load", "Loads a scene", new string[] { })]
		[Preserve]
		public static void LoadScene(string sceneName)
		{
		}

		[Preserve]
		[ConsoleMethod("scene.load", "Loads a scene", new string[] { })]
		public static void LoadScene(string sceneName, LoadSceneMode mode)
		{
		}

		[ConsoleMethod("scene.loadasync", "Loads a scene asynchronously", new string[] { })]
		[Preserve]
		public static void LoadSceneAsync(string sceneName)
		{
		}

		[Preserve]
		[ConsoleMethod("scene.loadasync", "Loads a scene asynchronously", new string[] { })]
		public static void LoadSceneAsync(string sceneName, LoadSceneMode mode)
		{
		}

		private static void LoadSceneInternal(string sceneName, bool isAsync, LoadSceneMode mode)
		{
		}

		[ConsoleMethod("scene.unload", "Unloads a scene", new string[] { })]
		[Preserve]
		public static void UnloadScene(string sceneName)
		{
		}

		[ConsoleMethod("scene.restart", "Restarts the active scene", new string[] { })]
		[Preserve]
		public static void RestartScene()
		{
		}
	}
}
