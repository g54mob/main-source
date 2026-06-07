using System.Collections.Generic;

namespace SettingScripts
{
	public static class ActionWarnings
	{
		public static ActionWarning deleteBibiteFileActionWarning = new ActionWarning
		{
			title = "Deleting Bibite File",
			key = "fileDeletionWarning",
			warningText = "Are you sure you want to delete this file?\nThis action cannot be reverted."
		};

		public static ActionWarning deleteSaveFileActionWarning = new ActionWarning
		{
			title = "Deleting Save File",
			key = "saveDeletionWarning",
			warningText = "Are you sure you want to delete this save file?"
		};

		public static ActionWarning pruneSpeciesActionWarning = new ActionWarning
		{
			title = "Pruning Species Warning",
			key = "pruneSpeciesWarning",
			warningText = "You're about to prune a species, this process is IRREVERSIBLE!\nAre you sure?"
		};

		public static ActionWarning startScenarioAfterEdit = new ActionWarning
		{
			title = "Starting Simulation After Edit",
			key = "startScenarioAfterEdit",
			warningText = "You're about to launch the Simulation from a modified Scenario. Make sure to save the scenario first if you intend to use it again later.\nIt's also possible to save the scenario once in-game.\n\nAre you sure you are Ready"
		};

		public static ActionWarning deleteWorkshopItem = new ActionWarning
		{
			title = "Delete Workshop Item",
			key = "deleteWorkshopItem",
			warningText = "You're about to permanently and irreversibly delete your workshop Item.\n\nAre you sure?"
		};

		public static List<ActionWarning> allInfoShown = new List<ActionWarning> { deleteSaveFileActionWarning, pruneSpeciesActionWarning, startScenarioAfterEdit };
	}
}
