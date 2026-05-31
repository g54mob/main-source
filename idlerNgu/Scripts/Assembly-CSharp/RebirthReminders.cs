using UnityEngine;
using UnityEngine.EventSystems;

public class RebirthReminders : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	private string message;

	public void OnPointerEnter(PointerEventData eventData)
	{
		message = "";
		if (character.settings.pitUnlocked && !character.pit.tossedGold && character.realGold > 1000.0 && character.pit.pitTime.totalseconds >= (double)character.pitController.currentPitTime())
		{
			message += "The Money Pit is ready to toss your gold into!";
		}
		message += yggdrasilCheck();
		if (character.bloodMagic.bloodPoints > 0.0 && !character.bloodMagicController.spells.castingAutoSpells())
		{
			message = message + "\nYou have " + character.display(character.bloodMagic.bloodPoints) + " Blood left to spend!";
		}
		if (character.bossID >= 58 && character.adventure.boss1Spawn.seconds >= (double)character.adventureController.boss1SpawnTime())
		{
			message += "\nGordon Ramsay Bolton is still available to fight!";
		}
		if (character.bossID >= 66 && character.adventure.boss2Spawn.seconds >= (double)character.adventureController.boss2SpawnTime())
		{
			message += "\nGrand Corrupted Tree is still available to fight!";
		}
		if (character.bossID >= 82 && character.adventure.boss3Spawn.seconds >= (double)character.adventureController.boss3SpawnTime())
		{
			message += "\nJake From Accounting is still available to fight!";
		}
		if (message == "")
		{
			message = "There's nothing you need to do! Go ahead and rebirth!";
		}
		tooltip.showTooltip(message);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}

	public string yggdrasilCheck()
	{
		for (int i = 0; i < character.yggdrasil.fruits.Count; i++)
		{
			if (character.yggdrasil.fruits[i].harvestTier() >= 1)
			{
				return "\nYou have fruit ready to be harvested!";
			}
		}
		return "";
	}
}
