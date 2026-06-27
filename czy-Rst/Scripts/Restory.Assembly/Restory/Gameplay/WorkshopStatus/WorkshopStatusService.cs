using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Data.WorkshopStatus;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;

namespace Restory.Gameplay.WorkshopStatus
{
	public sealed class WorkshopStatusService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private readonly HashSet<StatusInfo> currentStatuses = new HashSet<StatusInfo>();

		public IReadOnlyCollection<StatusInfo> CurrentStatuses => currentStatuses;

		public event Action<WorkshopStatusService, StatusInfo> OnStatusAdded;

		public event Action<WorkshopStatusService, StatusInfo> OnStatusRemoved;

		public bool HasStatus(StatusInfo status)
		{
			return currentStatuses.Contains(status);
		}

		public void AddStatus(StatusInfo status)
		{
			if (currentStatuses.Add(status))
			{
				this.OnStatusAdded?.Invoke(this, status);
			}
		}

		public void RemoveStatus(StatusInfo status)
		{
			if (currentStatuses.Remove(status))
			{
				this.OnStatusRemoved?.Invoke(this, status);
			}
		}

		public object CaptureState()
		{
			try
			{
				return new WorkshopStatusServiceSaveData
				{
					Statuses = currentStatuses.ToArray()
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
				WorkshopStatusServiceSaveData workshopStatusServiceSaveData = DataMigrationWizard.Migrate<WorkshopStatusServiceSaveData>(state, base.gameObject);
				currentStatuses.Clear();
				StatusInfo[] statuses = workshopStatusServiceSaveData.Statuses;
				foreach (StatusInfo item in statuses)
				{
					currentStatuses.Add(item);
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
