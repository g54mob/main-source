using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Parry : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	private float parryTimer;

	public Character character;

	public HoverTooltip tooltip;

	public Image border;

	public PlayerController pc;

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
			pc.parry();
			pc.usedMove();
			parryTimer = 0f;
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
		float num = Mathf.Max(pc.moveTimer, character.parryCooldown() - parryTimer);
		if (pc.isParrying)
		{
			border.color = Color.yellow;
		}
		else
		{
			border.color = Color.clear;
		}
		if (character.training.attackTraining[2] < 15000)
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
		parryTimer += Time.deltaTime;
		if (parryTimer > character.parryCooldown() && pc.canUseMove)
		{
			button.interactable = true;
			buttonText.text = "Parry";
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
		tooltip.showTooltip("<b>Parry [R]</b>\n\nCooldown: " + character.parryCooldown().ToString("##0.##") + " seconds\nStacks with Buffs\nAffected by Charge\nBlocks next attack damage by " + (100f - 100f / character.parryPower()).ToString("##.00") + "%", (float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
