using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContractHUDMaterialUI : MonoBehaviour
{
	[Header("UI Elements")]
	[Tooltip("Malzeme ikonu")]
	[SerializeField]
	private Image materialIcon;

	[Tooltip("Malzeme ismi")]
	[SerializeField]
	private TextMeshProUGUI materialNameText;

	[Tooltip("Progress text (x/x formatında)")]
	[SerializeField]
	private TextMeshProUGUI progressText;

	[Tooltip("Paletteki miktar text'i (opsiyonel - pallet machine UI için)")]
	[SerializeField]
	private TextMeshProUGUI palletCountText;

	[Tooltip("Depodaki miktar text'i (opsiyonel - HUD için)")]
	[SerializeField]
	private TextMeshProUGUI warehouseCountText;

	[Header("Visual States")]
	[Tooltip("Tamamlanmamış durumda progress text rengi")]
	[SerializeField]
	private Color incompleteColor = Color.white;

	[Tooltip("Tamamlanmış durumda progress text rengi")]
	[SerializeField]
	private Color completeColor = new Color(0.2f, 0.8f, 0.2f);

	private T_ItemSO _itemSO;

	private string _itemId;

	private int _requiredCount;

	private int _deliveredCount;

	private int _palletCount;

	private int _warehouseCount;

	public string ItemId => _itemId;

	public bool IsCompleted => _deliveredCount >= _requiredCount;

	public void Initialize(string itemId, int requiredCount, int deliveredCount, int warehouseCount = 0)
	{
		_itemId = itemId;
		_requiredCount = requiredCount;
		_deliveredCount = deliveredCount;
		_warehouseCount = warehouseCount;
		_itemSO = FindItemSO(itemId);
		UpdateUI();
	}

	public void UpdateDeliveryCount(int deliveredCount)
	{
		_deliveredCount = deliveredCount;
		UpdateUI();
	}

	public void UpdatePalletCount(int palletCount)
	{
		_palletCount = palletCount;
		UpdatePalletCountDisplay();
	}

	private void UpdateUI()
	{
		bool flag = _deliveredCount >= _requiredCount;
		if (materialIcon != null)
		{
			if (_itemSO != null && _itemSO.Icon != null)
			{
				materialIcon.sprite = _itemSO.Icon;
				materialIcon.gameObject.SetActive(value: true);
			}
			else
			{
				materialIcon.gameObject.SetActive(value: false);
			}
		}
		if (materialNameText != null)
		{
			if (_itemSO != null)
			{
				string translation = LocalizationManager.GetTranslation(_itemSO.Name);
				materialNameText.text = ((!string.IsNullOrEmpty(translation)) ? translation : _itemSO.Name);
			}
			else
			{
				materialNameText.text = _itemId;
			}
		}
		if (progressText != null)
		{
			progressText.text = $"({_deliveredCount}/{_requiredCount})";
			progressText.color = (flag ? completeColor : incompleteColor);
		}
		UpdateWarehouseCountDisplay();
		UpdatePalletCountDisplay();
	}

	private void UpdateWarehouseCountDisplay()
	{
		if (!(warehouseCountText == null))
		{
			if (_deliveredCount < _requiredCount && _warehouseCount > 0)
			{
				warehouseCountText.text = _warehouseCount.ToString();
				warehouseCountText.gameObject.SetActive(value: true);
			}
			else
			{
				warehouseCountText.gameObject.SetActive(value: false);
			}
		}
	}

	private void UpdatePalletCountDisplay()
	{
		if (!(palletCountText == null))
		{
			if (_palletCount > 0)
			{
				palletCountText.text = _palletCount.ToString();
				palletCountText.gameObject.SetActive(value: true);
			}
			else
			{
				palletCountText.gameObject.SetActive(value: false);
			}
		}
	}

	private T_ItemSO FindItemSO(string itemId)
	{
		if (string.IsNullOrEmpty(itemId))
		{
			return null;
		}
		if (ItemSOManager.Instance != null)
		{
			return ItemSOManager.Instance.GetItemSOById(itemId);
		}
		return null;
	}
}
