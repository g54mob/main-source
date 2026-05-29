using CTS.Core;
using CTS.StockInventory;
using CTS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_StockCountUpdater : CTSBehaviour
	{
		[InjectScope(EGetScope.Parent)]
		[Inject(false)]
		private IGive<StringKey<StockType>> _stockType;

		[SerializeField]
		[Inject(false)]
		private TMP_Text _text;

		[SerializeField]
		private Graphic _graphic;

		[SerializeField]
		private PaletteData _colorWhenFull;

		[SerializeField]
		private PaletteData _colorWhenNotFull;

		private const string Format = "{0}/{1}";

		protected override void OnEnabled()
		{
			base.OnEnabled();
			Stocks.BarStock.StockChanged += OnStockChanged;
			UpdateText(Stocks.BarStock.GetStockTypeCapacity(_stockType.Get()));
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			Stocks.BarStock.StockChanged -= OnStockChanged;
		}

		private void OnStockChanged(StockInventory<StockStack, CTS.BBT.StockItemSO>.StockChangedData changedData)
		{
			if (!(changedData.StockType != _stockType.Get()))
			{
				UpdateText(changedData.StockCapacity);
			}
		}

		private void UpdateText(StockCapacity capacity)
		{
			_text.text = string.Format("{0}/{1}", capacity.CurrentCapacity.ToString(), capacity.MaxCapacity.HasValue ? capacity.MaxCapacity.Value.ToString() : "~");
			if ((object)_graphic != null)
			{
				if (capacity.MaxCapacity.HasValue && capacity.CurrentCapacity >= capacity.MaxCapacity)
				{
					_graphic.color = _colorWhenFull;
				}
				else
				{
					_graphic.color = _colorWhenNotFull;
				}
			}
		}
	}
}
