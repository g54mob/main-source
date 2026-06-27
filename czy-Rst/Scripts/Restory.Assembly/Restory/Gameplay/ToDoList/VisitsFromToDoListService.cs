using System;
using Restory.Data.ToDoList;
using Restory.Gameplay.Visits;
using Restory.Utils;
using Zenject;

namespace Restory.Gameplay.ToDoList
{
	public sealed class VisitsFromToDoListService : IInitializable, IDisposable
	{
		private readonly ToDoListService toDoListService;

		private readonly CurrentDayVisitsQueueService currentDayVisitsQueueService;

		public VisitsFromToDoListService(ToDoListService toDoListService, CurrentDayVisitsQueueService currentDayVisitsQueueService)
		{
			this.toDoListService = toDoListService;
			this.currentDayVisitsQueueService = currentDayVisitsQueueService;
		}

		public void Initialize()
		{
			toDoListService.OnCompleted += ResolveToDoItemCompleted;
		}

		public void Dispose()
		{
			if (toDoListService.MonoShellExists())
			{
				toDoListService.OnCompleted -= ResolveToDoItemCompleted;
			}
		}

		private void ResolveToDoItemCompleted(ToDoListService _, ToDoItem completedToDoListItem)
		{
			if (completedToDoListItem.ShouldAddVisitOnItemCompletion)
			{
				currentDayVisitsQueueService.AddNewImmediateVisit(completedToDoListItem.NpcForVisitToAddOnCompletion, TimeSpan.FromMinutes(completedToDoListItem.GameMinutesBeforeVisitAfterCompletion), completedToDoListItem.TextureIdOfNpcForVisitToAddOnCompletion);
			}
		}
	}
}
