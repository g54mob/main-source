using System;
using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.StockInventory
{
	public abstract class StockInventory<TStack, TData> : CTSBehaviour where TStack : struct, IStackable<TStack, TData> where TData : class
	{
		public struct StockChangedData
		{
			public StringKey<StockType> StockType;

			public StockCapacity StockCapacity;

			public EOperation Operation;
		}

		public struct StockItemChangedData
		{
			public StockChangedData StockChangedData;

			public TData ItemChanged;

			public int ItemCount;
		}

		public struct ItemStackEnumerator<TComparator> : IEnumerator<TStack>, IEnumerator, IDisposable where TComparator : IStackComparator<TStack, TData>
		{
			private Dictionary<StringKey<StockType>, Dictionary<TData, List<TStack>>>.Enumerator _inventoryEnumerator;

			private TData _itemData;

			private List<TStack> _stackList;

			private TComparator _comparator;

			private bool _nextInventory;

			private int _listIndex;

			public TStack Current { get; private set; }

			object IEnumerator.Current => Current;

			public ItemStackEnumerator(StockInventory<TStack, TData> inventory, TData itemData, TComparator comparator)
			{
				_inventoryEnumerator = inventory._inventory.GetEnumerator();
				_itemData = itemData;
				_stackList = null;
				_comparator = comparator;
				_nextInventory = true;
				_listIndex = 0;
				Current = default(TStack);
			}

			public bool MoveNext()
			{
				if (_nextInventory)
				{
					if (!_inventoryEnumerator.MoveNext())
					{
						return false;
					}
					if (!_inventoryEnumerator.Current.Value.TryGetValue(_itemData, out _stackList))
					{
						_nextInventory = true;
						if (!MoveNext())
						{
							return false;
						}
					}
					_nextInventory = false;
				}
				while (_listIndex < _stackList.Count)
				{
					Current = _stackList[_listIndex];
					if (_comparator != null)
					{
						ref TComparator comparator = ref _comparator;
						TStack current = Current;
						if (comparator.IsValidStack(current))
						{
							_listIndex++;
							return true;
						}
					}
					_listIndex++;
				}
				_nextInventory = true;
				return MoveNext();
			}

			public void Reset()
			{
			}

			public void Dispose()
			{
			}
		}

		public struct StackEnumerator<TComparator> : IEnumerator<TStack>, IEnumerator, IDisposable where TComparator : IStackComparator<TStack, TData>
		{
			private Dictionary<StringKey<StockType>, Dictionary<TData, List<TStack>>>.Enumerator _inventoryEnumerator;

			private Dictionary<TData, List<TStack>>.Enumerator _stockEnumerator;

			private List<TStack> _stackList;

			private TComparator _comparator;

			private bool _nextInventory;

			private bool _nextStock;

			private int _listIndex;

			public TStack Current { get; private set; }

			object IEnumerator.Current => Current;

			public StackEnumerator(StockInventory<TStack, TData> inventory, TComparator comparator)
			{
				_comparator = comparator;
				_inventoryEnumerator = inventory._inventory.GetEnumerator();
				_stockEnumerator = default(Dictionary<TData, List<TStack>>.Enumerator);
				_stackList = null;
				_nextInventory = true;
				_nextStock = true;
				_listIndex = 0;
				Current = default(TStack);
			}

			public StackEnumerator<TComparator> GetEnumerator()
			{
				return this;
			}

			public bool MoveNext()
			{
				if (_nextInventory)
				{
					if (!_inventoryEnumerator.MoveNext())
					{
						return false;
					}
					_nextInventory = false;
					_stockEnumerator = _inventoryEnumerator.Current.Value.GetEnumerator();
					_nextStock = true;
				}
				if (_nextStock)
				{
					if (!_stockEnumerator.MoveNext())
					{
						_nextInventory = true;
						if (!MoveNext())
						{
							return false;
						}
					}
					_nextStock = false;
					_stackList = _stockEnumerator.Current.Value;
					_listIndex = 0;
				}
				while (_listIndex < _stackList.Count)
				{
					Current = _stackList[_listIndex];
					if (_comparator != null)
					{
						ref TComparator comparator = ref _comparator;
						TStack current = Current;
						if (comparator.IsValidStack(current))
						{
							_listIndex++;
							return true;
						}
					}
					_listIndex++;
				}
				_nextStock = true;
				return MoveNext();
			}

			public void Reset()
			{
			}

			public void Dispose()
			{
			}
		}

		public struct StackEnumerator : IEnumerator<TStack>, IEnumerator, IDisposable
		{
			private Dictionary<StringKey<StockType>, Dictionary<TData, List<TStack>>>.Enumerator _inventoryEnumerator;

			private Dictionary<TData, List<TStack>>.Enumerator _stockEnumerator;

			private List<TStack> _stackList;

			private bool _nextInventory;

			private bool _nextStock;

			private int _listIndex;

			public TStack Current { get; private set; }

			object IEnumerator.Current => Current;

			public StackEnumerator(StockInventory<TStack, TData> inventory)
			{
				_inventoryEnumerator = inventory._inventory.GetEnumerator();
				_stockEnumerator = default(Dictionary<TData, List<TStack>>.Enumerator);
				_stackList = null;
				_nextInventory = true;
				_nextStock = true;
				_listIndex = 0;
				Current = default(TStack);
			}

			public StackEnumerator GetEnumerator()
			{
				return this;
			}

			public bool MoveNext()
			{
				if (_nextInventory)
				{
					if (!_inventoryEnumerator.MoveNext())
					{
						return false;
					}
					_nextInventory = false;
					_stockEnumerator = _inventoryEnumerator.Current.Value.GetEnumerator();
					_nextStock = true;
				}
				if (_nextStock)
				{
					if (!_stockEnumerator.MoveNext())
					{
						_nextInventory = true;
						if (!MoveNext())
						{
							return false;
						}
					}
					_nextStock = false;
					_stackList = _stockEnumerator.Current.Value;
					_listIndex = 0;
				}
				if (_listIndex < _stackList.Count)
				{
					Current = _stackList[_listIndex];
					_listIndex++;
					return true;
				}
				_nextStock = true;
				return MoveNext();
			}

			public void Reset()
			{
			}

			public void Dispose()
			{
			}
		}

		[SerializeField]
		protected List<StringKey<StockType>> _availableStockTypes = new List<StringKey<StockType>>();

		protected Dictionary<StringKey<StockType>, Dictionary<TData, List<TStack>>> _inventory = new Dictionary<StringKey<StockType>, Dictionary<TData, List<TStack>>>();

		protected Dictionary<StringKey<StockType>, int?> _storageCapacity = new Dictionary<StringKey<StockType>, int?>();

		protected Dictionary<TData, Action<StockItemChangedData>> _stockChangedCallbacks = new Dictionary<TData, Action<StockItemChangedData>>();

		public ReadOnlyKeyCollection<StringKey<StockType>, Dictionary<TData, List<TStack>>> InventoryTypes => _inventory;

		public event Action<StockChangedData> StockChanged;

		public ReadOnlyKeyCollection<TData, List<TStack>> GetItemTypes(StringKey<StockType> stockType)
		{
			return _inventory[stockType];
		}

		public ReadOnlyList<TStack> GetStackList(StringKey<StockType> stockType, TData data)
		{
			return _inventory[stockType][data];
		}

		public void RegisterToStockChange(TData dataToTrack, Action<StockItemChangedData> changeAction)
		{
			if (!_stockChangedCallbacks.ContainsKey(dataToTrack))
			{
				_stockChangedCallbacks[dataToTrack] = changeAction;
				return;
			}
			Dictionary<TData, Action<StockItemChangedData>> stockChangedCallbacks = _stockChangedCallbacks;
			stockChangedCallbacks[dataToTrack] = (Action<StockItemChangedData>)Delegate.Combine(stockChangedCallbacks[dataToTrack], changeAction);
		}

		public void UnregisterToStockChange(TData dataToTrack, Action<StockItemChangedData> changeAction)
		{
			if (_stockChangedCallbacks.ContainsKey(dataToTrack))
			{
				Dictionary<TData, Action<StockItemChangedData>> stockChangedCallbacks = _stockChangedCallbacks;
				stockChangedCallbacks[dataToTrack] = (Action<StockItemChangedData>)Delegate.Remove(stockChangedCallbacks[dataToTrack], changeAction);
			}
		}

		public IEnumerable<TStack> Enumerate(IStackComparator<TStack, TData> stackComparator = null)
		{
			foreach (var (_, dictionary2) in _inventory)
			{
				foreach (var (_, list2) in dictionary2)
				{
					foreach (TStack item in list2)
					{
						if (stackComparator == null || stackComparator.IsValidStack(item))
						{
							yield return item;
						}
					}
				}
			}
		}

		public IEnumerable<TStack> Enumerate(TData itemData, IStackComparator<TStack, TData> stackComparator = null)
		{
			foreach (KeyValuePair<StringKey<StockType>, Dictionary<TData, List<TStack>>> item in _inventory)
			{
				item.Deconstruct(out var _, out var value);
				if (!value.TryGetValue(itemData, out var value2))
				{
					continue;
				}
				foreach (TStack item2 in value2)
				{
					if (stackComparator == null || stackComparator.IsValidStack(item2))
					{
						yield return item2;
					}
				}
			}
		}

		public IEnumerable<TStack> Enumerate(StringKey<StockType> stockType, IStackComparator<TStack, TData> stackComparator = null)
		{
			if (!_inventory.TryGetValue(stockType, out var value))
			{
				yield break;
			}
			foreach (var (_, list2) in value)
			{
				foreach (TStack item in list2)
				{
					if (stackComparator == null || stackComparator.IsValidStack(item))
					{
						yield return item;
					}
				}
			}
		}

		public IEnumerable<TStack> Enumerate(StringKey<StockType> stockType, TData itemData, IStackComparator<TStack, TData> stackComparator = null)
		{
			if (!_inventory.TryGetValue(stockType, out var value) || !value.TryGetValue(itemData, out var value2))
			{
				yield break;
			}
			foreach (TStack item in value2)
			{
				if (stackComparator == null || stackComparator.IsValidStack(item))
				{
					yield return item;
				}
			}
		}

		public StockCapacity GetStockTypeCapacity(StringKey<StockType> stockType)
		{
			StockCapacity result = default(StockCapacity);
			if (!_availableStockTypes.Contains(stockType))
			{
				result.MaxCapacity = 0;
				result.CurrentCapacity = 0;
			}
			if (_storageCapacity.TryGetValue(stockType, out var value))
			{
				result.MaxCapacity = value;
			}
			else
			{
				result.MaxCapacity = null;
			}
			result.CurrentCapacity = GetStockedCount(stockType);
			return result;
		}

		public void SetStockTypeCapacity(StringKey<StockType> stockType, int? maxCapacity)
		{
			if (!_storageCapacity.TryGetValue(stockType, out var value) || value != maxCapacity)
			{
				_storageCapacity[stockType] = (maxCapacity.HasValue ? new int?(Math.Max(0, maxCapacity.Value)) : ((int?)null));
				SendStockChangedEvent(null, stockType, EOperation.ChangedCapacity);
			}
		}

		public int GetStockedCount(StringKey<StockType> stockType, IStackComparator<TStack, TData> stackComparator = null)
		{
			if (!_inventory.TryGetValue(stockType, out var value))
			{
				return 0;
			}
			int num = 0;
			foreach (KeyValuePair<TData, List<TStack>> item in value)
			{
				item.Deconstruct(out var _, out var value2);
				List<TStack> stackList = value2;
				num += GetStackListCount(stackList, stackComparator);
			}
			return num;
		}

		public int GetStockedCount(TData itemData, IStackComparator<TStack, TData> stackComparator = null)
		{
			int num = 0;
			foreach (KeyValuePair<StringKey<StockType>, Dictionary<TData, List<TStack>>> item in _inventory)
			{
				item.Deconstruct(out var _, out var value);
				if (value.TryGetValue(itemData, out var value2))
				{
					num += GetStackListCount(value2, stackComparator);
				}
			}
			return num;
		}

		public int GetStockedCount(StringKey<StockType> stockType, TData itemData, IStackComparator<TStack, TData> stackComparator = null)
		{
			if (!_inventory.TryGetValue(stockType, out var value))
			{
				return 0;
			}
			if (!value.TryGetValue(itemData, out var value2))
			{
				return 0;
			}
			return GetStackListCount(value2, stackComparator);
		}

		private int GetStackListCount(List<TStack> stackList, IStackComparator<TStack, TData> stackComparator)
		{
			int num = 0;
			foreach (TStack stack in stackList)
			{
				if (stackComparator == null || stackComparator.IsValidStack(stack))
				{
					num += stack.StackCount;
				}
			}
			return num;
		}

		public bool TryPeekFirst(StringKey<StockType> stockType, out TStack peekedStack, IStackComparator<TStack, TData> stackComparator = null)
		{
			if (!_inventory.TryGetValue(stockType, out var value))
			{
				peekedStack = default(TStack);
				return false;
			}
			foreach (var (_, stackList) in value)
			{
				if (TryPeekFirstInStackList(stackList, out peekedStack, stackComparator))
				{
					return true;
				}
			}
			peekedStack = default(TStack);
			return false;
		}

		public bool TryPeekFirst(TData itemData, out TStack peekedStack, IStackComparator<TStack, TData> stackComparator = null)
		{
			if (itemData == null)
			{
				peekedStack = default(TStack);
				return false;
			}
			foreach (KeyValuePair<StringKey<StockType>, Dictionary<TData, List<TStack>>> item in _inventory)
			{
				item.Deconstruct(out var _, out var value);
				if (value.TryGetValue(itemData, out var value2) && TryPeekFirstInStackList(value2, out peekedStack, stackComparator))
				{
					return true;
				}
			}
			peekedStack = new TStack();
			peekedStack.SetupEmptyFrom(itemData);
			return false;
		}

		public bool TryPeekFirst(StringKey<StockType> stockType, TData itemData, out TStack peekedStack, IStackComparator<TStack, TData> stackComparator = null)
		{
			if (itemData == null)
			{
				peekedStack = default(TStack);
				return false;
			}
			if (!_inventory.TryGetValue(stockType, out var value) || !value.TryGetValue(itemData, out var value2))
			{
				peekedStack = new TStack();
				peekedStack.SetupEmptyFrom(itemData);
				return false;
			}
			if (TryPeekFirstInStackList(value2, out peekedStack, stackComparator))
			{
				return true;
			}
			peekedStack = new TStack();
			peekedStack.SetupEmptyFrom(itemData);
			return false;
		}

		private bool TryPeekFirstInStackList(List<TStack> stackList, out TStack peekedStack, IStackComparator<TStack, TData> stackComparator)
		{
			foreach (TStack stack in stackList)
			{
				if (stackComparator == null || stackComparator.IsValidStack(stack))
				{
					peekedStack = stack;
					return true;
				}
			}
			peekedStack = default(TStack);
			return false;
		}

		public bool RetrieveStock(TData itemData, int count, List<TStack> retrievedStacks, bool canGetLessThanCount = false, IStackComparator<TStack, TData> stackComparator = null)
		{
			retrievedStacks.Clear();
			if (count <= 0)
			{
				return true;
			}
			if (!canGetLessThanCount && GetStockedCount(itemData) < count)
			{
				return false;
			}
			foreach (var (stockType, dictionary2) in _inventory)
			{
				if (dictionary2.TryGetValue(itemData, out var value))
				{
					int num = count;
					RetrieveStockFromStackList(value, retrievedStacks, ref count, stackComparator);
					if (num != count)
					{
						SendStockChangedEvent(itemData, stockType, EOperation.Removed);
					}
				}
			}
			return true;
		}

		public void RetrieveStock(StringKey<StockType> stockType, TData itemData, int count, List<TStack> retrievedStacks, bool canGetLessThanCount = false, IStackComparator<TStack, TData> stackComparator = null)
		{
			retrievedStacks.Clear();
			int num = count;
			if (count > 0 && _inventory.TryGetValue(stockType, out var value) && (canGetLessThanCount || GetStockedCount(stockType, itemData) >= count) && value.TryGetValue(itemData, out var value2))
			{
				RetrieveStockFromStackList(value2, retrievedStacks, ref count, stackComparator);
				if (num != count)
				{
					SendStockChangedEvent(itemData, stockType, EOperation.Removed);
				}
			}
		}

		private void SendStockChangedEvent(TData itemData, StringKey<StockType> stockType, EOperation operation)
		{
			StockChangedData stockChangedData = new StockChangedData
			{
				StockType = stockType,
				Operation = operation,
				StockCapacity = GetStockTypeCapacity(stockType)
			};
			this.StockChanged?.Invoke(stockChangedData);
			if (itemData != null && _stockChangedCallbacks.TryGetValue(itemData, out var value))
			{
				StockItemChangedData obj = new StockItemChangedData
				{
					StockChangedData = stockChangedData,
					ItemChanged = itemData,
					ItemCount = GetStockedCount(stockType, itemData)
				};
				value?.Invoke(obj);
			}
		}

		private void RetrieveStockFromStackList(List<TStack> stackList, List<TStack> retrievedStacks, ref int count, IStackComparator<TStack, TData> stackComparator)
		{
			for (int i = 0; i < stackList.Count; i++)
			{
				TStack stack = stackList[i];
				if (stackComparator == null || stackComparator.IsValidStack(stack))
				{
					TStack val = new TStack();
					val.SetupEmptyFrom(stack);
					val = val.AddStack(ref stack, count);
					stackList[i] = stack;
					int stackCount = val.StackCount;
					retrievedStacks.Add(val);
					count -= stackCount;
					if (stack.StackCount <= 0)
					{
						stackList.RemoveAt(0);
						i--;
					}
					if (count <= 0)
					{
						break;
					}
				}
			}
		}

		public virtual int TryAdd(StringKey<StockType> stockType, ref TStack stackToAdd)
		{
			if (stackToAdd.StackCount <= 0)
			{
				return 0;
			}
			int maximumAddCount = GetMaximumAddCount(stockType);
			if (maximumAddCount <= 0)
			{
				return 0;
			}
			List<TStack> stackList_Internal = GetStackList_Internal(stockType, stackToAdd.ItemData);
			int num = 0;
			num += TryMergeStack(stackList_Internal, ref stackToAdd, maximumAddCount);
			num += TryAddNewStacks(stackList_Internal, ref stackToAdd, maximumAddCount - num);
			if (num != 0)
			{
				SendStockChangedEvent(stackToAdd.ItemData, stockType, EOperation.Added);
			}
			return num;
		}

		public virtual void ForceAdd(StringKey<StockType> stockType, TStack stackToAdd)
		{
			if (stackToAdd.StackCount > 0)
			{
				int stackCount = stackToAdd.StackCount;
				List<TStack> stackList_Internal = GetStackList_Internal(stockType, stackToAdd.ItemData);
				TryMergeStack(stackList_Internal, ref stackToAdd);
				TryAddNewStacks(stackList_Internal, ref stackToAdd);
				if (stackCount != stackToAdd.StackCount)
				{
					SendStockChangedEvent(stackToAdd.ItemData, stockType, EOperation.Added);
				}
			}
		}

		public void ClearInventory()
		{
			foreach (var (stockType, _) in _inventory)
			{
				ClearInventory(stockType);
			}
		}

		public void ClearInventory(StringKey<StockType> stockType)
		{
			if (!_inventory.TryGetValue(stockType, out var value) || _inventory.Count <= 0)
			{
				return;
			}
			foreach (var (_, stackList) in value)
			{
				ClearStackList(stackList, stockType);
			}
			value.Clear();
		}

		public void ClearInventory(TData itemData)
		{
			foreach (var (stockType, dictionary2) in _inventory)
			{
				if (dictionary2.TryGetValue(itemData, out var value))
				{
					ClearStackList(value, stockType);
				}
			}
		}

		public void ClearInventory(StringKey<StockType> stockType, TData itemData)
		{
			if (_inventory.TryGetValue(stockType, out var value) && value.TryGetValue(itemData, out var value2))
			{
				ClearStackList(value2, stockType);
			}
		}

		private void ClearStackList(List<TStack> stackList, StringKey<StockType> stockType)
		{
			if (stackList.Count > 0)
			{
				TData itemData = stackList[0].ItemData;
				stackList.Clear();
				SendStockChangedEvent(itemData, stockType, EOperation.Removed);
			}
		}

		private Dictionary<TData, List<TStack>> GetStockDictionary(StringKey<StockType> stockType)
		{
			if (!_inventory.TryGetValue(stockType, out var value))
			{
				value = new Dictionary<TData, List<TStack>>();
				_inventory.Add(stockType, value);
			}
			return value;
		}

		private List<TStack> GetStackList_Internal(StringKey<StockType> stockType, TData itemData)
		{
			Dictionary<TData, List<TStack>> stockDictionary = GetStockDictionary(stockType);
			if (!stockDictionary.TryGetValue(itemData, out var value))
			{
				value = new List<TStack>();
				stockDictionary.Add(itemData, value);
			}
			return value;
		}

		public virtual bool IsAtMaxCapacity(StringKey<StockType> stockType)
		{
			return GetMaximumAddCount(stockType) <= 0;
		}

		public virtual int GetMaximumAddCount(StringKey<StockType> stockType)
		{
			if (!_availableStockTypes.Contains(stockType))
			{
				return 0;
			}
			StockCapacity stockTypeCapacity = GetStockTypeCapacity(stockType);
			int num = stockTypeCapacity.MaxCapacity ?? int.MaxValue;
			return Math.Max(0, num - stockTypeCapacity.CurrentCapacity);
		}

		protected virtual int TryMergeStack(List<TStack> stackList, ref TStack stackToAdd, int maxAddCount = int.MaxValue)
		{
			int num = 0;
			for (int i = 0; i < stackList.Count; i++)
			{
				if (stackToAdd.StackCount <= 0)
				{
					break;
				}
				if (maxAddCount <= 0)
				{
					break;
				}
				TStack other = stackList[i];
				if (stackToAdd.CanAnythingBeAddedTo(other))
				{
					int stackCount = other.StackCount;
					other = other.AddStack(ref stackToAdd, maxAddCount);
					int num2 = other.StackCount - stackCount;
					num += num2;
					maxAddCount -= num2;
					stackList[i] = other;
				}
			}
			return num;
		}

		protected virtual int TryAddNewStacks(List<TStack> stackList, ref TStack stackToAdd, int maxAddCount = int.MaxValue)
		{
			int num = 0;
			while (stackToAdd.StackCount > 0 && maxAddCount > 0)
			{
				TStack val = new TStack();
				val.SetupEmptyFrom(stackToAdd);
				val = val.AddStack(ref stackToAdd, maxAddCount);
				maxAddCount -= val.StackCount;
				num += val.StackCount;
				if (val.StackCount == 0)
				{
					throw new Exception("Created stack has a 0 stack count, this isn't normal");
				}
				stackList.Add(val);
			}
			return num;
		}

		public StackEnumerator GetEnumerator()
		{
			return new StackEnumerator(this);
		}

		public StackEnumerator<TComparator> GetEnumerator<TComparator>(TComparator comparator = default(TComparator)) where TComparator : IStackComparator<TStack, TData>
		{
			return new StackEnumerator<TComparator>(this, comparator);
		}

		public ItemStackEnumerator<TComparator> GetEnumerator<TComparator>(TData itemData, TComparator comparator = default(TComparator)) where TComparator : IStackComparator<TStack, TData>
		{
			return new ItemStackEnumerator<TComparator>(this, itemData, comparator);
		}
	}
}
