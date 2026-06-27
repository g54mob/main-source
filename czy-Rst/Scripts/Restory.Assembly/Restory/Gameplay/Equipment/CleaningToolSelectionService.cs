using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Equipment;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class CleaningToolSelectionService : MonoBehaviour, IInitializable, IDisposable, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPostRestoreComponent
	{
		[SerializeField]
		private AvailableToolsTrackingService availableTools;

		[SerializeField]
		private CleaningToolInfo defaultTool;

		[SerializeField]
		private ToolsCategory defaultToolCategory;

		private ElementCleanerToolInfoBase currentlySelectedTool;

		public ElementCleanerToolInfoBase CurrentlySelectedTool
		{
			get
			{
				return currentlySelectedTool;
			}
			private set
			{
				if (!(value == currentlySelectedTool))
				{
					currentlySelectedTool = value;
					this.OnToolSwitched?.Invoke();
				}
			}
		}

		public CleaningToolInfo DefaultTool => defaultTool;

		public event Action OnToolSwitched;

		public void Initialize()
		{
			availableTools.OnToolsListChanged += ResolveOnToolsListChanged;
		}

		public void Dispose()
		{
			availableTools.OnToolsListChanged -= ResolveOnToolsListChanged;
		}

		private void ResolveOnToolsListChanged()
		{
			if ((bool)CurrentlySelectedTool && !availableTools.IsToolAvailable(CurrentlySelectedTool))
			{
				CurrentlySelectedTool = null;
			}
			if (!CurrentlySelectedTool || CurrentlySelectedTool.ToolsCategory.ID == defaultToolCategory.ID)
			{
				TryToSelectDefaultTool();
			}
		}

		public bool TryToSelectDefaultTool()
		{
			if (!availableTools.TryGetBestToolInCategory(defaultToolCategory, out var bestTool) || !(bestTool is ElementCleanerToolInfoBase toolToSelect) || !TryToSelectTool(toolToSelect))
			{
				return TryToSelectTool(defaultTool);
			}
			return true;
		}

		public bool TryToSelectTool(ElementCleanerToolInfoBase toolToSelect)
		{
			if (availableTools.IsToolAvailable(toolToSelect))
			{
				SelectTool(toolToSelect);
				return true;
			}
			return false;
		}

		public bool TryToSelectNextAvailableTool()
		{
			if (availableTools.AvailableTools.Count == 0)
			{
				return false;
			}
			List<CleaningToolInfo> value;
			using (CollectionPool<List<CleaningToolInfo>, CleaningToolInfo>.Get(out value))
			{
				value.AddRange(availableTools.AvailableTools.OfType<CleaningToolInfo>());
				if (value.Count == 1)
				{
					SelectTool(value[0]);
					return true;
				}
				int num = -1;
				for (int i = 0; i < value.Count; i++)
				{
					if (value[i].ID == currentlySelectedTool.ID)
					{
						num = i;
						break;
					}
				}
				num = ((num >= 0 && num < value.Count - 1) ? (num + 1) : 0);
				SelectTool(value[num]);
				return true;
			}
		}

		private void SelectTool(ElementCleanerToolInfoBase toolToSelect)
		{
			CurrentlySelectedTool = toolToSelect;
		}

		public object CaptureState()
		{
			try
			{
				return new CleaningToolSelectionServiceSaveData
				{
					SelectedTool = currentlySelectedTool
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
				CleaningToolSelectionServiceSaveData cleaningToolSelectionServiceSaveData = DataMigrationWizard.Migrate<CleaningToolSelectionServiceSaveData>(state, base.gameObject);
				currentlySelectedTool = cleaningToolSelectionServiceSaveData.SelectedTool;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public void PostRestore()
		{
			if (!currentlySelectedTool)
			{
				TryToSelectDefaultTool();
			}
		}
	}
}
