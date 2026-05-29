using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OhShit : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Character character;

	public PlayerController pc;

	public HoverTooltip tooltip;

	public Button button;

	public Text buttonText;

	public HyperRegen hyperRegen;

	public Paralyze paralyze;

	public Heal heal;

	public void OnPointerClick(PointerEventData eventData)
	{
		doMove();
	}

	public void doMove()
	{
		if (button.IsInteractable() && pc.moveCheck())
		{
			hyperRegen.doMove();
			paralyze.doMove();
			heal.doMove();
			pc.usedMove();
			button.interactable = false;
		}
	}

	public void Update()
	{
		if (!pc.moveCheck())
		{
			button.interactable = false;
			return;
		}
		float num = Mathf.Max(pc.moveTimer, character.hyperRegenCooldown() - hyperRegen.healTimer, character.healCooldown() - heal.healTimer, character.paralyzeCooldown() - paralyze.attackTimer);
		if (character.wishes.wishes[58].level < 1 || !character.allChallenges.hasParalyze() || character.training.defenseTraining[1] < 10000 || !character.settings.hasHyperRegen)
		{
			buttonText.text = "Locked";
			button.interactable = false;
		}
		else if (character.adventure.autoattacking)
		{
			buttonText.text = "Idle Mode";
			button.interactable = false;
		}
		else if (num <= 0f && pc.canUseMove)
		{
			button.interactable = true;
			buttonText.text = "OH SHIT!";
		}
		else
		{
			button.interactable = false;
			buttonText.text = num.ToString("#0.0") + " s";
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (buttonText.text == "Locked")
		{
			tooltip.showTooltip("You WISH you were cool enough to unlock this move.", (float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
		}
		else
		{
			tooltip.showTooltip("<b>OH SHIT! [B]</b>\n\nCan be used when Paralyze, Hyper Regen, and Heal are all off cooldown.\nPerforms Heal, Paralyze, and Hyper Regen simultaneously, buying you precious seconds of life!", (float)Screen.width * 0.5f, (float)Screen.height * 0.4f);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
