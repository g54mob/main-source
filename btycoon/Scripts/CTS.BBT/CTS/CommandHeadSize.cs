using System.Collections.Generic;
using CTS.DevConsole;
using UnityEngine;

namespace CTS
{
	public class CommandHeadSize : ConsoleCommand
	{
		public override string Command { get; } = "HeadSize";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Float };

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (args.Count == 0)
			{
				DeveloperConsole.Log($"Head size: {AgentHeadSize.Size}");
			}
			else if (args[0] is float size)
			{
				AgentHeadSize.Size = size;
				AgentHeadSize[] array = Object.FindObjectsByType<AgentHeadSize>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
				for (int i = 0; i < array.Length; i++)
				{
					array[i].UpdateSize();
				}
			}
		}

		public override string GetCommandDescription()
		{
			return "Changes the head size of agents.";
		}
	}
}
