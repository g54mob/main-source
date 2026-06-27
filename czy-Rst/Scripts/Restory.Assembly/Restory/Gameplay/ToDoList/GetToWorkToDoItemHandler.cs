using Restory.Data.ToDoList;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.TimeSystems;
using Restory.Utils;
using Zenject;

namespace Restory.Gameplay.ToDoList
{
	public sealed class GetToWorkToDoItemHandler : ToDoItemHandler, Restory.Gameplay.TimeSystems.ITickable
	{
		private InteractiveObjectService interactiveObjectService;

		private TickSystem tickSystem;

		[Inject]
		private void Construct(InteractiveObjectService interactiveObjectService, TickSystem tickSystem)
		{
			this.interactiveObjectService = interactiveObjectService;
			this.tickSystem = tickSystem;
		}

		public override void Initialize(ToDoItem item, ToDoListService toDoListService)
		{
			base.Initialize(item, toDoListService);
			tickSystem.AddSubscriber(this);
		}

		public override void Dispose()
		{
			base.Dispose();
			if (tickSystem.MonoShellExists())
			{
				tickSystem.RemoveSubscriber(this);
			}
		}

		public void Tick(float deltaTime)
		{
			if (!interactiveObjectService.AnyObjectOnSurface)
			{
				base.ToDoListService.CompleteItem(base.Item);
			}
		}
	}
}
