using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IdleAttack : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Button button;

	public Image Border;

	public Character character;

	public PlayerController pc;

	public HoverTooltip tooltip;

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.showTooltip("<b>Idle Attack [Q]</b>\n\nClick to Toggle Idle Mode On/Off.\nWhen on, automatically attacks every " + character.adventure.attackSpeed.ToString("0.0") + " seconds\nWhile on, Health Regen +20%\nWhile on, cannot use any other moves.\nDamage multiplier of " + character.idleAttackPower(), (float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}

	public void Update()
	{
		if (character.menuID == 3)
		{
			if (character.adventure.autoattacking)
			{
				button.GetComponentInChildren<Text>().text = "<b>Idle Mode ON</b>";
			}
			else
			{
				button.GetComponentInChildren<Text>().text = "Idle Mode OFF";
			}
		}
	}

	public void setToggle()
	{
		if (pc.moveCheck())
		{
			character.adventure.autoattacking = !character.adventure.autoattacking;
			if (character.adventure.autoattacking)
			{
				pc.usedMove();
				pc.moveTimer = 1f;
				Border.color = Color.yellow;
			}
			else
			{
				Border.color = Color.clear;
			}
		}
	}

	public void checkIdleAttackState()
	{
		if (character.adventure.autoattacking)
		{
			Border.color = Color.yellow;
		}
		else
		{
			Border.color = Color.clear;
		}
	}
}
