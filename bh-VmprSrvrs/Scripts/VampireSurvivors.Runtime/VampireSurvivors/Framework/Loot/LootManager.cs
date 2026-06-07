using System;
using System.Collections.Generic;
using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.Framework.Loot
{
	public class LootManager : IInitializable, IDisposable
	{
		[Inject]
		private DataManager _dataManager;

		[Inject]
		private GameSessionData _gameSessionData;

		[Inject]
		private Stage _stage;

		private float _accumulatedWeight;

		private List<WeightedItem> _weightedStore;

		private List<ItemType> _forcedLootTable;

		private List<ItemType> _addedLoot;

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void Init()
		{
		}

		public void SetPlainLootTable()
		{
		}

		public void AddToLootTable(ItemType itemToAdd)
		{
		}

		public void AddToLootTable(List<ItemType> itemsToAdd)
		{
		}

		public void RecalculateLoot()
		{
		}

		public void CheckForAddedLoot()
		{
		}

		public ItemType GetRandomWeightedItem(Unity.Mathematics.Random? rng = null)
		{
			return default(ItemType);
		}

		public ItemType GetItemFromExportedTable(WeightedStore store)
		{
			return default(ItemType);
		}

		public WeightedStore ExportCustomLootTable(ItemType[] items, bool ignorePlayerLevel = false)
		{
			return null;
		}

		private void MakeDefaultLootTable()
		{
		}

		public ItemType GetSurvarotDraft()
		{
			return default(ItemType);
		}

		public bool DropSurvarotsSuccessful()
		{
			return false;
		}

		private void MakeCustomLootTable(List<ItemType> items)
		{
		}

		private float ModifyItemWeight(ItemType itemType)
		{
			return 0f;
		}
	}
}
