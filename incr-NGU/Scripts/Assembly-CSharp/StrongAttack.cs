using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StrongAttack : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	private float strongAttackTimer;

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
			pc.strongAttack();
			pc.usedMove();
			strongAttackTimer = 0f;
			button.interactable = false;
		}
	}

	public void Update()
	{
		float num = Mathf.Max(pc.moveTimer, character.strongAttackCooldown() - strongAttackTimer);
		if (!pc.moveCheck())
		{
			button.interactable = false;
			return;
		}
		if (character.training.attackTraining[1] < 10000)
		{
			buttonText.text = "Locked";
			button.interactable = false;
			return;
		}
		if (pc.strongDisabled)
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
		strongAttackTimer += pc.timeDilation(Time.deltaTime);
		if (strongAttackTimer > character.strongAttackCooldown() && pc.canUseMove)
		{
			button.interactable = true;
			buttonText.text = "Strong Attack";
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
		tooltip.showTooltip("<b>Strong Attack [E]</b>\n\nCooldown: " + character.strongAttackCooldown().ToString("##0.##") + "  seconds\nAffected by Buffs\nAffected by Charge\nDamage multiplier of " + character.strongAttackPower(), (float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
