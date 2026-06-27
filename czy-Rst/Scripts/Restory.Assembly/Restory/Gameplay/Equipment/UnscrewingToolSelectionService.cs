using System;
using Restory.Data.Equipment;
using Restory.Data.SaveLoad;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class UnscrewingToolSelectionService : MonoBehaviour, IInitializable, IDisposable, IPostRestoreComponent
	{
		[SerializeField]
		private AvailableToolsTrackingService availableTools;

		private UnscrewingToolInfo currentlySelectedTool;

		public UnscrewingToolInfo CurrentlySelectedTool
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
			UnscrewingToolInfo unscrewingToolInfo = null;
			foreach (ToolInfo availableTool in availableTools.AvailableTools)
			{
				if (availableTool is UnscrewingToolInfo unscrewingToolInfo2 && (unscrewingToolInfo == null || unscrewingToolInfo2.ToolLevel > unscrewingToolInfo.ToolLevel))
				{
					unscrewingToolInfo = unscrewingToolInfo2;
				}
			}
			CurrentlySelectedTool = unscrewingToolInfo;
		}

		public void PostRestore()
		{
			ResolveOnToolsListChanged();
		}
	}
}
