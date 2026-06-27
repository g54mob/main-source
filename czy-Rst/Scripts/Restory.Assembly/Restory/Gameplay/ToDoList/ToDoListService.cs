using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Data.ToDoList;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.ToDoList
{
	public sealed class ToDoListService : MonoBehaviour, IInitializable, IDisposable, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private bool isActive;

		private readonly List<ToDoItem> availableItems = new List<ToDoItem>();

		private readonly HashSet<ToDoItem> completedItems = new HashSet<ToDoItem>();

		private readonly Dictionary<ToDoItem, ToDoItemHandler> handlers = new Dictionary<ToDoItem, ToDoItemHandler>();

		private ToDoItemHandlerFactory handlerFactory;

		public bool IsActive
		{
			get
			{
				return isActive;
			}
			set
			{
				if (isActive != value)
				{
					isActive = value;
					this.OnIsActiveChanged?.Invoke(this);
				}
			}
		}

		public IReadOnlyCollection<ToDoItem> Items => availableItems;

		public IReadOnlyCollection<ToDoItem> CompletedItems => completedItems;

		public event Action<ToDoListService, ToDoItem> OnAdded;

		public event Action<ToDoListService, ToDoItem> OnRemoved;

		public event Action<ToDoListService> OnIsActiveChanged;

		public event Action<ToDoListService, ToDoItem> OnCompleted;

		[Inject]
		private void Construct(ToDoItemHandlerFactory handlerFactory)
		{
			this.handlerFactory = handlerFactory;
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
			availableItems.Clear();
			completedItems.Clear();
			foreach (KeyValuePair<ToDoItem, ToDoItemHandler> handler in handlers)
			{
				handler.Value.Dispose();
			}
			handlers.Clear();
			handlerFactory = null;
		}

		public void AddItem(ToDoItem item)
		{
			if (item == null)
			{
				Debug.LogError("ToDoItem is null");
			}
			else if (!availableItems.Contains(item))
			{
				availableItems.Add(item);
				ToDoItemHandler toDoItemHandler = handlerFactory.Create(item);
				handlers[item] = toDoItemHandler;
				toDoItemHandler.Initialize(item, this);
				this.OnAdded?.Invoke(this, item);
				toDoItemHandler.ForceCheckCompletionConditions();
			}
		}

		public void RemoveItem(ToDoItem item)
		{
			if (item == null)
			{
				Debug.LogError("ToDoItem is null");
			}
			else if (availableItems.Remove(item))
			{
				completedItems.Remove(item);
				if (handlers.Remove(item, out var value))
				{
					value.Dispose();
				}
				this.OnRemoved?.Invoke(this, item);
			}
		}

		public void CompleteItem(ToDoItem item)
		{
			if (item == null)
			{
				Debug.LogError("ToDoItem is null");
			}
			else if (availableItems.Contains(item) && completedItems.Add(item))
			{
				if (handlers.Remove(item, out var value))
				{
					value.Dispose();
				}
				this.OnCompleted?.Invoke(this, item);
			}
		}

		public bool IsCompleted(ToDoItem item)
		{
			if (item == null)
			{
				Debug.LogError("ToDoItem is null");
				return false;
			}
			return completedItems.Contains(item);
		}

		public bool IsAllCompleted()
		{
			return completedItems.Count == availableItems.Count;
		}

		public void RestoreState(object state)
		{
			try
			{
				ToDoListServiceSaveData toDoListServiceSaveData = DataMigrationWizard.Migrate<ToDoListServiceSaveData>(state, base.gameObject);
				availableItems.Clear();
				ToDoItem[] array = toDoListServiceSaveData.AvailableItems;
				foreach (ToDoItem toDoItem in array)
				{
					bool flag = false;
					ToDoItem[] array2 = toDoListServiceSaveData.CompletedItems;
					for (int j = 0; j < array2.Length; j++)
					{
						if (array2[j] == toDoItem)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						availableItems.Add(toDoItem);
					}
					else
					{
						AddItem(toDoItem);
					}
				}
				completedItems.Clear();
				array = toDoListServiceSaveData.CompletedItems;
				foreach (ToDoItem item in array)
				{
					completedItems.Add(item);
				}
				IsActive = toDoListServiceSaveData.IsActive;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public object CaptureState()
		{
			try
			{
				return new ToDoListServiceSaveData
				{
					IsActive = isActive,
					AvailableItems = availableItems.ToArray(),
					CompletedItems = completedItems.ToArray()
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}
	}
}
