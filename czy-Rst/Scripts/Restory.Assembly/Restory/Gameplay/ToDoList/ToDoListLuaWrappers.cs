using System;
using PixelCrushers.DialogueSystem;
using Restory.AssetManagement;
using Restory.Data.ToDoList;
using Zenject;

namespace Restory.Gameplay.ToDoList
{
	public sealed class ToDoListLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string AddToDoItem = "ToDoList_AddItem";

			public static readonly string CompleteToDoItem = "ToDoList_CompleteItem";
		}

		private ToDoListService toDoListService;

		private GameEntityDataBaseProvider gameEntityDataBase;

		public ToDoListLuaWrappers(ToDoListService toDoListService, GameEntityDataBaseProvider gameEntityDataBase)
		{
			this.gameEntityDataBase = gameEntityDataBase;
			this.toDoListService = toDoListService;
		}

		public void Initialize()
		{
			Subscribe();
		}

		public void Dispose()
		{
			Unsubscribe();
		}

		private void Subscribe()
		{
			Lua.RegisterFunction(LuaNames.AddToDoItem, this, SymbolExtensions.GetMethodInfo(() => AddItemToToDoList(string.Empty)));
			Lua.RegisterFunction(LuaNames.CompleteToDoItem, this, SymbolExtensions.GetMethodInfo(() => CompleteItemInToDoList(string.Empty)));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.AddToDoItem);
			Lua.UnregisterFunction(LuaNames.CompleteToDoItem);
		}

		private void AddItemToToDoList(string itemID)
		{
			if (gameEntityDataBase.Asset.TryToGetEntityInfo<ToDoItem>(itemID, out var entityInfo))
			{
				toDoListService.AddItem(entityInfo);
			}
		}

		private void CompleteItemInToDoList(string itemID)
		{
			if (gameEntityDataBase.Asset.TryToGetEntityInfo<ToDoItem>(itemID, out var entityInfo))
			{
				toDoListService.CompleteItem(entityInfo);
			}
		}
	}
}
