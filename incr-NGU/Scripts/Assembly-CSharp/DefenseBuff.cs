using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DefenseBuff : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	public float defenseBuffTimer;

	private float defenseDuration = 99f;

	public Character character;

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
			pc.buffDefense();
			pc.usedMove();
			defenseBuffTimer = 0f;
			defenseDuration = 0f;
			button.interactable = false;
			border.color = Color.yellow;
		}
	}

	public void Update()
	{
		defenseDuration += Time.deltaTime;
		if (!pc.moveCheck())
		{
			button.interactable = false;
			return;
		}
		float num = Mathf.Max(pc.moveTimer, character.defenseBuffCooldown() - defenseBuffTimer);
		if (character.training.defenseTraining[0] < 5000)
		{
			buttonText.text = "Locked";
			button.interactable = false;
			return;
		}
		if (pc.defBuffDisabled)
		{
			buttonText.text = "DISABLED";
			button.interactable = false;
			return;
		}
		if (defenseDuration >= character.defenseBuffDuration())
		{
			border.color = Color.clear;
		}
		if (character.adventure.autoattacking)
		{
			buttonText.text = "Idle Mode";
			button.interactable = false;
			return;
		}
		defenseBuffTimer += pc.timeDilation(Time.deltaTime);
		if (defenseBuffTimer > character.defenseBuffCooldown() && pc.canUseMove)
		{
			button.interactable = true;
			buttonText.text = "Defensive Buff";
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
		tooltip.showTooltip("<b>Defensive Buff [S]</b>\n\nCooldown: " + character.defenseBuffCooldown().ToString("##0.##") + "  seconds\nStacks with other buffs\nStacks with Block and Parry\nNot affected by Charge\nIncreases Defense by " + (character.defenseBuffPower() * 100f - 100f).ToString("###,###.0") + "%", (float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
