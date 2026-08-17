using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using TMPro;
using UnityEngine;

public class ShopFooter : MonoBehaviour
{
	public TextMeshProUGUI t_title;

	public TextMeshProUGUI t_description;

	public ShopContainer shopContainer;

	public RequirementsContainer requirementsContainer;

	public GameObject buy;

	public GameObject refund;

	public void Set(ShopContainer shopContainerClicked)
	{
		if (shopContainerClicked != null && shopContainerClicked._003Cdata_003Ek__BackingField != null)
		{
			bool flag = MyAchievements.IsUnlocked(shopContainerClicked._003Cdata_003Ek__BackingField, out var _);
			GameObject gameObject = t_description.gameObject;
			gameObject.SetActive(flag);
			GameObject gameObject2 = requirementsContainer.gameObject;
			bool active = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			gameObject2.SetActive(active);
			buy.SetActive(flag);
			refund.SetActive(flag);
			string text = shopContainerClicked._003Cdata_003Ek__BackingField.GetName();
			t_title.text = text;
			shopContainer.Set(shopContainerClicked._003Cdata_003Ek__BackingField);
			if (!flag)
			{
				requirementsContainer.Set(shopContainerClicked._003Cdata_003Ek__BackingField);
				return;
			}
			string description = shopContainerClicked._003Cdata_003Ek__BackingField.GetDescription();
			t_description.text = description;
		}
	}

	private void SetLocked(ShopItemData shopItem)
	{
		shopContainer.Set(shopItem);
		requirementsContainer.Set(shopItem);
	}

	private void SetUnlocked(ShopItemData shopItem)
	{
		shopContainer.Set(shopItem);
		string description = shopItem.GetDescription();
		t_description.text = description;
	}
}
