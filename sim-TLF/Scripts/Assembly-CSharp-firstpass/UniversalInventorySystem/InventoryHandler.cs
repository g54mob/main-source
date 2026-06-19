using System;
using System.Collections.Generic;
using UnityEngine;

namespace UniversalInventorySystem
{
	[Serializable]
	public class InventoryHandler
	{
		public class AddItemEventArgs : EventArgs
		{
			public Inventory inv;

			public bool addedToNewSlot;

			public bool addedToSlot;

			public Item itemAdded;

			public int amount;

			public int? slotNumber;

			public AddItemEventArgs(Inventory _inv, bool _addedToNewSlot, bool _addedToSlot, Item _itemAdded, int _amount, int? _slotNumber)
			{
				inv = _inv;
				addedToNewSlot = _addedToNewSlot;
				addedToSlot = _addedToSlot;
				itemAdded = _itemAdded;
				amount = _amount;
				slotNumber = _slotNumber;
			}
		}

		public class RemoveItemEventArgs : EventArgs
		{
			public Inventory inv;

			public bool removedByUI;

			public int amount;

			public Item item;

			public int? slot;

			public RemoveItemEventArgs(Inventory _inv, bool _removedByUI, int _amount, Item _item, int? _slot)
			{
				inv = _inv;
				removedByUI = _removedByUI;
				amount = _amount;
				item = _item;
				slot = _slot;
			}
		}

		public class SwapItemsEventArgs : EventArgs
		{
			public Inventory inv;

			public int nativeSlot;

			public int targetSlot;

			public Item nativeItem;

			public Item targetItem;

			public int? amount;

			public SwapItemsEventArgs(Inventory _inv, int _nativeSlot, int _targetSlot, Item _nativeItem, Item _targetItem, int? _amount)
			{
				inv = _inv;
				nativeItem = _nativeItem;
				targetItem = _targetItem;
				nativeSlot = _nativeSlot;
				targetSlot = _targetSlot;
				amount = _amount;
			}
		}

		public class SwapItemsTrhuInvEventArgs : EventArgs
		{
			public Inventory nativeInv;

			public Inventory targetInv;

			public int? nativeSlot;

			public int? targetSlot;

			public Item nativeItem;

			public Item targetItem;

			public int? amount;

			public SwapItemsTrhuInvEventArgs(Inventory _nativeInv, Inventory _targetInv, int? _nativeSlot, int? _targetSlot, Item _nativeItem, Item _targetItem, int? _amount)
			{
				nativeInv = _nativeInv;
				targetInv = _targetInv;
				nativeItem = _nativeItem;
				targetItem = _targetItem;
				nativeSlot = _nativeSlot;
				targetSlot = _targetSlot;
				amount = _amount;
			}
		}

		public class UseItemEventArgs : EventArgs
		{
			public Inventory inv;

			public Item item;

			public int slot;

			public UseItemEventArgs(Inventory _inv, Item _item, int _slot)
			{
				inv = _inv;
				item = _item;
				slot = _slot;
			}
		}

		public class DropItemEventArgs : EventArgs
		{
			public Inventory inv;

			public bool takenFromSpecificSlot;

			public int slot;

			public Item item;

			public int amount;

			public bool droppedByUI;

			public Vector3 positionDropped;

			public bool useGeralDropBehaviour;

			public DropItemEventArgs(Inventory _inv, bool _takenFromSpecificSlot, int _slot, Item _item, int _amount, bool _droppedByUI, Vector3 _positionDropped, bool _useGeralDropBehaviour)
			{
				inv = _inv;
				takenFromSpecificSlot = _takenFromSpecificSlot;
				slot = _slot;
				item = _item;
				amount = _amount;
				droppedByUI = _droppedByUI;
				positionDropped = _positionDropped;
				useGeralDropBehaviour = _useGeralDropBehaviour;
			}
		}

		public class InitializeInventoryEventArgs : EventArgs
		{
			public Inventory inventory;

			public InitializeInventoryEventArgs(Inventory _inv)
			{
				inventory = _inv;
			}
		}

		public class OnToggleInventoryEventArgs : EventArgs
		{
			public Inventory inv;

			public bool isActive;

			public OnToggleInventoryEventArgs(Inventory _inv, bool _isActive)
			{
				inv = _inv;
				isActive = _isActive;
			}
		}

		public class OnDragItemEventArgs : EventArgs
		{
			public Inventory inv;

