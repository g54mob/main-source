using System;
using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	internal class ItemListWidget : BaseWidget
	{
		internal class Parameters : BaseParameters
		{
			public IReadOnlyList<CountedItemProperty> Items;

			public Parameters(IReadOnlyList<CountedItemProperty> items)
			{
				Items = items;
			}

			public bool HasItems()
			{
				foreach (CountedItemProperty item in Items)
				{
					if (item.Amount > 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		[SerializeField]
		private ItemCounterSlot _itemCounterSlotPrefab;

		internal override void Initialize(BaseParameters parameters)
		{
			if (!(parameters is Parameters parameters2))
			{
				Debug.LogException(new NotImplementedException());
				return;
			}
			foreach (CountedItemProperty item in parameters2.Items)
			{
				UnityEngine.Object.Instantiate(_itemCounterSlotPrefab, base.transform).Initialize(item.ItemProperties, item.Amount, showCounter: true);
			}
		}

		internal override BaseParameters CreateParameters(Dictionary<string, object> parameters)
		{
			throw new NotImplementedException();
		}
	}
}
