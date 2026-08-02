using UnityEngine;
using UnityEngine.UI;

public class ResearchNeededUIItem : MonoBehaviour
{
	public CollectableItemData data;

	public Image itemImage;

	public Image borderImage;

	private ItemInfoHover itemInfoHover;

	private void Awake()
	{
		itemInfoHover = GetComponent<ItemInfoHover>();
		if (itemInfoHover == null)
		{
			itemInfoHover = base.gameObject.AddComponent<ItemInfoHover>();
		}
	}

	public void UpdateUI()
	{
		if (!(data == null))
		{
			itemImage.sprite = data.itemImage;
			if (data.isResearched)
			{
				borderImage.color = Color.green;
			}
			else
			{
				borderImage.color = Color.white;
			}
			if (itemInfoHover != null)
			{
				itemInfoHover.SetItemData(data);
			}
		}
	}
}
