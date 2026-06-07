using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContractMaterialItemUI : MonoBehaviour
{
	[Header("UI Elements")]
	[Tooltip("Malzeme ikonu")]
	[SerializeField]
	private Image materialIcon;

	[Tooltip("Malzeme ismi")]
	[SerializeField]
	private TextMeshProUGUI materialNameText;

	[Tooltip("Gerekli adet")]
	[SerializeField]
	private TextMeshProUGUI requiredCountText;

	[Tooltip("Teslimat durumu (aktif contract için)")]
	[SerializeField]
	private TextMeshProUGUI deliveryStatusText;

	[Tooltip("İlerleme çubuğu (aktif contract için)")]
	[SerializeField]
	private Slider progressSlider;

	[Tooltip("İlerleme çubuğu dolgu görseli")]
	[SerializeField]
	private Image progressFillImage;

	[Header("Visual States")]
	[Tooltip("Tamamlanmamış durumda renk")]
	[SerializeField]
	private Color incompleteColor = new Color(1f, 0.8f, 0.2f);

	[Tooltip("Tamamlanmış durumda renk")]
	[SerializeField]
	private Color completeColor = new Color(0.2f, 0.8f, 0.2f);

	[Tooltip("Tamamlandı overlay")]
	[SerializeField]
	private GameObject completedOverlay;

	[Tooltip("Tamamlandı işareti")]
	[SerializeField]
	private GameObject checkmarkIcon;

	private T_ItemSO _itemSO;

	private string _itemId;

	private int _requiredCount;

	private int _deliveredCount;

	private bool _isActiveContract;

	public T_ItemSO ItemSO => _itemSO;

	public string ItemId => _itemId;

	public int RequiredCount => _requiredCount;

	public int DeliveredCount => _deliveredCount;

	public bool IsCompleted => _deliveredCount >= _requiredCount;

	public void InitializeForListing(string itemId, int requiredCount)
	{
		_itemId = itemId;
		_requiredCount = requiredCount;
		_deliveredCount = 0;
		_isActiveContract = false;
		_itemSO = FindItemSO(itemId);
		UpdateUI();
	}

	public void InitializeForActiveContract(string itemId, int requiredCount, int deliveredCount, string contractId = null)
	{
		_itemId = itemId;
		_requiredCount = requiredCount;
		_deliveredCount = deliveredCount;
		_isActiveContract = true;
		if (!string.IsNullOrEmpty(contractId) && ComputerContractManager.Instance != null && ComputerContractManager.Instance.DeliveryRequestedContractId == contractId && T_DeliveryZone.Instance != null)
		{
			_deliveredCount += T_DeliveryZone.Instance.GetItemCount(itemId);
		}
		_itemSO = FindItemSO(itemId);
		UpdateUI();
	}

	public void UpdateDeliveryCount(int deliveredCount)
	{
		_deliveredCount = deliveredCount;
		UpdateUI();
	}

	public void UpdateUI()
	{
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
		if (requiredCountText != null)
		{
			if (_isActiveContract)
			{
				requiredCountText.text = $"{_deliveredCount}/{_requiredCount}";
			}
			else
			{
				requiredCountText.text = $"x{_requiredCount}";
			}
		}
		if (_isActiveContract)
		{
			UpdateActiveContractUI();
			return;
		}
		if (deliveryStatusText != null)
		{
			deliveryStatusText.gameObject.SetActive(value: false);
		}
		if (progressSlider != null)
		{
			progressSlider.gameObject.SetActive(value: false);
		}
		if (completedOverlay != null)
		{
			completedOverlay.SetActive(value: false);
		}
		if (checkmarkIcon != null)
		{
			checkmarkIcon.SetActive(value: false);
		}
	}

	private void UpdateActiveContractUI()
	{
		bool flag = _deliveredCount >= _requiredCount;
		float value = ((_requiredCount > 0) ? ((float)_deliveredCount / (float)_requiredCount) : 0f);
		if (deliveryStatusText != null)
		{
			deliveryStatusText.gameObject.SetActive(value: true);
			if (flag)
			{
				deliveryStatusText.text = "Tamamlandı";
				deliveryStatusText.color = completeColor;
			}
			else
			{
				int num = _requiredCount - _deliveredCount;
				deliveryStatusText.text = $"{num} Kaldı";
				deliveryStatusText.color = incompleteColor;
			}
		}
		if (progressSlider != null)
		{
			progressSlider.gameObject.SetActive(value: true);
			progressSlider.value = Mathf.Clamp01(value);
		}
		if (progressFillImage != null)
		{
			progressFillImage.color = (flag ? completeColor : incompleteColor);
		}
		if (completedOverlay != null)
		{
			completedOverlay.SetActive(flag);
		}
		if (checkmarkIcon != null)
		{
			checkmarkIcon.SetActive(flag);
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
