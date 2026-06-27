using System;
using Restory.Constants;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.DetectableObjects;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;

namespace Restory.Gameplay.Equipment
{
	public class NotepadInteractiveWorkplaceItem : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IDetectableObject
	{
		public class NotepadActivatorSaveData
		{
			public bool IsActive;

			public bool HasShownOnFirstDrag;

			public bool WindowIsPinned;
		}

		[SerializeField]
		private ClickableTrigger clickableTrigger;

		private bool isActive = true;

		private bool hasShownOnFirstDrag;

		private bool windowIsPinned;

		public bool CanBeDetected
		{
			set
			{
				clickableTrigger.enabled = value;
			}
		}

		public bool IsActive
		{
			get
			{
				return isActive;
			}
			set
			{
				isActive = value;
				if (isActive)
				{
					base.gameObject.layer = ProjectConstants.Layers.Obstacles;
				}
			}
		}

		public bool HasShownOnFirstDrag
		{
			get
			{
				return hasShownOnFirstDrag;
			}
			set
			{
				hasShownOnFirstDrag = value;
			}
		}

		public bool WindowIsPinned
		{
			get
			{
				return windowIsPinned;
			}
			set
			{
				windowIsPinned = value;
			}
		}

		public ClickableTrigger Trigger => clickableTrigger;

		public void RestoreState(object state)
		{
			try
			{
				NotepadActivatorSaveData notepadActivatorSaveData = DataMigrationWizard.Migrate<NotepadActivatorSaveData>(state, base.gameObject);
				hasShownOnFirstDrag = notepadActivatorSaveData.HasShownOnFirstDrag;
				IsActive = notepadActivatorSaveData.IsActive;
				windowIsPinned = notepadActivatorSaveData.WindowIsPinned;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public object CaptureState()
		{
			try
			{
				return new NotepadActivatorSaveData
				{
					IsActive = IsActive,
					HasShownOnFirstDrag = hasShownOnFirstDrag,
					WindowIsPinned = windowIsPinned
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}
	}
}
