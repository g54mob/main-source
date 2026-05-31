using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RegularAttack : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	private float regularAttackTimer;

	public Character character;

	public PlayerController pc;

	public Button button;

	public Text buttonText;

	public HoverTooltip tooltip;

	public void OnPointerClick(PointerEventData eventData)
	{
		doMove();
	}

	public void doMove()
	{
		if (button.IsInteractable() && pc.moveCheck())
		{
			pc.regularAttack();
			regularAttackTimer = 0f;
			pc.usedMove();
			button.interactable = false;
		}
	}

	public void Update()
	{
		float num = Math.Max(pc.moveTimer, character.regAttackCooldown() - regularAttackTimer);
		if (!pc.moveCheck())
		{
			button.interactable = false;
			return;
		}
		if (character.training.attackTraining[0] < 5000)
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
		regularAttackTimer += pc.timeDilation(Time.deltaTime);
		if (regularAttackTimer > character.regAttackCooldown() && pc.canUseMove)
		{
			button.interactable = true;
			buttonText.text = "Regular Attack";
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
		tooltip.showTooltip("<b>Regular Attack [W]</b>\n\nCooldown: " + character.regAttackCooldown().ToString("##0.##") + " seconds\nAffected by Buffs\nAffected by Charge\nDamage multiplier of " + character.regAttackPower(), (float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
