using System;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;

namespace Restory.Gameplay.WorkshopRatings
{
	public sealed class WorkshopRatingsAppOpenStateComponent : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		[Serializable]
		private class WorkshopRatingsAppOpenStateSaveData
		{
			public bool HasBeenOpened { get; set; }
		}

		[SerializeField]
		private bool hasBeenOpened;

		public bool HasBeenOpened => hasBeenOpened;

		public event Action<WorkshopRatingsAppOpenStateComponent> OnOpened;

		public void MarkAsOpened()
		{
			if (!hasBeenOpened)
			{
				hasBeenOpened = true;
				this.OnOpened?.Invoke(this);
			}
		}

		public object CaptureState()
		{
			try
			{
				return new WorkshopRatingsAppOpenStateSaveData
				{
					HasBeenOpened = hasBeenOpened
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
				WorkshopRatingsAppOpenStateSaveData workshopRatingsAppOpenStateSaveData = DataMigrationWizard.Migrate<WorkshopRatingsAppOpenStateSaveData>(state, base.gameObject);
				hasBeenOpened = workshopRatingsAppOpenStateSaveData.HasBeenOpened;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
