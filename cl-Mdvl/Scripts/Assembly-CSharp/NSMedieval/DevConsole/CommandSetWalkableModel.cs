using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;

namespace NSMedieval.DevConsole
{
	public class CommandSetWalkableModel : ConsoleCommand
	{
		private string modelId;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetWalkableModel()
		{
			Command = "setWalkableModel";
			Description = "Sets or gets the creature's walkable model on click.";
			Help = "setWalkableModel <optional:modelId> - set the given walkable model on click. If no model is specified, current walkable model will be logged out to the console.";
		}

		private static string GetAllWalkableModels()
		{
			List<string> values = (from model in Repository<WalkableModelRepository, WalkableModel>.Instance.GetAllItems()
				select model.GetID()).ToList();
			return string.Join(", ", values);
		}

		private void CommandMethod(string value)
		{
			modelId = value;
			string result = ((!string.IsNullOrEmpty(modelId)) ? ("Click on a creature to set its WalkableModel to " + modelId + ".") : ("No model id specified. Possible values: " + GetAllWalkableModels()));
			Unsubscribe();
			Subscribe();
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command + " " + value });
		}

		private void CommandMethod()
		{
			modelId = null;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("No model id specified. Possible values: " + GetAllWalkableModels());
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Click on a creature to print out its WalkableModel to " + modelId + ".");
			Unsubscribe();
			Subscribe();
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command + " - click on a creature to get its WalkableModel." });
		}

		private void OnCreatureSelected(Agent agent)
		{
			if (!MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked && agent != null && agent.AgentOwner is CreatureBase creatureBase)
			{
				if (string.IsNullOrEmpty(modelId))
				{
					MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Current walkable model is: " + creatureBase.WalkableModel?.GetID());
					MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "WalkableModel: " + creatureBase.WalkableModel?.GetID() });
				}
				else
				{
					MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult($"Setting walkable model {modelId} for {creatureBase}");
					creatureBase.SetWalkableModel(modelId);
				}
			}
		}

		private void Subscribe()
		{
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent += OnCreatureSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
		}

		private void Unsubscribe()
		{
			MonoSingleton<GoapController>.Instance.AgentSelectedEvent -= OnCreatureSelected;
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
		}

		private void OnRightMouseClick()
		{
			Unsubscribe();
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
