using UnityEngine;

namespace GameCreator.Runtime.Console
{
	public sealed class CommandApplication : Command
	{
		public override string Name => "app";

		public override string Description => "Interacts with the game application";

		public CommandApplication()
			: base(new ActionOutput[3]
			{
				new ActionOutput("quit", "Quits the game", delegate
				{
					Application.Quit();
					return Output.Success("Exiting application...");
				}),
				new ActionOutput("fps", "Displays the frames per second", delegate
				{
					float num = 1f / Time.unscaledDeltaTime;
					return Output.Success($"FPS: {num}");
				}),
				new ActionOutput("version", "Displays the game and Unity versions", delegate
				{
					string version = Application.version;
					string unityVersion = Application.unityVersion;
					return Output.Success("Version: " + version + " in Unity: " + unityVersion);
				})
			})
		{
		}
	}
}
