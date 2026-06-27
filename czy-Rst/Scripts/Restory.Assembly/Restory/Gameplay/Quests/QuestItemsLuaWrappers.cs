using System;
using PixelCrushers.DialogueSystem;
using Restory.AssetManagement;
using Restory.Data.Elements;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Quests
{
	public class QuestItemsLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string DestroyPlacedQuestItem = "QuestItems_DestroyPlacedQuestItem";
		}

		private readonly QuestItemService questItemService;

		private readonly GameEntityDataBaseProvider gameEntityDataBaseProvider;

		public QuestItemsLuaWrappers(QuestItemService questItemService, GameEntityDataBaseProvider gameEntityDataBaseProvider)
		{
			this.gameEntityDataBaseProvider = gameEntityDataBaseProvider;
			this.questItemService = questItemService;
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
			Lua.RegisterFunction(LuaNames.DestroyPlacedQuestItem, this, SymbolExtensions.GetMethodInfo(() => DestroyPlacedQuestItem(string.Empty)));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.DestroyPlacedQuestItem);
		}

		private void DestroyPlacedQuestItem(string questItemID)
		{
			if (!gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<QuestItemInfo>(questItemID, out var entityInfo))
			{
				Debug.LogWarning("[QuestItemsLuaWrappers] tried to remove a quest item, but was unable to find a quest item with ID '" + questItemID + "' in the database!");
			}
			else
			{
				questItemService.DestroyPlacedQuestItem(entityInfo);
			}
		}
	}
}
