using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.TechTree;
using CTS.Core;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class MissionBasket : ShopBasket
	{
		public enum EMissionResult
		{
			None = 0,
			Partial = 1,
			Full = 2
		}

		[Serializable]
		public struct MissionItemCapacity
		{
			public StockStack ItemStack;

			public int RequiredCount;

			public StockItemSO ItemData => ItemStack.ItemData;

			public int CurrentCount => ItemStack.StackCount;
		}

		public struct MissionResult
		{
			public EMissionResult Result;

			public ReadOnlyMemory<MissionItemCapacity> SentStock;
		}

		[SerializeField]
		private StockMissionData _debugMission;

		private Dictionary<StockItemSO, MissionItemCapacity> _currentMissionFulfillment = new Dictionary<StockItemSO, MissionItemCapacity>();

		private static MissionItemCapacity[] _missionResultAlloc = new MissionItemCapacity[10];

		[field: SerializeField]
		public StringKey Identifier { get; private set; }

		public StockMissionData CurrentMission { get; private set; }

		public ReadOnlyDictionary<StockItemSO, MissionItemCapacity> CurrentMissionStatus => new ReadOnlyDictionary<StockItemSO, MissionItemCapacity>(_currentMissionFulfillment);

		public static event Action<MissionBasket> MissionStarted;

		public static event Action<MissionBasket, MissionResult> MissionEnded;

		[Button(null, EButtonEnableMode.Always)]
		private void StartDebugMission()
		{
			SetMission(_debugMission);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			EndCurrentMission();
		}

		public bool HasMission()
		{
			return _currentMissionFulfillment.Count > 0;
		}

		public void SetMission(StockMissionData missionData)
		{
			if (HasMission())
			{
				EndCurrentMission();
			}
			CurrentMission = missionData;
			StockItemSO[] items = missionData.StockData.Deliverables.Items;
			foreach (StockItemSO stockItemSO in items)
			{
				if (!(stockItemSO == null) && (CurrentMission.AllowLockedItems || (!stockItemSO.ForceLockInStore && (!stockItemSO.TechTreeTechnologyRequiered || TechTreeManager.FirstLevelHasBeenResearched(stockItemSO.TechTreeTechnologyRequiered)))))
				{
					int amount = missionData.StockData.GetAmount(stockItemSO);
					if (amount > 0)
					{
						_currentMissionFulfillment[stockItemSO] = new MissionItemCapacity
						{
							ItemStack = new StockStack(stockItemSO, 0, 0f),
							RequiredCount = amount
						};
					}
				}
			}
			if (_currentMissionFulfillment.Count <= 0)
			{
				throw new Exception("Started a mission without any items in it");
			}
			MissionBasket.MissionStarted?.Invoke(this);
			ClearBasket();
		}

		public void SetMission(StockMissionData missionData, Dictionary<StockItemSO, MissionItemCapacity> currentFullfilment)
		{
			EndCurrentMission();
			CurrentMission = missionData;
			foreach (var (key, value) in currentFullfilment)
			{
				_currentMissionFulfillment[key] = value;
			}
			MissionBasket.MissionStarted?.Invoke(this);
			ClearBasket();
		}

		public void EndCurrentMission()
		{
			if (!HasMission())
			{
				return;
			}
			bool flag = true;
			int num = 0;
			MissionItemCapacity[] itemCapacityAlloc = GetItemCapacityAlloc(_currentMissionFulfillment.Count);
			int num2 = 0;
			foreach (KeyValuePair<StockItemSO, MissionItemCapacity> item in _currentMissionFulfillment)
			{
				item.Deconstruct(out var _, out var value);
				MissionItemCapacity missionItemCapacity = value;
				num += missionItemCapacity.CurrentCount;
				itemCapacityAlloc[num2] = missionItemCapacity;
				num2++;
				if (missionItemCapacity.CurrentCount < missionItemCapacity.RequiredCount)
				{
					flag = false;
					break;
				}
			}
			MissionResult arg = new MissionResult
			{
				Result = (flag ? EMissionResult.Full : ((num > 0) ? EMissionResult.Partial : EMissionResult.None)),
				SentStock = new ReadOnlyMemory<MissionItemCapacity>(itemCapacityAlloc, 0, num2)
			};
			MissionBasket.MissionEnded?.Invoke(this, arg);
			_currentMissionFulfillment.Clear();
			CurrentMission = null;
		}

		public override bool IsAtMaximumCapacity(StockItemSO itemData)
		{
			if (!_currentMissionFulfillment.TryGetValue(itemData, out var value))
			{
				return true;
			}
			int num = value.RequiredCount - value.CurrentCount;
			int count = GetCount(itemData);
			int stockedCount = _stock.GetStockedCount(itemData);
			if (count < stockedCount)
			{
				return count >= num;
			}
			return true;
		}

		protected override int ClampItemCount(StockItemSO itemData, int count)
		{
			if (!_currentMissionFulfillment.TryGetValue(itemData, out var value))
			{
				return 0;
			}
			int max = value.RequiredCount - value.CurrentCount;
			return Math.Clamp(count, 0, max);
		}

		protected override int CalculatePrice()
		{
			return 0;
		}

		public bool WillCurrentBasketFinishMission()
		{
			using (Dictionary<StockItemSO, int>.Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					var (key, num2) = (KeyValuePair<StockItemSO, int>)(ref enumerator.Current);
					if (_currentMissionFulfillment.TryGetValue(key, out var value) && value.CurrentCount + num2 < value.RequiredCount)
					{
						return false;
					}
				}
			}
			return true;
		}

		public override BasketValidation OnValidateBasket()
		{
			StockStack[] basketValidationAlloc = ShopBasket.GetBasketValidationAlloc(_currentMissionFulfillment.Count);
			BasketValidation result = default(BasketValidation);
			int num = 0;
			StockItemSO key;
			using (Dictionary<StockItemSO, int>.Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.Deconstruct(out key, out var value);
					StockItemSO stockItemSO = key;
					int count = value;
					if (!_currentMissionFulfillment.TryGetValue(stockItemSO, out var value2))
					{
						continue;
					}
					_stock.RetrieveStock(stockItemSO, count, ShopBasket._stackRetriever, canGetLessThanCount: true);
					StockStack stack = default(StockStack);
					stack.SetupEmptyFrom(stockItemSO);
					foreach (StockStack item in ShopBasket._stackRetriever)
					{
						StockStack stack2 = item;
						stack.AddStack(ref stack2);
					}
					if (stack.StackCount > 0)
					{
						basketValidationAlloc[num] = stack;
						num++;
						value2.ItemStack.AddStack(ref stack);
						_currentMissionFulfillment[stockItemSO] = value2;
					}
				}
			}
			ClearBasket();
			bool flag = true;
			foreach (KeyValuePair<StockItemSO, MissionItemCapacity> item2 in _currentMissionFulfillment)
			{
				item2.Deconstruct(out key, out var value3);
				MissionItemCapacity missionItemCapacity = value3;
				if (missionItemCapacity.CurrentCount < missionItemCapacity.RequiredCount)
				{
					flag = false;
				}
			}
			if (flag)
			{
				EndCurrentMission();
			}
			result.StockValidated = new ReadOnlyMemory<StockStack>(basketValidationAlloc, 0, num);
			return result;
		}

		private MissionItemCapacity[] GetItemCapacityAlloc(int size)
		{
			if (_missionResultAlloc.Length < size)
			{
				_missionResultAlloc = new MissionItemCapacity[size + 5];
			}
			return _missionResultAlloc;
		}
	}
}
