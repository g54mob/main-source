using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandMakeNPCLeave : ConsoleCommand
	{
		private bool active;

		private Ray ray;

		private RaycastHit hit;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandMakeNPCLeave()
		{
			Command = "makeNPCLeave";
			Description = "Makes NPC retreat from map";
			Help = "makeNPCLeave";
		}

		private void CommandMethod()
		{
			if (!active)
			{
				active = true;
				MonoSingleton<GoapController>.Instance.AgentSelectedEvent += OnCreatureSelected;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("MakeNPCLeave Mode <color=lime>activated</color>! Right click to disable", ConsoleMessageType.Warning);
		}

		private void OnCreatureSelected(Agent agent)
		{
			if (agent.AgentOwner is HumanoidInstance humanoidInstance)
			{
				humanoidInstance.RetreatFromMap();
			}
		}

		private void OnRightMouseDown()
		{
			Disable();
		}

		private void Disable()
		{
			active = false;
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent -= OnCreatureSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("MakeNPCLeave Mode <color=red>disabled!</color>", ConsoleMessageType.Warning);
		}
	}
}
