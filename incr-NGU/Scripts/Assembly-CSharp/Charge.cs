using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Charge : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Character character;

	private float chargeTimer;

	public PlayerController pc;

	public HoverTooltip tooltip;

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
			pc.charge();
			pc.usedMove();
			chargeTimer = 0f;
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
		float num = Mathf.Max(pc.moveTimer, character.chargeCooldown() - chargeTimer);
		if (pc.chargeFactor == 1f)
		{
			border.color = Color.clear;
		}
		else
		{
			border.color = Color.yellow;
		}
		if (character.training.defenseTraining[3] < 20000)
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
		chargeTimer += pc.timeDilation(Time.deltaTime);
		if (chargeTimer > character.chargeCooldown() && pc.canUseMove)
		{
			button.interactable = true;
			buttonText.text = "Charge";
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
		tooltip.showTooltip("<b>Charge [G]</b>\n\nCooldown: " + character.chargeCooldown() + " seconds\nNot Affected by Charge (You'd destroy the universe if it did!)\nIncreases the effect of the next move by a factor of " + character.chargePower().ToString("###,###.00"), (float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
