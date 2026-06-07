using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PiercingAttack : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	private float attackTimer;

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
		if (pc.moveCheck() && button.IsInteractable())
		{
			pc.pierceAttack();
			pc.usedMove();
			attackTimer = 0f;
			button.interactable = false;
		}
	}

	public void Update()
	{
		float num = Mathf.Max(pc.moveTimer, character.pierceAttackCooldown() - attackTimer);
		if (!pc.moveCheck())
		{
			button.interactable = false;
			return;
		}
		if (character.training.attackTraining[3] < 20000)
		{
			buttonText.text = "Locked";
			button.interactable = false;
			return;
		}
		if (pc.pierceDisabled)
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
		attackTimer += pc.timeDilation(Time.deltaTime);
		if (attackTimer > character.pierceAttackCooldown() && pc.canUseMove)
		{
			button.interactable = true;
			buttonText.text = "Piercing Attack";
		}
		else
		{
			buttonText.text = num.ToString("#0.0") + " s";
			button.interactable = false;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (buttonText.text == "Locked")
		{
			tooltip.showTooltip("You have not yet unlocked this move. When you unlock new trainings in Attack and Defense, you also unlock these moves so... go train some more!", (float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
			return;
		}
		tooltip.showTooltip("<b>Piercing Attack [T]</b>\n\nPierces through 33% of enemy's defense\nCooldown: " + character.pierceAttackCooldown().ToString("##0.##") + "  seconds\nAffected by Buffs\nAffected by Charge\nDamage multiplier of " + character.pierceAttackPower(), (float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
