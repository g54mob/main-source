using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HyperRegen : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Character character;

	public float healTimer;

	public PlayerController pc;

	public HoverTooltip tooltip;

	public Button button;

	public Text buttonText;

	public void OnPointerClick(PointerEventData eventData)
	{
		doMove();
	}

	public void doMove()
	{
		if (button.IsInteractable() && pc.moveCheck())
		{
			pc.hyperRegen();
			pc.usedMove();
			healTimer = 0f;
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
		float num = Math.Max(pc.moveTimer, character.hyperRegenCooldown() - healTimer);
		if (!character.settings.hasHyperRegen)
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
		healTimer += pc.timeDilation(Time.deltaTime);
		if (healTimer > character.hyperRegenCooldown() && pc.canUseMove)
		{
			button.interactable = true;
			buttonText.text = "Hyper Regen";
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
			tooltip.showTooltip("You have not yet unlocked this special move! How do you unlock it? That's a secret!", (float)Screen.width * 0.5f, (float)Screen.height * 0.4f);
		}
		else
		{
			tooltip.showTooltip("<b>Hyper Regen [X]</b>\n\nCooldown: " + character.hyperRegenCooldown().ToString("##0.##") + " seconds\nNot affected by Charge\nMultiplies your HP regen by 500%, for 5 seconds", (float)Screen.width * 0.5f, (float)Screen.height * 0.4f);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
