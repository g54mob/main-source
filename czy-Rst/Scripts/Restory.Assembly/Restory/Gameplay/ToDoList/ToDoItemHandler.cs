using Restory.Data.ToDoList;

namespace Restory.Gameplay.ToDoList
{
	public abstract class ToDoItemHandler
	{
		private ToDoItem item;

		private ToDoListService toDoListService;

		public ToDoItem Item => item;

		public ToDoListService ToDoListService => toDoListService;

		public virtual void Initialize(ToDoItem item, ToDoListService toDoListService)
		{
			this.item = item;
			this.toDoListService = toDoListService;
		}

		public virtual void Dispose()
		{
		}

		public virtual void ForceCheckCompletionConditions()
		{
		}
	}
}
