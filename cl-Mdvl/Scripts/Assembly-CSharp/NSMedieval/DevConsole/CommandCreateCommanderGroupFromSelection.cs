using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.CommanderAI;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.Village;

namespace NSMedieval.DevConsole
{
	public class CommandCreateCommanderGroupFromSelection : ConsoleCommand
	{
		private readonly HashSet<EnemyBehaviour> selectedEnemies = new HashSet<EnemyBehaviour>();

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandCreateCommanderGroupFromSelection()
		{
			Command = "createCommanderGroupFromSelection";
			Description = "Creates a Commander AI group and lets you add units via left click";
			Help = "createCommanderGroup";
		}

		private void CommandMethod()
		{
			selectedEnemies.Clear();
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent += OnCreatureSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Left click to add enemies to group, right click to finish");
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>Add enemy to Commander group" });
		}

		private void OnCreatureSelected(Agent agent)
		{
			if (MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked || agent == null || !(agent.AgentOwner is HumanoidInstance { EnemyBehaviour: { } enemyBehaviour }))
			{
				return;
			}
			bool isEnabled;
			if (selectedEnemies.Add(enemyBehaviour))
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\Console\\Commands\\CommandCreateCommanderGroupFromSelection.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Added enemy from selection '");
					messageBuilder.AppendFormatted(enemyBehaviour.Humanoid.GetFullName());
					messageBuilder.AppendLiteral("'");
				}
				Log.Info(messageBuilder);
			}
			else
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(31, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\Console\\Commands\\CommandCreateCommanderGroupFromSelection.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Removed enemy from selection '");
					messageBuilder.AppendFormatted(enemyBehaviour.Humanoid.GetFullName());
					messageBuilder.AppendLiteral("'");
				}
				Log.Info(messageBuilder);
				selectedEnemies.Remove(enemyBehaviour);
			}
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>Add/remove enemy to Commander group (current count: {selectedEnemies.Count})" });
		}

		private void OnRightMouseClick()
		{
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent -= OnCreatureSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
			if (selectedEnemies.Count == 0)
			{
				return;
			}
			CommanderAIManager commanderAIManager = VillageManager.ActiveVillage.Map.CommanderAIManager;
			uint num = commanderAIManager.CreateCommander();
			foreach (EnemyBehaviour selectedEnemy in selectedEnemies)
			{
				commanderAIManager.AssignUnitToCommander(selectedEnemy, num);
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(28, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\Console\\Commands\\CommandCreateCommanderGroupFromSelection.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Created group ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(" with ");
				messageBuilder.AppendFormatted(selectedEnemies.Count);
				messageBuilder.AppendLiteral(" enemies");
			}
			Log.Info(messageBuilder);
		}
	}
}
