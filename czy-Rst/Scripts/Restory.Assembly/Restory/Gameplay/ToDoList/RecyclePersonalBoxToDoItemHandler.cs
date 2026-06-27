using Restory.Data.ToDoList;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.TimeSystems;
using Restory.Utils;
using Zenject;

namespace Restory.Gameplay.ToDoList
{
	public class RecyclePersonalBoxToDoItemHandler : ToDoItemHandler, Restory.Gameplay.TimeSystems.ITickable
	{
		private PersonalBoxService personalBoxService;

		private TickSystem tickSystem;

		[Inject]
		private void Construct(PersonalBoxService personalBoxService, TickSystem tickSystem)
		{
			this.personalBoxService = personalBoxService;
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
			if (personalBoxService.PersonalBox == null)
			{
				base.ToDoListService.CompleteItem(base.Item);
			}
		}
	}
}
