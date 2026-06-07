using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OffenseBuff : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Character character;

	public float offenseBuffTimer;

	public float offenseBuffDuration;

	public HoverTooltip tooltip;

	public PlayerController pc;

	public Image border;

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
			pc.buffOffense();
			pc.usedMove();
			offenseBuffTimer = 0f;
			offenseBuffDuration = 0f;
			border.color = Color.yellow;
			button.interactable = false;
		}
	}

	public void Update()
	{
		offenseBuffDuration += Time.deltaTime;
		if (!pc.moveCheck())
		{
			button.interactable = false;
			return;
		}
		float num = Mathf.Max(pc.moveTimer, character.offenseBuffCooldown() - offenseBuffTimer);
		if (character.training.defenseTraining[2] < 15000)
		{
			buttonText.text = "Locked";
			button.interactable = false;
			return;
		}
		if (pc.offBuffDisabled)
		{
			buttonText.text = "DISABLED";
			button.interactable = false;
			return;
		}
		if (offenseBuffDuration > character.offenseBuffDuration())
		{
			border.color = Color.clear;
		}
		if (character.adventure.autoattacking)
		{
			buttonText.text = "Idle Mode";
			button.interactable = false;
			return;
		}
		offenseBuffTimer += pc.timeDilation(Time.deltaTime);
		buttonText.text = num.ToString("#0.0") + " s";
		if (offenseBuffTimer > character.offenseBuffCooldown() && pc.canUseMove)
		{
			button.interactable = true;
			buttonText.text = "Offensive Buff";
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
		tooltip.showTooltip("<b>Offensive Buff [F]</b>\n\nCooldown: " + character.offenseBuffCooldown().ToString("##0.##") + "  seconds\nStacks with other buffs\nStacks with Block and Parry\nNot affected by Charge\nIncreases Power by " + (character.offenseBuffPower() * 100f - 100f).ToString("###,###.0") + "%", (float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
