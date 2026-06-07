using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using CTS.DevConsole.Variables;
using CTS.StockInventory;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[Constructor("Construct")]
	public class Stocks : CTSBehaviour
	{
		[SerializeField]
		private BBTStock _barStock;

		[SerializeField]
		private BBTStock _vendorStock;

		[SerializeField]
		private SerializableDictionary<StringKey<StockType>, LocalizedString> _stockNames = new SerializableDictionary<StringKey<StockType>, LocalizedString>();

		private static Dictionary<StringKey<StockType>, LocalizedString> _stockTypesNames = new Dictionary<StringKey<StockType>, LocalizedString>();

		private const string stockTypesPath = "Assets/Scriptables/Stocks/StockTypes/";

		private static readonly Addressable<StockType> _humanStockType = "Assets/Scriptables/Stocks/StockTypes/HumanStock.asset";

		private static readonly Addressable<StockType> _vampireStockType = "Assets/Scriptables/Stocks/StockTypes/VampireStock.asset";

		private static readonly Addressable<StockType> _bodyStockType = "Assets/Scriptables/Stocks/StockTypes/BodyStock.asset";

		private static readonly Dictionary<StockItemSO, Action> _restrictionsChanged = new Dictionary<StockItemSO, Action>();

		private static readonly Dictionary<StockItemSO, float> _machineRestrictions = new Dictionary<StockItemSO, float>();

		public static CVarBoolReference CVarDrinksRequireStock { get; private set; }

		public static StringKey<StockType> HumanStockType => new StringKey<StockType>(_humanStockType);

		public static StringKey<StockType> VampireStockType => new StringKey<StockType>(_vampireStockType);

		public static StringKey<StockType> BodyStockType => new StringKey<StockType>(_bodyStockType);

		public static BBTStock BarStock { get; private set; }

		public static BBTStock VendorStock { get; private set; }

		public static event Action RestrictionsChanged;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Init()
		{
			_machineRestrictions.Clear();
			_restrictionsChanged.Clear();
			_stockTypesNames.Clear();
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			CVarDrinksRequireStock = ConsoleVar.GetVariable<CVarBoolReference>("drinksrequirestock");
			BarStock.SetStockTypeCapacity(VampireStockType, 0);
			BarStock.SetStockTypeCapacity(HumanStockType, 0);
			_stockTypesNames = _stockNames.Dict;
		}

		public static string GetStockName(StringKey<StockType> stockType)
		{
			if (_stockTypesNames.TryGetValue(stockType, out var value))
			{
				return value.GetLocalizedString();
			}
			return "String not found";
		}

		public static void SetMachineRestriction(StockItemSO itemData, float maxAmountUnitInterval)
		{
			float num = Math.Clamp(maxAmountUnitInterval, 0f, 1f);
			if (!_machineRestrictions.TryGetValue(itemData, out var value) || !(Math.Abs(value - num) < float.Epsilon))
			{
				_machineRestrictions[itemData] = num;
				Stocks.RestrictionsChanged?.Invoke();
				if (_restrictionsChanged.TryGetValue(itemData, out var value2))
				{
					value2?.Invoke();
				}
			}
		}

		public static float GetMachineRestriction(StockItemSO itemData)
		{
			if (_machineRestrictions.TryGetValue(itemData, out var value))
			{
				return value;
			}
			return 1f;
		}

		public static void RegisterToRestrictionChange(StockItemSO itemData, Action action)
		{
			if (!_restrictionsChanged.ContainsKey(itemData))
			{
				_restrictionsChanged[itemData] = action;
				return;
			}
			Dictionary<StockItemSO, Action> restrictionsChanged = _restrictionsChanged;
			restrictionsChanged[itemData] = (Action)Delegate.Combine(restrictionsChanged[itemData], action);
		}

		public static void UnregisterToRestrictionChange(StockItemSO itemData, Action action)
		{
			if (_restrictionsChanged.ContainsKey(itemData))
			{
				Dictionary<StockItemSO, Action> restrictionsChanged = _restrictionsChanged;
				restrictionsChanged[itemData] = (Action)Delegate.Remove(restrictionsChanged[itemData], action);
			}
		}

		public static int GetStockedCount(StockItemSO itemData)
		{
			if ((object)itemData == null)
			{
				return 0;
			}
			if (itemData.StockType == HumanStockType)
			{
				return BarStock.GetStockedCount(HumanStockType, itemData);
			}
			if (itemData.StockType == VampireStockType)
			{
				return BarStock.GetStockedCount(VampireStockType, itemData);
			}
			return 0;
		}

		public static bool IsAtMaxCapacityWithRestriction(StockItemSO itemData)
		{
			return GetMaximumAddCountWithRestriction(itemData) <= 0;
		}

		public static int GetMaximumAddCountWithRestriction(StockItemSO itemData)
		{
			if (itemData.StockType == HumanStockType)
			{
				return BarStock.GetMaximumAddCount(HumanStockType);
			}
			if (itemData.StockType != VampireStockType)
			{
				return 0;
			}
			if (!_machineRestrictions.TryGetValue(itemData, out var value) || value >= 1f)
			{
				return BarStock.GetMaximumAddCount(itemData.StockType);
			}
			StockCapacity stockTypeCapacity = BarStock.GetStockTypeCapacity(VampireStockType);
			if (!stockTypeCapacity.MaxCapacity.HasValue)
			{
				return BarStock.GetMaximumAddCount(itemData.StockType);
			}
			int num = (int)Math.Floor(value * (float)stockTypeCapacity.MaxCapacity.Value);
			if (stockTypeCapacity.CurrentCapacity >= num)
			{
				return 0;
			}
			return num - stockTypeCapacity.CurrentCapacity;
		}

		public static int TryAddWithRestriction(ref StockStack itemStack)
		{
			if (itemStack.ItemData.StockType == HumanStockType)
			{
				return BarStock.TryAdd(HumanStockType, ref itemStack);
			}
			if (itemStack.ItemData.StockType != VampireStockType)
			{
				return 0;
			}
			if (!_machineRestrictions.TryGetValue(itemStack.ItemData, out var value) || value >= 1f)
			{
				return BarStock.TryAdd(VampireStockType, ref itemStack);
			}
			StockCapacity stockTypeCapacity = BarStock.GetStockTypeCapacity(VampireStockType);
			if (!stockTypeCapacity.MaxCapacity.HasValue)
			{
				return BarStock.TryAdd(VampireStockType, ref itemStack);
			}
			int num = (int)Math.Floor(value * (float)stockTypeCapacity.MaxCapacity.Value);
			if (stockTypeCapacity.CurrentCapacity >= num)
			{
				return 0;
			}
			int maxCount = num - stockTypeCapacity.CurrentCapacity;
			StockStack stockStack = default(StockStack);
			stockStack.SetupEmptyFrom(itemStack);
			stockStack = stockStack.AddStack(ref itemStack, maxCount);
			int result = BarStock.TryAdd(VampireStockType, ref stockStack);
			if (stockStack.StackCount > 0)
			{
				itemStack = itemStack.AddStack(ref stockStack, stockStack.StackCount);
			}
			return result;
		}

		public static int TryAdd(ref StockStack itemStack)
		{
			if (itemStack.ItemData.StockType == HumanStockType)
			{
				return BarStock.TryAdd(HumanStockType, ref itemStack);
			}
			if (itemStack.ItemData.StockType == VampireStockType)
			{
				return BarStock.TryAdd(VampireStockType, ref itemStack);
			}
			return 0;
		}

		public static void ForceAdd(StockStack itemStack)
		{
			if (itemStack.ItemData.StockType == HumanStockType)
			{
				BarStock.ForceAdd(HumanStockType, itemStack);
			}
			if (itemStack.ItemData.StockType == VampireStockType)
			{
				BarStock.ForceAdd(VampireStockType, itemStack);
			}
		}

		private void Construct()
		{
			BarStock = _barStock;
			VendorStock = _vendorStock;
		}
	}
}
