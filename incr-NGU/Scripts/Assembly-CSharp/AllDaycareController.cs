using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllDaycareController : MonoBehaviour
{
	public Character character;

	public GameObject anchor;

	public GameObject panel;

	public Button button;

	public Text titleText;

	public Image kitty;

	public List<Sprite> kittySprites;

	private void Start()
	{
		hidePanel();
	}

	private void Update()
	{
		if (character.menuID == 4)
		{
			if (character.purchases.hasDaycare)
			{
				button.gameObject.SetActive(value: true);
			}
			else
			{
				button.gameObject.SetActive(value: false);
			}
		}
	}

	public void kiityTooltip()
	{
		if (character.platform == platform.Kong)
		{
			character.tooltip.showTooltip("Badly Drawn Kitty says that if you rate NGU 5 stars she will be super happy! You should make kitty happy.");
		}
		else if (character.platform == platform.AG)
		{
			character.tooltip.showTooltip("Badly Drawn Kitty says that if you give NGU Idle a high rating she will be super happy! You should make kitty happy.");
		}
		else if (character.platform == platform.Steam)
		{
			character.tooltip.showTooltip("Badly Drawn Kitty says that if you give NGU Idle a kind review on Steam she will be super happy! You should make kitty happy. :)");
		}
	}

	public float daycareTime(Equipment item)
	{
		float num = character.itemInfo.daycareRate[item.id];
		float num2 = 1f;
		if (character.allChallenges.blindChallenge.completions() >= 1)
		{
			num2 -= 0.05f;
		}
		num2 -= (float)character.allChallenges.blindChallenge.completions() * 0.01f;
		if (num2 < 0.85f)
		{
			num2 = 0.85f;
		}
		num *= num2;
		num *= 1f - (float)character.adventure.itopod.perkLevel[27] * character.adventureController.itopod.effectPerLevel[27];
		num *= 1f - (float)character.adventure.itopod.perkLevel[28] * character.adventureController.itopod.effectPerLevel[28];
		if (character.arbitrary.hasDaycareSpeed)
		{
			num *= 0.9f;
		}
		return num;
	}

	public void showPanel()
	{
		character.inventoryController.hideMacguffinPanel();
		panel.transform.position = anchor.transform.position;
		character.inventoryController.loadoutsController.hidePanel();
		character.inventoryController.daycareUp = true;
		if (Random.value < 0.01f)
		{
			titleText.text = "ITEM RAVE WOOOO";
		}
		else
		{
			titleText.text = "Item Daycare";
		}
	}

	public void hidePanel()
	{
		panel.transform.position = new Vector3(-5000f, -5000f);
		character.inventoryController.daycareUp = false;
	}

	public void updateKitty()
	{
		if (character.purchases.choseKitty)
		{
			character.inventory.unlockedKittyArt[1] = true;
		}
		if (character.inventory.kittyArt < 0 || character.inventory.kittyArt > kittySprites.Count)
		{
			character.inventory.kittyArt = 0;
			kitty.sprite = kittySprites[character.inventory.kittyArt];
		}
		else
		{
			kitty.sprite = kittySprites[character.inventory.kittyArt];
		}
	}

	public void advanceKitty()
	{
		character.inventory.kittyArt++;
		if (character.inventory.kittyArt >= character.inventory.unlockedKittyArt.Count)
		{
			character.inventory.kittyArt = 0;
		}
		if (character.inventory.kittyArt >= kittySprites.Count)
		{
			character.inventory.kittyArt = 0;
		}
		while (character.inventory.kittyArt != 0 && !character.inventory.unlockedKittyArt[character.inventory.kittyArt])
		{
			character.inventory.kittyArt++;
			if (character.inventory.kittyArt >= character.inventory.unlockedKittyArt.Count)
			{
				character.inventory.kittyArt = 0;
			}
			if (character.inventory.kittyArt >= kittySprites.Count)
			{
				character.inventory.kittyArt = 0;
			}
		}
		updateKitty();
	}
}
