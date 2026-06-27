using Restory.Data.ToDoList;
using Restory.Gameplay.Equipment;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.ToDoList
{
	public class UseCleaningToolToDoItemHandler : ToDoItemHandler
	{
		private UseCleaningToolToDoItem useCleaningToolToDoItem;

		private CleanerBrush cleanerBrush;

		[Inject]
		private void Construct(CleanerBrush cleanerBrush)
		{
			this.cleanerBrush = cleanerBrush;
		}

		public override void Initialize(ToDoItem item, ToDoListService toDoListService)
		{
			if (!(item is UseCleaningToolToDoItem useCleaningToolToDoItem))
			{
				Debug.LogError("[DialogueToDoItemHandler] tried to initialize, but the supplied item is not [UseCleaningToolToDoItem], but [" + item.GetType().Name + "] instead!");
				return;
			}
			this.useCleaningToolToDoItem = useCleaningToolToDoItem;
			base.Initialize(item, toDoListService);
			cleanerBrush.OnExecute += ResolveOnExecute;
			cleanerBrush.OnExecuteSoldering += ResolveOnExecuteSoldering;
		}

		public override void Dispose()
		{
			base.Dispose();
			if (cleanerBrush.MonoShellExists())
			{
				cleanerBrush.OnExecute -= ResolveOnExecute;
				cleanerBrush.OnExecuteSoldering -= ResolveOnExecuteSoldering;
			}
		}

		private void ResolveOnExecute()
		{
			if (!(cleanerBrush.CurrentBrushSettings.ID != useCleaningToolToDoItem.Tool.ID))
			{
				base.ToDoListService.CompleteItem(base.Item);
			}
		}

		private void ResolveOnExecuteSoldering()
		{
			if (!(cleanerBrush.CurrentSolderingSettings.ID != useCleaningToolToDoItem.Tool.ID))
			{
				base.ToDoListService.CompleteItem(base.Item);
			}
		}
	}
}
