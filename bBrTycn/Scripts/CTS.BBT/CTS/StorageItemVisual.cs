using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class StorageItemVisual : MonoBehaviour
	{
		public enum E_Option
		{
			NoService = 0,
			CocktailOnly = 1,
			FullService = 2,
			OutOfStock = 3,
			NewItem = 4
		}

		[field: SerializeField]
		public Image IconImage { get; private set; }

		[field: SerializeField]
		public TMP_Text ItemNameText { get; private set; }

		[field: SerializeField]
		public Image BackgroundFilter { get; private set; }

		[field: SerializeField]
		public Image QuantityImage { get; private set; }

		[field: SerializeField]
		public TMP_Text QuantityText { get; private set; }

		[field: SerializeField]
		public Button Button { get; private set; }

		[field: SerializeField]
		public TMP_Text ButtonText { get; private set; }

		[field: SerializeField]
		public Color NewItemColor { get; private set; }

		[field: SerializeField]
		public Color OutStockItemColor { get; private set; }

		[field: SerializeField]
		public Color NoServiceItemColor { get; private set; }

		[field: SerializeField]
		public Color FullServiceItemColor { get; private set; }

		[field: SerializeField]
		public Color CocktailItemColor { get; private set; }

		[field: SerializeField]
		public string NewItemTitle { get; private set; }

		[field: SerializeField]
		public string OutStockItemTitle { get; private set; }

		[field: SerializeField]
		public string NoServiceItemTitle { get; private set; }

		[field: SerializeField]
		public string FullServiceItemTitle { get; private set; }

		[field: SerializeField]
		public string CocktailItemTitle { get; private set; }

		[field: SerializeField]
		public TMP_Text Quality { get; private set; }

		[field: SerializeField]
		public GameObject Qualityparent { get; private set; }

		public void UpdateVisual(E_Option _option)
		{
			switch (_option)
			{
			case E_Option.NoService:
				BackgroundFilter.enabled = true;
				BackgroundFilter.color = NoServiceItemColor;
				ButtonText.text = NoServiceItemTitle;
				break;
			case E_Option.CocktailOnly:
				BackgroundFilter.enabled = true;
				BackgroundFilter.color = CocktailItemColor;
				ButtonText.text = CocktailItemTitle;
				break;
			case E_Option.FullService:
				BackgroundFilter.enabled = true;
				BackgroundFilter.color = FullServiceItemColor;
				ButtonText.text = FullServiceItemTitle;
				break;
			case E_Option.OutOfStock:
				BackgroundFilter.enabled = true;
				BackgroundFilter.color = OutStockItemColor;
				ButtonText.text = OutStockItemTitle;
				break;
			case E_Option.NewItem:
				BackgroundFilter.enabled = true;
				BackgroundFilter.color = NewItemColor;
				ButtonText.text = NewItemTitle;
				break;
			}
		}
	}
}
