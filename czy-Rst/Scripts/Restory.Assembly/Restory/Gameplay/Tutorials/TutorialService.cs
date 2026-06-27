using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Data.Tutorials;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.Tutorials.Handlers;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tutorials
{
	public class TutorialService : MonoBehaviour, IDisposable, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPostRestoreComponent
	{
		private readonly HashSet<TutorialBase> notCompletedTutorials = new HashSet<TutorialBase>();

		private readonly List<TutorialHandlerBase> activeInBackgroundHandlers = new List<TutorialHandlerBase>();

		private TutorialRegistry tutorialRegistry;

		private TutorialHandlerFactory tutorialHandlerFactory;

		[Inject]
		private void Construct(TutorialRegistry tutorialRegistry, TutorialHandlerFactory tutorialHandlerFactory)
		{
			this.tutorialRegistry = tutorialRegistry;
			this.tutorialHandlerFactory = tutorialHandlerFactory;
		}

		public void Dispose()
		{
			CleanupHandlers();
		}

		public void AddTutorials(IEnumerable<TutorialBase> tutorials)
		{
			foreach (TutorialBase tutorial in tutorials)
			{
				AddTutorial(tutorial);
			}
		}

		public void AddTutorial(TutorialBase tutorial)
		{
			if (!tutorialRegistry.IsTutorialCompleted(tutorial) && notCompletedTutorials.Add(tutorial))
			{
				ActivateTutorial(tutorial);
			}
		}

		private void ActivateTutorial(TutorialBase tutorial)
		{
			foreach (TutorialHandlerBase activeInBackgroundHandler in activeInBackgroundHandlers)
			{
				if (activeInBackgroundHandler.Tutorial.ID == tutorial.ID)
				{
					return;
				}
			}
			TutorialHandlerBase tutorialHandlerBase = tutorialHandlerFactory.Create(tutorial);
			tutorialHandlerBase.OnTutorialComplete += ResolveTutorialComplete;
			tutorialHandlerBase.Init();
			activeInBackgroundHandlers.Add(tutorialHandlerBase);
		}

		private void ResolveTutorialComplete(TutorialHandlerBase tutorialHandler)
		{
			tutorialHandler.OnTutorialComplete -= ResolveTutorialComplete;
			notCompletedTutorials.Remove(tutorialHandler.Tutorial);
			activeInBackgroundHandlers.Remove(tutorialHandler);
			tutorialRegistry.RegisterCompletedTutorial(tutorialHandler.Tutorial);
			tutorialHandler.Cleanup();
			AddTutorials(tutorialHandler.Tutorial.UpcomingTutorials);
		}

		private void CleanupHandlers()
		{
			foreach (TutorialHandlerBase activeInBackgroundHandler in activeInBackgroundHandlers)
			{
				activeInBackgroundHandler.OnTutorialComplete -= ResolveTutorialComplete;
				activeInBackgroundHandler.Cleanup();
			}
			activeInBackgroundHandlers.Clear();
		}

		public object CaptureState()
		{
			try
			{
				return new TutorialServiceSaveData
				{
					NotCompletedTutorials = notCompletedTutorials.ToList()
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
				foreach (TutorialBase notCompletedTutorial in DataMigrationWizard.Migrate<TutorialServiceSaveData>(state, base.gameObject).NotCompletedTutorials)
				{
					if (tutorialRegistry.IsTutorialCompleted(notCompletedTutorial))
					{
						break;
					}
					notCompletedTutorials.Add(notCompletedTutorial);
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public void PostRestore()
		{
			foreach (TutorialBase notCompletedTutorial in notCompletedTutorials)
			{
				ActivateTutorial(notCompletedTutorial);
			}
		}

		public void SetAllTutorialsCompleted()
		{
			while (activeInBackgroundHandlers.Count > 0)
			{
				TutorialHandlerBase tutorialHandler = activeInBackgroundHandlers[0];
				ResolveTutorialComplete(tutorialHandler);
			}
		}
	}
}
