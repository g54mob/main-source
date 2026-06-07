using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Move69 : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	private float move69Timer;

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
			pc.move69();
			pc.usedMove();
			move69Timer = 0f;
			border.color = Color.yellow;
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
		float num = Mathf.Max(pc.moveTimer, character.move69Cooldown() - move69Timer);
		if (!character.adventure.move69Unlocked)
		{
			buttonText.text = "Locked";
			button.interactable = false;
			return;
		}
		border.color = Color.clear;
		move69Timer += Time.deltaTime;
		if (character.adventure.autoattacking)
		{
			buttonText.text = "Idle Mode";
			button.interactable = false;
		}
		else if (move69Timer > character.move69Cooldown())
		{
			button.interactable = true;
			buttonText.text = "MOVE 69";
		}
		else
		{
			button.interactable = false;
			buttonText.text = num.ToString("###0") + " s";
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			tooltip.showTooltip("You are UNWORTHY of this move.", (float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
		}
		else if (!character.adventure.move69Unlocked)
		{
			tooltip.showTooltip("You have not yet proven yourself worthy of this move. The answer lies with <b>Lemmiwinks</b>.", (float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
		}
		else
		{
			tooltip.showTooltip("<b>MOVE 69</b>\n\nCooldown: " + character.move69Cooldown().ToString("#,##0") + "  seconds.\nPerforms $#fRHe+7!!k_=;\nERROR CS0103 IN MOVE69.CS:91: THE END DOES NOT EXIST IN THE CURRENT CONTEXT", (float)Screen.width * 0.5f, (float)Screen.height * 0.4f);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
