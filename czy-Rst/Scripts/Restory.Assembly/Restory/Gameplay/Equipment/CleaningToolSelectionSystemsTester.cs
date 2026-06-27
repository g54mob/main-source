using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Equipment;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class CleaningToolSelectionSystemsTester : MonoBehaviour
	{
		private AvailableToolsTrackingService availableTools;

		private CleaningToolSelectionService toolSelector;

		private ElementCleanerToolInfoBase CurrentlySelectedTool
		{
			get
			{
				if (!toolSelector)
				{
					return null;
				}
				return toolSelector.CurrentlySelectedTool;
			}
		}

		private IReadOnlyList<CleaningToolInfo> AvailableTools
		{
			get
			{
				if (!availableTools)
				{
					return Array.Empty<CleaningToolInfo>();
				}
				return availableTools.AvailableTools.OfType<CleaningToolInfo>().ToList();
			}
		}

		[Inject]
		private void Construct(AvailableToolsTrackingService availableTools, CleaningToolSelectionService toolSelector)
		{
			this.availableTools = availableTools;
			this.toolSelector = toolSelector;
		}

		private void SelectDefaultTool()
		{
			toolSelector.TryToSelectDefaultTool();
		}

		private void TryToSelectNextAvailableTool()
		{
			toolSelector.TryToSelectNextAvailableTool();
		}

		private void TryToSelect(CleaningToolInfo toolToSelect)
		{
			toolSelector.TryToSelectTool(toolToSelect);
		}

		private void AddToolToAvailableList(CleaningToolInfo toolToAdd)
		{
			availableTools.AddTool(toolToAdd);
		}

		private void RemoveToolFromAvailableList(CleaningToolInfo toolToRemove)
		{
			availableTools.RemoveTool(toolToRemove);
			if (CurrentlySelectedTool.ID == toolToRemove.ID && !toolSelector.TryToSelectDefaultTool())
			{
				toolSelector.TryToSelectNextAvailableTool();
			}
		}
	}
}
