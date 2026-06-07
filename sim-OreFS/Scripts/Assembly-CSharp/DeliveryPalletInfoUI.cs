using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;

public class DeliveryPalletInfoUI : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private TextMeshProUGUI contractNameText;

	[SerializeField]
	private Transform materialListParent;

	[SerializeField]
	private GameObject materialItemPrefab;

	[Header("Runtime")]
	private T_DeliveryPallet currentPallet;

	private int lastKnownTotalCount = -1;

	private List<DeliveryPalletMaterialItemUI> materialItems = new List<DeliveryPalletMaterialItemUI>();

	private void Start()
	{
		if (canvasGroup != null)
		{
			canvasGroup.alpha = 0f;
		}
	}

	private void Update()
	{
		if (!(currentPallet == null) && currentPallet.TotalItemCount != lastKnownTotalCount)
		{
			lastKnownTotalCount = currentPallet.TotalItemCount;
			UpdateMaterialDisplays();
		}
	}

	public void SetTarget(T_DeliveryPallet pallet)
	{
		if (pallet == null)
		{
			Hide();
			return;
		}
		currentPallet = pallet;
		lastKnownTotalCount = pallet.TotalItemCount;
		if (contractNameText != null)
		{
			string activeContractId = pallet.ActiveContractId;
			if (!string.IsNullOrEmpty(activeContractId) && ComputerContractManager.Instance != null)
			{
				ActiveContractData? activeContract = ComputerContractManager.Instance.GetActiveContract(activeContractId);
				if (activeContract.HasValue)
				{
					string text = LocalizationManager.GetTranslation(activeContract.Value.companyName);
					if (string.IsNullOrEmpty(text))
					{
						text = activeContract.Value.companyName;
					}
					contractNameText.text = text;
				}
				else
				{
					contractNameText.text = "Unknown Contract";
				}
			}
			else
			{
				contractNameText.text = "No Contract";
			}
		}
		UpdateMaterialList();
		if (canvasGroup != null)
		{
			canvasGroup.alpha = 1f;
		}
	}

	private void UpdateMaterialList()
	{
		if (materialListParent == null || materialItemPrefab == null || currentPallet == null)
		{
			return;
		}
		foreach (DeliveryPalletMaterialItemUI materialItem in materialItems)
		{
			if (materialItem != null && materialItem.gameObject != null)
			{
				Object.Destroy(materialItem.gameObject);
			}
		}
		materialItems.Clear();
		int materialCount = currentPallet.MaterialCount;
		for (int i = 0; i < materialCount; i++)
		{
			if (!currentPallet.TryGetMaterialData(i, out var itemId, out var count, out var maxCount) || string.IsNullOrEmpty(itemId))
			{
				continue;
			}
			T_ItemSO t_ItemSO = ItemSOManager.Instance?.GetItemSOById(itemId);
			if (!(t_ItemSO == null))
			{
				DeliveryPalletMaterialItemUI component = Object.Instantiate(materialItemPrefab, materialListParent).GetComponent<DeliveryPalletMaterialItemUI>();
				if (component != null)
				{
					component.Initialize(t_ItemSO, count, maxCount);
					materialItems.Add(component);
				}
			}
		}
	}

	private void UpdateMaterialDisplays()
	{
		if (currentPallet == null)
		{
			return;
		}
		int materialCount = currentPallet.MaterialCount;
		int num = 0;
		for (int i = 0; i < materialCount; i++)
		{
			if (num >= materialItems.Count)
			{
				break;
			}
			if (currentPallet.TryGetMaterialData(i, out var itemId, out var count, out var maxCount) && !string.IsNullOrEmpty(itemId) && num < materialItems.Count && materialItems[num] != null)
			{
				materialItems[num].UpdateCount(count, maxCount);
				num++;
			}
		}
	}

	public void Hide()
	{
		currentPallet = null;
		lastKnownTotalCount = -1;
		if (canvasGroup != null)
		{
			canvasGroup.alpha = 0f;
		}
	}

	public bool IsVisible()
	{
		if (canvasGroup != null)
		{
			return canvasGroup.alpha > 0f;
		}
		return false;
	}

	public T_DeliveryPallet GetCurrentTarget()
	{
		return currentPallet;
	}
}
