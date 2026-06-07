using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UltimateBuff : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	public float ultimateBuffTimer;

	private float ultimateBuffDuration = 99f;

	public Character character;

	public PlayerController pc;

	public Button button;

	public Image border;

	public HoverTooltip tooltip;

	public Text buttonText;

	public void OnPointerClick(PointerEventData eventData)
	{
		doMove();
	}

	public void doMove()
	{
		if (button.IsInteractable() && pc.moveCheck())
		{
			pc.buffUltimate();
			pc.usedMove();
			ultimateBuffTimer = 0f;
			ultimateBuffDuration = 0f;
			border.color = Color.yellow;
			button.interactable = false;
		}
	}

	public void Update()
	{
		ultimateBuffDuration += Time.deltaTime;
		if (!pc.moveCheck())
		{
			button.interactable = false;
			return;
		}
		float num = Mathf.Max(pc.moveTimer, character.ultimateBuffCooldown() - ultimateBuffTimer);
		if (character.training.defenseTraining[4] < 25000)
		{
			buttonText.text = "Locked";
			button.interactable = false;
			return;
		}
		if (pc.ultiBuffDisabled)
		{
			buttonText.text = "DISABLED";
			button.interactable = false;
			return;
		}
		if (ultimateBuffDuration > character.ultimateBuffDuration())
		{
			border.color = Color.clear;
		}
		if (character.adventure.autoattacking)
		{
			buttonText.text = "Idle Mode";
			button.interactable = false;
			return;
		}
		ultimateBuffTimer += pc.timeDilation(Time.deltaTime);
		if (ultimateBuffTimer > character.ultimateBuffCooldown() && pc.canUseMove)
		{
			button.interactable = true;
			buttonText.text = "Ultimate Buff";
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
		tooltip.showTooltip("<b>Ultimate Buff [H]</b>\n\nCooldown: " + character.ultimateBuffCooldown().ToString("##0.##") + "  seconds\nStacks with other buffs\nStacks with Block and Parry\nNot affected by Charge\nIncreases Power and Toughness by " + (character.ultimateBuffPower() * 100f - 100f).ToString("###,###.0") + "%", (float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
