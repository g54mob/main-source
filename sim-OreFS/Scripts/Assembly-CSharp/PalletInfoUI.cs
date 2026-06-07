using System.Collections.Generic;
using System.Text;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PalletInfoUI : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private Image itemIcon;

	[SerializeField]
	private TextMeshProUGUI itemNameText;

	[SerializeField]
	private TextMeshProUGUI itemCountText;

	[Header("Contract Info UI")]
	[SerializeField]
	private CanvasGroup contractInfoCanvasGroup;

	[SerializeField]
	private TextMeshProUGUI contractIdText;

	[Header("Runtime")]
	private T_Pallet currentPallet;

	private T_DeliveryPallet currentDeliveryPallet;

	private int lastKnownCount = -1;

	private void Start()
	{
		if (canvasGroup != null)
		{
			canvasGroup.alpha = 0f;
		}
		if (contractInfoCanvasGroup != null)
		{
			contractInfoCanvasGroup.alpha = 0f;
		}
	}

	private void Update()
	{
		if (currentPallet != null)
		{
			if (currentPallet.PaletItemCount != lastKnownCount)
			{
				lastKnownCount = currentPallet.PaletItemCount;
				UpdateCountDisplay();
			}
		}
		else if (currentDeliveryPallet != null)
		{
			int totalItemCount = currentDeliveryPallet.TotalItemCount;
			if (totalItemCount != lastKnownCount)
			{
				lastKnownCount = totalItemCount;
				UpdateDeliveryCountDisplay();
			}
		}
	}

	public void SetTarget(T_Pallet pallet)
	{
		if (pallet == null)
		{
			Hide();
			return;
		}
		if (pallet.IsEmpty)
		{
			Hide();
			return;
		}
		currentPallet = pallet;
		currentDeliveryPallet = null;
		lastKnownCount = pallet.PaletItemCount;
		if (ItemSOManager.Instance == null)
		{
			Hide();
			return;
		}
		T_ItemSO itemSOById = ItemSOManager.Instance.GetItemSOById(pallet.PaletItemId);
		if (itemSOById == null)
		{
			Hide();
			return;
		}
		if (itemIcon != null)
		{
			itemIcon.sprite = itemSOById.Icon;
			itemIcon.enabled = itemSOById.Icon != null;
		}
		if (itemNameText != null)
		{
			string translation = LocalizationManager.GetTranslation(itemSOById.Name);
			itemNameText.text = (string.IsNullOrEmpty(translation) ? itemSOById.Name : translation);
		}
		UpdateCountDisplay();
		UpdateContractInfoUI(pallet.PaletItemId);
		if (canvasGroup != null)
		{
			canvasGroup.alpha = 1f;
		}
	}

	public void SetTarget(T_DeliveryPallet deliveryPallet)
	{
		if (deliveryPallet == null)
		{
			Hide();
			return;
		}
		if (deliveryPallet.IsEmpty || deliveryPallet.MaterialCount == 0)
		{
			Hide();
			return;
		}
		currentPallet = null;
		currentDeliveryPallet = deliveryPallet;
		string itemId = deliveryPallet.GetItemId(0);
		int itemCount = deliveryPallet.GetItemCount(0);
		lastKnownCount = itemCount;
		if (string.IsNullOrEmpty(itemId))
		{
			Hide();
			return;
		}
		if (ItemSOManager.Instance == null)
		{
			Hide();
			return;
		}
		T_ItemSO itemSOById = ItemSOManager.Instance.GetItemSOById(itemId);
		if (itemSOById == null)
		{
			Hide();
			return;
		}
		if (itemIcon != null)
		{
			itemIcon.sprite = itemSOById.Icon;
			itemIcon.enabled = itemSOById.Icon != null;
		}
		if (itemNameText != null)
		{
			string translation = LocalizationManager.GetTranslation(itemSOById.Name);
			itemNameText.text = (string.IsNullOrEmpty(translation) ? itemSOById.Name : translation);
		}
		UpdateDeliveryCountDisplay();
		UpdateContractInfoUI(itemId);
		if (canvasGroup != null)
		{
			canvasGroup.alpha = 1f;
		}
	}

	private void UpdateCountDisplay()
	{
		if (!(itemCountText == null) && !(currentPallet == null))
		{
			int paletItemCount = currentPallet.PaletItemCount;
			int maxItemCount = currentPallet.GetMaxItemCount();
			itemCountText.text = $"{paletItemCount}/{maxItemCount}";
		}
	}

	private void UpdateDeliveryCountDisplay()
	{
		if (!(itemCountText == null) && !(currentDeliveryPallet == null))
		{
			int totalItemCount = currentDeliveryPallet.TotalItemCount;
			itemCountText.text = $"{totalItemCount}";
		}
	}

	public void Hide()
	{
		currentPallet = null;
		currentDeliveryPallet = null;
		lastKnownCount = -1;
		if (canvasGroup != null)
		{
			canvasGroup.alpha = 0f;
		}
		HideContractInfoUI();
	}

	public bool IsVisible()
	{
		if (canvasGroup != null)
		{
			return canvasGroup.alpha > 0f;
		}
		return false;
	}

	public T_Pallet GetCurrentTarget()
	{
		return currentPallet;
	}

	private void UpdateContractInfoUI(string itemId)
	{
		if (contractInfoCanvasGroup == null || contractIdText == null)
		{
			return;
		}
		if (ComputerContractManager.Instance == null)
		{
			contractInfoCanvasGroup.alpha = 0f;
			return;
		}
		IReadOnlyList<ActiveContractData> activeContracts = ComputerContractManager.Instance.ActiveContracts;
		List<int> list = new List<int>();
		foreach (ActiveContractData item in activeContracts)
		{
			if (!item.IsActive || item.materialIds == null)
			{
				continue;
			}
			for (int i = 0; i < item.materialIds.Length; i++)
			{
				if (item.materialIds[i] == itemId)
				{
					list.Add(item.contractNumber);
					break;
				}
			}
		}
		if (list.Count == 0)
		{
			contractInfoCanvasGroup.alpha = 0f;
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int j = 0; j < list.Count; j++)
		{
			if (j > 0)
			{
				stringBuilder.Append(", ");
			}
			stringBuilder.Append("#");
			stringBuilder.Append(list[j]);
		}
		contractIdText.text = stringBuilder.ToString();
		contractInfoCanvasGroup.alpha = 1f;
	}

	private void HideContractInfoUI()
	{
		if (contractInfoCanvasGroup != null)
		{
			contractInfoCanvasGroup.alpha = 0f;
		}
	}
}
