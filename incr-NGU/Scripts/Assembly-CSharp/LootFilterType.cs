using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LootFilterType : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public Button head;

	public Button chest;

	public Button legs;

	public Button boots;

	public Button weapon;

	public Button accessory;

	public Button boostAtk;

	public Button boostDef;

	public Button boostSpec;

	public Button misc;

	public void toggleHeadFilter()
	{
		character.settings.filterHead = !character.settings.filterHead;
		updateButtons();
	}

	public void toggleChestFilter()
	{
		character.settings.filterChest = !character.settings.filterChest;
		updateButtons();
	}

	public void toggleLegsFilter()
	{
		character.settings.filterLegs = !character.settings.filterLegs;
		updateButtons();
	}

	public void toggleBootsFilter()
	{
		character.settings.filterBoots = !character.settings.filterBoots;
		updateButtons();
	}

	public void toggleWeaponFilter()
	{
		character.settings.filterWeapon = !character.settings.filterWeapon;
		updateButtons();
	}

	public void toggleAccessoryFilter()
	{
		character.settings.filterAccessory = !character.settings.filterAccessory;
		updateButtons();
	}

	public void toggleBoostAtkFilter()
	{
		character.settings.filterBoostAtk = !character.settings.filterBoostAtk;
		updateButtons();
	}

	public void toggleBoostSpecFilter()
	{
		character.settings.filterBoostSpec = !character.settings.filterBoostSpec;
		updateButtons();
	}

	public void toggleBoostDefFilter()
	{
		character.settings.filterBoostDef = !character.settings.filterBoostDef;
		updateButtons();
	}

	public void toggleMiscFilter()
	{
		character.settings.filterMisc = !character.settings.filterMisc;
		updateButtons();
	}

	public void updateButtons()
	{
		if (character.settings.filterHead)
		{
			head.image.color = Color.grey;
		}
		else
		{
			head.image.color = Color.white;
		}
		if (character.settings.filterChest)
		{
			chest.image.color = Color.grey;
		}
		else
		{
			chest.image.color = Color.white;
		}
		if (character.settings.filterLegs)
		{
			legs.image.color = Color.grey;
		}
		else
		{
			legs.image.color = Color.white;
		}
		if (character.settings.filterBoots)
		{
			boots.image.color = Color.grey;
		}
		else
		{
			boots.image.color = Color.white;
		}
		if (character.settings.filterWeapon)
		{
			weapon.image.color = Color.grey;
		}
		else
		{
			weapon.image.color = Color.white;
		}
		if (character.settings.filterAccessory)
		{
			accessory.image.color = Color.grey;
		}
		else
		{
			accessory.image.color = Color.white;
		}
		if (character.settings.filterMisc)
		{
			misc.image.color = Color.grey;
		}
		else
		{
			misc.image.color = Color.white;
		}
		if (character.settings.filterBoostAtk)
		{
			boostAtk.image.color = Color.grey;
		}
		else
		{
			boostAtk.image.color = Color.white;
		}
		if (character.settings.filterBoostDef)
		{
			boostDef.image.color = Color.grey;
		}
		else
		{
			boostDef.image.color = Color.white;
		}
		if (character.settings.filterBoostSpec)
		{
			boostSpec.image.color = Color.grey;
		}
		else
		{
			boostSpec.image.color = Color.white;
		}
	}

	private void Start()
	{
		updateButtons();
	}

	private void Update()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.showTooltip("WARNING: This will do nothing until you buy the Loot Filter in the Spend EXP menu!\n\nUse this to filter out certain types of items you hate clogging up your inventory. Dark means filtered, Light means you'll get the drop.");
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
