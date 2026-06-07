using System.Collections;
using TMPro;
using UnityEngine;

public class ContractCompletedUI : MonoBehaviour
{
	[Header("Panel")]
	[SerializeField]
	private GameObject panel;

	[Header("Materials Section")]
	[SerializeField]
	private ContractCompletedItemUI[] materialItems;

	[SerializeField]
	private TextMeshProUGUI totalDeliveredText;

	[Header("Stats Section")]
	[SerializeField]
	private ContractStatItemUI contractPriceItem;

	[SerializeField]
	private ContractStatItemUI fastDeliveryBonusItem;

	[SerializeField]
	private ContractStatItemUI missingDeliveryPenaltyItem;

	[Header("XP Section")]
	[SerializeField]
	private TextMeshProUGUI earnedXPText;

	[Header("Totals Section")]
	[SerializeField]
	private TextMeshProUGUI totalEarningsText;

	[Header("Animation")]
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private string showKey = "Show";

	[SerializeField]
	private string hideKey = "Hide";

	public bool IsVisible
	{
		get
		{
			if (panel != null)
			{
				return panel.activeSelf;
			}
			return false;
		}
	}

	public void Show(ContractCompletionResult result)
	{
		if (!(panel == null))
		{
			UpdateMaterialItems(result);
			UpdateTotalDelivered(result);
			UpdateStatItems(result);
			if (earnedXPText != null)
			{
				earnedXPText.text = $"{result.earnedXP} XP";
			}
			if (totalEarningsText != null)
			{
				totalEarningsText.text = $"${result.totalEarnings:N0}";
			}
			panel.SetActive(value: true);
			if (animator != null)
			{
				animator.SetTrigger(showKey);
			}
		}
	}

	public void Hide()
	{
		if (panel != null)
		{
			StartCoroutine(HideLoop());
		}
	}

	public IEnumerator HideLoop()
	{
		if (animator != null)
		{
			animator.SetTrigger(hideKey);
			yield return new WaitForSeconds(0.5f);
		}
		panel.SetActive(value: false);
	}

	private void UpdateMaterialItems(ContractCompletionResult result)
	{
		if (materialItems == null)
		{
			return;
		}
		string[] materialIds = result.contract.materialIds;
		int num = ((materialIds != null) ? materialIds.Length : 0);
		for (int i = 0; i < materialItems.Length; i++)
		{
			if (!(materialItems[i] == null))
			{
				if (i < num)
				{
					materialItems[i].gameObject.SetActive(value: true);
					string itemId = result.contract.materialIds[i];
					int num2 = ((result.contract.materialCounts != null && i < result.contract.materialCounts.Length) ? result.contract.materialCounts[i] : 0);
					int deliveredCount = ((result.finalDeliveredCounts != null && i < result.finalDeliveredCounts.Length) ? Mathf.Min(result.finalDeliveredCounts[i], num2) : 0);
					materialItems[i].Initialize(itemId, deliveredCount, num2);
				}
				else
				{
					materialItems[i].gameObject.SetActive(value: false);
				}
			}
		}
	}

	private void UpdateTotalDelivered(ContractCompletionResult result)
	{
		if (totalDeliveredText == null)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		if (result.contract.materialCounts != null && result.finalDeliveredCounts != null)
		{
			for (int i = 0; i < result.contract.materialCounts.Length; i++)
			{
				num2 += result.contract.materialCounts[i];
				if (i < result.finalDeliveredCounts.Length)
				{
					num += Mathf.Min(result.finalDeliveredCounts[i], result.contract.materialCounts[i]);
				}
			}
		}
		totalDeliveredText.text = $"({num}/{num2})";
	}

	private void UpdateStatItems(ContractCompletionResult result)
	{
		if (contractPriceItem != null)
		{
			contractPriceItem.gameObject.SetActive(value: true);
			contractPriceItem.Initialize(result.basePrice, showSign: false);
		}
		if (fastDeliveryBonusItem != null)
		{
			bool flag = result.earlyDeliveryBonus > 0;
			fastDeliveryBonusItem.gameObject.SetActive(flag);
			if (flag)
			{
				fastDeliveryBonusItem.Initialize(result.earlyDeliveryBonus);
			}
		}
		if (missingDeliveryPenaltyItem != null)
		{
			bool flag2 = result.missingDeliveryPenalty < 0;
			missingDeliveryPenaltyItem.gameObject.SetActive(flag2);
			if (flag2)
			{
				missingDeliveryPenaltyItem.Initialize(result.missingDeliveryPenalty);
			}
		}
	}
}
