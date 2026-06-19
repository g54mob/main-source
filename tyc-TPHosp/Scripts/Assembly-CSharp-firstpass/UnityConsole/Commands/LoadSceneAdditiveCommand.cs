using UnityEngine.SceneManagement;

namespace UnityConsole.Commands
{
	public static class LoadSceneAdditiveCommand
	{
		public static readonly string Name = "LoadSceneAdditive";

		public static readonly string Description = "Load the specified scene by name. Before you can load a scene you have to add it to the list of levels used in the game. Use File->Build Settings... in Unity and add the levels you need to the level list there.";

		public static readonly string Usage = "LoadSceneAdditive sceneName";

		public static ConsoleCommandResult Execute(params string[] args)
		{
			if (args.Length == 0)
			{
				return HelpCommand.Execute(Name);
			}
			return LoadSceneAdditive(args[0]);
		}

		private static ConsoleCommandResult LoadSceneAdditive(string sceneName)
		{
			try
			{
				SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
			}
			catch
			{
				return ConsoleCommandResult.Failed($"Failed to load {sceneName}.");
			}
			Scene sceneByName = SceneManager.GetSceneByName(sceneName);
			if (sceneByName.IsValid() && sceneByName.isLoaded)
			{
				return ConsoleCommandResult.Succeeded($"Success loading {sceneName}.");
			}
			return ConsoleCommandResult.Failed($"Failed to load {sceneName}. Are you sure it's in the list of levels in Build Settings?");
		}
	}
}
