using System;
using Restory.Data.ToDoList;
using Zenject;

namespace Restory.Gameplay.ToDoList
{
	public class ToDoItemHandlerFactory : IFactory<ToDoItem, ToDoItemHandler>, IFactory
	{
		private readonly DiContainer container;

		public ToDoItemHandlerFactory(DiContainer container)
		{
			this.container = container;
		}

		public ToDoItemHandler Create(ToDoItem item)
		{
			ToDoItemHandler toDoItemHandler;
			if (!(item is GetToWorkToDoItem))
			{
				if (!(item is OpenWorkshopToDoItem))
				{
					if (!(item is RecyclePersonalBoxToDoItem))
					{
						if (!(item is DialogueToDoItem))
						{
							if (!(item is GetObjectToDoItem))
							{
								if (!(item is ReadEmailLetterToDoItem))
								{
									if (!(item is UseCleaningToolToDoItem))
									{
										if (!(item is BuyCompetitionDeviceToDoItem))
										{
											if (!(item is AssembledCompetitionDeviceToDoItem))
											{
												if (!(item is BestTimeCompetitionDeviceToDoItem))
												{
													throw new ArgumentException($"Unknown ToDoItem type: {item.GetType()}");
												}
												toDoItemHandler = new BestTimeCompetitionDeviceToDoItemHandler();
											}
											else
											{
												toDoItemHandler = new AssembledCompetitionDeviceToDoItemHandler();
											}
										}
										else
										{
											toDoItemHandler = new BuyCompetitionDeviceToDoItemHandler();
										}
									}
									else
									{
										toDoItemHandler = new UseCleaningToolToDoItemHandler();
									}
								}
								else
								{
									toDoItemHandler = new ReadEmailLetterToDoItemHandler();
								}
							}
							else
							{
								toDoItemHandler = new GetObjectToDoItemHandler();
							}
						}
						else
						{
							toDoItemHandler = new DialogueToDoItemHandler();
						}
					}
					else
					{
						toDoItemHandler = new RecyclePersonalBoxToDoItemHandler();
					}
				}
				else
				{
					toDoItemHandler = new OpenWorkshopToDoItemHandler();
				}
			}
			else
			{
				toDoItemHandler = new GetToWorkToDoItemHandler();
			}
			ToDoItemHandler toDoItemHandler2 = toDoItemHandler;
			container.Inject(toDoItemHandler2);
			return toDoItemHandler2;
		}
	}
}