			public Vector3 pos;

			public GameObject slot;

			public OnDragItemEventArgs(Inventory _inv, Vector3 _pos, GameObject _slot)
			{
				inv = _inv;
				pos = _pos;
				slot = _slot;
			}
		}

		public class OnDropItemUIEventArgs : EventArgs
		{
			public Inventory inv;

			public int amount;

			public Vector3 pos;

			public Item item;

			public OnDropItemUIEventArgs(Inventory _inv, int _amount, Vector3 _pos, Item _item)
			{
				inv = _inv;
				amount = _amount;
				pos = _pos;
				item = _item;
			}
		}

		public bool autoSaveOnChange;

		[Header("Items Handler")]
		public List<ItemGroup> itemAssets;

		[Header("Recipe Handler")]
		public List<RecipeGroup> recipeAssets = new List<RecipeGroup>();

		public EventHandler<OnToggleInventoryEventArgs> OnToggleInventory;

		public EventHandler<OnDragItemEventArgs> OnDragItem;

		public EventHandler<OnDropItemUIEventArgs> OnDropItemUI;

		public event EventHandler<AddItemEventArgs> OnAddItem;

		public event EventHandler<RemoveItemEventArgs> OnRemoveItem;

		public event EventHandler<SwapItemsEventArgs> OnSwapItem;

		public event EventHandler<SwapItemsTrhuInvEventArgs> OnSwapTrhuInventory;

		public event EventHandler<UseItemEventArgs> OnUseItem;

		public event EventHandler<DropItemEventArgs> OnDropItem;

		public event EventHandler<AddItemEventArgs> OnPickUpItem;

		public event EventHandler<InitializeInventoryEventArgs> OnInitializeInventory;

		public event EventHandler<EventArgs> OnChange;

		public ItemGroup GetItemAssetAtIndex(int index)
		{
			return itemAssets[index];
		}

		public ItemGroup GetItemAssetWithName(string _strId)
		{
			foreach (ItemGroup itemAsset in itemAssets)
			{
				if (itemAsset.strId == _strId)
				{
					return itemAsset;
				}
			}
			return null;
		}

		public ItemGroup GetItemAssetWithID(int id)
		{
			foreach (ItemGroup itemAsset in itemAssets)
			{
				if (itemAsset.id == id)
				{
					return itemAsset;
				}
			}
			return null;
		}

		public List<ItemGroup> OrderItemsAssetById()
		{
			return InsertionSort(itemAssets);
		}

		private static List<ItemGroup> InsertionSort(List<ItemGroup> inputArray)
		{
			for (int i = 0; i < inputArray.Count - 1; i++)
			{
				for (int num = i + 1; num > 0; num--)
				{
					if (inputArray[num - 1].id > inputArray[num].id)
					{
						int id = inputArray[num - 1].id;
						inputArray[num - 1].id = inputArray[num].id;
						inputArray[num].id = id;
					}
				}
			}
			return inputArray;
		}

		public Item GetItem(int iAssetIndex, int itemIndex)
		{
			return GetItemAssetWithID(iAssetIndex).GetItemWithID(itemIndex);
		}

		public Item GetItemWithName(int id, string itemName)
		{
			return GetItemAssetWithID(id).GetItemWithName(itemName);
		}

		public Item GetItemWithName(string itemAssetStrId, string itemName)
		{
			return GetItemAssetWithName(itemAssetStrId).GetItemWithName(itemName);
		}

		public RecipeGroup GetRecipeAssetAtIndex(int index)
		{
			return recipeAssets[index];
		}

		public RecipeGroup GetRecipeAssetWithName(string _strId)
		{
			foreach (RecipeGroup recipeAsset in recipeAssets)
			{
				if (recipeAsset.strId == _strId)
				{
					return recipeAsset;
				}
			}
			return null;
		}

		public RecipeGroup GetRecipeAssetWithID(int id)
		{
			foreach (RecipeGroup recipeAsset in recipeAssets)
			{
				if (recipeAsset.id == id)
				{
					return recipeAsset;
				}
			}
			return null;
		}

		public List<RecipeGroup> OrderRecipeAssetById()
		{
			return InsertionSort(recipeAssets);
		}

