using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BeastMode : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	private float attackTimer;

	public Character character;

	public PlayerController pc;

	public Button button;

	public Image border;

	public Text buttonText;

	public HoverTooltip tooltip;

	public void OnPointerClick(PointerEventData eventData)
	{
		doMove();
	}

	public void doMove()
	{
		if (pc.moveCheck() && button.IsInteractable())
		{
			pc.toggleBeastMode();
			pc.usedMove();
			attackTimer = 0f;
		}
	}

	public void Update()
	{
		float num = Mathf.Max(pc.moveTimer, character.beastModeCooldown() - attackTimer);
		if (character.adventure.beastModeOn)
		{
			border.color = Color.yellow;
		}
		else
		{
			border.color = Color.clear;
		}
		if (!pc.moveCheck())
		{
			button.interactable = false;
			return;
		}
		if (!character.adventureController.hasBeastMode())
		{
			buttonText.text = "Locked";
			button.interactable = false;
			return;
		}
		if (character.adventure.autoattacking)
		{
			buttonText.text = "Idle Mode";
			button.interactable = false;
			return;
		}
		attackTimer += pc.timeDilation(Time.deltaTime);
		if (attackTimer > character.beastModeCooldown() && pc.canUseMove)
		{
			button.interactable = true;
			buttonText.text = "BEAST MODE";
		}
		else
		{
			button.interactable = false;
			buttonText.text = num.ToString("#0.0") + " s";
		}
	}

	public string beastModeBonus()
	{
		if (character.inventory.itemList.purpleLiquidComplete)
		{
			return "50%";
		}
		return "40%";
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (buttonText.text == "Locked")
		{
			tooltip.showTooltip("You have not yet unlocked this move yet. This move is unlocked by defeating a Mighty Beast! Don't know what that is yet? You will eventually, padawan.", (float)Screen.width * 0.5f, (float)Screen.height * 0.4f);
			return;
		}
		tooltip.showTooltip("<b>BEAST MODE [C]</b>\n\nCooldown: " + character.beastModeCooldown() + "  seconds\nNot affected by Charge\nActivates/Deactivates BEAST MODE, which increases your Power stat by " + beastModeBonus() + ", however you will receive 300% damage from all sources! Use carefully!", (float)Screen.width * 0.5f, (float)Screen.height * 0.4f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
