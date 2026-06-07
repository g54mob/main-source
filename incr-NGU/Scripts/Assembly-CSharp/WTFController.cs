using UnityEngine;
using UnityEngine.EventSystems;

public class WTFController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public HoverTooltip tooltip;

	public Character character;

	public int id;

	private string message;

	public void OnPointerEnter(PointerEventData eventData)
	{
		switch (id)
		{
		case 0:
			message = "";
			break;
		case 1:
			message = "";
			break;
		case 2:
			message = "<b>";
			if (character.magic.capMagic >= 10000)
			{
				message += "\n\n<b>Blood Magic Bonus:</b> The more power you generate from Blood Magic rituals, the higher this bonus will be! This bonus multiplies your NUMBER.";
			}
			break;
		case 3:
			message = "";
			break;
		case 4:
			message = "";
			break;
		case 5:
			message = "<b>";
			break;
		case 6:
			message = "<b>Rebirth</b>\n\n";
			break;
		case 7:
			message = "<b>Wandoos 98</b>\n\n";
			break;
		case 8:
			message = "<b>Advanced Training</b>\n\n";
			break;
		case 9:
			message = "<b>Spend EXP</b>\n\n";
			break;
		default:
			message = "Hey, 4g screwed something up, again!";
			break;
		}
		tooltip.showTooltip(message);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
