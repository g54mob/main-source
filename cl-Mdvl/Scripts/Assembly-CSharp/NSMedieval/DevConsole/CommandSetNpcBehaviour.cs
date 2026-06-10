using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandSetNpcBehaviour : ConsoleCommand
	{
		private bool active;

		private Ray ray;

		private RaycastHit hit;

		private Type behaviourType;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetNpcBehaviour()
		{
			Command = "setNPCBehaviour";
			Description = "Sets behaviour for an Humanoid on click";
			Help = GetHelpString();
			behaviourType = null;
		}

		private string GetHelpString()
		{
			Type typeFromHandle = typeof(HumanoidBehaviour);
			Type[] types = Assembly.GetAssembly(typeFromHandle).GetTypes();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("setNPCBehaviour [behaviourClassName]\nPossible behaviours: ");
			Type[] array = types;
			foreach (Type type in array)
			{
				if (type.IsClass && !type.IsAbstract && typeFromHandle.IsAssignableFrom(type))
				{
					stringBuilder.AppendFormat("{0} ", type.Name);
				}
			}
			return stringBuilder.ToString();
		}

		private void CommandMethod(string behaviourClassName)
		{
			string text = "NSMedieval.State." + behaviourClassName;
			Type type = Type.GetType(text);
			if (type == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("S<color=red>Behaviour class '" + text + "' not found</color>", ConsoleMessageType.Error);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<GoapController>.Instance.AgentSelectedEvent += OnCreatureSelected;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
			}
			behaviourType = type;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command + " " + behaviourClassName });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SetNPCBehaviour Mode <color=lime>activated</color>! Right click to disable", ConsoleMessageType.Warning);
		}

		private void OnCreatureSelected(Agent agent)
		{
			if (agent.AgentOwner is HumanoidInstance obj)
			{
				typeof(HumanoidInstance).GetMethod("SetActiveBehaviour").MakeGenericMethod(behaviourType).Invoke(obj, new object[1] { true });
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
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SetNPCBehaviour Mode <color=red>disabled!</color>", ConsoleMessageType.Warning);
		}
	}
}
