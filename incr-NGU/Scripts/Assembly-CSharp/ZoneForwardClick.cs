using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoneForwardClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public Character character;

	public AdventureController ac;

	public HoverTooltip tooltip;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			goToMaxZone();
		}
		else
		{
			tryZoneForward();
		}
	}

	public void tryZoneForward()
	{
		if (ac.zone >= 1000)
		{
			return;
		}
		Debug.Log(ac.zone);
		Debug.Log(ac.enemyList.Count - 1);
		Debug.Log(character.effectiveBossID());
		if (ac.zone >= ac.enemyList.Count - 1)
		{
			return;
		}
		Debug.Log(ac.zone);
		if (ac.zone >= 0 && character.effectiveBossID() < 7)
		{
			tooltip.showTooltip("You need to defeat Boss 7 in the Fight Boss menu to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 1 && character.effectiveBossID() < 17)
		{
			tooltip.showTooltip("You need to defeat Boss 17 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 2 && character.effectiveBossID() < 37)
		{
			tooltip.showTooltip("You need to defeat Boss 37 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 3 && character.effectiveBossID() < 48)
		{
			tooltip.showTooltip("You need to defeat Boss 48 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 4 && character.effectiveBossID() < 58)
		{
			tooltip.showTooltip("You need to defeat Boss 58 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 5 && character.effectiveBossID() < 58)
		{
			tooltip.showTooltip("You need to defeat Boss 58 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 6 && character.effectiveBossID() < 66)
		{
			tooltip.showTooltip("You need to defeat Boss 66 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 7 && character.effectiveBossID() < 66)
		{
			tooltip.showTooltip("You need to defeat Boss 66 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 8 && character.effectiveBossID() < 74)
		{
			tooltip.showTooltip("You need to defeat Boss 74 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 9 && character.effectiveBossID() < 82)
		{
			tooltip.showTooltip("You need to defeat Boss 82 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 10 && character.effectiveBossID() < 82)
		{
			tooltip.showTooltip("You need to defeat Boss 82 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 11 && character.effectiveBossID() < 90)
		{
			tooltip.showTooltip("You need to defeat Boss 90 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 12 && character.effectiveBossID() < 100)
		{
			tooltip.showTooltip("You need to defeat Boss 100 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 13 && character.effectiveBossID() < 100)
		{
			tooltip.showTooltip("You need to defeat Boss 100 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 14 && character.effectiveBossID() < 108)
		{
			tooltip.showTooltip("You need to defeat Boss 108 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 15 && character.effectiveBossID() < 116)
		{
			tooltip.showTooltip("You need to defeat Boss 116 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 16 && character.effectiveBossID() < 116)
		{
			tooltip.showTooltip("You need to defeat Boss 116 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 17 && character.effectiveBossID() < 124)
		{
			tooltip.showTooltip("You need to defeat Boss 124 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 18 && character.effectiveBossID() < 132)
		{
			tooltip.showTooltip("You need to defeat Boss 132 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 19 && character.effectiveBossID() < 137)
		{
			tooltip.showTooltip("You need to defeat Boss 137 to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 20 && character.effectiveBossID() < 359)
		{
			tooltip.showTooltip("You need to defeat Boss 58 on Evil to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 21 && character.effectiveBossID() < 401)
		{
			tooltip.showTooltip("You need to defeat Boss 100 on Evil to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 22 && character.effectiveBossID() < 426)
		{
			tooltip.showTooltip("You need to defeat Boss 125 on Evil to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 23 && character.effectiveBossID() < 459)
		{
			tooltip.showTooltip("You need to defeat Boss 158 on Evil to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 24 && character.effectiveBossID() < 467)
		{
			tooltip.showTooltip("You need to defeat Boss 166 on Evil to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 25 && character.effectiveBossID() < 467)
		{
			tooltip.showTooltip("You need to defeat Boss 166 on Evil to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 26 && character.effectiveBossID() < 475)
		{
			tooltip.showTooltip("You need to defeat Boss 174 on Evil to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 27 && character.effectiveBossID() < 483)
		{
			tooltip.showTooltip("You need to defeat Boss 182 on Evil to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 28 && character.effectiveBossID() < 491)
		{
			tooltip.showTooltip("You need to defeat Boss 190 on Evil to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 29 && character.effectiveBossID() < 491)
		{
			tooltip.showTooltip("You need to defeat Boss 190 on Evil to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 30 && character.effectiveBossID() < 501)
		{
			tooltip.showTooltip("You need to defeat Boss 200 on Evil to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 31 && character.effectiveBossID() < 727)
		{
			tooltip.showTooltip("You need to defeat Boss 125 on Sadistic to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 32 && character.effectiveBossID() < 752)
		{
			tooltip.showTooltip("You need to defeat Boss 150 on Sadistic to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 33 && character.effectiveBossID() < 777)
		{
			tooltip.showTooltip("You need to defeat Boss 175 on Sadistic to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 34 && character.effectiveBossID() < 810)
		{
			tooltip.showTooltip("You need to defeat Boss 208 on Sadistic to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 35 && character.effectiveBossID() < 818)
		{
			tooltip.showTooltip("You need to defeat Boss 216 on Sadistic to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 36 && character.effectiveBossID() < 826)
		{
			tooltip.showTooltip("You need to defeat Boss 224 on Sadistic to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 37 && character.effectiveBossID() < 826)
		{
			tooltip.showTooltip("You need to defeat Boss 224 on Sadistic to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 38 && character.effectiveBossID() < 834)
		{
			tooltip.showTooltip("You need to defeat Boss 232 on Sadistic to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 39 && character.effectiveBossID() < 842)
		{
			tooltip.showTooltip("You need to defeat Boss 240 on Sadistic to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 40 && character.effectiveBossID() < 850)
		{
			tooltip.showTooltip("You need to defeat Boss 248 on Sadistic to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 41 && character.effectiveBossID() < 850)
		{
			tooltip.showTooltip("You need to defeat Boss 248 on Sadistic to advance to the next Zone!", 2f);
			return;
		}
		if (ac.zone == 42 && character.effectiveBossID() < 871)
		{
			tooltip.showTooltip("You need to defeat Boss 269 on Sadistic to advance to the next Zone!", 2f);
			return;
		}
		Debug.Log(ac.zone);
		if (ac.zone == 43 && character.effectiveBossID() < 897)
		{
			tooltip.showTooltip("You need to defeat Boss 295 on Sadistic to advance to the next Zone!", 2f);
		}
		else if (ac.zone == 44 && character.effectiveBossID() < 902)
		{
			tooltip.showTooltip("You need to defeat Boss 300 on Sadistic to advance to the next Zone!", 2f);
		}
		else if (ac.zone == 44 && !character.adventure.ratTitanDefeated)
		{
			tooltip.showTooltip("You need to defeat this Titan to advance to the next Zone!", 2f);
		}
		else
		{
			zoneForward();
		}
	}

	public void zoneForward()
	{
		ac.zoneSelector.changeZone(character.adventure.zone + 1);
	}

	public void goToMaxZone()
	{
		int num = ac.zoneDropdown.options.Count - 2;
		if (num == 6 || num == 8 || num == 11 || num == 14 || num == 16 || num == 19 || num == 23 || num == 26 || num == 30 || num == 34 || num == 38 || num == 42 || num == 44)
		{
			num--;
		}
		if (num == 45)
		{
			num -= 2;
		}
		ac.zoneSelector.changeZone(num);
	}

	public void goToMaxZone(int cap)
	{
		if (cap < 0)
		{
			cap = 0;
		}
		int num = Math.Min(cap, ac.zoneDropdown.options.Count - 2);
		if (num == 6 || num == 8 || num == 11 || num == 14 || num == 16 || num == 19 || num == 23 || num == 26 || num == 30 || num == 34 || num == 38 || num == 42 || num == 44)
		{
			num--;
		}
		if (num == 45)
		{
			num -= 2;
		}
		ac.zoneSelector.changeZone(num);
	}
}
