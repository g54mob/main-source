using UnityEngine;
using UnityEngine.UI;

public class BestiaryIconController : MonoBehaviour
{
	public Character character;

	public Image bestiaryIconSprite;

	public GameObject icon;

	public int id;

	public void updateIcon()
	{
		if (character.menuID != 24)
		{
			return;
		}
		if (id <= 0 || id >= character.adventureController.enemySprites.Count)
		{
			icon.SetActive(value: false);
			return;
		}
		icon.SetActive(value: true);
		if (unlocked(id))
		{
			if (id == 192)
			{
				bestiaryIconSprite.sprite = character.adventureController.enemySprites[197];
			}
			else if (id == 197)
			{
				bestiaryIconSprite.sprite = character.adventureController.enemySprites[192];
			}
			else
			{
				bestiaryIconSprite.sprite = character.adventureController.enemySprites[id];
			}
		}
		else
		{
			bestiaryIconSprite.sprite = character.adventureController.enemySprites[0];
		}
	}

	public void selected()
	{
		if (id >= 0 && id <= character.bestiary.enemies.Count)
		{
			if (unlocked(id))
			{
				character.bestiaryController.selectNewEnemy(id);
			}
			else
			{
				character.tooltip.showTooltip("OI, you haven't unlocked this Bestiary entry yet! You have to encounter and defeat whatever this is in Adventure to see what it is. No looksies!", 8f);
			}
		}
	}

	public bool unlocked(int id)
	{
		if (id <= 0 || id >= character.adventureController.enemySprites.Count)
		{
			return false;
		}
		if (character.bestiary.enemies[id].kills <= 0)
		{
			if (id > 0 && id <= 150 && character.highestBoss >= id)
			{
				return true;
			}
			if (id > 150 && id <= 200 && character.highestHardBoss >= id)
			{
				return true;
			}
			if (id > 200 && id <= 301 && character.highestSadisticBoss >= id)
			{
				return true;
			}
			return false;
		}
		return true;
	}
}
