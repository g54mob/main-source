using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Paralyze : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	public float attackTimer;

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
			pc.paralyzeEnemy();
			pc.usedMove();
			attackTimer = 0f;
		}
	}

	public void Update()
	{
		float num = Mathf.Max(pc.moveTimer, character.paralyzeCooldown() - attackTimer);
		if (!pc.moveCheck())
		{
			button.interactable = false;
			return;
		}
		if (!character.allChallenges.hasParalyze())
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
		attackTimer += pc.timeDilation(Time.deltaTime);
		if (attackTimer > character.paralyzeCooldown() && pc.canUseMove)
		{
			button.interactable = true;
			buttonText.text = "Paralyze Gaze";
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
			tooltip.showTooltip("You have not yet unlocked this move yet. This move is unlocked by capping completions of the Basic Challenge! Don't know what that is yet? You will eventually, padawan.", (float)Screen.width * 0.5f, (float)Screen.height * 0.4f);
			return;
		}
		tooltip.showTooltip("<b>Paralyze Gaze [Z]</b>\n\nCooldown: " + character.paralyzeCooldown().ToString("##0.##") + "  seconds\nNot affected by Charge\nParalyzes Enemies for " + character.paralyzePower() + " seconds", (float)Screen.width * 0.5f, (float)Screen.height * 0.4f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
