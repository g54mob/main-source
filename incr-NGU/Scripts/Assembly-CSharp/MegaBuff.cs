using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MegaBuff : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	private float megaBuffTimer;

	private float megaBuffDuration = 99f;

	public Character character;

	public OffenseBuff offenseBuff;

	public DefenseBuff defenseBuff;

	public UltimateBuff ultiBuff;

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
			offenseBuff.doMove();
			defenseBuff.doMove();
			ultiBuff.doMove();
			pc.megaBuff();
			pc.usedMove();
			megaBuffTimer = 0f;
			megaBuffDuration = 0f;
			border.color = Color.yellow;
			button.interactable = false;
		}
	}

	public void Update()
	{
		megaBuffDuration += Time.deltaTime;
		if (!pc.moveCheck())
		{
			button.interactable = false;
			return;
		}
		float num = Mathf.Max(pc.moveTimer, character.megaBuffCooldown() - megaBuffTimer, character.offenseBuffCooldown() - offenseBuff.offenseBuffTimer, character.defenseBuffCooldown() - defenseBuff.defenseBuffTimer, character.ultimateBuffCooldown() - ultiBuff.ultimateBuffTimer);
		if (character.training.defenseTraining[4] < 25000 || character.wishes.wishes[8].level < 1)
		{
			buttonText.text = "Locked";
			button.interactable = false;
			return;
		}
		if (pc.megaBuffDisabled)
		{
			buttonText.text = "DISABLED";
			button.interactable = false;
			return;
		}
		if (megaBuffDuration > character.megaBuffDuration())
		{
			border.color = Color.clear;
		}
		if (character.adventure.autoattacking)
		{
			buttonText.text = "Idle Mode";
			button.interactable = false;
			return;
		}
		megaBuffTimer += pc.timeDilation(Time.deltaTime);
		if (megaBuffTimer > character.megaBuffCooldown() && offenseBuff.offenseBuffTimer > character.offenseBuffCooldown() && defenseBuff.defenseBuffTimer > character.defenseBuffCooldown() && ultiBuff.ultimateBuffTimer > character.ultimateBuffCooldown() && pc.canUseMove)
		{
			button.interactable = true;
			buttonText.text = "Mega Buff";
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
			tooltip.showTooltip("You WISH you were cool enough to unlock this move.", (float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
		}
		else
		{
			tooltip.showTooltip("<b>Mega Buff [V]</b>\n\nCooldown: " + character.megaBuffCooldown().ToString("##0.##") + "  seconds. All other buffs must also be off cooldown.\nPerforms Offensive Buff, Defensive Buff, and Ultimate Buff simultaneously, plus 20% extra buffage!", (float)Screen.width * 0.5f, (float)Screen.height * 0.4f);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
