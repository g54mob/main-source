using UnityEngine.SceneManagement;

namespace UnityConsole.Commands
{
	public static class SetActiveSceneCommand
	{
		public static readonly string Name = "SetActiveScene";

		public static readonly string Description = "Sets the named scene as the active scene";

		public static readonly string Usage = "SetActiveScene sceneName";

		public static ConsoleCommandResult Execute(params string[] args)
		{
			if (args.Length == 0)
			{
				return HelpCommand.Execute(Name);
			}
			return SetActiveScene(args[0]);
		}

		private static ConsoleCommandResult SetActiveScene(string sceneName)
		{
			Scene sceneByName = SceneManager.GetSceneByName(sceneName);
			try
			{
				SceneManager.SetActiveScene(sceneByName);
			}
			catch
			{
				return ConsoleCommandResult.Failed($"Failed to set {sceneName} as active.");
			}
			if (sceneByName.IsValid() && SceneManager.GetActiveScene() == sceneByName)
			{
				return ConsoleCommandResult.Succeeded($"Success setting {sceneName} as active.");
			}
			return ConsoleCommandResult.Failed($"Failed to set {sceneName} as active. Are you sure it's in the list of levels in Build Settings?");
		}
	}
}
