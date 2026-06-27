using System;
using PixelCrushers.DialogueSystem;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;

namespace Restory.Gameplay.Dialogue
{
	public class RestoryDialogueSystemSaver : DialogueSystemSaver, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPreCaptureComponent, IPostCaptureComponent
	{
		private readonly DialogueSystemSaveData capturedState = new DialogueSystemSaveData();

		public void PreCapture()
		{
			capturedState.JsonData = RecordData();
		}

		public object CaptureState()
		{
			try
			{
				return capturedState;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void PostCapture()
		{
			capturedState.JsonData = string.Empty;
		}

		public void RestoreState(object state)
		{
			try
			{
				DialogueSystemSaveData dialogueSystemSaveData = DataMigrationWizard.Migrate<DialogueSystemSaveData>(state, base.gameObject);
				ApplyData(dialogueSystemSaveData.JsonData);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
