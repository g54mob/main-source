using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.View;
using NSMedieval.Village;

namespace NSMedieval.DevConsole
{
	public class CommandSetAgentStat : ConsoleCommand
	{
		private float value;

		private string name;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetAgentStat()
		{
			Command = "setStat";
			Description = "Set current level of the stat.";
			Help = "Usage: setStat <stat_name> <value>";
		}

		private void CommandMethod(string name, float value)
		{
			this.value = value;
			this.name = name;
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent += OnCreatureSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelected;
			string result = "Changing stat '" + this.name + "' value";
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {value}" });
		}

		private void OnSelected(SelectableObject obj)
		{
			if (!(obj == null))
			{
				WorldObject asWorldObject = obj.GetAsWorldObject();
				if (asWorldObject != null && asWorldObject is IStatsOwner statsOwner)
				{
					UpdateStat(statsOwner.Stats);
				}
			}
		}

		private void OnCreatureSelected(Agent agent)
		{
			if (!MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked && agent != null && agent.AgentOwner is CreatureBase creatureBase && creatureBase.Stats?.GetStat(StatType.Health) != null)
			{
				UpdateStat(creatureBase.Stats);
			}
		}

		private float UpdateStat(StatsInstance stats)
		{
			StatType statType = StatType.None;
			foreach (StatType value in Enum.GetValues(typeof(StatType)))
			{
				if (value.ToString().ToLower().Contains(name.ToLower()))
				{
					statType = value;
					break;
				}
			}
			if (statType == StatType.None)
			{
				return 0f;
			}
			StatInstance stat = stats.GetStat(statType);
			if (stat == null)
			{
				return 0f;
			}
			stat.SetCurrent(this.value);
			return stat.Current;
		}

		private void OnRightMouseClick()
		{
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent -= OnCreatureSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent -= OnSelected;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
