using CTS.BBT;
using CTS.Core;
using CTS.Emotes;
using CTS.StockInventory;
using UnityEngine;

namespace CTS
{
	public class StationStockEmote : CTSBehaviour
	{
		[SerializeField]
		private SelectionModes _visibleInSelectionModes;

		[SerializeField]
		protected StringKey<StockType> _storageType;

		[Inject(false)]
		private Furniture _furniture;

		private Emote _emote;

		private SelectableObject _selectableObject => _furniture.SelectableObject;

		private BarVisualObject _barVisualObject => _furniture.BarVisualObject;

		private Collider _collider => _furniture.Bounds.SelectionCollider;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_selectableObject.HoverEnter += OnHoverEnter;
			_selectableObject.HoverExit += OnHoverExit;
			RegisterEvents();
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_selectableObject.HoverEnter -= OnHoverEnter;
			_selectableObject.HoverExit -= OnHoverExit;
			UnregisterEvents();
		}

		private void OnDestroy()
		{
			_emote?.Kill();
		}

		private void RegisterEvents()
		{
			Stocks.BarStock.StockChanged += OnStocksChanged;
		}

		private void UnregisterEvents()
		{
			Stocks.BarStock.StockChanged -= OnStocksChanged;
		}

		private void OnHoverEnter(SelectionMode selectionMode)
		{
			_emote?.Kill();
			if (_visibleInSelectionModes.CanBeSelectedBy(selectionMode))
			{
				_emote = EmoteManager.Play<EmoteBBT>(_barVisualObject, GetEmoteText());
				_emote.SetStayDuration(-1f);
				_emote.SetHeight(_collider, 0.5f);
			}
		}

		private void OnHoverExit(SelectionMode selectionMode)
		{
			_emote?.Kill();
			_emote = null;
		}

		private void OnStocksChanged(StockInventory<StockStack, StockItemSO>.StockChangedData changedData)
		{
			if (_emote != null && !(changedData.StockType != _storageType))
			{
				_emote.SetText(GetEmoteText(changedData.StockCapacity));
			}
		}

		private string GetEmoteText()
		{
			return GetEmoteText(Stocks.BarStock.GetStockTypeCapacity(_storageType));
		}

		private string GetEmoteText(StockCapacity stockCapacity)
		{
			int? maxCapacity = stockCapacity.MaxCapacity;
			int currentCapacity = stockCapacity.CurrentCapacity;
			if (!maxCapacity.HasValue)
			{
				return currentCapacity.ToString();
			}
			return $"{currentCapacity}/{maxCapacity}";
		}
	}
}
