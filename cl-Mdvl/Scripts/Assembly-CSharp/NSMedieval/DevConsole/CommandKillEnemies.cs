using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.StatsSystem;

namespace NSMedieval.DevConsole
{
	public class CommandKillEnemies : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandKillEnemies()
		{
			Command = "killEnemies";
			Description = "Kills all enemy NPCs on the map";
			Help = "Use this to kill all enemy NPCs on the map";
		}

		private void CommandMethod()
		{
			foreach (HumanoidInstance item in MonoSingleton<NPCManager>.Instance.IterateNPCs((HumanoidInstance npc) => npc.IsEnemy()))
			{
				item.Stats.GetStat(StatType.Health).SetCurrent(0f);
				MonoSingleton<NPCController>.Instance.RemoveNPC(item);
			}
		}
	}
}
