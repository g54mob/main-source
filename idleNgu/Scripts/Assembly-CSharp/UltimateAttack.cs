using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UltimateAttack : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	private float ultimateAttackTimer;

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
			pc.ultimateAttack();
			pc.usedMove();
			ultimateAttackTimer = 0f;
			button.interactable = false;
		}
	}

	public void Update()
	{
		float num = Mathf.Max(pc.moveTimer, character.ultimateAttackCooldown() - ultimateAttackTimer);
		if (!pc.moveCheck())
		{
			button.interactable = false;
			return;
		}
		if (character.training.attackTraining[4] < 25000)
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
		if (pc.ultimateDisabled)
		{
			buttonText.text = "DISABLED";
			button.interactable = false;
			return;
		}
		ultimateAttackTimer += pc.timeDilation(Time.deltaTime);
		if (ultimateAttackTimer > character.ultimateAttackCooldown() && pc.canUseMove)
		{
			button.interactable = true;
			buttonText.text = "Ultimate Attack";
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
		tooltip.showTooltip("<b>Ultimate Attack [Y]</b>\n\nCooldown: " + character.ultimateAttackCooldown().ToString("##0.##") + "  seconds\nAffected by Buffs\nAffected by Charge\nDamage multiplier increases with highest Boss defeated\nDamage multiplier of " + character.ultimateAttackPower(), (float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
