using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputItemSlot : MonoBehaviour
{
	[SerializeField]
	private Image iconItemGrayedOut;

	[SerializeField]
	private TMP_Text labelNeededAmount;

	[SerializeField]
	private TMP_Text labelCurrentAmount;

	public void UpdateSlot(int itemId, int neededAmount)
	{
		labelNeededAmount.text = neededAmount + "x";
		ItemInfo itemInfo = InventorySystem.GetItemLibrary().itemInfos[itemId];
		iconItemGrayedOut.sprite = itemInfo.icon;
	}

	public void UpdateItemAmount(int amount)
	{
		labelCurrentAmount.text = amount.ToString();
	}
}
