using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavOrg
{
	private class Item
	{
		public Button button;

		public Navigation originalNavigation;
	}

	private List<Item> items = new List<Item>();

	public Button firstInteractableButton
	{
		get
		{
			foreach (Item item in items)
			{
				if (item.button.enabled && item.button.interactable)
				{
					return item.button;
				}
			}
			return null;
		}
	}

	public void Add(Button button)
	{
		if (button.navigation.mode != Navigation.Mode.Explicit)
		{
			throw new UnityException("NavOrg can only be used with explicit Navigation");
		}
		items.Add(new Item
		{
			button = button,
			originalNavigation = button.navigation
		});
	}

	public void Apply()
	{
		foreach (Item item in items)
		{
			item.button.navigation = item.originalNavigation;
		}
		foreach (Item item2 in items)
		{
			Navigation navigation = item2.button.navigation;
			while (navigation.selectOnRight != null && (!navigation.selectOnRight.enabled || !navigation.selectOnRight.interactable))
			{
				navigation.selectOnRight = navigation.selectOnRight.navigation.selectOnRight;
			}
			while (navigation.selectOnLeft != null && (!navigation.selectOnLeft.enabled || !navigation.selectOnLeft.interactable))
			{
				navigation.selectOnLeft = navigation.selectOnLeft.navigation.selectOnLeft;
			}
			while (navigation.selectOnUp != null && (!navigation.selectOnUp.enabled || !navigation.selectOnUp.interactable))
			{
				navigation.selectOnUp = navigation.selectOnUp.navigation.selectOnUp;
			}
			while (navigation.selectOnDown != null && (!navigation.selectOnDown.enabled || !navigation.selectOnDown.interactable))
			{
				navigation.selectOnDown = navigation.selectOnDown.navigation.selectOnDown;
			}
			item2.button.navigation = navigation;
		}
	}

	public void MakeVerticalList(Button leftButton = null, Button rightButton = null)
	{
		for (int i = 0; i < items.Count; i++)
		{
			Navigation navigation = new Navigation
			{
				mode = Navigation.Mode.Explicit,
				selectOnLeft = leftButton,
				selectOnRight = rightButton
			};
			if (i > 0)
			{
				navigation.selectOnUp = items[i - 1].button;
			}
			if (i < items.Count - 1)
			{
				navigation.selectOnDown = items[i + 1].button;
			}
			items[i].button.navigation = navigation;
			items[i].originalNavigation = navigation;
		}
	}
}
