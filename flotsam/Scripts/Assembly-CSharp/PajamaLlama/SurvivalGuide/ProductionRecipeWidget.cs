using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	internal class ProductionRecipeWidget : BaseWidget
	{
		internal class Parameters : BaseParameters
		{
			public ProductionRecipeProperties Recipe { get; private set; }

			public ItemListWidget.Parameters ItemListParameters { get; private set; }

			public string ProductionDurationString { get; private set; }

			public Parameters(ProductionRecipeProperties productionRecipe, string productionDurationString)
			{
				Recipe = productionRecipe;
				ItemListParameters = new ItemListWidget.Parameters(productionRecipe.RequiredItems);
				ProductionDurationString = productionDurationString;
			}
		}

		[SerializeField]
		private Transform _producedItemsParent;

		[SerializeField]
		private ItemCounterSlot _itemCounterSlotPrefab;

		[SerializeField]
		private ItemListWidget _itemListWidget;

		[SerializeField]
		private TextMeshProUGUI _productionTimeLabel;

		internal override void Initialize(BaseParameters parameters)
		{
			if (!(parameters is Parameters parameters2))
			{
				Debug.LogException(new NotImplementedException());
				return;
			}
			foreach (CountedItemProperty producedItem in parameters2.Recipe.ProducedItems)
			{
				UnityEngine.Object.Instantiate(_itemCounterSlotPrefab, _producedItemsParent).Initialize(producedItem.ItemProperties, producedItem.Amount, showCounter: true);
			}
			if (parameters2.ItemListParameters.HasItems())
			{
				_itemListWidget.Initialize(parameters2.ItemListParameters);
			}
			else
			{
				_itemListWidget.gameObject.SetActive(value: false);
			}
			_productionTimeLabel.text = parameters2.ProductionDurationString;
		}

		internal override BaseParameters CreateParameters(Dictionary<string, object> parameters)
		{
			throw new NotImplementedException();
		}
	}
}
