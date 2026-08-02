using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftNeededPartUI : MonoBehaviour
{
	public CollectableItemData data;

	public Image itemImage;

	public Image neededCountTextBG;

	public TextMeshProUGUI neededCountText;

	[Header("Text Colors")]
	public Color insufficientColor = Color.red;

	public Color sufficientColor = Color.black;

	private ItemInfoHover itemInfoHover;

	private void Awake()
	{
		itemInfoHover = GetComponent<ItemInfoHover>();
		if (itemInfoHover == null)
		{
			itemInfoHover = base.gameObject.AddComponent<ItemInfoHover>();
		}
		itemInfoHover.UseImagePanel = true;
	}

	public void SetPanel(CostData costData, int inventoryCount)
	{
		data = costData.item;
		itemImage.enabled = true;
		neededCountText.enabled = true;
		neededCountTextBG.gameObject.SetActive(value: true);
		itemImage.sprite = costData.item.itemImage;
		if (costData.cost > inventoryCount)
		{
			neededCountText.color = insufficientColor;
		}
		else
		{
			neededCountText.color = sufficientColor;
		}
		neededCountText.SetText(inventoryCount + "/" + costData.cost);
		if (itemInfoHover != null)
		{
			itemInfoHover.SetItemData(costData.item);
		}
	}

	public void SetNull()
	{
		itemImage.enabled = false;
		neededCountText.enabled = false;
		neededCountTextBG.gameObject.SetActive(value: false);
		if (itemInfoHover != null)
		{
			itemInfoHover.SetItemData(null);
		}
	}
}
