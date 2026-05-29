using UnityEngine;
using UnityEngine.UI;

public class SpecialController : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public Image kitty;

	private void Start()
	{
	}

	public void refreshMenu()
	{
		if (character.menuID == 45)
		{
			if (character.purchases.choseKitty)
			{
				kitty.gameObject.SetActive(value: true);
			}
			else
			{
				kitty.gameObject.SetActive(value: false);
			}
		}
	}

	public void chooseKitty()
	{
		if (character.purchases.hasSpecialPrize1)
		{
			tooltip.showOverrideTooltip("Nice try, greedypants.", 2f);
			return;
		}
		character.arbitrary.curArbitraryPoints += 50000L;
		tooltip.showOverrideTooltip("PRETTY KITTY HAS APPEARED! She blesses you with 50,000 AP anyways! Thank you for being a friend :3", 2f);
		character.purchases.hasSpecialPrize1 = true;
		character.purchases.choseKitty = true;
		refreshMenu();
	}

	public void chooseAP()
	{
		if (character.purchases.hasSpecialPrize1)
		{
			tooltip.showOverrideTooltip("Nice try, greedypants.", 2f);
			return;
		}
		character.purchases.hasSpecialPrize1 = true;
		character.purchases.choseKitty = false;
		character.arbitrary.curArbitraryPoints += 50000L;
		tooltip.showOverrideTooltip("50,000 AP has been awarded! Thank you for being a friend.", 2f);
	}
}
