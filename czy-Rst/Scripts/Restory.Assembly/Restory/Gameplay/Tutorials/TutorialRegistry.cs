using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Data.Tutorials;
using Restory.Gameplay.SaveLoad.Exceptions;
using Sirenix.Utilities;
using UnityEngine;

namespace Restory.Gameplay.Tutorials
{
	public class TutorialRegistry : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private readonly HashSet<string> completedTutorials = new HashSet<string>();

		public bool IsTutorialCompleted(TutorialBase tutorial)
		{
			return completedTutorials.Contains(tutorial.ID);
		}

		public void RegisterCompletedTutorial(TutorialBase tutorial)
		{
			if (!tutorial)
			{
				Debug.LogError("tutorial is null on RegisterCompletedTutorial");
			}
			else if (!completedTutorials.Add(tutorial.ID))
			{
				Debug.LogError("tutorial for " + tutorial.ID + " has already been registered as completed");
			}
		}

		public object CaptureState()
		{
			try
			{
				return new TutorialRegistrySaveData
				{
					CompletedTutorials = completedTutorials.ToList()
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
				TutorialRegistrySaveData tutorialRegistrySaveData = DataMigrationWizard.Migrate<TutorialRegistrySaveData>(state, base.gameObject);
				completedTutorials.Clear();
				completedTutorials.AddRange(tutorialRegistrySaveData.CompletedTutorials);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
