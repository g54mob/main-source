using UnityEngine.SceneManagement;

namespace GameCreator.Runtime.Console
{
	public sealed class CommandScene : Command
	{
		public override string Name => "scene";

		public override string Description => "Loads or Unloads game scenes";

		public CommandScene()
			: base(new ActionOutput[2]
			{
				new ActionOutput("load", "Loads a scene by its name", delegate(string value)
				{
					SceneManager.LoadScene(value);
					return Output.Success("Loaded scene " + value);
				}),
				new ActionOutput("unload", "Unloads a scene by its name", delegate(string value)
				{
					SceneManager.UnloadSceneAsync(value);
					return Output.Success("Unloaded scene '" + value + "'");
				})
			})
		{
		}
	}
}
