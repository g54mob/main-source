using CTS.StockInventory;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace CTS
{
	[RequireComponent(typeof(MachineUI))]
	public class MachineUIFeedbackStock : MonoBehaviour
	{
		[SerializeField]
		[BoxGroup("Link Component")]
		[Space(10f)]
		private MachineUI _machineUI;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		[Space(10f)]
		private GameObject _outOfStockGameObject;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TMP_Text _outOfStockDataText;

		private int _currentCapacity;

		private void OnEnable()
		{
			Stocks.BarStock.StockChanged += OnStockChanged;
			OnStockChanged(new StockInventory<StockStack, CTS.BBT.StockItemSO>.StockChangedData
			{
				StockType = Stocks.VampireStockType,
				StockCapacity = Stocks.BarStock.GetStockTypeCapacity(Stocks.VampireStockType)
			});
		}

		private void OnDisable()
		{
			Stocks.BarStock.StockChanged -= OnStockChanged;
		}

		private void OnStockChanged(StockInventory<StockStack, CTS.BBT.StockItemSO>.StockChangedData obj)
		{
			if (!(obj.StockType != Stocks.VampireStockType))
			{
				StockCapacity stockCapacity = obj.StockCapacity;
				_currentCapacity = stockCapacity.CurrentCapacity;
				CallDisplayOrHide(stockCapacity.HasCapacityFor(1));
			}
		}

		private void CallDisplayOrHide(bool value)
		{
			_outOfStockGameObject.SetActive(!value);
			if (!value)
			{
				_machineUI.TrySetIcon(_machineUI.DangerSprite);
				_outOfStockDataText.text = $"{_currentCapacity} / {_currentCapacity}";
			}
			else
			{
				_machineUI.TrySetIcon(_machineUI.ProgressSprite);
			}
		}
	}
}