		private static List<RecipeGroup> InsertionSort(List<RecipeGroup> inputArray)
		{
			for (int i = 0; i < inputArray.Count - 1; i++)
			{
				for (int num = i + 1; num > 0; num--)
				{
					if (inputArray[num - 1].id > inputArray[num].id)
					{
						int id = inputArray[num - 1].id;
						inputArray[num - 1].id = inputArray[num].id;
						inputArray[num].id = id;
					}
				}
			}
			return inputArray;
		}

		public Recipe GetRecipeWithName(int id, string recipeName)
		{
			return GetRecipeAssetWithID(id).GetRecipeWithName(recipeName);
		}

		public Recipe GetRecipeWithName(string recipeAssetStrId, string recipeName)
		{
			return GetRecipeAssetWithName(recipeAssetStrId).GetRecipeWithName(recipeName);
		}

		public Recipe GetRecipeAtIndex(int recipeAssetIndex, int recipeIndex)
		{
			return recipeAssets[recipeAssetIndex].recipesList[recipeIndex];
		}

		public PatternRecipe GetPatternRecipeWithName(int id, string recipeName)
		{
			return GetRecipeAssetWithID(id).GetRecipePatternWithKey(recipeName);
		}

		private PatternRecipe GetPatternRecipeWithName(string recipeAssetStrId, string recipeName)
		{
			return GetRecipeAssetWithName(recipeAssetStrId).GetRecipePatternWithKey(recipeName);
		}

		public PatternRecipe GetPatternRecipeAtIndex(int recipeAssetIndex, int recipeIndex)
		{
			return recipeAssets[recipeAssetIndex].receipePatternsList[recipeIndex];
		}

		public PatternRecipe GetPatternRecipeWithID(int recipeAssetID, int patternRecipeID)
		{
			RecipeGroup recipeAssetWithID = GetRecipeAssetWithID(recipeAssetID);
			if (recipeAssetWithID != null)
			{
				foreach (PatternRecipe receipePatterns in recipeAssetWithID.receipePatternsList)
				{
					if (receipePatterns.id == patternRecipeID)
					{
						return receipePatterns;
					}
				}
			}
			return null;
		}

		public void Broadcast(BroadcastEventType e, AddItemEventArgs aea = null, RemoveItemEventArgs rea = null, SwapItemsEventArgs sea = null, SwapItemsTrhuInvEventArgs siea = null, UseItemEventArgs uea = null, DropItemEventArgs dea = null, InitializeInventoryEventArgs iea = null)
		{
			switch (e)
			{
			case BroadcastEventType.AddItem:
				this.OnAddItem?.Invoke(this, aea);
				this.OnChange?.Invoke(this, aea);
				break;
			case BroadcastEventType.RemoveItem:
				this.OnRemoveItem?.Invoke(this, rea);
				this.OnChange?.Invoke(this, rea);
				break;
			case BroadcastEventType.SwapItem:
				this.OnSwapItem?.Invoke(this, sea);
				this.OnChange?.Invoke(this, sea);
				break;
			case BroadcastEventType.SwapTrhuInventory:
				this.OnSwapTrhuInventory?.Invoke(this, siea);
				this.OnChange?.Invoke(this, siea);
				break;
			case BroadcastEventType.UseItem:
				this.OnUseItem?.Invoke(this, uea);
				this.OnChange?.Invoke(this, uea);
				break;
			case BroadcastEventType.DropItem:
				this.OnDropItem?.Invoke(this, dea);
				this.OnChange?.Invoke(this, dea);
				break;
			case BroadcastEventType.PickUpItem:
				this.OnPickUpItem?.Invoke(this, aea);
				this.OnChange?.Invoke(this, aea);
				break;
			case BroadcastEventType.InitializeInventory:
				this.OnInitializeInventory?.Invoke(this, iea);
				this.OnChange?.Invoke(this, iea);
				break;
			}
			if (autoSaveOnChange)
			{
				InventoryController.SaveInventoryData();
			}
		}

		public void BroadcastUIEvent(BroadcastEventType e, OnToggleInventoryEventArgs oti = null, OnDragItemEventArgs odi = null, OnDropItemUIEventArgs drop = null)
		{
			switch (e)
			{
			case BroadcastEventType.UIToggled:
				OnToggleInventory?.Invoke(this, oti);
				break;
			case BroadcastEventType.ItemDragged:
				OnDragItem?.Invoke(this, odi);
				break;
			case BroadcastEventType.DropItem:
				OnDropItemUI?.Invoke(this, drop);
				break;
			}
		}
	}
}
