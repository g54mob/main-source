using System;
using System.Collections.Generic;
using CTS.Emotes;
using UnityEngine;

namespace CTS.DevConsole.Commands
{
	public class CommandEmote : SelectionCommand<Collider>
	{
		public override string Command { get; } = "Emote";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.String };

		public override string GetCommandDescription()
		{
			return "Displays an emote on the selected object";
		}

		protected override void RunCommandOnSelection(Collider selection, List<object> args, string[] rawArgs)
		{
			if (Enum.TryParse<E_EmoteIcons>(rawArgs[0], ignoreCase: true, out var result))
			{
				EmoteManager.Play<Emote>(selection, result).SetHeight(selection, 0.5f);
			}
			else
			{
				EmoteManager.Play<Emote>(selection, rawArgs[0]).SetHeight(selection, 0.5f);
			}
		}
	}
}
