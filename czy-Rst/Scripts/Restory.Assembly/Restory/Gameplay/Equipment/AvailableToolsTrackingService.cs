using System;
using System.Collections.Generic;
using Restory.Data.Equipment;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;

namespace Restory.Gameplay.Equipment
{
	public class AvailableToolsTrackingService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private readonly List<ToolInfo> availableTools = new List<ToolInfo>();

		private readonly Dictionary<string, ToolRuntimeState> tools = new Dictionary<string, ToolRuntimeState>();

		private readonly HashSet<ToolsCategory> availableToolsCategories = new HashSet<ToolsCategory>();

		public bool HasDevicePaintingTool { get; private set; }

		public IReadOnlyList<ToolInfo> AvailableTools => availableTools;

		public event Action OnToolsListChanged;

		public event Action<ToolInfo> OnToolAdded;

		public event Action<ToolInfo> OnToolRemoved;

		public event Action<ToolInfo> OnToolResourceChanged;

		public bool AddTool(ToolInfo toolToAdd, int amount = 1)
		{
			if (!toolToAdd || amount <= 0)
			{
				return false;
			}
			if (!tools.TryGetValue(toolToAdd.ID, out var value))
			{
				tools[toolToAdd.ID] = new ToolRuntimeState
				{
					Tool = toolToAdd,
					Count = amount,
					CurrentUsesLeft = toolToAdd.MaxUses
				};
				AddAvailableTool(toolToAdd);
			}
			else
			{
				value.Count += amount;
				if (toolToAdd.IsConsumable && value.Count >= 2 && value.CurrentUsesLeft <= 0f)
				{
					value.Count--;
					value.CurrentUsesLeft = toolToAdd.MaxUses;
				}
				tools[toolToAdd.ID] = value;
			}
			this.OnToolsListChanged?.Invoke();
			this.OnToolAdded?.Invoke(toolToAdd);
			this.OnToolResourceChanged?.Invoke(toolToAdd);
			return true;
		}

		public bool RemoveTool(ToolInfo toolToRemove, int amount = 1)
		{
			if (!toolToRemove || amount <= 0)
			{
				return false;
			}
			if (!tools.TryGetValue(toolToRemove.ID, out var value))
			{
				return false;
			}
			value.Count = Mathf.Max(0, value.Count - amount);
			if (value.Count > 0)
			{
				tools[toolToRemove.ID] = value;
			}
			else
			{
				tools.Remove(toolToRemove.ID);
				availableTools.RemoveAll((ToolInfo t) => t.ID == toolToRemove.ID);
			}
			this.OnToolsListChanged?.Invoke();
			this.OnToolRemoved?.Invoke(toolToRemove);
			this.OnToolResourceChanged?.Invoke(toolToRemove);
			return true;
		}

		public bool TryGetToolState(ToolInfo tool, out ToolRuntimeState state)
		{
			return tools.TryGetValue(tool.ID, out state);
		}

		public bool IsToolsCategoryAvailable(ToolsCategory category)
		{
			return availableToolsCategories.Contains(category);
		}

		public bool IsToolAvailable(ToolInfo toolToCheck)
		{
			return GetToolCount(toolToCheck) > 0;
		}

		public int GetToolCount(ToolInfo tool)
		{
			if (!tool)
			{
				return 0;
			}
			if (!tools.TryGetValue(tool.ID, out var value))
			{
				return 0;
			}
			return Mathf.Max(value.Count, 0);
		}

		public float GetToolCurrentUsesLeft(ToolInfo tool)
		{
			if (!tool)
			{
				return 0f;
			}
			if (!tools.TryGetValue(tool.ID, out var value) || value.Count <= 0)
			{
				return 0f;
			}
			if (!tool.IsConsumable)
			{
				return float.MaxValue;
			}
			return value.CurrentUsesLeft;
		}

		public bool SetToolCurrentUsesLeft(ToolInfo tool, float newUsesLeft)
		{
			if (!tool)
			{
				return false;
			}
			if (!tools.TryGetValue(tool.ID, out var value) || value.Count <= 0)
			{
				return false;
			}
			if (!tool.IsConsumable)
			{
				return false;
			}
			value.CurrentUsesLeft = Mathf.Clamp(newUsesLeft, 0f, tool.MaxUses);
			tools[tool.ID] = value;
			this.OnToolResourceChanged?.Invoke(tool);
			return true;
		}

		public float GetToolTotalUsesRemaining(ToolInfo tool)
		{
			if (!tool)
			{
				return 0f;
			}
			if (!tools.TryGetValue(tool.ID, out var value) || (float)value.Count <= 0f)
			{
				return 0f;
			}
			if (!tool.IsConsumable)
			{
				return float.MaxValue;
			}
			return value.CurrentUsesLeft + (float)(value.Count - 1) * tool.MaxUses;
		}

		public void RefillToolUses(ToolInfo tool)
		{
			if ((bool)tool && tool.IsConsumable && tools.TryGetValue(tool.ID, out var value) && !((float)value.Count <= 0f))
			{
				value.CurrentUsesLeft = tool.MaxUses;
				tools[tool.ID] = value;
				this.OnToolResourceChanged?.Invoke(tool);
			}
		}

		public bool TryGetBestToolInCategory(ToolsCategory toolCategory, out ToolInfo bestTool)
		{
			bestTool = null;
			int num = int.MinValue;
			foreach (ToolInfo availableTool in availableTools)
			{
				if ((bool)availableTool && !(availableTool.ToolsCategory.ID != toolCategory.ID) && availableTool.ToolLevel > num)
				{
					num = availableTool.ToolLevel;
					bestTool = availableTool;
				}
			}
			return bestTool;
		}

		private void AddAvailableTool(ToolInfo tool)
		{
			availableTools.Add(tool);
			availableToolsCategories.Add(tool.ToolsCategory);
			if (tool is DevicePainterToolInfo)
			{
				HasDevicePaintingTool = true;
			}
		}

		public object CaptureState()
		{
			try
			{
				List<ToolRuntimeState> list = new List<ToolRuntimeState>(tools.Count);
				foreach (ToolRuntimeState value in tools.Values)
				{
					if (value.Count > 0 && (bool)value.Tool)
					{
						list.Add(value);
					}
				}
				return new AvailableToolsSaveData
				{
					Tools = list.ToArray()
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				AvailableToolsSaveData availableToolsSaveData = DataMigrationWizard.Migrate<AvailableToolsSaveData>(state, base.gameObject);
				tools.Clear();
				availableTools.Clear();
				if (availableToolsSaveData.Tools == null)
				{
					return;
				}
				ToolRuntimeState[] array = availableToolsSaveData.Tools;
				for (int i = 0; i < array.Length; i++)
				{
					ToolRuntimeState value = array[i];
					if ((bool)value.Tool && value.Count > 0)
					{
						tools[value.Tool.ID] = value;
					}
				}
				foreach (ToolRuntimeState value2 in tools.Values)
				{
					AddAvailableTool(value2.Tool);
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
