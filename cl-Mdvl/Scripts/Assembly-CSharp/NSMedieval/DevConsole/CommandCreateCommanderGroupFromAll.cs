using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.CommanderAI;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Village;

namespace NSMedieval.DevConsole
{
	public class CommandCreateCommanderGroupFromAll : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandCreateCommanderGroupFromAll()
		{
			Command = "createCommanderGroupFromAll";
			Description = "Creates a Commander AI group from all enemies on the map";
			Help = "createCommanderGroupFromAll";
		}

		private void CommandMethod()
		{
			CommanderAIManager commanderAIManager = VillageManager.ActiveVillage.Map.CommanderAIManager;
			uint num = commanderAIManager.CreateCommander();
			foreach (EnemyBehaviour item in MonoSingleton<NPCManager>.Instance.IterateNPCs<EnemyBehaviour>())
			{
				commanderAIManager.AssignUnitToCommander(item, num);
			}
			CommanderAgentBase commander = commanderAIManager.GetCommander(num);
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(32, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\Console\\Commands\\CommandCreateCommanderGroupFromAll.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Created commander ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(" with ");
				messageBuilder.AppendFormatted(commander.UnitGroup.Units.Count);
				messageBuilder.AppendLiteral(" enemies");
			}
			Log.Info(messageBuilder);
		}
	}
}
