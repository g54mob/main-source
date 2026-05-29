using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Heal : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
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
			pc.heal();
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
		float num = Math.Max(pc.moveTimer, character.healCooldown() - healTimer);
		if (character.training.defenseTraining[1] < 10000)
		{
			buttonText.text = "Locked";
			button.interactable = false;
			return;
		}
		if (pc.healDisabled)
		{
			buttonText.text = "DISABLED";
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
		if (healTimer > character.healCooldown() && pc.canUseMove)
		{
			button.interactable = true;
			buttonText.text = "Heal";
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
			tooltip.showTooltip("You have not yet unlocked this move. When you unlock new trainings in Attack and Defense, you also unlock these moves so... go train some more!", (float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
			return;
		}
		tooltip.showTooltip("<b>Heal [D]</b>\n\nCooldown: " + character.adventureController.healCooldown.ToString("##0.##") + " seconds\nNot Affected by Charge\nHeals " + (character.adventureController.healMulti * 100f).ToString("#0") + "% of your max HP.", (float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
