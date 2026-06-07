using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Block : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	private float blockTimer;

	private float blockDuration;

	public PlayerController pc;

	public Character character;

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
			pc.block();
			blockTimer = 0f;
			blockDuration = 0f;
			button.interactable = false;
			border.color = Color.yellow;
			pc.usedMove();
		}
	}

	public void Update()
	{
		blockDuration += Time.deltaTime;
		if (!pc.moveCheck())
		{
			button.interactable = false;
			return;
		}
		float num = Mathf.Max(pc.moveTimer, character.blockCooldown() - blockTimer);
		if (blockDuration > character.blockDuration())
		{
			border.color = Color.clear;
		}
		if (character.adventure.autoattacking)
		{
			buttonText.text = "Idle Mode";
			button.interactable = false;
			return;
		}
		blockTimer += pc.timeDilation(Time.deltaTime);
		if (blockTimer > character.blockCooldown() && pc.canUseMove)
		{
			button.interactable = true;
			buttonText.text = "Block";
		}
		else
		{
			button.interactable = false;
			buttonText.text = num.ToString("#0.0") + " s";
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.showTooltip("<b>Block [A]</b>\n\nCooldown: " + character.blockCooldown().ToString("##0.##") + " seconds\nStacks with Buffs\nAffected by Charge\nBlocks " + (100f - 100f / character.blockPower()).ToString("##.0") + "% of incoming damage for the next 3 seconds.", (float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
