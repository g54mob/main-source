using Restory.Data.ToDoList;

namespace Restory.Data.SaveLoad.Containers
{
	public class ToDoListServiceSaveData
	{
		public bool IsActive;

		public ToDoItem[] AvailableItems;

		public ToDoItem[] CompletedItems;
	}
}
