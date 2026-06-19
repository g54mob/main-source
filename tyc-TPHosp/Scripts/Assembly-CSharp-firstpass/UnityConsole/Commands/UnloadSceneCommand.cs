using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityConsole.Commands
{
	public static class UnloadSceneCommand
	{
		public static readonly string Name = "UnloadScene";

		public static readonly string Description = "Unloads the named scene";

		public static readonly string Usage = "UnloadScene sceneName";

		public static ConsoleCommandResult Execute(params string[] args)
		{
			if (args.Length == 0)
			{
				return HelpCommand.Execute(LoadSceneAdditiveCommand.Name);
			}
			return UnloadScene(args[0]);
		}

		private static ConsoleCommandResult UnloadScene(string sceneName)
		{
			SceneManager.UnloadSceneAsync(sceneName);
			Resources.UnloadUnusedAssets();
			return ConsoleCommandResult.Succeeded("Scene may or may not have unloaded - a Unity API change makes this hard to tell!.");
		}
	}
}
