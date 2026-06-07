using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipDisplay : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public int id;

	public HoverTooltip tooltip;

	public Character character;

	private string message;

	public string altMessage;

	public void Start()
	{
		string[] array = (Resources.Load("TooltipText") as TextAsset).text.Split(new string[1] { "\n/////" }, StringSplitOptions.RemoveEmptyEntries);
		if (id < 1000)
		{
			message = array[id];
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (id == 1000)
		{
			tooltip.showTooltip(altMessage);
		}
		else if (id == 1001)
		{
			tooltip.showTooltip("Buying this will make the " + character.res3.res3Name + " bar fill up faster. Max speed is 1 bar fill per tick, or 50 fills/second. NOTE: the bar fills at a rate of (50 / " + character.res3.res3Name + " Speed) ticks per fill, rounded up! Later on, you'll want to buy this upgrade in chunks such as 25=>50 speed, in order to gain any effect!");
		}
		else if (id == 1002)
		{
			tooltip.showTooltip("This upgrade improves the effectiveness of your allocated " + character.res3.res3Name + ". This means faster progress on features that you allocate " + character.res3.res3Name + " to!");
		}
		else if (id == 1003)
		{
			tooltip.showTooltip("Wish your " + character.res3.res3Name + " Cap was higher? Buy these upgrades!");
		}
		else if (id == 1004)
		{
			tooltip.showTooltip("Got your " + character.res3.res3Name + " bar filling as fast as possible and it STILL isn't enough? Fine, buy these upgrades, and you'll gain more " + character.res3.res3Name + " every time the bar fills!");
		}
		else
		{
			tooltip.showTooltip(message);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
