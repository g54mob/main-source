using System;
using System.Linq;
using Restory.Data.Equipment;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Views
{
	public class CleanerActivator : ToolActivator, IInitializable, IDisposable
	{
		[SerializeField]
		private ToolView compressedAirToolView;

		[SerializeField]
		private Vector3 notActivatedPosition;

		private AvailableToolsTrackingService toolsTrackingService;

		[Inject]
		private void Construct(AvailableToolsTrackingService toolsTrackingService)
		{
			this.toolsTrackingService = toolsTrackingService;
		}

		public void Initialize()
		{
			toolsTrackingService.OnToolRemoved += ResolveToolRemoved;
		}

		public void Dispose()
		{
			toolsTrackingService.OnToolRemoved -= ResolveToolRemoved;
		}

		public override void RestoreState(bool isActivated)
		{
			if (!isActivated)
			{
				base.transform.position = notActivatedPosition;
			}
			base.RestoreState(isActivated);
		}

		private void ResolveToolRemoved(ToolInfo toolInfo)
		{
			if (!(toolInfo != compressedAirToolView.ToolInfo) && !toolsTrackingService.AvailableTools.Contains(toolInfo))
			{
				compressedAirToolView.RemoveTool();
			}
		}
	}
}
