using UnityEngine;
using UnityEngine.EventSystems;

public class BossInfoDisplay : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public Boss boss;

	public NumberFormat numberFormat;

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (character.bossID < character.bossController.bossProperties.Count)
		{
			string message = character.bossController.getBossName(character.bossID) + " (" + (character.bossID + 1) + ")\nAttack: " + numberFormat.suffixFormat(character.bossAttack) + "\nDefense: " + numberFormat.suffixFormat(character.bossDefense) + "\nMax HP: " + numberFormat.suffixFormat(character.bossMaxHP);
			if (!character.challenges.blindChallenge.inChallenge)
			{
				tooltip.showTooltip(message);
			}
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
