using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.View;
using NSMedieval.Village;

namespace NSMedieval.DevConsole
{
	public class CommandSetWorkerHealth : ConsoleCommand
	{
		private float health;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetWorkerHealth()
		{
			Command = "setHealth";
			Description = "Set health level of creatures, plants or resources.";
			Help = "Use this command to change health of any object you select";
		}

		private void CommandMethod(float value)
		{
			health = value;
			string result = "Health level is updated";
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent += OnCreatureSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelected;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {value}" });
		}

		private void OnSelected(SelectableObject obj)
		{
			if (obj == null)
			{
				return;
			}
			WorldObject asWorldObject = obj.GetAsWorldObject();
			if (asWorldObject == null || !(asWorldObject is IStatsOwner statsOwner))
			{
				return;
			}
			StatInstance statInstance = statsOwner.Stats?.GetStat(StatType.Health);
			if (statInstance != null)
			{
				statInstance.SetCurrent(health);
				if (statInstance.Current <= 0f && statsOwner is PlantMapResourceInstance plantMapResourceInstance)
				{
					plantMapResourceInstance.SetLastPhase();
				}
			}
		}

		private void OnCreatureSelected(Agent agent)
		{
			if (!MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked && agent != null && agent.AgentOwner is CreatureBase creatureBase && creatureBase.Stats?.GetStat(StatType.Health) != null)
			{
				creatureBase.Stats.GetStat(StatType.Health).SetCurrent(health);
			}
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
