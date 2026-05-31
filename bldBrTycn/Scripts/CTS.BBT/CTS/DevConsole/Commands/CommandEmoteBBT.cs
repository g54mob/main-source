using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Emotes;
using UnityEngine;

namespace CTS.DevConsole.Commands
{
	public class CommandEmoteBBT : SelectionCommand<RoomObject>, ISubCommand<CommandEmote>, ISubCommand
	{
		public override string Command { get; } = "BBT";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.String };

		public override string GetCommandDescription()
		{
			return "Displays an emote on the selected object";
		}

		protected override void RunCommandOnSelection(RoomObject selection, List<object> args, string[] rawArgs)
		{
			E_EmoteIcons result;
			bool flag = Enum.TryParse<E_EmoteIcons>(rawArgs[0], ignoreCase: true, out result);
			if (selection.TryGetComponent<Agent>(out var component))
			{
				if (flag)
				{
					EmoteManagerBBT.Play(component, result);
				}
				else
				{
					EmoteManagerBBT.Play(component, rawArgs[0]);
				}
				return;
			}
			Collider component2 = selection.GetComponent<Collider>();
			if ((bool)component2)
			{
				if (flag)
				{
					EmoteManagerBBT.Play(selection, result).SetHeight(component2, 0.5f);
				}
				else
				{
					EmoteManagerBBT.Play(selection, rawArgs[0]).SetHeight(component2, 0.5f);
				}
			}
			else if (flag)
			{
				EmoteManagerBBT.Play(selection, result);
			}
			else
			{
				EmoteManagerBBT.Play(selection, rawArgs[0]);
			}
		}
	}
}
