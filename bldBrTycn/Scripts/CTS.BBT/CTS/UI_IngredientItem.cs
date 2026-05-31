using System.Globalization;
using CTS.BBT;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_IngredientItem : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _priceText;

		[SerializeField]
		private Image _usedItemImage;

		private StockItemSO _item;

		private SlotableItem _slotableItem;

		private void Awake()
		{
			_slotableItem = GetComponentInChildren<SlotableItem>();
			_slotableItem.OnSlotted += SetUsedItem;
		}

		private void OnDestroy()
		{
			_slotableItem.OnSlotted -= SetUsedItem;
		}

		public void SetItemData(StockItemSO p_item)
		{
			_item = p_item;
			_priceText.text = _item.PurchasePrice.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
			_slotableItem.SetData(_item);
		}

		public void SetUsedItem(bool p_used)
		{
			_usedItemImage.enabled = p_used;
		}
	}
}
