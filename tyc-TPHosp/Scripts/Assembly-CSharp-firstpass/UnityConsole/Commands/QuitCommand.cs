using UnityEngine;

namespace UnityConsole.Commands
{
	public static class QuitCommand
	{
		public static readonly string Name = "QUIT";

		public static readonly string Description = "Quit the application.";

		public static readonly string Usage = "QUIT";

		public static ConsoleCommandResult Execute(params string[] args)
		{
			Debug.Log("Quitting from console command");
			Application.Quit();
			return ConsoleCommandResult.Succeeded();
		}
	}
}
