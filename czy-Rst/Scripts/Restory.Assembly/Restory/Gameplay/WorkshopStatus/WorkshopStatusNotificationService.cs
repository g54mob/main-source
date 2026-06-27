using System;
using Restory.Data.WorkshopStatus;
using Restory.UI.Presenters.WorkshopStatus;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.WorkshopStatus
{
	public sealed class WorkshopStatusNotificationService : MonoBehaviour, IInitializable, IDisposable
	{
		private WorkshopStatusService workshopStatusService;

		private GUI_WorkshopStatusNotificationCanvas guiStatusNotificationCanvas;

		[Inject]
		private void Construct(WorkshopStatusService workshopStatusService, GUI_WorkshopStatusNotificationCanvas guiStatusNotificationCanvas)
		{
			this.workshopStatusService = workshopStatusService;
			this.guiStatusNotificationCanvas = guiStatusNotificationCanvas;
		}

		public void Initialize()
		{
			workshopStatusService.OnStatusAdded += ResolveStatusAdded;
		}

		public void Dispose()
		{
			workshopStatusService.OnStatusAdded -= ResolveStatusAdded;
		}

		public void ShowAll()
		{
			foreach (StatusInfo currentStatus in workshopStatusService.CurrentStatuses)
			{
				guiStatusNotificationCanvas.Show(currentStatus);
			}
		}

		private void ResolveStatusAdded(WorkshopStatusService service, StatusInfo status)
		{
			guiStatusNotificationCanvas.Show(status);
		}
	}
}
