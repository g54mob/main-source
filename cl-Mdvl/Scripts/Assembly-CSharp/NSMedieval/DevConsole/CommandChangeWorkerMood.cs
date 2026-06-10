using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.StatsSystem;

namespace NSMedieval.DevConsole
{
	public class CommandChangeWorkerMood : ConsoleCommand
	{
		private int amount;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandChangeWorkerMood()
		{
			Command = "changeWorkerMood";
			Description = "Click on humanoid to change mood";
			Help = "Use this command to change humanoid mood.";
		}

		private void CommandMethod(int amount)
		{
			this.amount = amount;
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent += OnWorkerSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			string result = "Click on humanoid to change mood " + amount;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#FF263C><i>{Command}" });
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private void OnWorkerSelected(Agent agent)
		{
			if (!MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked && agent.AgentOwner is HumanoidInstance humanoidInstance)
			{
				string empty = string.Empty;
				if (amount > 0)
				{
					humanoidInstance.Stats.RemoveAttributeModifier(ModifierType.MoodBasic, "debug_mood_minus");
					empty = "debug_mood_plus";
				}
				else
				{
					humanoidInstance.Stats.RemoveAttributeModifier(ModifierType.MoodBasic, "debug_mood_plus");
					empty = "debug_mood_minus";
				}
				humanoidInstance.Stats.AddAttributeModifier(new MoodBasicModifierInstance(amount, empty));
				StatInstance stat = humanoidInstance.Stats.GetStat(StatType.Mood);
				humanoidInstance.Stats.Update();
				stat.SetCurrent(stat.Target);
			}
		}

		private void OnRightMouseClick()
		{
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent -= OnWorkerSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
