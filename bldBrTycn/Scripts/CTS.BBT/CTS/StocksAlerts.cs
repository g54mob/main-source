using System;
using CTS.BBT;
using CTS.Core;
using CTS.StockInventory;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class StocksAlerts : MonoBehaviour
	{
		public enum EState
		{
			Default = 0,
			LowDanger = 1,
			HighDanger = 2,
			Empty = 3
		}

		[SerializeField]
		private StockAlertsStruct[] _stockAlert;

		protected void Awake()
		{
			for (int i = 0; i < _stockAlert.Length; i++)
			{
				_stockAlert[i].CurrentState = EState.Empty;
			}
		}

		protected void OnEnable()
		{
			Stocks.BarStock.StockChanged += OnStockChanged;
		}

		protected void OnDisable()
		{
			Stocks.BarStock.StockChanged -= OnStockChanged;
		}

		private void OnStockChanged(StockInventory<StockStack, StockItemSO>.StockChangedData stockChanged)
		{
			for (int i = 0; i < _stockAlert.Length; i++)
			{
				StockItemSO stockItemSO = _stockAlert[i].StockItemSO;
				if (!(stockChanged.StockType != stockItemSO.StockType))
				{
					int stockedCount = Stocks.GetStockedCount(stockItemSO);
					EState eState;
					if (stockedCount == 0)
					{
						eState = EState.Empty;
						OnStateChange(eState, stockItemSO, i);
					}
					else if ((float)stockedCount <= _stockAlert[i].WhenTheStockIsVeryLow)
					{
						eState = EState.HighDanger;
						OnStateChange(eState, stockItemSO, i);
					}
					else if ((float)stockedCount <= _stockAlert[i].WhenTheStockIsLow)
					{
						eState = EState.LowDanger;
						OnStateChange(eState, stockItemSO, i);
					}
					else
					{
						eState = EState.Default;
						OnStateChange(eState, stockItemSO, i);
					}
					_stockAlert[i].CurrentState = eState;
				}
			}
		}

		private void OnStateChange(EState state, StockItemSO item, int index)
		{
			if (_stockAlert[index].CurrentState >= state)
			{
				return;
			}
			Action tmpScriptToExecute = delegate
			{
				if (CTSSelectable.TryGet((StringKey)"UI_Button_Stock", out CTSToggle outSelectable))
				{
					outSelectable.isOn = true;
				}
			};
			switch (state)
			{
			case EState.LowDanger:
				MonoSingleton<PushHandlers>.Instance.PushANotification("<sprite=\"Emoji_Notifications\" index=6>", PushColor.Danger, tmpScriptToExecute, "Stocks  Low", " Your stock of : " + item.Name + " is low", null);
				break;
			case EState.HighDanger:
				MonoSingleton<PushHandlers>.Instance.PushANotification("<sprite=\"Emoji_Notifications\" index=6>", PushColor.Danger, tmpScriptToExecute, "Stocks Very Low", " You need to refill your : " + item.Name, null);
				break;
			case EState.Empty:
				MonoSingleton<PushHandlers>.Instance.PushANotification("<sprite=\"Emoji_Notifications\" index=6>", PushColor.Danger, tmpScriptToExecute, "Stocks Empty", " You sell all your : " + item.Name, null);
				break;
			case EState.Default:
				break;
			}
		}
	}
}
