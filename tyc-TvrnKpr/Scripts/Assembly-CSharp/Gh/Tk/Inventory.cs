using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace Gh.Tk
{
	public class Inventory : ItemProvider, IEnumerable<GameItem>, IEnumerable
	{
		[CompilerGenerated]
		private sealed class _003CGetAllItemsOfTemplate_003Ed__90 : IEnumerable<GameItem>, IEnumerable, IEnumerator<GameItem>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private GameItem _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private string templateId;

			public string _003C_003E3__templateId;

			private List<GameItem>.Enumerator _003C_003E7__wrap1;

			GameItem IEnumerator<GameItem>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CGetAllItemsOfTemplate_003Ed__90(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<GameItem> IEnumerable<GameItem>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetItemsForItemType_003Ed__89 : IEnumerable<GameItem>, IEnumerable, IEnumerator<GameItem>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private GameItem _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private string itemType;

			public string _003C_003E3__itemType;

			private IEnumerator<GameItemTemplate> _003C_003E7__wrap1;

			private List<GameItem>.Enumerator _003C_003E7__wrap2;

			GameItem IEnumerator<GameItem>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CGetItemsForItemType_003Ed__89(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<GameItem> IEnumerable<GameItem>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetUnionEnumerator_003Ed__49 : IEnumerator<GameItem>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private GameItem _003C_003E2__current;

			public Inventory _003C_003E4__this;

			private List<GameItem>.Enumerator _003Cenumerator_003E5__2;

			private IEnumerator<GameItem> _003CsubEnumerator_003E5__3;

			GameItem IEnumerator<GameItem>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CGetUnionEnumerator_003Ed__49(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public static HashSet<Inventory> AllInventories;

		[Header("Inventory Settings")]
		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool enableOutsideAccess;

		public int maxNoOfItems;

		public bool autoDestroyWhenEmpty;

		public bool ignoreWhenCountingStock;

		public GameObject SpawnPoint;

		public bool isMergeAllowed;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private List<GameItem> _inventory;

		public static Func<IPersistable, string, bool> GameItemFilterByTemplateId;

		private Func<IPersistable, string, bool> gameItemFilterByType;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public float SpoilModifier;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private float _nextDirtCheckTimestamp;

		private static Dictionary<string, StockInfo> _stock;

		public static EventHandler<EventArgs<string>> StockableItemAdded;

		public event EventHandler<GameItemEventArgs> ItemAdded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<GameItemEventArgs> ItemRemoved
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler InventoryChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<GameItemTemplateEventArgs> StockChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<GameItemTemplateEventArgs> StockInfoRemoved
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}

		public override bool CanUse(Actor actor)
		{
			return false;
		}

		public override bool CanProvide(GameItemTemplate template, long amount, bool restrictToContainer)
		{
			return false;
		}

		private GameItem GetItemToMerge(GameItem item)
		{
			return null;
		}

		public bool CanMerge(GameItem item)
		{
			return false;
		}

		public int GetAvailableSpace()
		{
			return 0;
		}

		public void ReserveSpotForItem(GameItem item)
		{
		}

		private void TriggerAdded(GameItem item)
		{
		}

		private void TriggerRemoved(GameItem item)
		{
		}

		public void AddItem(GameItem item, bool merge = true, bool silently = false)
		{
		}

		public void ItemAmountChanged(GameItem item, int difference)
		{
		}

		public void UnreserveSpotForItem(GameItem item)
		{
		}

		public PlaceHolderItem GetExistingReservationObject(GameItem item)
		{
			return null;
		}

		private void TriggerChanged()
		{
		}

		public void RemoveItem(GameItem item, bool silently = false)
		{
		}

		public void Clear()
		{
		}

		public bool HasGameItemOfTemplate(GameItemTemplate template, bool includePlaceholderItems = false)
		{
			return false;
		}

		private int GetGameItemAmount(Func<GameItem, bool> filter, bool restrictToContainer, bool includePlaceholderItems, bool excludeItemsInSealedItemStacks, bool includeIgnoredItems)
		{
			return 0;
		}

		public int GetGameItemAmountOfTemplate(GameItemTemplate template, bool restrictToContainer, bool includePlaceholderItems = false, bool excludeItemsInSealedItemStacks = false, bool includeIgnoredItems = false)
		{
			return 0;
		}

		public int GetGameItemAmountOfType(string type, bool restrictToContainer, bool includePlaceholderItems = false, bool excludeItemsInSealedItemStacks = false, bool includeIgnoredItems = false)
		{
			return 0;
		}

		public GameItem PeekGameItemOfTemplateOrDefault(GameItemTemplate template, int? amount = null)
		{
			return null;
		}

		public GameItem PeekGameItemOfTypeOrDefault(string type, int? amount = null)
		{
			return null;
		}

		private GameItem FindBestItemByType(string type, int? amount)
		{
			return null;
		}

		private GameItem FindBestItemByTemplate(GameItemTemplate template, int? amount, GameItem exclude = null)
		{
			return null;
		}

		private GameItem FindBestItem(string key, int? amount, Func<IPersistable, string, bool> filter, GameItem exclude = null)
		{
			return null;
		}

		public GameItem TakeGameItemOfTemplateOrDefault(GameItemTemplate template, int amount, out bool isNewItem, bool removeFromInventory = true, bool restrictToContainer = false)
		{
			isNewItem = default(bool);
			return null;
		}

		public IEnumerator<GameItem> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetUnionEnumerator_003Ed__49))]
		private IEnumerator<GameItem> GetUnionEnumerator()
		{
			return null;
		}

		protected int GetLocationBasedSpoilModifier(GameItem targetItem, StringBuilder details = null)
		{
			return 0;
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		private static int GetGlobalSpoilRateModifierPercentage(StringBuilder details = null)
		{
			return 0;
		}

		public int GetEffectiveSpoilModifierPercentage(GameItem targetIngredient, StringBuilder details = null)
		{
			return 0;
		}

		public float GetEffectiveSpoilModifier(GameItem targetIngredient, StringBuilder details = null)
		{
			return 0f;
		}

		protected override void UpdateInternal()
		{
		}

		private void RemoveInvalidPlaceHolderItems()
		{
		}

		private void SpawnRoomDirt()
		{
		}

		private void SpawnDirtFromSpoiledIngredients()
		{
		}

		private void HandleSpoiling()
		{
		}

		public void ReplaceItem(GameItem item, GameItem newItem, bool silently = false)
		{
		}

		public override float GetRating(GameItemTemplate template, int amount, bool includePlaceholderItems = false)
		{
			return 0f;
		}

		internal static DataStore Save()
		{
			return null;
		}

		internal static void Load(DataStore data)
		{
		}

		internal static void ClearStock()
		{
		}

		public static Dictionary<string, StockInfo> GetStock()
		{
			return null;
		}

		public static void CheckStock(GameItemTemplate template)
		{
		}

		public static StockInfo GetStockInfo(GameItemTemplate template, bool createIfNotPresent)
		{
			return null;
		}

		public static int CalculateAvailableStockCount(string templateId)
		{
			return 0;
		}

		public static StockInfo GetStockInfo(string templateId, bool createIfNotPresent)
		{
			return null;
		}

		public static void RegisterStockableItem(string templateId)
		{
		}

		private static void AddItemToStock(GameItem item)
		{
		}

		private static void RemoveItemFromStock(GameItem item)
		{
		}

		public static void RemoveStockInfoForTemplate(GameItemTemplate template)
		{
		}

		public static void ChangeStockCount(GameItemTemplate template, int difference)
		{
		}

		public static void RecordDemand(string key, int amount)
		{
		}

		public static int GetDemandForItem(string key)
		{
			return 0;
		}

		public static int GetStockAmount(GameItemTemplate template)
		{
			return 0;
		}

		public static int GetStockAmountForItemType(string itemType, Predicate<GameItemTemplate> filter = null)
		{
			return 0;
		}

		[IteratorStateMachine(typeof(_003CGetItemsForItemType_003Ed__89))]
		public static IEnumerable<GameItem> GetItemsForItemType(string itemType)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetAllItemsOfTemplate_003Ed__90))]
		public static IEnumerable<GameItem> GetAllItemsOfTemplate(string templateId)
		{
			return null;
		}

		public static int GetStockAmountForCategory(string category)
		{
			return 0;
		}
	}
}
