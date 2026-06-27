using Restory.Data.ToDoList;
using Restory.Gameplay.Equipment;
using Zenject;

namespace Restory.Gameplay.ToDoList
{
	public class OpenWorkshopToDoItemHandler : ToDoItemHandler
	{
		private WindowShuttersStoreInteractiveItem windowShuttersStoreInteractiveItem;

		[Inject]
		private void Construct(WindowShuttersStoreInteractiveItem windowShuttersStoreInteractiveItem)
		{
			this.windowShuttersStoreInteractiveItem = windowShuttersStoreInteractiveItem;
		}

		public override void Initialize(ToDoItem item, ToDoListService toDoListService)
		{
			base.Initialize(item, toDoListService);
			windowShuttersStoreInteractiveItem.OnIsOpenStatusChanged += ResolveOnIsOpenStatusChanged;
		}

		public override void Dispose()
		{
			base.Dispose();
			windowShuttersStoreInteractiveItem.OnIsOpenStatusChanged -= ResolveOnIsOpenStatusChanged;
		}

		private void ResolveOnIsOpenStatusChanged()
		{
			if (windowShuttersStoreInteractiveItem.IsWindowOpen)
			{
				base.ToDoListService.CompleteItem(base.Item);
			}
		}
	}
}
