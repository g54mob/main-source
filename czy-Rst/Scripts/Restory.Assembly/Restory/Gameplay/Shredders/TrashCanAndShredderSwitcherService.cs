using System;
using System.Linq;
using Restory.Data.Equipment;
using Restory.Data.SaveLoad;
using Restory.Gameplay.Equipment;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Shredders
{
	public class TrashCanAndShredderSwitcherService : MonoBehaviour, IInitializable, IDisposable, IPostRestoreComponent
	{
		private TrashCan trashCan;

		private Shredder shredder;

		private AvailableToolsTrackingService availableToolsTrackingService;

		[Inject]
		private void Construct(AvailableToolsTrackingService availableToolsTrackingService, TrashCan trashCan, Shredder shredder)
		{
			this.availableToolsTrackingService = availableToolsTrackingService;
			this.trashCan = trashCan;
			this.shredder = shredder;
		}

		public void Initialize()
		{
			availableToolsTrackingService.OnToolsListChanged += ResolveToolsListChanged;
			UpdateState();
		}

		public void Dispose()
		{
			availableToolsTrackingService.OnToolsListChanged -= ResolveToolsListChanged;
		}

		public void ActivateShredder()
		{
			trashCan.gameObject.SetActive(value: false);
			shredder.gameObject.SetActive(value: true);
		}

		public void ActivateTrashCan()
		{
			shredder.gameObject.SetActive(value: false);
			trashCan.gameObject.SetActive(value: true);
		}

		public void PostRestore()
		{
			UpdateState();
		}

		private void ResolveToolsListChanged()
		{
			UpdateState();
		}

		private void UpdateState()
		{
			if (availableToolsTrackingService.AvailableTools.Any((ToolInfo tool) => tool is ShredderToolInfo))
			{
				ActivateShredder();
			}
			else
			{
				ActivateTrashCan();
			}
		}
	}
}
