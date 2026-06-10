using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandAddExperience : ConsoleCommand
	{
		private bool active;

		private string selectedSkill;

		private int valueToAdd;

		private Ray ray;

		private RaycastHit hit;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandAddExperience()
		{
			Command = "addExperience";
			Description = "Increases / decreases the experience of the given skill to the humanoid you click on.";
			Help = "Usage: addExperience <skillName:string> <valueToAdd:int>";
		}

		private void CommandMethod(string skillName, int xpToAdd)
		{
			if (active && valueToAdd == xpToAdd && selectedSkill.Equals(skillName))
			{
				active = false;
				MonoSingleton<GoapController>.Instance.AgentSelectedEvent -= OnWorkerSelected;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("AddSkill Mode <color=red>disabled!</color>", ConsoleMessageType.Warning);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<GoapController>.Instance.AgentSelectedEvent += OnWorkerSelected;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {skillName} {xpToAdd}" });
			selectedSkill = skillName;
			valueToAdd = xpToAdd;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("AddSkill Mode <color=lime>activated</color>! Use same command call to disable it", ConsoleMessageType.Warning);
		}

		private void OnWorkerSelected(Agent agent)
		{
			if (!MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked && agent.AgentOwner is HumanoidInstance humanoidInstance && Enum.TryParse<SkillType>(selectedSkill, ignoreCase: true, out var result))
			{
				humanoidInstance.AddExperience(result, valueToAdd);
				DamagePopup.Create(humanoidInstance.GetPosition(), $"DEBUG: Adding {valueToAdd} XP to {result}", Color.green);
			}
		}

		private void OnRightMouseClick()
		{
			active = false;
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent -= OnWorkerSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
